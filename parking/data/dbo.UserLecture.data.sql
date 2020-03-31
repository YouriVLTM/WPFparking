CREATE TABLE [dbo].[UserLecture]
(
	[Id] INT NOT NULL,
    [LectureId] INT NOT NULL,
    [UserId] INT NOT NULL,

    PRIMARY KEY Clustered ([Id] ASC),
    CONSTRAINT [FK_UserLecture_Lecture] FOREIGN KEY ([lectureId]) REFERENCES [Lecture]([Id]),
    CONSTRAINT [FK_UserLecture_User] FOREIGN KEY ([userId]) REFERENCES [Userx]([Id])
)

﻿INSERT INTO [dbo].[UserLecture] ([Id], [lectureId], [userId]) VALUES (1, 1, 5)
INSERT INTO [dbo].[UserLecture] ([Id], [lectureId], [userId]) VALUES (2, 2, 4)
INSERT INTO [dbo].[UserLecture] ([Id], [lectureId], [userId]) VALUES (3, 3, 3)
INSERT INTO [dbo].[UserLecture] ([Id], [lectureId], [userId]) VALUES (4, 4, 2)
INSERT INTO [dbo].[UserLecture] ([Id], [lectureId], [userId]) VALUES (5, 5, 1)
