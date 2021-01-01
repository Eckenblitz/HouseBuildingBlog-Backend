USE HouseBuildingBlog;
GO

CREATE SCHEMA Documents
GO

CREATE TABLE Documents.Documents (
	DocumentId uniqueidentifier NOT NULL, 
	Title nvarchar(max) NOT NULL, 
	Comment nvarchar(max),
	FileAdress nvarchar(max) NOT NULL,
	Price decimal(10,2),
	EventId uniqueidentifier NULL,
	CONSTRAINT PK_Documents PRIMARY KEY (DocumentId),
	CONSTRAINT FK_Documents_Events FOREIGN KEY (EventId) REFERENCES Events.Events (EventId) ON DELETE SET NULL
)
GO

UPDATE Info.DatabaseVersion SET Major = 0, Minor = 2, Patch = 0
GO