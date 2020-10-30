USE HouseBuildingBlog;
GO

CREATE SCHEMA Costplan
GO

CREATE TABLE Costplan.CostplanItems (
	CostplanItemId uniqueidentifier NOT NULL,
	Name nvarchar(max) NOT NULL,
	EstimatedCost decimal(10,2) NULL,
	Number int NOT NULL,
	CONSTRAINT PK_CostplanItems PRIMARY KEY (CostplanItemId)
)
GO