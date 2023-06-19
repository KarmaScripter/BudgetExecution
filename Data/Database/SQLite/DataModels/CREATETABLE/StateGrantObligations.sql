CREATE TABLE IF NOT EXISTS StateGrantObligations 
(
	StateGrantObligationsId INTEGER NOT NULL UNIQUE,
	RpioCode TEXT(80) NULL DEFAULT NS,
	RpioName TEXT(80) NULL DEFAULT NS,
	FundCode TEXT(80) NULL DEFAULT NS,
	FundName TEXT(80) NULL DEFAULT NS,
	AhCode	TEXT(80) NULL DEFAULT NS,
	AhName	TEXT(80) NULL DEFAULT NS,
	OrgCode	TEXT(80) NULL DEFAULT NS,
	OrgName	TEXT(80) NULL DEFAULT NS,
	StateCode TEXT(80) NULL DEFAULT NS,
	StateName TEXT(80) NULL DEFAULT NS,
	AccountCode	TEXT(80) NULL DEFAULT NS,
	ProgramProjectCode	TEXT(80) NULL DEFAULT NS,
	ProgramProjectName	TEXT(80) NULL DEFAULT NS,
	RcCode	TEXT(80) NULL DEFAULT NS,
	RcName	TEXT(80) NULL DEFAULT NS,
	BocCode	TEXT(80) NULL DEFAULT NS,
	BocName	TEXT(80) NULL DEFAULT NS,
	Amount	DOUBLE DEFAULT 0.0,
	TreasuryAccountCode	TEXT(80) NULL DEFAULT NS,
	TreasuryAccountName	TEXT(80) NULL DEFAULT NS,
	BudgetAccountCode	TEXT(80) NULL DEFAULT NS,
	BudgetAccountName	TEXT(80) NULL DEFAULT NS,
	PRIMARY KEY(StateGrantObligationsId AUTOINCREMENT)
);