USE [GatewayMgmt]
GO

DELETE FROM Gateways
GO
DELETE FROM Devices
GO

-- GATEWAYS
SET IDENTITY_INSERT Gateways ON
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (1, '4696550214', 'Roomm', '134.231.87.69') 
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (2, '1168238331', 'Aimbo', '238.123.90.244') 
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (3, '7657875224', 'Mycat', '71.192.42.234')
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (4, '1478273917', 'Zoomcast', '166.114.36.103') 
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (5, '2664686267', 'Topiclounge', '26.0.211.2') 
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (6, '4697075773', 'Meevee', '18.57.87.239')
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (7, '7179607134', 'BlogXS', '233.79.252.219')
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (8, '1107150329', 'Oyoyo', '208.128.40.137') 
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (9, '2876511592', 'Ntag', '183.171.25.215')
INSERT INTO Gateways (Id, SerialNumber, Name, IPv4) values (10, '7643063990', 'Bubblemix', '155.147.254.227')
SET IDENTITY_INSERT Gateways OFF
GO

-- DEVICES
SET IDENTITY_INSERT Devices ON
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (1,1,5888821969, 'n/a', '2019-02-12 14:19:23', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (1,2,3894895403, 'Electronic Components', '2018-12-18 03:47:56', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (1,3,4011974757, 'n/a', '2018-11-27 17:02:35', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,4,2912465001, 'Oil & Gas Production', '2019-03-16 21:02:01', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,5,7687290429, 'Major Banks', '2018-06-18 12:42:56', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,6,5995261657, 'Marine Transportation', '2019-04-16 02:15:42', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,7,5994828602, 'n/a', '2018-06-23 23:46:32', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,8,7039867257, 'n/a', '2018-05-06 09:05:21', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,9,5426120388, 'Medical Specialities', '2019-04-04 05:29:26', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,10,5611424775, 'n/a', '2019-01-08 20:38:10', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,11,5440170723, 'Computer Software', '2019-01-02 15:08:48', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,12,8948669435, 'Industrial Components', '2018-08-30 22:07:40', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (2,13,5802934220, 'Real Estate Investment Trusts', '2018-12-11 22:26:07', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (3,14,4443510710, 'Industrial Components', '2018-07-14 09:49:09', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (3,15,9076973768, 'Computer Software', '2018-07-06 21:48:33', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (3,16,6085283784, 'n/a', '2018-08-30 14:46:15', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (3,17,3802851013, 'Major Chemicals', '2018-09-08 10:32:51', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (3,18,4529780430, 'Biotechnology', '2019-02-28 13:59:50', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (3,19,4141609668, 'n/a', '2018-07-07 20:16:11', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (1,20,8274901266, 'n/a', '2018-08-01 20:45:22', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (4,21,5594106251, 'Major Banks', '2019-04-20 21:58:47', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (5,22,2164418433, 'Pollution Control Equipment', '2018-05-12 03:52:51', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (5,23,8819574993, 'Semiconductors', '2018-12-02 21:42:22', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (6,24,9225317166, 'n/a', '2018-07-16 11:32:44', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (7,25,7770497892, 'Marine Transportation', '2018-05-15 00:58:31', 1);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (7,26,8851893926, 'Catalog/Specialty Distribution', '2019-01-14 21:10:17', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (8,27,8653493832, 'Real Estate', '2018-07-18 02:52:23', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (9,28,6528790345, 'Banks', '2019-01-11 18:08:18', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (9,29,1062599888, 'Specialty Chemicals', '2019-01-06 16:34:58', 0);
INSERT INTO Devices (GatewayId, Id, UID, Vendor, DateCreated, Status) values (10,30,7563308954, 'Forest Products', '2018-12-04 01:40:32', 0);
SET IDENTITY_INSERT Devices OFF
GO