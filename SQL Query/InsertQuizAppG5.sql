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

dbcc checkident([account],reseed,1)

insert into[DifficultLevel] values (N'Dễ'), 
								   (N'Trung bình'),
								   (N'Khó')
select * from [DifficultLevel]

ALTER TABLE [Subject] alter column [SubjectName] nvarchar(MAX)

insert into[Book](BookName) select bookname from dbo.bookTable

SELECT * FROM [BOOK]

insert into[Subject](subjectName, BookID) select subjectname, BookID 
from dbo.subjectTable

select * from [question]

delete from Question

insert into[Question](QuestionDetail, SubjectID, AccountID, IsOK, IsTest, DifficultLevelID) 
select QuestionDetail, SubjectID, AccountID, IsOK, IsTest, DifficultLevelID
from dbo.questionTable

select * from answer

delete from answer

insert into[Answer](AnswerDetail, QuestionID, IsTrue) 
select AnswerDetail, QuestionID, IsTrue
from dbo.answertable

dbcc checkident([question],reseed,0)

select * from Question, answer where  question.QuestionID = answer.QuestionID
go

alter proc createAccount
(
	@username nvarchar(255),
	@email nvarchar(255),
	@fullname nvarchar(255),
	@password varbinary(MAX),
	@DOB datetime,
	@roleName nvarchar(10),
	@className nvarchar(255),
	@isMale bit,
	@image varbinary(MAX)
)
as
begin
	declare @classID int
	declare @roleID int
	select @classID = [ClassID] from [Class] where [ClassName] = @className
	select @roleID = [RoleID] from [Role] where [RoleName] = @roleName
	insert into [Account](
		[Username], [FullName], [Email], [Password], [isMale], [ClassID],
		[RoleID], [DOB]
	)
	values(
		@username, @fullname, @email, @password, @isMale, @classID, @roleID, @DOB
	)
	declare @accountID int
	select @accountID = [AccountID] from [Account] where [Username] = @username
	insert into [AccountImage] ([Image], [AccountID])
	values(@image, @accountID)
end
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

select Username from [Account] 

alter proc findAllQuestionByUsername
(
	@username nvarchar(255),
	@pagenumber int, 
	@rowsofpage int
)
as
	select [QuestionID], [QuestionDetail], [IsOK], [IsTest], [DifficultName]
	from [Question], [DifficultLevel], [Account] 
	where [Question].[DifficultLevelID] = [DifficultLevel].[DifficultLevelID]
	and [Question].[AccountID] = [Account].[AccountID]
	and [Username] = @username 
	order by [QuestionID]
	OFFSET (@pagenumber-1)*@rowsofpage ROWS
	FETCH NEXT @rowsofpage ROWS ONLY
go

