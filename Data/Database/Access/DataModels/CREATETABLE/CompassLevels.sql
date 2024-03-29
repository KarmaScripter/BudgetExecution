CREATE TABLE CompassLevels
(
	CompassLevelsId     AUTOINCREMENT NOT NULL UNIQUE,
	BFY                 TEXT( 150 )   NULL DEFAULT NS,
	EFY                 TEXT( 150 )   NULL DEFAULT NS,
	FundCode            TEXT( 150 )   NULL DEFAULT NS,
	FundName            TEXT( 150 )   NULL DEFAULT NS,
	TreasurySymbol      TEXT( 150 )   NULL DEFAULT NS,
	BudgetLevel         TEXT( 150 )   NULL DEFAULT NS,
	RpioCode            TEXT( 150 )   NULL DEFAULT NS,
	RpioName            TEXT( 150 )   NULL DEFAULT NS,
	AccountCode         TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName  TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaCode     TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaName     TEXT( 150 )   NULL DEFAULT NS,
	Authority           DOUBLE        NULL DEFAULT 0.0,
	CarryoverIn         DOUBLE        NULL DEFAULT 0.0,
	CarryoverOut        DOUBLE        NULL DEFAULT 0.0,
	Recoveries          DOUBLE        NULL DEFAULT 0.0,
	Reimbursements      DOUBLE        NULL DEFAULT 0.0,
	TreasuryAccountCode TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountName TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode   TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName   TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	CompassLevelsPrimaryKey
)
	PRIMARY KEY
(
	CompassLevelsId
)
	);
