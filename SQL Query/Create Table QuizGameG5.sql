use [QuizAppG5]
go

create table [SchoolYear](
	[SchoolYearID] int identity primary key,
	[SchoolYearDescription] nvarchar(255) not null,
)
go

create table [Class](
	[ClassID] int identity primary key,
	[ClassName] nvarchar(255) not null,
	[SchoolYearID] int,
)
go

alter table [Class] 
add constraint fk_ClassSchoolYear foreign key ([SchoolYearID]) 
references [SchoolYear]([SchoolYearID])
go

create table [Role](
	[RoleID] int identity primary key,
	[RoleName] nvarchar(10) not null,
)
go

create table [Account](
	[AccountID] int identity primary key,
	[RoleID] int not null,
	[FullName] nvarchar(255) not null,
	[Email] nvarchar(255) not null unique,
	[Username] nvarchar(255) not null unique,
	[Password] varbinary(MAX) not null,
	[CreateAt] datetime default getdate(),
	[ClassID] int not null,
	[DOB] datetime not null,
	[IsBanned] bit default 0,
	[isMale] bit,
	[UpdateAt] datetime default getdate(),
)
go

alter table [Account] 
add constraint fk_AccountRole foreign key ([RoleID]) 
references [Role]([RoleID])
go

alter table [Account] 
add constraint fk_AccountClass foreign key ([ClassID]) 
references [Class]([ClassID])
go

create table [AccountImage](
	[AccountID] int primary key,
	[Image] varbinary(MAX) not null,
)

alter table [AccountImage] 
add constraint fk_AccountImageAccount foreign key ([AccountID]) 
references [Account]([AccountID])
go

create table [Book](
	[BookID] int identity primary key,
	[BookName] nvarchar(255) not null,
)
go

create table [Subject](
	[SubjectID] int identity primary key,
	[SubjectName] nvarchar(MAX) not null,
)
go

create table [BookSubject](
	[BookID] int,
	[SubjectID] int
	primary key([BookID], [SubjectID])
)
go

alter table [BookSubject]
add constraint fk_BookSubjectBook foreign key ([BookID]) 
references [Book]([BookID])
go

alter table [BookSubject]
add constraint fk_BookSubjectSubject foreign key ([SubjectID]) 
references [Subject]([SubjectID])
go

create table [DifficultLevel](
	[DifficultLevelID] int identity primary key,
	[DifficultName] nvarchar(50) not null,
)
go

create table [Question](
	[QuestionID] int identity primary key,
	[QuestionDetail] nvarchar(MAX) not null,
	[SubjectID] int not null,
	[CreateAt] datetime default getdate(),
	[AccountID] int not null,
	[IsOK] bit default 0,
	[IsTest] bit not null,
	[DifficultLevelID] int,
	[UpdateAt] datetime default getdate(),
)
go

alter table [Question] 
add constraint fk_QuestionAccount foreign key ([AccountID]) 
references [Account]([AccountID])
go

alter table [Question] 
add constraint fk_QuestionSubject foreign key ([SubjectID]) 
references [Subject]([SubjectID])
go

alter table [Question] 
add constraint fk_QuestionDifficult foreign key ([DifficultLevelID]) 
references [DifficultLevel]([DifficultLevelID])
go

create table [Answer](
	[AnswerID] int primary key identity,
	[AnswerDetail] nvarchar(MAX) not null,
	[QuestionID] int,
	[IsTrue] bit not null
)
go

alter table [Answer] 
add constraint fk_AnswerQuestion foreign key ([QuestionID]) 
references [Question]([QuestionID]) on delete cascade
go

create table [QuestionSet](
	[QuestionSetID] int primary key identity,
	[QuestionSetName] nvarchar(255) not null,
	[IsOK] bit default 0,
	[Time] int not null,
	[AccountID] int,
	[CreateAt] datetime default getdate(),
	[UpdateAt] datetime default getdate()
)
go

alter table [QuestionSet] 
add constraint fk_QuestionSetAccount foreign key ([AccountID]) 
references [Account]([AccountID])
go

create table [QuestionSetQuestion](
	[QuestionSetID] int,
	[QuestionID] int,
	primary key ([QuestionSetID], [QuestionID])
)
go

alter table [QuestionSetQuestion] 
add constraint fk_QuestionSetQuestionQuestionSet foreign key ([QuestionSetID]) 
references [QuestionSet]([QuestionSetID])
go

alter table [QuestionSetQuestion] 
add constraint fk_QuestionSetQuestionQuestion foreign key ([QuestionID]) 
references [Question]([QuestionID])
go

create table [TestSetManage](
	[TestSetManageID] int identity unique,
	[AccountID] int,
	[QuestionSetID] int,
	[ClassID] int,
	[TestSetManageName] nvarchar(100), 
	[CreateAt] datetime default getdate(),
	[UpdateAt] datetime default getdate()
	primary key([QuestionSetID], [ClassID])
)
go

alter table [TestSetManage] 
add constraint fk_TestSetManageQuestionSet foreign key ([QuestionSetID]) 
references [QuestionSet]([QuestionSetID])
go

alter table [TestSetManage] 
add constraint fk_TestSetManageClass foreign key ([ClassID]) 
references [Class]([ClassID])
go

alter table [TestSetManage] 
add constraint fk_TestSetManageAccount foreign key ([AccountID]) 
references [Account]([AccountID])
go

create table [TestLog](
	[TestLogID] int identity primary key,
	[AccountID] int,
	[TestSetManageID] int,
	[Score] float,
	[CreateAt] datetime default getdate()
)
go

alter table [TestLog] 
add constraint fk_TestLogAccount foreign key ([AccountID]) 
references [Account]([AccountID])
go

alter table [TestLog] 
add constraint fk_TestLogTestSetManageID foreign key ([TestSetManageID]) 
references [TestSetManage]([TestSetManageID])
go

create table [UserAnswer]
(
	[UserAnswerID] int identity primary key,
	[AnswerID] int,
	[TestLogID] int,
)
go

alter table [UserAnswer] alter column [AnswerID] int

alter table [UserAnswer]
add constraint fk_UserAnswer foreign key([TestLogID])
references [TestLog]([TestLogID])

alter table [UserAnswer]
add constraint fk_UserAnswerAnswer foreign key([AnswerID])
references [Answer]([AnswerID])
