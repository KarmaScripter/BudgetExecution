CREATE TABLE IF NOT EXISTS Transfers
(
	TransfersId
	INTEGER
	NOT
	NULL
	UNIQUE,
	BudgetLevel
	TEXT
(
	150
) NULL DEFAULT NS,
	DocPrefix TEXT
(
	150
) NULL DEFAULT NS,
	DocType TEXT
(
	150
) NULL DEFAULT NS,
	BFY TEXT
(
	150
) NULL DEFAULT NS,
	EFY TEXT
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
	FundCode TEXT
(
	150
) NULL DEFAULT NS,
	FundName TEXT
(
	150
) NULL DEFAULT NS,
	ReprogrammingNumber TEXT
(
	150
) NULL DEFAULT NS,
	ControlNumber TEXT
(
	150
) NULL DEFAULT NS,
	ProcessedDate DATETIME NULL,
	Quarter TEXT
(
	150
) NULL DEFAULT NS,
	Line TEXT
(
	150
) NULL DEFAULT NS,
	Subline TEXT
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
	RcCode TEXT
(
	150
) NULL DEFAULT NS,
	RcName TEXT
(
	150
) NULL DEFAULT NS,
	AccountCode TEXT
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
	ProgramProjectName TEXT
(
	150
) NULL DEFAULT NS,
	ProgramProjectCode TEXT
(
	150
) NULL DEFAULT NS,
	FromTo TEXT
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
	NpmCode TEXT
(
	150
) NULL DEFAULT NS,
	Amount DOUBLE NULL DEFAULT 0.0,
	Purpose TEXT
(
	MAX
) NULL DEFAULT NS,
	ResourceType TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT TransfersPrimaryKey
	PRIMARY KEY
(
	TransfersId
)
	);
