CREATE TABLE IF NOT EXISTS OperatingPlans 
(
	OperatingPlansId	INTEGER NOT NULL UNIQUE,
	BFY	TEXT(80) NULL DEFAULT NS,
	EFY	TEXT(80) NULL DEFAULT NS,
	FundCode	TEXT(80) NULL DEFAULT NS,
	FundName	TEXT(80) NULL DEFAULT NS,
	RpioCode	TEXT(80) NULL DEFAULT NS,
	RpioName	TEXT(80) NULL DEFAULT NS,
	AhCode	TEXT(80) NULL DEFAULT NS,
	OrgCode	TEXT(80) NULL DEFAULT NS,
	AccountCode	TEXT(80) NULL DEFAULT NS,
	BocCode	TEXT(80) NULL DEFAULT NS,
	BocName	TEXT(80) NULL DEFAULT NS,
	Amount	DOUBLE DEFAULT 0.0,
	NpmCode	TEXT(80) NULL DEFAULT NS,
	ProgramProjectCode	TEXT(80) NULL DEFAULT NS,
	ProgramAreaCode	TEXT(80) NULL DEFAULT NS,
	NpmName	TEXT(80) NULL DEFAULT NS,
	AhName	TEXT(80) NULL DEFAULT NS,
	OrgName	TEXT(80) NULL DEFAULT NS,
	ProgramProjectName	TEXT(80) NULL DEFAULT NS,
	ActivityCode	TEXT(80) NULL DEFAULT NS,
	ActivityName	TEXT(80) NULL DEFAULT NS,
	ProgramAreaName	TEXT(80) NULL DEFAULT NS,
	GoalCode	TEXT(80) NULL DEFAULT NS,
	GoalName	TEXT(80) NULL DEFAULT NS,
	ObjectiveCode	TEXT(80) NULL DEFAULT NS,
	ObjectiveName	TEXT(80) NULL DEFAULT NS,
	TreasuryAccountCode	TEXT(80) NULL DEFAULT NS,
	TreasuryAccountName	TEXT(80) NULL DEFAULT NS,
	BudgetAccountCode	TEXT(80) NULL DEFAULT NS,
	BudgetAccountName	TEXT(80) NULL DEFAULT NS,
	Version	TEXT(80) NULL DEFAULT NS,
	PRIMARY KEY(OperatingPlansId AUTOINCREMENT)
);