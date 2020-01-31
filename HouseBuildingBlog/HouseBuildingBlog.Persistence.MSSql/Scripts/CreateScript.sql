USE HouseBuildingBlog;

CREATE SCHEMA Events
GO

CREATE SCHEMA Documents
GO

CREATE TABLE Events.Events (
	EventId uniqueidentifier NOT NULL, 
	Title nvarchar(max) NOT NULL, 
	Text nvarchar(max),
	Date datetime2 NOT NULL,
	CONSTRAINT PK_Events PRIMARY KEY (EventId)
)
GO

CREATE TABLE Events.Tags (
	TagId uniqueidentifier NOT NULL,
	Title nvarchar(200) NOT NULL,
	CONSTRAINT PK_Tags PRIMARY KEY (TagId)
)
GO

CREATE TABLE Documents.Documents (
	DocumentId uniqueidentifier NOT NULL,
	Title nvarchar(200),
	Comment nvarchar(max),
	FileName nvarchar(200) NOT NULL,
	FilePath nvarchar(max) NOT NULL,
	CONSTRAINT PK_Documents PRIMARY KEY (DocumentId),
)
GO

CREATE TABLE Documents.Images (
	ImageId uniqueidentifier NOT NULL,
	Comment nvarchar(max),
	FileName nvarchar(200) NOT NULL,
	FilePath nvarchar(max) NOT NULL,
	CONSTRAINT PK_Images PRIMARY KEY (ImageId)
)
GO

CREATE TABLE Events.AssignedTags (
	EventId uniqueidentifier NOT NULL,
	TagId uniqueidentifier NOT NULL,
	CONSTRAINT PK_AssignedTags PRIMARY KEY (EventId, TagId),
	CONSTRAINT FK_AssignedTags_Events FOREIGN KEY (EventId) REFERENCES Events.Events (EventId),
	CONSTRAINT FK_AssignedTags_Tags FOREIGN KEY (TagId) REFERENCES Events.Tags (TagId)
)
GO

CREATE TABLE Events.AssignedDocuments (
	EventId uniqueidentifier NOT NULL,
	DocumentId uniqueidentifier NOT NULL,
	CONSTRAINT PK_AssignedDocuments PRIMARY KEY (EventId, DocumentId),
	CONSTRAINT FK_AssignedDocuments_Events FOREIGN KEY (EventId) REFERENCES Events.Events (EventId),
	CONSTRAINT FK_AssignedDocuments_Documents FOREIGN KEY (DocumentId) REFERENCES Documents.Documents (DocumentId)
)
GO

CREATE TABLE Events.AssignedImages (
	EventId uniqueidentifier NOT NULL,
	ImageId uniqueidentifier NOT NULL,
	CONSTRAINT PK_AssignedImages PRIMARY KEY (EventId, ImageId),
	CONSTRAINT FK_AssignedImages_Events FOREIGN KEY (EventId) REFERENCES Events.Events (EventId),
	CONSTRAINT FK_AssignedImages_Images FOREIGN KEY (ImageId) REFERENCES Documents.Images (ImageId)
)
GO
