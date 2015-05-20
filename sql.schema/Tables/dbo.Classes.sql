CREATE TABLE [dbo].[Classes]
(
[ClassId] [int] NOT NULL IDENTITY(1, 1),
[InstanceId] [int] NOT NULL,
[TeacherId] [int] NULL,
[StudentId] [int] NULL
)
ALTER TABLE [dbo].[Classes] ADD 
CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED  ([ClassId])
GO
ALTER TABLE [dbo].[Classes] ADD CONSTRAINT [UQ_Classes_InstanceId] UNIQUE NONCLUSTERED  ([InstanceId])

GO

ALTER TABLE [dbo].[Classes] ADD CONSTRAINT [FK_Classes_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Classes] ADD CONSTRAINT [FK_Classes_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teachers] ([TeacherId])
GO
