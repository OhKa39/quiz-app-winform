use [QuizAppG5]
go

begin /*SchoolYear Table*/
create table [SchoolYear](
	[SchoolYearID] int identity primary key,
	[SchoolYearDescription] nvarchar(255) not null,
)	
end

begin /*Class Table*/
create table [Class](
	[ClassID] int identity primary key,
	[ClassName] nvarchar(255) not null,
	[SchoolYearID] int,
)

alter table [Class] 
add constraint fk_ClassSchoolYear foreign key ([SchoolYearID]) 
references [SchoolYear]([SchoolYearID])
end

begin /*Role Table*/
create table [Role](
	[RoleID] int identity primary key,
	[RoleName] nvarchar(10) not null,
)
end

begin /* Account Table */
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

alter table [Account] 
add constraint fk_AccountRole foreign key ([RoleID]) 
references [Role]([RoleID])

alter table [Account] 
add constraint fk_AccountClass foreign key ([ClassID]) 
references [Class]([ClassID])
end 

begin /* Account Image Table */
create table [AccountImage](
	[AccountID] int primary key,
	[Image] varbinary(MAX) not null,
)

alter table [AccountImage] 
add constraint fk_AccountImageAccount foreign key ([AccountID]) 
references [Account]([AccountID])
end

begin /* Book Table */
create table [Book](
	[BookID] int identity primary key,
	[BookName] nvarchar(255) not null,
)
end 

begin /* Subject Table */
create table [Subject](
	[SubjectID] int identity primary key,
	[SubjectName] nvarchar(MAX) not null,
)
end

begin /* BookSubject Table */
create table [BookSubject](
	[BookID] int,
	[SubjectID] int
	primary key([BookID], [SubjectID])
)

alter table [BookSubject]
add constraint fk_BookSubjectBook foreign key ([BookID]) 
references [Book]([BookID])

alter table [BookSubject]
add constraint fk_BookSubjectSubject foreign key ([SubjectID]) 
references [Subject]([SubjectID])
end

begin /* Difficult Level Table */
create table [DifficultLevel](
	[DifficultLevelID] int identity primary key,
	[DifficultName] nvarchar(50) not null,
)
end 

begin /* Question Table */
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

alter table [Question] 
add constraint fk_QuestionAccount foreign key ([AccountID]) 
references [Account]([AccountID])

alter table [Question] 
add constraint fk_QuestionSubject foreign key ([SubjectID]) 
references [Subject]([SubjectID])

alter table [Question] 
add constraint fk_QuestionDifficult foreign key ([DifficultLevelID]) 
references [DifficultLevel]([DifficultLevelID])
end

begin /* Answer Table */
create table [Answer](
	[AnswerID] int primary key identity,
	[AnswerDetail] nvarchar(MAX) not null,
	[QuestionID] int,
	[IsTrue] bit not null
)


alter table [Answer] 
add constraint fk_AnswerQuestion foreign key ([QuestionID]) 
references [Question]([QuestionID]) on delete cascade
end

begin /* QuestionSet Table */
create table [QuestionSet](
	[QuestionSetID] int primary key identity,
	[QuestionSetName] nvarchar(255) not null,
	[IsOK] bit default 0,
	[Time] int not null,
	[IsTest] bit not null,
	[AccountID] int,
	[CreateAt] datetime default getdate(),
	[UpdateAt] datetime default getdate()
)

alter table [QuestionSet] 
add constraint fk_QuestionSetAccount foreign key ([AccountID]) 
references [Account]([AccountID])
end

begin /* QuestionSetQuestion Table */
create table [QuestionSetQuestion](
	[QuestionSetID] int,
	[QuestionID] int,
	primary key ([QuestionSetID], [QuestionID])
)

alter table [QuestionSetQuestion] 
drop constraint fk_TestSetQuestionQuestion

alter table [QuestionSetQuestion] 
add constraint fk_QuestionSetQuestionQuestionSet foreign key ([QuestionSetID]) 
references [QuestionSet]([QuestionSetID]) on delete cascade

alter table [QuestionSetQuestion] 
add constraint fk_QuestionSetQuestionQuestion foreign key ([QuestionID]) 
references [Question]([QuestionID])
end

begin /* Test Set Manage Table*/
create table [TestSetManage](
	[TestSetManageID]  int identity primary key,
	[AccountID] int,
	[TestSetManageName] nvarchar(100),
	[TotalQuestion] int,
	[Time] int,
	[CreateAt] datetime default getdate(),
	[UpdateAt] datetime default getdate()
)

alter table [TestSetManage] 
add constraint fk_TestSetManage_Account foreign key ([AccountID]) 
references [Account]([AccountID])
end

begin /* TestSetManageQuestionSet Table */
create table [TestSetManageQuestionSet]
(
	TestSetManageID int,
	QuestionSetID int,
	primary key(QuestionSetID, TestSetManageID)
)

alter table [TestSetManageQuestionSet] 
add constraint fk_TestSetManageClass_QuestionSet foreign key ([QuestionSetID]) 
references [QuestionSet]([QuestionSetID]) on delete cascade

alter table [TestSetManageQuestionSet] 
add constraint fk_TestSetManageQuestionSet_TestSetManage foreign key ([TestSetManageID]) 
references [TestSetManage]([TestSetManageID]) on delete cascade
end

begin /* TestSetManageClass Table */
create table [TestSetManageClass]
(
	TestSetManageID int,
	ClassID int,
	primary key(ClassID, TestSetManageID)
)

alter table [TestSetManageClass] 
add constraint fk_TestSetManageClass_Class foreign key ([ClassID]) 
references [Class]([ClassID]) on delete cascade

alter table [TestSetManageClass] 
add constraint fk_TestSetManageClass_TestSetManage foreign key ([TestSetManageID]) 
references [TestSetManage]([TestSetManageID]) on delete cascade
end

begin /* TestLog Table */
create table [TestLog](
	[TestLogID] int identity primary key,
	[AccountID] int,
	[TestSetManageID] int,
	[IsTest] bit,
	[CreateAt] datetime default getdate(),
	[TimeTaken] int
)

alter table [TestLog] 
add constraint fk_TestLogAccount foreign key ([AccountID]) 
references [Account]([AccountID])

alter table [TestLog] 
add constraint fk_TestLogTestSetManage foreign key ([TestSetManageID]) 
references [TestSetManage]([TestSetManageID]) on delete cascade
end

begin /* UserAnswer Table */
create table [UserAnswer]
(

	[AnswerID] int,
	[TestLogID] int,
	[QuestionID] int
	primary key([TestLogID], [QuestionID])
)

alter table [UserAnswer]
add constraint fk_UserAnswerTestLog foreign key([TestLogID])
references [TestLog]([TestLogID]) on delete cascade

alter table [UserAnswer]
add constraint fk_UserAnswerAnswer foreign key([AnswerID])
references [Answer]([AnswerID])

alter table [UserAnswer]
add constraint fk_UserAnswerQuestion foreign key([QuestionID])
references [Question]([QuestionID])
end

begin /* TestLogQuestion Table */
create table [TestLogQuestion](
	[TestLogID] int,
	[QuestionID] int,
	primary key([TestLogID], [QuestionID])
)
drop table [TestLogQuestion]

alter table [TestLogQuestion]
add constraint FK_TestLogQuestionTestLog
foreign key ([TestLogID]) references [TestLog]([TestLogID])

alter table [TestLogQuestion]
add constraint FK_TestLogQuestionQuestion
foreign key ([QuestionID]) references [Question]([QuestionID])
end