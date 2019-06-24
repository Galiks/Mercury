﻿--
-- Script was generated by Devart dbForge Studio 2019 for SQL Server, Version 5.7.31.0
-- Product Home Page: http://www.devart.com/dbforge/sql/studio
-- Script date 20.06.2019 01:45:17 
-- Target server version: 13.00.4224
-- Target connection string: Data Source=PC\SQLEXPRESS01;Encrypt=False;Initial Catalog=Solution2;Integrated Security=True;User ID=PC\pavel
--



SET LANGUAGE 'Russian'
SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

--
-- Backing up database Solution2
--
--
-- Create backup folder
--
IF OBJECT_ID('xp_create_subdir') IS NOT NULL
  EXEC xp_create_subdir N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\Backup'
--
-- Backup database to the file with the name: <database_name>_<yyyy>_<mm>_<dd>_<hh>_<mi>.bak
--
DECLARE @db_name SYSNAME
SET @db_name = N'Solution2'

DECLARE @filepath NVARCHAR(4000)
SET @filepath =
/*define base part*/ N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\Backup\' + @db_name + '_' +
/*append date*/ REPLACE(CONVERT(NVARCHAR(10), GETDATE(), 102), '.', '_') + '_' +
/*append time*/ REPLACE(CONVERT(NVARCHAR(5), GETDATE(), 108), ':', '_') + '.bak'

DECLARE @SQL NVARCHAR(MAX)
SET @SQL = 
    N'BACKUP DATABASE ' + QUOTENAME(@db_name) + ' TO DISK = @filepath WITH INIT' + 
      CASE WHEN EXISTS(
                SELECT value
                FROM sys.configurations
                WHERE name = 'backup compression default'
          )
        THEN ', COMPRESSION'
        ELSE ''
      END

EXEC sys.sp_executesql @SQL, N'@filepath NVARCHAR(4000)', @filepath = @filepath
GO

USE Solution2
GO

IF DB_NAME() <> N'Solution2' SET NOEXEC ON
GO
--
-- Delete data from the table 'dbo.MovieActor'
--
TRUNCATE TABLE dbo.MovieActor
GO
--
-- Delete data from the table 'dbo.Movie'
--
DELETE dbo.Movie
GO
--
-- Delete data from the table 'dbo.Director'
--
DELETE dbo.Director
GO
--
-- Delete data from the table 'dbo.Actor'
--
DELETE dbo.Actor
GO

--
-- Inserting data into table dbo.Actor
--
SET IDENTITY_INSERT dbo.Actor ON
GO
INSERT dbo.Actor(id, Name, Age) VALUES (1, N'Letha241', 55)
INSERT dbo.Actor(id, Name, Age) VALUES (2, N'Mollie1975', 46)
INSERT dbo.Actor(id, Name, Age) VALUES (3, N'Quintin5', 41)
INSERT dbo.Actor(id, Name, Age) VALUES (4, N'Kathern49', 32)
INSERT dbo.Actor(id, Name, Age) VALUES (5, N'Felisa221', 36)
INSERT dbo.Actor(id, Name, Age) VALUES (6, N'Shenita2027', 39)
INSERT dbo.Actor(id, Name, Age) VALUES (7, N'Arnita2004', 53)
INSERT dbo.Actor(id, Name, Age) VALUES (8, N'Woodrow2009', 29)
INSERT dbo.Actor(id, Name, Age) VALUES (9, N'Chantel318', 37)
INSERT dbo.Actor(id, Name, Age) VALUES (10, N'Aisha2010', 57)
INSERT dbo.Actor(id, Name, Age) VALUES (11, N'Christopher1976', 23)
INSERT dbo.Actor(id, Name, Age) VALUES (12, N'Stephan1976', 42)
INSERT dbo.Actor(id, Name, Age) VALUES (13, N'Brinson972', 63)
INSERT dbo.Actor(id, Name, Age) VALUES (14, N'Carpenter1994', 47)
INSERT dbo.Actor(id, Name, Age) VALUES (15, N'Doyle2', 35)
INSERT dbo.Actor(id, Name, Age) VALUES (16, N'Johnston1952', 54)
INSERT dbo.Actor(id, Name, Age) VALUES (17, N'Booker6', 24)
INSERT dbo.Actor(id, Name, Age) VALUES (18, N'Carvalho72', 21)
INSERT dbo.Actor(id, Name, Age) VALUES (19, N'Aguilera1993', 38)
INSERT dbo.Actor(id, Name, Age) VALUES (20, N'Paris2022', 20)
INSERT dbo.Actor(id, Name, Age) VALUES (21, N'Jerrod1982', 28)
INSERT dbo.Actor(id, Name, Age) VALUES (22, N'Suarez82', 51)
INSERT dbo.Actor(id, Name, Age) VALUES (23, N'Abreu232', 18)
INSERT dbo.Actor(id, Name, Age) VALUES (24, N'Shank212', 25)
INSERT dbo.Actor(id, Name, Age) VALUES (25, N'Elise28', 65)
INSERT dbo.Actor(id, Name, Age) VALUES (26, N'Alcala1977', 31)
INSERT dbo.Actor(id, Name, Age) VALUES (27, N'Abernathy6', 50)
INSERT dbo.Actor(id, Name, Age) VALUES (28, N'Lindsey295', 43)
INSERT dbo.Actor(id, Name, Age) VALUES (29, N'Hubert2025', 48)
INSERT dbo.Actor(id, Name, Age) VALUES (30, N'Paris24', 27)
INSERT dbo.Actor(id, Name, Age) VALUES (31, N'Muncy1', 22)
INSERT dbo.Actor(id, Name, Age) VALUES (32, N'Jestine2015', 40)
INSERT dbo.Actor(id, Name, Age) VALUES (33, N'Alexander3', 62)
INSERT dbo.Actor(id, Name, Age) VALUES (34, N'Seymour1989', 19)
INSERT dbo.Actor(id, Name, Age) VALUES (35, N'Lorretta2028', 58)
INSERT dbo.Actor(id, Name, Age) VALUES (36, N'Andre58', 59)
INSERT dbo.Actor(id, Name, Age) VALUES (37, N'Carlson9', 44)
INSERT dbo.Actor(id, Name, Age) VALUES (38, N'Jefferies7', 30)
INSERT dbo.Actor(id, Name, Age) VALUES (39, N'Verona3', 26)
INSERT dbo.Actor(id, Name, Age) VALUES (40, N'Lanette688', 45)
INSERT dbo.Actor(id, Name, Age) VALUES (41, N'Crystle2000', 52)
INSERT dbo.Actor(id, Name, Age) VALUES (42, N'Weston1954', 61)
INSERT dbo.Actor(id, Name, Age) VALUES (43, N'Abdul134', 34)
INSERT dbo.Actor(id, Name, Age) VALUES (44, N'Brigida1989', 49)
GO
SET IDENTITY_INSERT dbo.Actor OFF
GO

--
-- Inserting data into table dbo.Director
--
SET IDENTITY_INSERT dbo.Director ON
GO
INSERT dbo.Director(id, Name) VALUES (1, N'Abraham968')
INSERT dbo.Director(id, Name) VALUES (2, N'Markus549')
INSERT dbo.Director(id, Name) VALUES (3, N'Jason4')
INSERT dbo.Director(id, Name) VALUES (4, N'Mcnally2')
INSERT dbo.Director(id, Name) VALUES (5, N'Adolph45')
INSERT dbo.Director(id, Name) VALUES (6, N'Luther2020')
INSERT dbo.Director(id, Name) VALUES (7, N'Ada2005')
INSERT dbo.Director(id, Name) VALUES (8, N'Gerardo1992')
INSERT dbo.Director(id, Name) VALUES (9, N'Carmela778')
INSERT dbo.Director(id, Name) VALUES (10, N'Florida343')
INSERT dbo.Director(id, Name) VALUES (11, N'Abel79')
INSERT dbo.Director(id, Name) VALUES (12, N'Alesia1986')
INSERT dbo.Director(id, Name) VALUES (13, N'Abigail658')
INSERT dbo.Director(id, Name) VALUES (14, N'Abernathy1968')
INSERT dbo.Director(id, Name) VALUES (15, N'Allman22')
INSERT dbo.Director(id, Name) VALUES (16, N'Brandt151')
INSERT dbo.Director(id, Name) VALUES (17, N'Celestine1984')
INSERT dbo.Director(id, Name) VALUES (18, N'Andrew2004')
INSERT dbo.Director(id, Name) VALUES (19, N'Lewis1950')
INSERT dbo.Director(id, Name) VALUES (20, N'Alphonso1996')
INSERT dbo.Director(id, Name) VALUES (21, N'Huey266')
INSERT dbo.Director(id, Name) VALUES (22, N'Sauer1')
INSERT dbo.Director(id, Name) VALUES (23, N'Angelia7')
INSERT dbo.Director(id, Name) VALUES (24, N'Douglass6')
INSERT dbo.Director(id, Name) VALUES (25, N'Adrian25')
INSERT dbo.Director(id, Name) VALUES (26, N'Julius176')
INSERT dbo.Director(id, Name) VALUES (27, N'Crocker161')
INSERT dbo.Director(id, Name) VALUES (28, N'Laci2018')
INSERT dbo.Director(id, Name) VALUES (29, N'Najera259')
INSERT dbo.Director(id, Name) VALUES (30, N'Adah1954')
INSERT dbo.Director(id, Name) VALUES (31, N'Banks331')
INSERT dbo.Director(id, Name) VALUES (32, N'Alice7')
INSERT dbo.Director(id, Name) VALUES (33, N'Antonio2012')
INSERT dbo.Director(id, Name) VALUES (34, N'Ivory222')
INSERT dbo.Director(id, Name) VALUES (35, N'Aiko2002')
INSERT dbo.Director(id, Name) VALUES (36, N'Alesia1990')
INSERT dbo.Director(id, Name) VALUES (37, N'Jessika1979')
INSERT dbo.Director(id, Name) VALUES (38, N'Percy22')
INSERT dbo.Director(id, Name) VALUES (39, N'Marilu1968')
INSERT dbo.Director(id, Name) VALUES (40, N'Trent844')
INSERT dbo.Director(id, Name) VALUES (41, N'Evalyn1973')
INSERT dbo.Director(id, Name) VALUES (42, N'Tyrell2000')
INSERT dbo.Director(id, Name) VALUES (43, N'Caleb49')
INSERT dbo.Director(id, Name) VALUES (44, N'Vernon2007')
INSERT dbo.Director(id, Name) VALUES (45, N'Guillen2015')
INSERT dbo.Director(id, Name) VALUES (46, N'Mack1955')
INSERT dbo.Director(id, Name) VALUES (47, N'Marcelo13')
INSERT dbo.Director(id, Name) VALUES (48, N'Melody1989')
INSERT dbo.Director(id, Name) VALUES (49, N'Chaney85')
INSERT dbo.Director(id, Name) VALUES (50, N'Abram2009')
GO
SET IDENTITY_INSERT dbo.Director OFF
GO

--
-- Inserting data into table dbo.Movie
--
SET IDENTITY_INSERT dbo.Movie ON
GO
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (1, N'Quia at doloribus quia praesentium.', 24, '1976-10-07 02:53:58.830', 48, 0)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (2, N'Nesciunt cum iure saepe sint alias.', 134, '2015-10-18 03:44:21.860', 44, 2)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (3, N'Dolorum sed ratione rerum.', 151, '2010-11-06 08:32:21.990', 50, 1)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (4, N'Unde enim consequatur aut illo.', 135, '2009-05-06 01:33:43.180', 39, 6)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (5, N'Tempora omnis aliquid quibusdam.', 116, '2004-05-25 06:21:43.280', 24, 3)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (6, N'Delectus quo vel fugiat aut fugiat.', 100, '2015-10-18 03:44:21.870', 30, 10)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (7, N'Deserunt unde ducimus.', 119, '2010-11-06 08:32:22.000', 25, 5)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (8, N'Quia recusandae ut eveniet atque aut.', 72, '1989-02-10 04:23:45.420', 34, 9)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (9, N'Voluptatibus ab officia sed ut quasi.', 41, '2009-05-06 01:33:43.190', 31, 8)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (10, N'Est omnis vitae.', 136, '1971-10-27 07:41:58.930', 40, 4)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (11, N'Rerum voluptate inventore asperiores.', 117, '2004-05-25 06:21:43.290', 46, 7)
INSERT dbo.Movie(id, Title, DurationMinutes, ReleaseDate, DirectorId, Rating) VALUES (12, N'Molestias sunt et aspernatur enim.', 56, '1984-03-01 09:11:45.520', 6, NULL)
GO
SET IDENTITY_INSERT dbo.Movie OFF
GO

--
-- Inserting data into table dbo.MovieActor
--
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (5, 4)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (1, 19)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (4, 30)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (10, 44)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (3, 9)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (12, 5)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (2, 24)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (11, 35)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (6, 37)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (9, 1)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (8, 6)
INSERT dbo.MovieActor(MovieId, ActorId) VALUES (7, 20)
GO

--
-- Set NOEXEC to off
--

SET NOEXEC OFF
GO