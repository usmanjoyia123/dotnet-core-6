USE [AdvProg]
GO
CREATE TABLE [dbo].[Orders](
[Id] [int] IDENTITY(1,1) NOT NULL,
[CustomerId] [int] NOT NULL,
[CarId] [int] NOT NULL,
[TimeStamp] [timestamp] NULL,
CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED
(
[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO