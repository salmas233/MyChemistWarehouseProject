CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(500) NOT NULL,
	YearEstablished INT,
	Email NVARCHAR(100),
	Phone NVARCHAR(100)
)
