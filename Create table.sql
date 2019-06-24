USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Solution2') 
BEGIN 
DROP DATABASE Solution2
END 
GO 

CREATE DATABASE Solution2
GO 

USE Solution2
GO

CREATE TABLE [Director] ( 
	[id] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Client's_Order] primary key,
	[Name] nvarchar(MAX) NOT NULL,
	);

CREATE TABLE [Movie] ( 
	[id] int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Client primary key,
	[Title] nvarchar(MAX) NOT NULL, 
	[DurationMinutes] int NOT NULL,
	[ReleaseDate] datetime NOT NULL,
	[DirectorId] int NOT NULL,
	[Rating] int, 
);

CREATE TABLE [Actor] (
	[id] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Client's_Size] primary key, 
	[Name] nvarchar(MAX) NOT NULL,
	[Age] int NOT NULL,
);

CREATE TABLE [MovieActor] ( 
	[MovieId] int NOT NULL, 
	[ActorId] int NOT NULL,
);

ALTER TABLE [MovieActor] ADD CONSTRAINT [FK_MovieActor_Movie]
FOREIGN KEY ([MovieId]) references [Movie]([id])
on delete cascade
on update cascade
GO

ALTER TABLE [MovieActor] ADD CONSTRAINT [FK_MovieActor_Actor]
FOREIGN KEY ([ActorId]) references [Actor]([id])
on delete cascade
on update cascade
GO

ALTER TABLE [Movie] ADD CONSTRAINT [FK_Movie_Director]
FOREIGN KEY ([DirectorId]) references [Director]([id])
on delete cascade
on update cascade
GO