CREATE TABLE IF NOT EXISTS Outlays
(
	CompassOutlaysId
	INTEGER
	NOT
	NULL
	UNIQUE,
	BFY
	TEXT
(
	150
) NULL DEFAULT NS,
	EFY TEXT
(
	150
) NULL DEFAULT NS,
	FundCode TEXT
(
	150
) NULL DEFAULT NS,
	FundName TEXT
(
	150
) NULL DEFAULT NS,
	AppropriationCode TEXT
(
	150
) NULL DEFAULT NS,
	AppropriationName TEXT
(
	150
) NULL DEFAULT NS,
	TreasurySymbol TEXT
(
	150
) NULL DEFAULT NS,
	TreasuryAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	TreasuryAccountName TEXT
(
	150
) NULL DEFAULT NS,
	BudgetAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	BudgetAccountName TEXT
(
	150
) NULL DEFAULT NS,
	ProgramAreaCode TEXT
(
	150
) NULL DEFAULT NS,
	ProgramAreaName TEXT
(
	150
) NULL DEFAULT NS,
	ProgramProjectCode TEXT
(
	150
) NULL DEFAULT NS,
	ProgramProjectName TEXT
(
	150
) NULL DEFAULT NS,
	BocCode TEXT
(
	150
) NULL DEFAULT NS,
	BocName TEXT
(
	150
) NULL DEFAULT NS,
	ProcessedDate TEXT
(
	150
) NULL DEFAULT NS,
	LastActivityDate TEXT
(
	150
) NULL DEFAULT NS,
	TotalObligations DOUBLE NULL DEFAULT 0.0,
	UnliquidatedObligations DOUBLE NULL DEFAULT 0.0,
	ObligationsPaid DOUBLE NULL DEFAULT 0.0,
	CONSTRAINT CompassOutlaysPrimaryKey
	PRIMARY KEY
(
	CompassOutlaysId
)
	);
