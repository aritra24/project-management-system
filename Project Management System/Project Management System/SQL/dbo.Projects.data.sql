SET IDENTITY_INSERT [dbo].[Projects] ON
INSERT INTO [dbo].[Projects] ([id], [name], [description], [createdby], [postedOn], [duration], [client], [reviseCount]) VALUES (17, N'Edited Project', N'Lorem Ipsum Dolor', 5, N'2019-10-29', N'2 Years', 1, 2)
INSERT INTO [dbo].[Projects] ([id], [name], [description], [createdby], [postedOn], [duration], [client], [reviseCount]) VALUES (18, N'Project 2', N'Lorem Ipsum Dolor', 5, N'2019-10-29', N'2 Month', 3, 0)
INSERT INTO [dbo].[Projects] ([id], [name], [description], [createdby], [postedOn], [duration], [client], [reviseCount]) VALUES (19, N'Project 3', N'Lorem Ipsum Dolor', 5, N'2019-10-29', N'1 year', 5, 0)
SET IDENTITY_INSERT [dbo].[Projects] OFF
