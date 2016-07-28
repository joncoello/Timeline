if exists ( select * from sys.tables where name = 'TimelineDefinition' )
	drop Table WF.TimelineDefinition
go

Create Table WF.TimelineDefinition(
	TimelineDefinitionID	INT,
	TimelineDefinitionName	varchar(255),
	Constraint PK_TimelineDefinition Primary Key Clustered (TimelineDefinitionID)
)