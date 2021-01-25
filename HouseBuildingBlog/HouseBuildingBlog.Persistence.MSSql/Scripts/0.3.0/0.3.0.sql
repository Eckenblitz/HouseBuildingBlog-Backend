﻿USE HouseBuildingBlog;
GO

CREATE TABLE Documents.Files (
	DocumentId uniqueidentifier NOT NULL, 
	FileType nvarchar(max) NOT NULL, 
	FileName nvarchar(max) NOT NULL,
	CONSTRAINT PK_Files PRIMARY KEY (DocumentId),
	CONSTRAINT FK_Files_Documents FOREIGN KEY (DocumentId) REFERENCES Documents.Documents (DocumentId) ON DELETE CASCADE
)
GO

UPDATE Info.DatabaseVersion SET Major = 0, Minor = 3, Patch = 0
GO
