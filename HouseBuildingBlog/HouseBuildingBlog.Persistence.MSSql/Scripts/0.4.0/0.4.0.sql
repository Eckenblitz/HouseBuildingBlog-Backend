USE HouseBuildingBlog;
GO

CREATE SCHEMA Images
GO

CREATE TABLE Images.Galleries (
	GalleryId uniqueidentifier NOT NULL, 
	Title nvarchar(200) NOT NULL, 
	CONSTRAINT PK_Galleries PRIMARY KEY (GalleryId)
)
GO

CREATE TABLE Images.Images (
	ImageId uniqueidentifier NOT NULL,
	Title nvarchar(200) NULL,
	Comment nvarchar(max) NULL,
	GalleryId uniqueidentifier NOT NULL
	CONSTRAINT PK_Images PRIMARY KEY (ImageId),
	CONSTRAINT FK_Images_Galleries FOREIGN KEY (GalleryId) REFERENCES Images.Galleries (GalleryId) ON DELETE CASCADE
)
GO

CREATE TABLE Images.Files (
	ImageId uniqueidentifier NOT NULL, 
	FileType nvarchar(20) NOT NULL, 
	FileName nvarchar(200) NOT NULL,
	CONSTRAINT PK_Files PRIMARY KEY (ImageId),
	CONSTRAINT FK_Files_Images FOREIGN KEY (ImageId) REFERENCES Images.Images (ImageId) ON DELETE CASCADE
)
GO

UPDATE Info.DatabaseVersion SET Major = 0, Minor = 4, Patch = 0
GO