CREATE TABLE [dbo].[Building]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [place] VARCHAR(50) NOT NULL,
    [description] VARCHAR(50) NULL,
    [location] VARCHAR(50) NOT NULL
)

INSERT INTO [dbo].[Building] ([Id], [place], [description], [location]) VALUES (1, 'B blok', 'Mooi gebouw', 'B202')
INSERT INTO [dbo].[Building] ([Id], [place], [description], [location]) VALUES (2, 'A blok', 'Mooi gebouw', 'A202')
INSERT INTO [dbo].[Building] ([Id], [place], [description], [location]) VALUES (3, 'F blok', 'Mooi gebouw', 'F202')
INSERT INTO [dbo].[Building] ([Id], [place], [description], [location]) VALUES (4, 'G blok', 'Mooi gebouw', 'G202')
INSERT INTO [dbo].[Building] ([Id], [place], [description], [location]) VALUES (5, 'B blok', 'Mooi gebouw', 'B102')
INSERT INTO [dbo].[Building] ([Id], [place], [description], [location]) VALUES (6, 'B blok', 'Mooi gebouw', 'B208')
