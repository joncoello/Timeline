-- reset
if exists ( select * from sys.tables where name = 'ContactTimeline' )
	drop Table WF.ContactTimeline
go

if exists ( select * from sys.tables where name = 'TimelineDefinitionStep' )
	drop Table WF.TimelineDefinitionStep
go

if exists ( select * from sys.tables where name = 'TimelineDefinition' )
	drop Table WF.TimelineDefinition
go

drop Procedure WF.TimelineDefinition_Save
go

-- main schema script
Create Table WF.TimelineDefinition(
	TimelineDefinitionID	INT				IDENTITY(1,1),
	TimelineDefinitionName	varchar(255),

	Constraint PK_TimelineDefinition Primary Key Clustered (TimelineDefinitionID)
)
go

Create Table WF.TimelineDefinitionStep(
	TimelineDefinitionStepID		INT				NOT NULL		IDENTITY(1,1),
	TimelineDefinitionID			INT				NOT NULL,
	TimelineDefinitionStepName		varchar(255)	NOT NULL,
	Position						INT				NOT NULL

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

-- procs
Create Procedure WF.TimelineDefinition_Save
	
	@TimelineDefinitionID int,
	@TimelineDefinitionName varchar(100),
	@steps xml

as

	-- definition header
	if @TimelineDefinitionID = 0
	begin 
		insert into wf.TimelineDefinition(TimelineDefinitionName)
		values(@TimelineDefinitionName)
		set @TimelineDefinitionID = SCOPE_IDENTITY()
	end
	else
		update wf.TimelineDefinition
		set TimelineDefinitionName = @TimelineDefinitionName
		where TimelineDefinitionID = @TimelineDefinitionID

	select @TimelineDefinitionID

	-- steps
	insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, Position, TimelineDefinitionID)
	output inserted.*
	select
		T.c.value('@name', 'varchar(100)'),
		T.c.value('@position', 'int'),
		@TimelineDefinitionID
	from
		@steps.nodes('/definition/step') T(c)
	where
		T.c.value('@id', 'int') = 0

	update wf.TimelineDefinitionStep
	set
		TimelineDefinitionStepName = T.c.value('@name', 'varchar(100)'),
		Position = T.c.value('@position', 'int')
	from
		@steps.nodes('/definition/step') T(c)
	where
		T.c.value('@id', 'int') = TimelineDefinitionStepID


go

-- test data
declare @definitionID int
declare @stepID int

-- defintion
insert into wf.TimelineDefinition(TimelineDefinitionName)
values('Personal Tax')

set @definitionID = SCOPE_IDENTITY()

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID, Position)
values ('Step 1', @definitionID, 0)

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID, Position)
values ('Step 2', @definitionID, 1)

set @stepID = SCOPE_IDENTITY()

insert into wf.TimelineDefinitionStep(TimelineDefinitionStepName, TimelineDefinitionID, Position)
values ('Step 3', @definitionID, 2)

-- client
insert into wf.ContactTimeline(TimelineDefinitionID, TimelineDefinitionStepID, ContactID)
values(@definitionID, @stepID, 307) -- bob jones contact - change on other DBs
