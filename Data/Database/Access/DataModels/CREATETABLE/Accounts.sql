CREATE TABLE Accounts
(
	AccountsId         AUTOINCREMENT NOT NULL UNIQUE,
	Code               TEXT( 150 )   NULL DEFAULT NS,
	GoalCode           TEXT( 150 )   NULL DEFAULT NS,
	ObjectiveCode      TEXT( 150 )   NULL DEFAULT NS,
	NpmCode            TEXT( 150 )   NULL DEFAULT NS,
	NpmName            TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaCode    TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaName    TEXT( 150 )   NULL DEFAULT NS,
	ActivityCode       TEXT( 150 )   NULL DEFAULT NS,
	ActivityName       TEXT( 150 )   NULL DEFAULT NS,
	AgencyActivity     TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	AccountsPrimaryKey
)
	PRIMARY KEY
(
	AccountsId
)
	);
