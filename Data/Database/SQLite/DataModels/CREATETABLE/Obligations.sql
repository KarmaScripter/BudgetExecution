CREATE TABLE IF NOT EXISTS Obligations
(
	ObligationsId
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
	TreasuryAccountCode TEXT
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
	RcCode TEXT
(
	150
) NULL DEFAULT NS,
	RcName TEXT
(
	150
) NULL DEFAULT NS,
	DocumentType TEXT
(
	150
) NULL DEFAULT NS,
	DocumentNumber TEXT
(
	150
) NULL DEFAULT NS,
	DocumentControlNumber TEXT
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
	ApportionmentAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	ProcessedDate DATETIME NULL,
	LastActivityDate DATETIME NULL,
	Age DOUBLE NULL DEFAULT 0.0,
	BocCode TEXT
(
	150
) NULL DEFAULT NS,
	BocName TEXT
(
	150
) NULL DEFAULT NS,
	FocCode TEXT
(
	150
) NULL DEFAULT NS,
	FocName TEXT
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
	VendorCode TEXT
(
	150
) NULL DEFAULT NS,
	VendorName TEXT
(
	150
) NULL DEFAULT NS,
	OpenCommitments DOUBLE NULL DEFAULT 0.0,
	Obligations DOUBLE NULL DEFAULT 0.0,
	UnliquidatedObligations DOUBLE NULL DEFAULT 0.0,
	Expenditures DOUBLE NULL DEFAULT 0.0,
	CONSTRAINT ObligationsPrimaryKey
	PRIMARY KEY
(
	ObligationsId
)
	);
