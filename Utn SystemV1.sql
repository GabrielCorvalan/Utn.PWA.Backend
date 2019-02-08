CREATE DATABASE Utn_Sys
GO
USE Utn_Sys
GO
CREATE TABLE Rols
(
	Id INT IDENTITY (1000, 1),
	[Name] VARCHAR (50) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	--Constraits
	CONSTRAINT PK_Rols_Id PRIMARY KEY( Id )

)
CREATE TABLE Pages
(
	Id INT IDENTITY (1000, 1),
	[Name] VARCHAR (50) NOT NULL,
	[Description] VARCHAR (60) NULL,
	[Icon] VARCHAR (50) NULL,
	[Tittle] VARCHAR (40) NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	CONSTRAINT PK_Pages_Id PRIMARY KEY( Id )
)
CREATE TABLE Users
(
	Id INT IDENTITY (1000, 1),
	RolId INT FOREIGN KEY REFERENCES Rols(Id),
	Names VARCHAR (40) NOT NULL,
	Surnames VARCHAR (40) NOT NULL,
	Dni VARCHAR (25) NOT NULL,
	Cuil VARCHAR (25) NOT NULL,
	Email VARCHAR (60) NOT NULL,
	[Address] VARCHAR (150) NOT NULL,
	Sex VARCHAR (20) NULL,
	UniversityPosition VARCHAR (50) NOT NULL,
	[Password] VARCHAR (500) NOT NULL,
	Birthdate DATE NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	--Constraint
	CONSTRAINT PK_Users_Id PRIMARY KEY( Id )
)
CREATE TABLE PagesRols
(
	PageId INT FOREIGN KEY REFERENCES Pages(Id) NOT NULL,
	RolId INT FOREIGN KEY REFERENCES Rols(Id) NOT NULL,
	Write BIT NOT NULL,
	[Read] BIT NOT NULL,
	[Update] BIT NOT NULL,

	CONSTRAINT PK_PageUsers_Id PRIMARY KEY( PageId, RolId )
)
CREATE TABLE Careers
(
	Id INT IDENTITY (1000, 1),
	[Name] VARCHAR (50) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	--Constraints
	CONSTRAINT PK_Careers_Id PRIMARY KEY( Id )
)

CREATE TABLE Teachers
(
	Id INT IDENTITY (1000,1),
	Names VARCHAR (40) NOT NULL,
	Surnames VARCHAR (40) NOT NULL,
	Dni VARCHAR (25) NOT NULL,
	Cuil VARCHAR (25) NOT NULL,
	Email VARCHAR (60) NOT NULL,
	[Address] VARCHAR (150) NOT NULL,
	[File] VARCHAR (20) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	Sex VARCHAR (20) NULL,
	Birthdate DATE NOT NULL,
	--Constraints
	CONSTRAINT PK_Teachers_Id PRIMARY KEY( Id ),
	CONSTRAINT Unique_Teacher_Person UNIQUE( Dni ),
	CONSTRAINT Unique_Teacher_File UNIQUE( [File] ),
	CONSTRAINT Unique_Teacher_Cuil UNIQUE( Cuil ),
	CONSTRAINT Check_Teacher_Sex CHECK( Sex IN ( 'Femenino', 'Masculino' ) )
)

CREATE TABLE Students
(
	Id INT IDENTITY (1000,1),
	Names VARCHAR (40) NOT NULL,
	Surnames VARCHAR (40) NOT NULL,
	Dni VARCHAR (25) NOT NULL,
	Cuil VARCHAR (25) NOT NULL,
	[File] VARCHAR (30) NOT NULL,
	CareerId INT FOREIGN KEY REFERENCES Careers(Id),
	TeacherGuideId INT FOREIGN KEY REFERENCES Teachers(Id),
	Birthdate DATE NOT NULL,
	[Address] VARCHAR (150) NOT NULL,
	Email VARCHAR (60) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	Sex VARCHAR (20) NULL,
	--Constraints
	CONSTRAINT PK_Students_Id PRIMARY KEY( Id ),
	CONSTRAINT Unique_Student_Person UNIQUE( Dni ),
	CONSTRAINT Unique_Student_File UNIQUE( [File] ),
	CONSTRAINT Check_Student_Sex CHECK( Sex IN ( 'Femenino', 'Masculino' ) ),
	CONSTRAINT Unique_Student_Cuil UNIQUE( Cuil )
)

CREATE TABLE Companies
(
	Id INT IDENTITY (1000,1),
	[Name] VARCHAR (60) NOT NULL,
	Cuit VARCHAR (40) NOT NULL,
	Email VARCHAR (60) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	[Address] VARCHAR (150) NOT NULL,
	--Constraints
	CONSTRAINT PK_Companies_Id PRIMARY KEY( Id ),
	CONSTRAINT Unique_Company_Cuit UNIQUE ( Cuit )
)

CREATE TABLE CompanyTutor
(
	Id INT IDENTITY (1000,1),
	Names VARCHAR (40) NOT NULL,
	Surnames VARCHAR (40) NOT NULL,
	Dni VARCHAR (25) NOT NULL,
	Cuil VARCHAR (25) NOT NULL,
	Email VARCHAR (60) NOT NULL,
	--[Address] VARCHAR (150) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	Sex VARCHAR (20) NULL,
	Birthdate DATE NOT NULL,
	CompanyId INT FOREIGN KEY REFERENCES Companies(Id),
	--Constraints
	CONSTRAINT PK_CompanyM_Id PRIMARY KEY( Id ),
	CONSTRAINT Unique_CompanyT_Person UNIQUE( Dni ),
	CONSTRAINT Unique_CompanyT_Cuil UNIQUE( Cuil ),
	CONSTRAINT Check_CompanyT_Sex CHECK( Sex IN ( 'Femenino', 'Masculino' ) )
	
)

CREATE TABLE Interships
(
	Id INT IDENTITY (1000, 1),
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	CompanyId INT FOREIGN KEY REFERENCES Companies(Id),
	CompanyTutorId INT FOREIGN KEY REFERENCES CompanyTutor(Id),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	SalaryWorkAssignment MONEY NOT NULL,
	WorkAgreement VARCHAR (50) NOT NULL,
	CompanySignatory VARCHAR (60) NOT NULL,
	DailyHours SMALLINT NOT NULL,
	CreatedDate DATE NOT NULL,
	UserCreatedId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	LastModified DATE NULL,
	UserLasModifiedId INT FOREIGN KEY REFERENCES Users(Id) NULL,
	CancellationDate DATE NULL,
	UserCancelattionId INT FOREIGN KEY REFERENCES Users(Id) NULL,
	TaskDescription VARCHAR (200) NULL,
	CancellationDescription VARCHAR (200) NULL,
	RenovationDate DATE NULL,
	UserRenovationId INT FOREIGN KEY REFERENCES Users(Id) NULL,
	ConfirmationState VARCHAR (50) NULL,
	Observations VARCHAR (200) NULL,
	[State] VARCHAR (20) NOT NULL,
	Deleted BIT DEFAULT 0 NOT NULL,
	--Constraints
	CONSTRAINT PK_Interships_Id PRIMARY KEY( Id ),
	CONSTRAINT Check_Intership_Salary CHECK( SalaryWorkAssignment > 0 ),
	CONSTRAINT Check_Intership_DailyHours CHECK( DailyHours > 0 ),
	CONSTRAINT Check_Internship_State CHECK( [State] IN ( 'Nueva', 'Renovada', 'Cancelada' ) )
)