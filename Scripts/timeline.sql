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

Create Table WF.ContactTimeline(
	ClientTimelineID				INT		IDENTITY(1,1),
	TimelineDefinitionID			INT,
	TimelineDefinitionStepID		INT,
	ContactID						INT,

	Constraint PK_ClientTimeline Primary Key Clustered (ClientTimelineID),
	Constraint FK_ClientTimeline_TimelineDefinition Foreign Key (TimelineDefinitionID) References WF.TimelineDefinition(TimelineDefinitionID),
	Constraint FK_ClientTimeline_TimelineDefinitionStep Foreign Key (TimelineDefinitionStepID) References WF.TimelineDefinitionStep(TimelineDefinitionStepID),
	Constraint FK_ClientTimeline_Contact Foreign Key (ContactID) References Contact(ContactID)
)
go

-- test data
declare @definitionID int
declare @stepID int

-- defintion
insert into wf.TimelineDefinition(TimelineDefinitionName)
values('Personal Tax')

set @definitionID = SCOPE_IDENTITY()

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID)
values ('Step 1', @definitionID)

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID)
values ('Step 2', @definitionID)

set @stepID = SCOPE_IDENTITY()

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID)
values ('Step 3', @definitionID)

-- client
insert into wf.ContactTimeline(TimelineDefinitionID, TimelineDefinitionStepID, ContactID)
values(@definitionID, @stepID, 307) -- bob jones contact - change on other DBs
