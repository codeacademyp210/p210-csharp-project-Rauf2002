--CREATE TABLE Students (
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Name nvarchar(30) NOT NULL,
--	Surname nvarchar(30) NOT NULL,
--	Email nvarchar(50) NOT NULL,
--	Phone nvarchar(30) NOT NULL,
--	Fee int NOT NULL,
--	GroupId int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
--	Status bit NOT NULL
--);

--CREATE TABLE Tasks (
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Name nvarchar(30) NOT NULL,
--	Deadline Datetime NOT NULL,
--	GroupId int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
--	Status bit NOT NULL
--);

--CREATE TABLE Grades (
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Grade int NOT NULL,
--	StudentId int NOT NULL FOREIGN KEY REFERENCES Students(Id),
--	TaskId int NOT NULL FOREIGN KEY REFERENCES Tasks(Id),
--	Status bit NOT NULL
--);

--CREATE TABLE AcademyInfo (
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Name nvarchar(30) NOT NULL,
--	Address nvarchar(100) NOT NULL,
--	Phone nvarchar(50) NOT NULL,
--	Status bit NOT NULL
--);

--INSERT INTO AcademyInfo (Name,Address,Phone,Status)
--VALUES ('Code Academy','Nizami street 203B, AF Business House, second floor','+994125552525',1);
