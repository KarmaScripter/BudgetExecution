CREATE TABLE MonthlyActuals
(
	MonthlyActualsId	INT NOT NULL IDENTITY(1,1),
	BFY	NVARCHAR(80) NULL,
	EFY	NVARCHAR(80) NULL,
	FundCode	NVARCHAR(80) NULL,
	FundName	NVARCHAR(80) NULL,
	RpioCode	NVARCHAR(80) NULL,
	RpioName	NVARCHAR(80) NULL,
	AhCode	NVARCHAR(80) NULL,
	AhName	NVARCHAR(80) NULL,
	AppropriationCode	NVARCHAR(80) NULL,
	AppropriationName	NVARCHAR(80) NULL,
	SubAppropriationCode	NVARCHAR(80) NULL,
	SubAppropriationName	NVARCHAR(80) NULL,
	OrgCode	NVARCHAR(80) NULL,
	OrgName	NVARCHAR(80) NULL,
	AccountCode	NVARCHAR(80) NULL,
	ProgramProjectCode	NVARCHAR(80) NULL,
	ProgramProjectName	NVARCHAR(80) NULL,
	BocCode	NVARCHAR(80) NULL,
	BocName	NVARCHAR(80) NULL,
	NetOutlays	FLOAT NULL,
	GrossOutlays	FLOAT NULL,
	Obligations	FLOAT NULL,
	TreasuryAccountCode	NVARCHAR(80) NULL,
	TreasuryAccountName NVARCHAR(MAX) NULL,
	BudgetAccountCode	NVARCHAR(80) NULL,
	BudgetAccountName NVARCHAR(MAX) NULL
);