CREATE TABLE Expenditures
(
	ExpendituresId        INT           NOT NULL UNIQUE,
	ObligationsId         INT           NULL,
	BFY                   NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                   NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName              NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode   NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName              NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName                NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgName               NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode    NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName    NVARCHAR(150) NULL DEFAULT ('NS'),
	RcCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	RcName                NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentType          NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentNumber        NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentControlNumber NVARCHAR(150) NULL DEFAULT ('NS'),
	ProcessedDate         DATETIME      NULL,
	LastActivityDate      DATETIME      NULL,
	Age                   FLOAT         NULL DEFAULT (0.0),
	BocCode               NVARCHAR(255) NULL,
	BocName               NVARCHAR(150) NULL DEFAULT ('NS'),
	FocCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	FocName               NVARCHAR(150) NULL DEFAULT ('NS'),
	NpmCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	NpmName               NVARCHAR(150) NULL DEFAULT ('NS'),
	VendorCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	VendorName            NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                FLOAT         NULL DEFAULT (0.0),
	TreasuryAccountName   NVARCHAR(MAX) NULL,
	BudgetAccountCode     NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName     NVARCHAR(MAX) NULL,
	CONSTRAINT ExpendituresPrimaryKey PRIMARY KEY
		(
		  ExpendituresId ASC
			)
);
