CREATE TABLE IF NOT EXISTS MonthlyActuals
(
	MonthlyActualsId
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
	SubAppropriationCode TEXT
(
	150
) NULL DEFAULT NS,
	SubAppropriationName TEXT
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
	OrgCode TEXT
(
	150
) NULL DEFAULT NS,
	OrgName TEXT
(
	150
) NULL DEFAULT NS,
	RpioActivityCode TEXT
(
	150
) NULL DEFAULT NS,
	AccountCode TEXT
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
	NetOutlays DOUBLE NULL DEFAULT 0.0,
	GrossOutlays DOUBLE NULL DEFAULT 0.0,
	Obligations DOUBLE NULL DEFAULT 0.0,
	TreasuryAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	TreasuryAccountName TEXT
(
	MAX
) NULL DEFAULT NS,
	BudgetAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	BudgetAccountName TEXT
(
	MAX
) NULL DEFAULT NS,
	CONSTRAINT MonthlyActualsPrimaryKey
	PRIMARY KEY
(
	MonthlyActualsId
)
	);
