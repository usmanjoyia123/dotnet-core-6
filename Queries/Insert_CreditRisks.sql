USE [AdvProg]
GO
SET IDENTITY_INSERT [dbo].[CreditRisks] ON
INSERT INTO [dbo].[CreditRisks] ([Id], [FirstName], [LastName], [CustomerId]) VALUES (1, N'Bad', N'Customer', 6)
INSERT INTO [dbo].[CreditRisks] ([Id], [FirstName], [LastName], [CustomerId]) VALUES (2, N'Dave', N'Brenner', 1)
SET IDENTITY_INSERT [dbo].[CreditRisks] OFF