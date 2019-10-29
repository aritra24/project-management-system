SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [username], [password], [salt], [accessLevel]) VALUES (5, N'admin', N'6NqSegSHcNaRlTTh8foIHTLbyOc=', N'484073242', 20)
INSERT INTO [dbo].[Users] ([Id], [username], [password], [salt], [accessLevel]) VALUES (6, N'user1', N'aad7nbwYGjcMaHP5XPYXMo8vP/E=', N'1956044701', 10)
INSERT INTO [dbo].[Users] ([Id], [username], [password], [salt], [accessLevel]) VALUES (7, N'user2', N'31HK9FxJGlPIfvtPt0cm+pMVu1U=', N'1903364456', 10)
SET IDENTITY_INSERT [dbo].[Users] OFF
