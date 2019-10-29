CREATE TABLE [dbo].[Projects] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50) NOT NULL,
    [description] TEXT         NOT NULL,
    [createdby]   INT          NOT NULL,
    [postedOn]    DATE         NOT NULL,
    [duration]    VARCHAR (50) NOT NULL,
    [client]      INT          NOT NULL,
    [reviseCount] INT          DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [created_by_user] FOREIGN KEY ([createdby]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [created_for_client] FOREIGN KEY ([client]) REFERENCES [dbo].[Clients] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

