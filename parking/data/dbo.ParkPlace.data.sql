CREATE TABLE [dbo].[ParkPlace]
(
	[Id] INT NOT NULL,
    [parkingId] INT NOT NULL,
    [row] INT NOT NULL,
    [cel] INT NOT NULL,
    [description] VARCHAR(50) NULL,
    [buildingId] INT NOT NULL,

    PRIMARY KEY Clustered ([Id] ASC),
    CONSTRAINT [FK_ParkPlace_Parking] FOREIGN KEY ([parkingId]) REFERENCES [Parking]([Id]),
    CONSTRAINT [FK_ParkPlace_Building] FOREIGN KEY ([buildingId]) REFERENCES [Building]([Id])
)


﻿INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (1, 1, 2, 1, 1, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (2, 1, 2, 1, 2, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (3, 1, 2, 1, 3, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (4, 1, 2, 1, 4, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (5, 1, 2, 1, 5, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (6, 1, 2, 1, 6, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (7, 1, 2, 1, 7, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (8, 1, 2, 1, 8, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (9, 1, 2, 1, 9, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (10, 1, 2, 1, 10, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (11, 1, 2, 1, 11, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (12, 1, 2, 1, 12, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (13, 1, 2, 1, 13, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (14, 1, 2, 1, 14, 'Grote parking')

INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (15, 1, 2, 2, 1, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (16, 1, 2, 2, 2, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (17, 1, 2, 2, 3, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (18, 1, 2, 2, 4, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (19, 1, 2, 2, 5, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (20, 1, 2, 2, 6, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (21, 1, 2, 2, 7, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (22, 1, 2, 2, 8, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (23, 1, 2, 2, 9, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (24, 1, 2, 2, 10, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (25, 1, 2, 2, 11, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (26, 1, 2, 2, 12, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (27, 1, 2, 2, 13, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (28, 1, 2, 2, 14, 'Grote parking')


INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (29, 1, 2, 3, 1, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (30, 1, 2, 3, 2, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (31, 1, 2, 3, 3, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (32, 1, 2, 3, 4, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (33, 1, 2, 3, 5, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (34, 1, 2, 3, 6, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (35, 1, 2, 3, 7, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (36, 1, 2, 3, 8, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (37, 1, 2, 3, 9, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (38, 1, 2, 3, 10, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (39, 1, 2, 3, 11, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (40, 1, 2, 3, 12, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (41, 1, 2, 3, 13, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (42, 1, 2, 3, 14, 'Grote parking')
