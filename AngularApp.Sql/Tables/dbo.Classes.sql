CREATE TABLE [dbo].[Classes]
(
[ClassId] [int] NOT NULL IDENTITY(1, 1), 
    [Name] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(500) NULL,
)
GO
ALTER TABLE [dbo].[Classes] ADD 
CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED  ([ClassId])
GO



