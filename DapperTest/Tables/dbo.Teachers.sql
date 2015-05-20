CREATE TABLE [dbo].[Teachers]
(
[TeacherId] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[BirthDate] [datetime] NULL,
[Address1] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address2] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[State] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Zipcode] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[Teachers] ADD CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED  ([TeacherId])
GO
