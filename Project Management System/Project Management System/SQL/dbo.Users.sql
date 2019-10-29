CREATE TABLE [dbo].[Users] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [username]    NVARCHAR (50) NOT NULL,
    [password]    NVARCHAR (50) NOT NULL,
    [salt]        NVARCHAR (50) NOT NULL,
    [accessLevel] INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

