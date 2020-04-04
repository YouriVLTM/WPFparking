CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL,
    [userId] INT NOT NULL,
    [parkPlaceId] INT NOT NULL,
    [status] VARCHAR(50) NOT NULL,
    [date] DATE NOT NULL,
    [beginTime] TIME NOT NULL,
    [endTime] TIME NOT NULL,

    PRIMARY KEY Clustered ([Id] ASC),
  	CONSTRAINT [FK_Reservation_User] FOREIGN KEY ([userId]) REFERENCES [Userx]([Id]),
    CONSTRAINT [FK_Reservation_ParkPlace] FOREIGN KEY ([parkPlaceId]) REFERENCES [ParkPlace]([Id])
)


﻿INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (1, 1, 8, 'Ready', '20200417', '08:30:00', '10:05:00')
INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (2, 2, 7, 'Ready', '20200517', '08:30:00', '10:05:00')
INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (3, 3, 6, 'Ready', '20200617', '08:30:00', '10:05:00')
INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (4, 4, 5, 'Ready', '20200405', '08:30:00', '10:05:00')
INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (5, 5, 4, 'Ready', '20200420', '10:30:00', '16:05:00')
INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (6, 6, 3, 'Ready', '20200430', '11:30:00', '20:05:00')
INSERT INTO [dbo].[Reservation] ([Id], [userId], [parkPlaceId], [status], [date], [beginTime], [endTime]) VALUES (7, 7, 2, 'Ready', '20200417', '14:30:00', '18:05:00')



Select * from Reservation res
RIGHT JOIN ParkPlace pa ON pa.id = res.parkPlaceId
JOIN Building bu ON pa.buildingId = bu.Id
Where
bu.location = 'A202'
AND
res.beginTime NOT BETWEEN CONVERT(datetime, '02/02/2020 14:29:00') AND CONVERT(datetime, '02/02/2020 15:30:00')
OR res.beginTime IS NULL
AND
res.endTime NOT BETWEEN CONVERT(datetime, '02/02/2020 14:29:00') AND CONVERT(datetime, '02/02/2020 15:30:00')
OR res.endTime IS NULL
AND
pa.Id NOT IN(
	Select pa.Id from Reservation res
		RIGHT JOIN ParkPlace pa ON pa.id = res.parkPlaceId
		JOIN Building bu ON pa.buildingId = bu.Id
		Where
		bu.location = 'A202'
		AND
		res.beginTime BETWEEN CONVERT(datetime, '02/02/2020 14:30:00') AND CONVERT(datetime, '02/02/2020 15:30:00')
		OR
		res.endTime BETWEEN CONVERT(datetime, '02/02/2020 14:30:00') AND CONVERT(datetime, '02/02/2020 15:30:00')
	)

ORDER by res.Id
