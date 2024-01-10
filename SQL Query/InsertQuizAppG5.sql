use [QuizAppG5]
go

insert into [Role] values ('Teacher'),
						  ('Student'),
						  ('Admin')

select * from [Role]

insert into [SchoolYear] values (N'2023 - 2024')
select * from [SchoolYear]
go

create proc insertClass
as
begin
	declare @cnt int = 1;
	while @cnt <= 8
	begin
		insert into [Class]([ClassName], [SchoolYearID]) values('11A' +Convert(nvarchar(10), @cnt), 1)
		set @cnt +=1
	end
end
go

EXEC insertClass

select * from [Class]

dbcc checkident([Subject],reseed,0)

insert into[DifficultLevel] values (N'Dễ'), 
								   (N'Trung bình'),
								   (N'Khó')
select * from [SchoolYear]

dbcc checkident([Class], reseed, 0)

insert into[Book](BookName) select bookname from dbo.bookTable

SELECT * FROM [BOOK]

insert into[Subject](subjectName) select subjectname
from dbo.subjectTable

select * from [Subject]

insert into[BookSubject](BookID, SubjectID) select BookID, SubjectID
from dbo.[BookSubjectsDF]

select * from [BookSubject]


select * from Book, [Subject], [BookSubject] 
where [Book].[BookID] = [BookSubject].[BookID]
AND [Subject].[SubjectID] = [BookSubject].[SubjectID]


insert into[Question](QuestionDetail, SubjectID, AccountID, IsOK, IsTest, DifficultLevelID) 
select QuestionDetail, SubjectID, AccountID, IsOK, IsTest, DifficultLevelID
from dbo.questionTable

select * from [Question]

insert into[Answer](AnswerDetail, QuestionID, IsTrue) 
select AnswerDetail, QuestionID, IsTrue
from dbo.answertable

select * from answer

dbcc checkident([Answer],reseed,0)

select questionDetail, AnswerDetail, isTrue from Question, answer where  question.QuestionID = answer.QuestionID
go

create proc getLastSchoolYear
as
begin
	declare @currentSchoolYearID int
	set @currentSchoolYearID = IDENT_CURRENT('SchoolYear')

	select [SchoolYearDescription] from SchoolYear
	where [SchoolYearID] = @currentSchoolYearID
end
go

create PROCEDURE CreateAccount
(
	@username NVARCHAR(255),
	@email NVARCHAR(255),
	@fullname NVARCHAR(255),
	@password VARBINARY(MAX),
	@DOB DATETIME,
	@roleName NVARCHAR(10),
	@className NVARCHAR(255),
	@isMale BIT,
	@image VARBINARY(MAX)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @classID INT;
		DECLARE @roleID INT;

		SELECT @classID = [ClassID] FROM [Class] WHERE [ClassName] = @className;
		SELECT @roleID = [RoleID] FROM [Role] WHERE [RoleName] = @roleName;

		INSERT INTO [Account] (
			[Username], [FullName], [Email], [Password], [isMale], [ClassID], [RoleID], [DOB]
		)
		VALUES (
			@username, @fullname, @email, @password, @isMale, @classID, @roleID, @DOB
		);

		DECLARE @accountID INT;
		SELECT @accountID = Convert(int, SCOPE_IDENTITY());

		INSERT INTO [AccountImage] ([Image], [AccountID])
		VALUES (@image, @accountID);

		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH;
END;
go

create proc getUserInformation
(
	@username nvarchar(255),
	@password varbinary(MAX)
)
as
	select [Account].[AccountID], [Username], [RoleName], [FullName],
	[Image], [DOB], [IsBanned], [IsMale], [Email], [ClassName]
	from [Account], [AccountImage], [Role], [Class]
	where [Account].[Username] = @username
	and [Account].Password = @password
	and [Account].[AccountID] = [AccountImage].[AccountID]
	and [Account].[RoleID] = [Role].[RoleID]
	and [Account].[ClassID] = [Class].[ClassID]
go

select Username from [Account] 	
go

select * from [Question]
go

alter proc findAllQuestion
(
	@username nvarchar(255) = NULL,
	@pagenumber int, 
	@rowsofpage int,
	@questionDetail nvarchar(MAX) = NULL,
	@difficultName nvarchar(MAX) = NULL,
	@subjectName nvarchar(MAX) = NULL,
	@from datetime = NULL,
	@to datetime = NULL,
	@isTest bit = NULL,
	@isOK bit = NULL,
	@questionID nvarchar(MAX) = null
)
as
	begin
		declare @query nvarchar(MAX)
		set @to = DateAdd(day, 1, @to)
		declare @WHERE_SQL nvarchar(MAX) = ' and 1=1 AND [Question].[UpdateAt] >= @from and [Question].[UpdateAt] < @to'
		declare @orderBy nvarchar(MAX) = ' order by [QuestionID]'
		
		if COALESCE(@questionID, '') <> ''
			set @WHERE_SQL += ' AND [Question].[QuestionID] IN (' + @questionID + ')'
		if COALESCE(@username, '') <> ''
			set @WHERE_SQL += ' AND [Username] = @username'
		if COALESCE(@questionDetail, '') <> ''
		begin
				set @questionDetail += '%'
				set @WHERE_SQL += ' AND [QuestionDetail] like @questionDetail'
		end
		if COALESCE(@difficultName, '') <> ''
			set @WHERE_SQL += ' AND [DifficultName] = @difficultName'
		if COALESCE(@subjectName, '') <> '' 
			set @WHERE_SQL += ' AND [subjectName] = @subjectName'
		if @isTest is not null
			set @WHERE_SQL += ' AND [Question].[IsTest] = @isTest'
		if @isOK is not null
			set @WHERE_SQL += ' AND [Question].[IsOK] = @isOK'
		
		set @query = 'select [QuestionID], [QuestionDetail], [Question].[IsOK], 
						[Question].[IsTest], [DifficultName],
						[SubjectName], [Question].[UpdateAt],
						count(*) OVER() as [TotalRecords]
						from [Question], [DifficultLevel], 
						[Account], [Subject]
						where [Question].[DifficultLevelID] = [DifficultLevel].[DifficultLevelID]
						and [Question].[AccountID] = [Account].[AccountID]
						and [Question].[SubjectID] = [Subject].[SubjectID]'
						+ @WHERE_SQL
						+ @orderBy
						+ ' OFFSET (@pagenumber-1)*@rowsofpage ROWS
							FETCH NEXT @rowsofpage ROWS ONLY'
		
		declare @ParmDefinition nvarchar(MAX)
		set @ParmDefinition = '@username nvarchar(255), 
							   @pagenumber int, @rowsofpage int,
		                       @questionDetail nvarchar(MAX), 
							   @difficultName nvarchar(MAX), 
							   @subjectName nvarchar(MAX),
		                       @from datetime, @to datetime, 
							   @isTest bit, @isOK bit'

		EXECUTE sp_executesql @query, @ParmDefinition, 
								@username = @username,
								@pagenumber = @pagenumber,
								@rowsofpage = @rowsofpage,
								@questionDetail = @questionDetail,
								@difficultName = @difficultName,
								@subjectName = @subjectName,
								@from = @from,
								@to = @to,
								@isTest = @isTest,
								@isOK = @isOK
	end
go

findAllQuestion 'ohka1234', 1, 25, '', '', '','20231201', '20240101', 1
go

select * from question

select * from answer

ALTER PROCEDURE CreateQuestionAndAnswer
(
	@questionDetail NVARCHAR(MAX),
	@subjectName NVARCHAR(MAX),
	@difficultName NVARCHAR(MAX),
	@isTest BIT,
	@userID INT,
	@answerDetail NVARCHAR(MAX),
	@isTrue NVARCHAR(MAX)
)
AS
BEGIN
	BEGIN TRANSACTION;

	DECLARE @subjectID INT;
	DECLARE @difficultID INT;

	BEGIN TRY
		SELECT @subjectID = [SubjectID] FROM [Subject] WHERE [SubjectName] = @subjectName;
		SELECT @difficultID = [DifficultLevelID] FROM [DifficultLevel] WHERE [DifficultName] = @difficultName;

		INSERT INTO [Question]([QuestionDetail], [SubjectID], [IsOK], [IsTest], [AccountID], [DifficultLevelID])
		VALUES (@questionDetail, @subjectID, 0, @isTest, @userID, @difficultID);

		DECLARE @questionID INT;
		SET @questionID = CONVERT(INT, SCOPE_IDENTITY());

		DECLARE @temp1 NVARCHAR(MAX) = @answerDetail;
		DECLARE @temp2 NVARCHAR(MAX) = @isTrue;

		WHILE (CHARINDEX(',', @temp1) > 0)
		BEGIN
			DECLARE @temp3 NVARCHAR(MAX);
			DECLARE @temp4 BIT;

			SET @temp3 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));
			SET @temp4 = LTRIM(RTRIM(SUBSTRING(@temp2, 1, CHARINDEX(',', @temp2) - 1)));

			INSERT INTO [Answer]([AnswerDetail], [QuestionID], [IsTrue])
			VALUES (@temp3, @questionID, @temp4);

			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp2, CHARINDEX(',', @temp2) + 1, LEN(@temp2))));
		END
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH
END;
GO

alter proc deleteQuestionById(
	@questionID nvarchar(MAX)
)
as
begin
	declare @query nvarchar(MAX)
	set @query = 'DELETE FROM [Question] WHERE [QuestionID] IN (' + @questionID + ')'
	EXEC sp_executesql @query
end
go

create proc loadAnswerByQuestionID(
	@questionID int
)
as
	select [AnswerID], [AnswerDetail], [IsTrue] 
	from [Answer] where [QuestionID] = @questionID
go

alter proc UpdateQuestionAndAnswer
(
	@questionID INT,
	@questionDetail NVARCHAR(MAX),
	@subjectName NVARCHAR(MAX),
	@difficultName NVARCHAR(MAX),
	@isTest BIT,
	@answerID NVARCHAR(MAX),
	@answerDetail NVARCHAR(MAX),
	@isTrue NVARCHAR(MAX)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @subjectID INT;
		DECLARE @difficultID INT;

		SELECT @subjectID = [SubjectID] FROM [Subject] WHERE [SubjectName] = @subjectName;
		SELECT @difficultID = [DifficultLevelID] FROM [DifficultLevel] WHERE [DifficultName] = @difficultName;

		UPDATE [Question]
		SET [QuestionDetail] = @questionDetail,
			[UpdateAt] = GETDATE(),
			[SubjectID] = @subjectID,
			[DifficultLevelID] = @difficultID,
			[IsTest] = @isTest
		WHERE [QuestionID] = @questionID;

		DECLARE @temp1 NVARCHAR(MAX) = @answerDetail;
		DECLARE @temp2 NVARCHAR(MAX) = @isTrue;
		DECLARE @temp3 NVARCHAR(MAX) = @answerID;

		WHILE (CHARINDEX(',', @temp1) > 0)
		BEGIN
			DECLARE @temp4 NVARCHAR(MAX);
			DECLARE @temp5 BIT;
			DECLARE @temp6 INT;

			SET @temp4 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));
			SET @temp5 = LTRIM(RTRIM(SUBSTRING(@temp2, 1, CHARINDEX(',', @temp2) - 1)));
			SET @temp6 = LTRIM(RTRIM(SUBSTRING(@temp3, 1, CHARINDEX(',', @temp3) - 1)));

			UPDATE [Answer]
			SET [AnswerDetail] = @temp4,
				[IsTrue] = @temp5
			WHERE [AnswerID] = @temp6;

			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp2, CHARINDEX(',', @temp2) + 1, LEN(@temp2))));
			SET @temp3 = LTRIM(RTRIM(SUBSTRING(@temp3, CHARINDEX(',', @temp3) + 1, LEN(@temp3))));
		END

		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH;
END;
go

alter proc createQuestionSet(
	@questionSetName nvarchar(MAX),
	@Time int,
	@AccountID int,
	@isTest bit,
	@questionID nvarchar(MAX)
)
as
begin
	begin try
		begin transaction;
		insert into [QuestionSet](
			[QuestionSetName], [AccountID], [IsOK], [Time], [IsTest]
		) values(@questionSetName, @AccountID, 0, @Time, @isTest)

		DECLARE @temp1 NVARCHAR(MAX) = @questionID;
		DECLARE @questionSETID int;

		select @questionSETID = convert(int, SCOPE_IDENTITY())
		WHILE (CHARINDEX(',', @temp1) > 0)
		begin
			DECLARE @temp2 NVARCHAR(MAX);
			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));
			insert into [QuestionSetQuestion]([QuestionSetID], [QuestionID])
			values(@questionSETID, @temp2)
			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
		end
		COMMIT;
	end try
	begin catch
		ROLLBACK;
		THROW
	end catch
end
go

alter proc findAllQuestionSet(
	@AccountID int = null,
	@pagenumber int, 
	@rowsofpage int,
	@istest bit = null,
	@time int = null,
	@totalQuestion int = null,
	@from datetime = null,
	@to datetime = null,
	@isOK bit = null,
	@questionSetName nvarchar(MAX) = null,
	@questionSetID nvarchar(MAX) = null
)
as
begin
		declare @query nvarchar(MAX)
		set @to = DateAdd(day, 1, @to)
		declare @WHERE_SQL nvarchar(MAX) = ' and [QuestionSet].[UpdateAt] >= @from and [QuestionSet].[UpdateAt] < @to'
		declare @orderBy nvarchar(MAX) = ' order by [QuestionSetID]'
		declare @havingClause nvarchar(MAX) = ''

		if COALESCE(@questionSetID, '') <> ''
			set @WHERE_SQL += ' AND [QuestionSet].[QuestionSetID] IN (' + @questionSetID + ')'
		if COALESCE(@questionSetName, '') <> ''
		begin
				set @questionSetName += '%'
				set @WHERE_SQL += ' AND [QuestionSetName] like @questionSetName'
		end
		if @isTest is not null
			set @WHERE_SQL += ' AND [IsTest] = @istest'
		if @isOK is not null
			set @WHERE_SQL += ' AND [IsOK] = @isOK'
		if @time is not null
			set @WHERE_SQL += ' AND [Time] = @time'
		if @AccountID is not null
			set @WHERE_SQL += ' AND [AccountID] = @AccountID'
		if @totalQuestion is not null
			set @havingClause = ' having count([QuestionSetQuestion].[QuestionSetID]) = @totalQuestion'

		set @query = 'SELECT [QuestionSet].[QuestionSetID], [QuestionSetName], [IsOK],
					  [Time], [AccountID], [UpdateAt], [IsTest], 
					  count([QuestionSet].[QuestionSetID]) totalQuestion,
					  Count(*) OVER() as TotalRecords
					  from [QuestionSet], [QuestionSetQuestion]
					  where [QuestionSet].[QuestionSetID] = [QuestionSetQuestion].[QuestionSetID]'
					  + @WHERE_SQL
					  + ' group by [QuestionSet].[QuestionSetID],
						  [QuestionSetName], [IsOK],
						  [Time], [AccountID], [UpdateAt], [IsTest]'
					  +	@havingClause
					  + @orderBy
					  + ' OFFSET (@pagenumber-1)*@rowsofpage ROWS
							FETCH NEXT @rowsofpage ROWS ONLY'

		declare @ParmDefinition nvarchar(MAX)
		set @ParmDefinition =  '@AccountID int,
								@pagenumber int, 
								@rowsofpage int,
								@istest bit,
								@time int,
								@totalQuestion int,
								@from datetime,
								@to datetime,
								@isOK bit,
								@questionSetName nvarchar(MAX)'
		EXECUTE sp_executesql @query, @ParmDefinition, 
							  @AccountID = @AccountID,
							  @pagenumber = @pagenumber, 
							  @rowsofpage = @rowsofpage,
							  @istest = @istest,
							  @time = @time,
							  @totalQuestion = @totalQuestion,
							  @from = @from,
							  @to = @to,
							  @isOK = @isOK,
							  @questionSetName = @questionSetName
	SELECT @Query
end
go

SELECT [QuestionSet].[QuestionSetID], [QuestionSetName], [IsOK],
					  [Time], [AccountID], [UpdateAt], [IsTest], 
					  count([QuestionSet].[QuestionSetID]) totalQuestion,
					  Count(*) OVER() as TotalRecords
					  from [QuestionSet], [QuestionSetQuestion]
					  where [QuestionSet].[QuestionSetID] = [QuestionSetQuestion].[QuestionSetID]
					  group by [QuestionSet].[QuestionSetID],
					  [QuestionSetName], [IsOK],
					  [Time], [AccountID], [UpdateAt], [IsTest]
					  having count([QuestionSetQuestion].[QuestionSetID]) = 10

create proc countQuestionInQuestionSet(
	@questionSetID int
)
as
begin
	select Count(*) from QuestionSetQuestion
	where [QuestionSetID] = @questionSetID
end
go

create proc findQuestionIDinQuestionSet(
	@questionSetID int
)
as
	select [QuestionID] FROM [QuestionSetQuestion]
	where [QuestionSetID] = @questionSetID
go

findAllQuestionSet 1, 1, 25, null, null, '20231230', '20240108', null, null, '1002,1004'
go

alter proc createTestSet(
	@accountID int,
	@Time int,
	@TotalQuestion int,
	@testSetManageName nvarchar(MAX),
	@questionSetID nvarchar(MAX),
	@classID nvarchar(MAX)
)
as
begin
	begin try
		begin transaction;
		insert into [TestSetManage](
			[TestSetManageName], [AccountID], [Time], [TotalQuestion]
		) values(@testSetManageName, @accountID, @Time, @TotalQuestion)

		declare @temp1 NVARCHAR(MAX) = @questionSetID
		declare @TestSetManageID int

		set @TestSetManageID = convert(int, SCOPE_IDENTITY())
		WHILE (CHARINDEX(',', @temp1) > 0)
		begin
			DECLARE @temp2 NVARCHAR(MAX);

			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));
			
			insert into [TestSetManageQuestionSet]([TestSetManageID], [QuestionSetID])
			values(@TestSetManageID, @temp2)

			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
		end

		set @temp1 = @classID
		WHILE (CHARINDEX(',', @temp1) > 0)
		begin
			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));
			
			insert into [TestSetManageClass]([TestSetManageID], [ClassID])
			values(@TestSetManageID, @temp2)

			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
		end
		COMMIT;
	end try
	begin catch
		ROLLBACK;
		THROW
	end catch
end
go

alter proc loadTestSetofUser(
	@accountID int
)
as
begin
	declare @currentClassID int
	select @currentClassID = [ClassID] from [Account] 
	where [AccountID] = @accountID
	
	select [TestSetManage].[TestSetManageID], [TestSetManageName],
	[Time], [TotalQuestion]
	from [TestSetManage], [TestSetManageClass]
	where [TestSetManage].[TestSetManageID] = [TestSetManageClass].[TestSetManageID]
	and [ClassID] = @currentClassID
end
go

loadTestSetofUser 1

create proc getRandomQuestionSet(
	@testSetManageID int
)
as
	select top 1 [QuestionSetID]  
	from [TestSetManageQuestionSet]
	where [TestSetManageID] = @testSetManageID
	order by NEWID()
go

create proc loadAllQuestionInQuestionSet(
	@questionSetID int
)
as
	select [Question].[QuestionID], [QuestionDetail] 
	from [Question], [QuestionSetQuestion]
	where [Question].[QuestionID] = [QuestionSetQuestion].[QuestionID]
	and [QuestionSetQuestion].[QuestionSetID] = @questionSetID
go

alter proc createTestLog(
	@accountID int,
	@isTest bit,
	@accountChoices nvarchar(MAX),
	@questionID nvarchar(MAX),
	@timeTaken int,
	@TestSetManageID int = NULL 
)
as
begin
	declare @TestLogID int
	begin try
		begin transaction;
		Insert into [TestLog]([AccountID], [IsTest], [TestSetManageID], [TimeTaken])
		values(@accountID, @isTest, @TestSetManageID, @timeTaken)

		declare @temp1 NVARCHAR(MAX) = @questionID
		declare @temp2 NVARCHAR(MAX) = @accountChoices;

		set @TestLogID = convert(int, SCOPE_IDENTITY())
		WHILE (CHARINDEX(',', @temp1) > 0)
		begin
			DECLARE @temp3 NVARCHAR(MAX);
			DECLARE @temp4 NVARCHAR(MAX);

			SET @temp3 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));
			SET @temp4 = LTRIM(RTRIM(SUBSTRING(@temp2, 1, CHARINDEX(',', @temp2) - 1)));
			if(@temp4 = '0')
				set @temp4 = null
			
			insert into [UserAnswer]
			([TestLogID], [QuestionID], [AnswerID])
			values(@TestLogID, @temp3, @temp4)

			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp2, CHARINDEX(',', @temp2) + 1, LEN(@temp2))));
		end

		commit;
		select @TestLogID
	end try
	begin catch
		rollback;
		throw;
	end catch
end
go

alter proc findTestLogByTestSetManageID(
	@testSetManageID int,
	@accountID int
)
as
	select [TestLogID],[TimeTaken],[IsTest] from [TestLog]
	where [TestSetManageID] = @testSetManageID
	and [AccountID] = @accountID
go

alter proc countTrueAnswerInTestLog(
	@testLogID int
)
as
	select count([UserAnswer].AnswerID) from [UserAnswer], [Answer]
	where [UserAnswer].[AnswerID] = [Answer].[AnswerID]
	and [UserAnswer].TestLogID = @testLogID
	and [Answer].[IsTrue] = 1
go

alter proc findAllQuestionIDInTestLog(
	@testLogID int
)
as
	select [QuestionDetail], [UserAnswer].[QuestionID], 
	CONVERT(INT, ISNULL([UserAnswer].[AnswerID], 0)) AnswerID
	from [UserAnswer], [Question]
	where [UserAnswer].[TestLogID] = @testLogID
	and [Question].[QuestionID] = [UserAnswer].[QuestionID]
go

alter proc deleteQuestionSetById(
	@questionSetID nvarchar(MAX)
)
as
begin
	declare @query nvarchar(MAX)
	set @query = 'DELETE FROM [QuestionSet] WHERE [QuestionSetID] IN (' + @questionSetID + ')'
	EXEC sp_executesql @query
end
go

alter proc validateQuestionSetById(
	@questionSetID nvarchar(MAX),
	@State bit
)
as
begin
	declare @query nvarchar(MAX)
	set @query = 'Update [QuestionSet] 
				  Set [IsOK] = @State
				  WHERE [QuestionSetID] IN (' + @questionSetID + ')'

	declare @params nvarchar(MAX)
	set @params = '@State bit'
	EXEC sp_executesql @query, @params,
	                   @State = @State
end
go

alter proc validateQuestionById(
	@questionID nvarchar(MAX),
	@State bit
)
as
begin
	declare @query nvarchar(MAX)
	set @query = 'Update [Question] 
				  Set [IsOK] = @State
				  WHERE [QuestionID] IN (' + @questionID + ')'

	declare @params nvarchar(MAX)
	set @params = '@State bit'
	EXEC sp_executesql @query, @params,
	                   @State = @State
end
go

alter proc loadAllTestSet(
	@accountID int = null,
	@searchBox nvarchar(MAX) = null,
	@rowsofpage int,
	@pagenumber int
)
as
begin
	declare @query nvarchar(MAX)
	declare @WHERE_SQL nvarchar(MAX) = ' and 1=1'
	declare @orderBy nvarchar(MAX) = ' order by [TestSetManageID]'

	if @accountID is not null
		set @WHERE_SQL += ' AND [TestSetManage].[AccountID] = @accountID'
	if COALESCE(@searchBox, '') <> ''
	begin
		set @searchBox += '%'
		set @WHERE_SQL += ' AND [TestSetManageName] like @searchBox'
	end
	set @query = 'select [TestSetManageID], [TestSetManage].[AccountID],
					[TestSetManageName], [TestSetManage].[CreateAt],
					[TotalQuestion], [Time], [UserName],
					Count(*) OVER() as TotalRecords
					from [TestSetManage], [Account]
					where [TestSetManage].[AccountID] = [Account].[AccountID]'
					+ @WHERE_SQL
					+ @orderBy
					+ ' OFFSET (@pagenumber-1)*@rowsofpage ROWS
						FETCH NEXT @rowsofpage ROWS ONLY'

	declare @params nvarchar(MAX)
	set @params = '@accountID int, @searchBox nvarchar(MAX), @rowsofpage int,  
	               @pagenumber int'
	exec sp_executesql @query, @params,
					   @accountID = @accountID,
					   @searchBox = @searchBox,
					   @rowsofpage = @rowsofpage,
					   @pagenumber = @pagenumber
end
go

create proc findAllQuestionSetIDinTestSet(
	@testSetID int
)
as
	select [QuestionSetID] from [TestSetManageQuestionSet]
	where [TestSetManageID] = @testSetID
go

alter proc loadAllUserTestLog(
	@classID int = null,
	@testSetManageID int = null,
	@searchBox nvarchar(MAX),
	@rowsofpage int,
	@pagenumber int
)
as
begin
	declare @query nvarchar(MAX)
	declare @WHERE_SQL nvarchar(MAX) = ' and 1=1'
	declare @orderBy nvarchar(MAX) = ' order by [TestLogID]'

	if @classID is not null
		set @WHERE_SQL += ' and [Class].[ClassID] = @classID'
	if @testSetManageID is not null
		set @WHERE_SQL += ' and [TestLog].[TestSetManageID] = @testSetManageID'
    if COALESCE(@searchBox, '') <> ''
	begin
		set @searchBox += '%'
		set @WHERE_SQL += ' AND [FullName] like @searchBox'
	end

	set @query = '
		select [FullName],[TestLogID],[TestLog].[CreateAt],[TimeTaken], 
		[ClassName], Count(*) OVER() as TotalRecords
		from [TestLog], [TestSetManage], [Account], [Class]
		where [TestLog].[AccountID] = [Account].[AccountID]
		and [Account].[ClassID] = [Class].[ClassID]
		and [TestLog].[TestSetManageID] = [TestSetManage].[TestSetManageID]'
		+ @WHERE_SQL
		+ @orderBy
		+ ' OFFSET (@pagenumber-1)*@rowsofpage ROWS
			FETCH NEXT @rowsofpage ROWS ONLY'

	declare @params nvarchar(MAX)
	set @params = '@classID int, @testSetManageID int, @searchBox nvarchar(MAX), 
	               @rowsofpage int,  @pagenumber int'
	exec sp_executesql @query, @params,
					   @classID = @classID,
					   @testSetManageID = @testSetManageID,
					   @searchBox = @searchBox,
					   @rowsofpage = @rowsofpage,
					   @pagenumber = @pagenumber    
end
go

create proc getClassInTestSetManageClass(
	@testSetManageID int
)
as
	select [TestSetManageClass].[ClassID], [ClassName]
	from [TestSetManageClass], [Class]
	where [TestSetManageClass].[ClassID] = [Class].[ClassID]
	and [TestSetManageClass].[TestSetManageID] = @testSetManageID
go

create proc deleteTestSetById(
	@TestSetID nvarchar(MAX)
)
as
begin
	declare @query nvarchar(MAX)
	set @query = 'DELETE FROM [TestSetManage] WHERE [TestSetManageID] IN (' + @TestSetID + ')'
	EXEC sp_executesql @query
end
go

create proc loadRandomQuestionbySubject(
	@subjectName nvarchar(MAX),
	@questionCount int
)
as
begin
	declare @subjectID int
	select @subjectID = [SubjectID] from [Subject]
						where [SubjectName] = @subjectName

	select top (@questionCount) [QuestionDetail], [QuestionID]
	from [Question], [Subject]
	where [Question].[SubjectID] = [Subject].[SubjectID]
	and [Subject].[SubjectID] = @subjectID
end
go

alter proc loadAllPracticeTestLog(
	@accountID int = null,
	@rowsofpage int,
	@pagenumber int
)
as
begin
	declare @query nvarchar(MAX)
	declare @WHERE_SQL nvarchar(MAX) = ' and 1=1'
	declare @orderBy nvarchar(MAX) = ' order by [TestLog].[CreateAt] DESC'

	if @accountID is not null
		set @WHERE_SQL += ' and [TestLog].[AccountID] = @accountID'

	set @query = '
		select [FullName],[TestLogID],[TestLog].[CreateAt],[TimeTaken], 
		[ClassName], Count(*) OVER() as TotalRecords
		from [TestLog], [Account], [Class]
		where [TestLog].[AccountID] = [Account].[AccountID]
		and [Account].[ClassID] = [Class].[ClassID]
		and [TestLog].[IsTest] = 0'
		+ @WHERE_SQL
		+ @orderBy
		+ ' OFFSET (@pagenumber-1)*@rowsofpage ROWS
			FETCH NEXT @rowsofpage ROWS ONLY'

	declare @params nvarchar(MAX)
	set @params = '@accountID int,
	               @rowsofpage int,  @pagenumber int'
	exec sp_executesql @query, @params,
					   @accountID = @accountID,
					   @rowsofpage = @rowsofpage,
					   @pagenumber = @pagenumber    
end
go

create proc countAllQuestionInTestLog(
	@testLogID int
)
as
	select count([QuestionID])
	from UserAnswer
	where [UserAnswer].[TestLogID] = @testLogID

loadAllPracticeTestLog '1', 25, 1
go

alter proc getPercentTestLogHasDone(
	@AccountID int
)
as
begin
	declare @query nvarchar(MAX) = '
	select Convert(float, haveDone) / Count([TestSetManageClass].[ClassID])
	as percentDone
	from(
		SELECT COUNT([AccountID]) as haveDone, [AccountID]
		FROM [TestLog]
		WHERE [TESTLOG].[AccountID] = @AccountID
		and [Testlog].[IsTest] = 1
		GROUP BY [AccountID]
	) subquery,
	[Account], [Class], [TestSetManageClass]
	where subquery.[AccountID] = [Account].[AccountID]
	and [Account].[ClassID] = [Class].[ClassID]
	AND [TestSetManageClass].[ClassID] = [Class].[ClassID]
	group by [TestSetManageClass].[ClassID], subquery.haveDone'

	declare @params nvarchar(MAX)
	set @params = '@AccountID int'

	exec sp_executesql @query, @params,
					   @AccountID = @AccountID
end
go

create proc updateUserPassword(
	@email nvarchar(MAX),
	@password varbinary(MAX)
)
as
	update [Account] set [Password] = @password
	where [Email] = @email
go

alter proc updateQuestionSet
(
	@questionSetID INT,
	@questionSetName NVARCHAR(MAX),
	@Time bit,
	@isTest BIT,
	@questionID NVARCHAR(MAX)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		UPDATE [QuestionSet]
		SET [QuestionSetName] = @questionSetName,
			[UpdateAt] = GETDATE(),
			[Time] = @Time,
			[IsTest] = @isTest
		WHERE [QuestionSetID] = @questionSetID;

		DECLARE @temp1 NVARCHAR(MAX) = @questionID;

		declare @query nvarchar(MAX)
		set @query = 'DELETE FROM [QuestionSetQuestion] WHERE [QuestionSetID] = @questionSetID'
		declare @params nvarchar(Max) = '@questionSetID int'
		EXEC sp_executesql @query, @params,
						   @questionSetID = @questionSetID

		WHILE (CHARINDEX(',', @temp1) > 0)
		BEGIN
			DECLARE @temp2 NVARCHAR(MAX);

			SET @temp2 = LTRIM(RTRIM(SUBSTRING(@temp1, 1, CHARINDEX(',', @temp1) - 1)));

			insert into [QuestionSetQuestion]([QuestionSetID], [QuestionID])
			values(@questionSetID, @temp2)

			SET @temp1 = LTRIM(RTRIM(SUBSTRING(@temp1, CHARINDEX(',', @temp1) + 1, LEN(@temp1))));
		END

		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH;
END;
go