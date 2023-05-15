USE [AdvProg]
GO
CREATE TABLE [dbo].[Makes](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](50) NOT NULL,
[TimeStamp] [timestamp] NULL,
CONSTRAINT [PK_Makes] PRIMARY KEY CLUSTERED
(
[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO