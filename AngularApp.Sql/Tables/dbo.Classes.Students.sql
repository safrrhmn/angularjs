CREATE TABLE [dbo].[Classes.Students]
(
	[Classes.StudentsId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[ClassId] INT NOT NULL,
	[StudentId] int NOT NULL
)
GO
ALTER TABLE [dbo].[Classes.Students] ADD CONSTRAINT [FK_Classes.Students_StudentsId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Classes.Students] ADD CONSTRAINT [FK_Classes.Students_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Classes] ([ClassId])
GO