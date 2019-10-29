CREATE TABLE [dbo].[Comments] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [userID]  INT           NOT NULL,
    [comment] VARCHAR (MAX) NOT NULL,
    [state]   INT           NOT NULL,
    [project] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [comment_by_user] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

