USE [AdvProg]
GO
CREATE TABLE [dbo].[CreditRisks](
[Id] [int] IDENTITY(1,1) NOT NULL,
[FirstName] [nvarchar](50) NOT NULL,
[LastName] [nvarchar](50) NOT NULL,
[CustomerId] [int] NOT NULL,
[TimeStamp] [timestamp] NULL,
CONSTRAINT [PK_CreditRisks] PRIMARY KEY CLUSTERED
(
[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO