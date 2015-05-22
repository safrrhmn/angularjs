CREATE TABLE [dbo].[Classes.Teachers]
(
	[Classes.TeachersId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[ClassId] INT NOT NULL,
	[TeacherId] int NOT NULL
)
GO
ALTER TABLE [dbo].[Classes.Teachers] ADD CONSTRAINT [FK_Classes.Teachers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[Classes.Teachers] ADD CONSTRAINT [FK_Classes.Teachers_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Classes] ([ClassId])
GO