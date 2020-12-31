CREATE DATABASE HouseBuildingBlog
GO

USE HouseBuildingBlog;
GO

CREATE SCHEMA Info
GO

CREATE TABLE Info.DatabaseVersion(
	Major int NOT NULL,
	Minor int NOT NULL,
	Patch int NOT NULL
)
GO

INSERT INTO Info.DatabaseVersion VALUES (0, 0, 0)
GO