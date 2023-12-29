use [QuizAppG5]
go

insert into [Role] values ('Teacher'),
						  ('Student'),
						  ('Admin')

select * from [Role]

insert into [SchoolYear] values (N'2023 - 2024')
select * from [SchoolYear]

insert into[Class]([ClassName],[SchoolYearID]) values (N'11A8', 1)
select * from [Class]

insert into [Account]([RoleID],[FullName], [Username], [Password], [Email],[ClassID], [DOB], [isMale]) 
values(
	1, N'Lý Thanh Khoa', N'khoaly123', 
	CONVERT(VARBINARY(MAX), HASHBYTES('SHA2_256', N'12303123Aa@'), 2),
	N'lythanhkhoa360@gmail.com', 1,
	convert(datetime, '03-09-2003', 105), 1
)

update [Account] set [Password] = CONVERT(VARBINARY(MAX), HASHBYTES('SHA2_256', N'12303123Aa@'), 2) where [AccountID] = 1 
update [Account] set [Username] = N'khoaly123' where [AccountID] = 1 

select * from [Account]

delete from [Account] where [AccountID] = 2 

dbcc checkident([Subject],reseed,0)

insert into[DifficultLevel] values (N'Dễ'), 
								   (N'Trung bình'),
								   (N'Khó')
select * from [DifficultLevel]

insert into[Book](BookName) select bookname from dbo.bookTable

SELECT * FROM [BOOK]

insert into[Subject](subjectName) select subjectname
from dbo.subjectTable

select * from [Subject]

insert into[BookSubject](BookID, SubjectID) select BookID, SubjectID
from dbo.[BookSubjectsDF]

select * from [BookSubject]

select * from [question]

select * from Book, [Subject], [BookSubject] 
where [Book].[BookID] = [BookSubject].[BookID]
AND [Subject].[SubjectID] = [BookSubject].[SubjectID]


insert into[Question](QuestionDetail, SubjectID, AccountID, IsOK, IsTest, DifficultLevelID) 
select QuestionDetail, SubjectID, AccountID, IsOK, IsTest, DifficultLevelID
from dbo.questionTable

select * from answer

delete from [Question]

insert into[Answer](AnswerDetail, QuestionID, IsTrue) 
select AnswerDetail, QuestionID, IsTrue
from dbo.answertable

dbcc checkident([Answer],reseed,0)

select questionDetail, AnswerDetail, isTrue from Question, answer where  question.QuestionID = answer.QuestionID
go

ALTER PROCEDURE CreateAccount
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

alter proc findAllQuestionByUsername
(
	@username nvarchar(255),
	@pagenumber int, 
	@rowsofpage int,
	@questionDetail nvarchar(MAX) = NULL,
	@difficultName nvarchar(MAX) = NULL,
	@subjectName nvarchar(MAX) = NULL,
	@from datetime = NULL,
	@to datetime = NULL,
	@isTest bit = NULL,
	@isOK bit = NULL
)
as
	begin
		declare @query nvarchar(MAX)
		set @to = DateAdd(day, 1, @to)
		declare @WHERE_SQL nvarchar(MAX) = ' and 1=1 AND [Question].[UpdateAt] >= @from and [Question].[UpdateAt] < @to'
		declare @orderBy nvarchar(MAX) = ' order by [QuestionID]'
		
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
			set @WHERE_SQL += ' AND [IsTest] = @IsTest'
		if @isOK is not null
			set @WHERE_SQL += ' AND [Question].[IsOK] = @isOK'
		
		set @query = 'select [QuestionID], [QuestionDetail], [IsOK], [IsTest], [DifficultName],
						[SubjectName], [Question].[UpdateAt],count(*) OVER() as [TotalRecords]
						from [Question], [DifficultLevel], [Account], [Subject] 
						where [Question].[DifficultLevelID] = [DifficultLevel].[DifficultLevelID]
						and [Question].[AccountID] = [Account].[AccountID]
						and [Question].[SubjectID] = [Subject].[SubjectID]
						and [Username] = @username'
						+ @WHERE_SQL
						+ @orderBy
						+ ' OFFSET (@pagenumber-1)*@rowsofpage ROWS
							FETCH NEXT @rowsofpage ROWS ONLY'
		
		declare @ParmDefinition nvarchar(MAX)
		set @ParmDefinition = '@username nvarchar(255), @pagenumber int, @rowsofpage int,
		@questionDetail nvarchar(MAX), @difficultName nvarchar(MAX), @subjectName nvarchar(MAX),
		@from datetime, @to datetime, @isTest bit, @isOK bit'
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
		select @query
	end
go

findAllQuestionByUsername 'ohka1234', 1, 25, '', '', '','20231229', '20231229', 0, 0
go

select * from question

select * from answer

alter proc createQuestion
(
	@questionDetail nvarchar(MAX),
	@subjectName nvarchar(MAX),
	@difficultName nvarchar(MAX),
	@isTest bit,
	@userID int
)
as
	begin
		declare @subjectID int
		declare @difficultID int

		select @subjectID = [SubjectID] from [Subject] 
		where [SubjectName] = @subjectName

		select @difficultID = [DifficultLevelID] from [DifficultLevel]
		where [DifficultName] = @difficultName

		insert into [Question](
			[QuestionDetail], [SubjectID], [IsOK], [IsTest], [AccountID],
			[DifficultLevelID]
		) 
		values(@questionDetail, @subjectID, 0, @isTest, @userID, @difficultID)
		select convert(int, SCOPE_IDENTITY())
	end
go 

alter proc createAnswer
(
	@questionID int,
	@answerDetail nvarchar(MAX),
	@isTrue nvarchar(MAX)
)
as
	begin
		declare @temp1 nvarchar(MAX) = @answerDetail
		declare @temp2 nvarchar(MAX) = @isTrue
		declare @cnt int = 0

		while(CHARINDEX(',', @temp1) > 0)
			begin
				declare @temp3 nvarchar(MAX)
				declare @temp4 bit

				set @temp3 = Ltrim(
					Rtrim(substring(@temp1, 1, CHARINDEX(',', @temp1) - 1))
				)
				set @temp4 = Ltrim(
					Rtrim(substring(@temp2, 1, CHARINDEX(',', @temp2) - 1))
				)

				insert into [Answer]([AnswerDetail], [QuestionID], [IsTrue])
				values(@temp3, @questionID, @temp4)

				set @temp1 = Ltrim(
					Rtrim(
						SUBSTRING(@temp1, charindex(',', @temp1) + 1, len(@temp1))
					)
				)
				
				set @temp2 = Ltrim(
					Rtrim(
						SUBSTRING(@temp2, charindex(',', @temp2) + 1, len(@temp2))
					)
				)
				set @cnt += 1
			end
		select @cnt
	end
go

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
	
)
as
	select [AnswerID], [AnswerDetail], [IsTrue] 
	from [Answer] where [QuestionID] = @questionID
go

create proc updateQuestionByQuestionID(
	@questionID int,
	@questionDetail nvarchar(MAX),
	@subjectName nvarchar(MAX),
	@difficultName nvarchar(MAX),
	@isTest bit
)
as
begin
	declare @subjectID int
	declare @difficultID int

	select @subjectID = [SubjectID] from [Subject] 
	where [SubjectName] = @subjectName

	select @difficultID = [DifficultLevelID] from [DifficultLevel]
	where [DifficultName] = @difficultName

	update [Question] set [QuestionDetail] = @questionDetail,
	[UpdateAt] = getdate(), [SubjectID] = @subjectID, [DifficultLevelID] = @difficultID,
	[IsTest] = @isTest where [questionID] = @questionID
end
go

create proc updateAnswer
(
	@answerID nvarchar(MAX),
	@answerDetail nvarchar(MAX),
	@isTrue nvarchar(MAX)
)
as
	begin
		declare @temp1 nvarchar(MAX) = @answerDetail
		declare @temp2 nvarchar(MAX) = @isTrue
		declare @temp3 nvarchar(MAX) = @answerID
		declare @cnt int = 0

		while(CHARINDEX(',', @temp1) > 0)
			begin
				declare @temp4 nvarchar(MAX)
				declare @temp5 bit
				declare @temp6 int

				set @temp4 = Ltrim(
					Rtrim(substring(@temp1, 1, CHARINDEX(',', @temp1) - 1))
				)
				set @temp5 = Ltrim(
					Rtrim(substring(@temp2, 1, CHARINDEX(',', @temp2) - 1))
				)
				set @temp6 = Ltrim(
					Rtrim(substring(@temp3, 1, CHARINDEX(',', @temp3) - 1))
				)

				update [Answer] set [AnswerDetail] = @temp3, [IsTrue] = @temp4
				where [AnswerID] = @temp6

				set @temp1 = Ltrim(
					Rtrim(
						SUBSTRING(@temp1, charindex(',', @temp1) + 1, len(@temp1))
					)
				)
				
				set @temp2 = Ltrim(
					Rtrim(
						SUBSTRING(@temp2, charindex(',', @temp2) + 1, len(@temp2))
					)
				)

				set @temp3 = Ltrim(
					Rtrim(
						SUBSTRING(@temp2, charindex(',', @temp2) + 1, len(@temp2))
					)
				)
				set @cnt += 1
			end
		select @cnt
	end
go

alter PROCEDURE UpdateQuestionAndAnswer
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
		DECLARE @cnt INT = 0;

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
			SET @cnt += 1;
		END

		COMMIT;
		SELECT @cnt;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH;
END;
go
	