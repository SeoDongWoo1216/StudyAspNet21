CREATE TABLE [dbo].[users]
(
	[UID] INT NOT NULL PRIMARY KEY, 
    [UserID] NVARCHAR(25) NOT NULL, 
    [Password] VARCHAR(200) NOT NULL
)
