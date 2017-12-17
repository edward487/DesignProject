CREATE TABLE [dbo].[Users] (
    [UserID]   INT        NOT NULL,
    [UserName] NCHAR (50) NOT NULL,
    [Password] NCHAR (50) NOT NULL,
    [FullName]  VARCHAR(50)        NOT NULL,
    [IsAdmin] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

