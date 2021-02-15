USE HouseBuildingBlog;
GO

CREATE SCHEMA Tags
GO

ALTER SCHEMA Tags TRANSFER Events.Tags
GO

CREATE TABLE Documents.AssignedTags (
	DocumentId uniqueidentifier NOT NULL,
	TagId uniqueidentifier NOT NULL,
	CONSTRAINT PK_AssignedTags PRIMARY KEY (DocumentId, TagId),
	CONSTRAINT FK_AssignedTags_Documents FOREIGN KEY (DocumentId) REFERENCES Documents.Documents (DocumentId) ON DELETE CASCADE,
	CONSTRAINT FK_AssignedTags_Tags FOREIGN KEY (TagId) REFERENCES Tags.Tags (TagId) ON DELETE CASCADE
)
GO


UPDATE Info.DatabaseVersion SET Major = 0, Minor = 3, Patch = 1
GO
