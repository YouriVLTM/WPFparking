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


﻿INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (1, 1, 2, 10, 5, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (2, 2, 1, 15, 12, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (3, 3, 3, 2, 10, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (4, 4, 4, 5, 2, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (5, 1, 2, 20, 8, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (6, 2, 4, 4, 10, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (7, 3, 3, 8, 12, 'Grote parking')
INSERT INTO [dbo].[ParkPlace] ([Id], [parkingId], [buildingId], [row], [cel], [description]) VALUES (8, 4, 1, 9, 3, 'Grote parking')
