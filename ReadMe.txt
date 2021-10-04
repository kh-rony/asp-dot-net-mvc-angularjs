
Microsoft SQL Server Configurations for ASPDotNETMVCAngularJS - ASP.NET MVC with AngularJS:


server=KH-RONY-PC;
database=ASPDotNETMVCAngularJS;
uid=kh-rony;
password=1234;



CREATE DATABASE ASPDotNETMVCAngularJS;

DROP DATABASE ASPDotNETMVCAngularJS;

USE ASPDotNETMVCAngularJS;

SELECT COUNT(*) FROM [ASPDotNETMVCAngularJS].[dbo].[Student];


USE [ASPDotNETMVCAngularJS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
    [ID] [int] IDENTITY(1, 1),
    [Name] nvarchar(100),
    [Email] nvarchar(100)
) ON [PRIMARY]
GO


USE [ASPDotNETMVCAngularJS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStudent] 
    @Name nvarchar(100),
    @Email nvarchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Student VALUES(@Name, @Email)   
END


USE [ASPDotNETMVCAngularJS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStudent]
AS
BEGIN
    SET NOCOUNT ON; Select * FROM Student
END


USE [ASPDotNETMVCAngularJS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudent]
    @Id int,
    @Name nvarchar(100),
    @Email nvarchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Student SET Name = @Name, Email = @Email WHERE Id = @Id
END


USE [ASPDotNETMVCAngularJS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudent]
    @Id int 
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Student WHERE Id = @Id
END