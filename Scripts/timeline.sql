-- reset
if exists ( select * from sys.tables where name = 'TimelineDefinitionStep' )
	drop Table WF.TimelineDefinitionStep
go

if exists ( select * from sys.tables where name = 'TimelineDefinition' )
	drop Table WF.TimelineDefinition
go

-- main schema script
Create Table WF.TimelineDefinition(
	TimelineDefinitionID	INT				IDENTITY(1,1),
	TimelineDefinitionName	varchar(255),

	Constraint PK_TimelineDefinition Primary Key Clustered (TimelineDefinitionID)
)
go

Create Table WF.TimelineDefinitionStep(
	TimelineDefinitionStepID		INT		IDENTITY(1,1),
	TimelineDefinitionID			INT,
	TimelineDefinitionStepName		varchar(255),

	Constraint PK_TimelineDefinitionStep Primary Key Clustered (TimelineDefinitionStepID),
	Constraint FK_TimelineDefinitionStep_TimelineDefinition Foreign Key (TimelineDefinitionID) References WF.TimelineDefinition(TimelineDefinitionID)
)
go

-- test data
declare @definitionID int

insert into wf.TimelineDefinition(TimelineDefinitionName)
values('Personal Tax')

set @definitionID = SCOPE_IDENTITY()

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID)
values 
	('Step 1', @definitionID),
	('Step 2', @definitionID),
	('Step 3', @definitionID)