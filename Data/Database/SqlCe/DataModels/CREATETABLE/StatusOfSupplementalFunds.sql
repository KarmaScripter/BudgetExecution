CREATE TABLE StatusOfSupplementalFunds
(
	StatusOfSupplementalFundingId INT           NOT NULL UNIQUE,
	StatusOfFundsId               INT           NULL,
	BudgetLevel                   NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                      NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                      NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                      NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName                      NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode                        NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName                        NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode                       NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgName                       NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode                   NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode                       NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName                       NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName            NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaName               NVARCHAR(150) NULL DEFAULT ('NS'),
	RcCode                        NVARCHAR(150) NULL DEFAULT ('NS'),
	RcName                        NVARCHAR(150) NULL DEFAULT ('NS'),
	LowerName                     NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                        FLOAT         NULL DEFAULT (0.0),
	Budgeted                      FLOAT         NULL DEFAULT (0.0),
	Posted                        FLOAT         NULL DEFAULT (0.0),
	OpenCommitments               FLOAT         NULL DEFAULT (0.0),
	UnliquidatedObligations       FLOAT         NULL DEFAULT (0.0),
	Expenditures                  FLOAT         NULL DEFAULT (0.0),
	Obligations                   FLOAT         NULL DEFAULT (0.0),
	Used                          FLOAT         NULL DEFAULT (0.0),
	Available                     FLOAT         NULL DEFAULT (0.0),
	Balance                       FLOAT         NULL DEFAULT (0.0),
	NpmCode                       NVARCHAR(150) NULL DEFAULT ('NS'),
	NpmName                       NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName           NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName             NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT StatusOfSupplementalFundsPrimaryKey PRIMARY KEY
		(
		  StatusOfSupplementalFundingId
			)
);
