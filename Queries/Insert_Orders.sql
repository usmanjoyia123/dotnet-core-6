USE [AdvProg]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (2, 1, 4)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (3, 2, 2)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (4, 2, 6)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (5, 2, 11)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (6, 4, 18)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (7, 6, 20)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (8, 3, 21)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (9, 3, 24)
INSERT INTO [dbo].[Orders] ([Id], [CustomerId], [CarId]) VALUES (10, 4, 17)
SET IDENTITY_INSERT [dbo].[Orders] OFF