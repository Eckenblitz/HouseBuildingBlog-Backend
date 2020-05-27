USE HouseBuildingBlog;
GO

CREATE SCHEMA Events
GO

CREATE TABLE Events.Events (
	EventId uniqueidentifier NOT NULL, 
	Title nvarchar(max) NOT NULL, 
	Description nvarchar(max),
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

CREATE TABLE Events.AssignedTags (
	EventId uniqueidentifier NOT NULL,
	TagId uniqueidentifier NOT NULL,
	CONSTRAINT PK_AssignedTags PRIMARY KEY (EventId, TagId),
	CONSTRAINT FK_AssignedTags_Events FOREIGN KEY (EventId) REFERENCES Events.Events (EventId),
	CONSTRAINT FK_AssignedTags_Tags FOREIGN KEY (TagId) REFERENCES Events.Tags (TagId)
)
GO
