CREATE TABLE IF NOT EXISTS CongressionalProjects
(
	CongressionalEarmarksId
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
	RpioCode TEXT
(
	150
) NULL DEFAULT NS,
	RpioName TEXT
(
	150
) NULL DEFAULT NS,
	AhCode TEXT
(
	150
) NULL DEFAULT NS,
	AhName TEXT
(
	150
) NULL DEFAULT NS,
	NpmCode TEXT
(
	150
) NULL DEFAULT NS,
	NpmName TEXT
(
	150
) NULL DEFAULT NS,
	AccountCode TEXT
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
	ProgramProjectCode TEXT
(
	150
) NULL DEFAULT NS,
	ProgramProjectName TEXT
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
	StateCode TEXT
(
	150
) NULL DEFAULT NS,
	StateName TEXT
(
	150
) NULL DEFAULT NS,
	Project TEXT
(
	150
) NULL DEFAULT NS,
	Amount DOUBLE NULL DEFAULT 0.0,
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
	CONSTRAINT CongressionalProjectsPrimaryKey)
	PRIMARY KEY
(
	CongressionalEarmarksId
)
	);
