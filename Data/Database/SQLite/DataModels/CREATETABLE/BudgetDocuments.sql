CREATE TABLE IF NOT EXISTS BudgetDocuments
(
	BudgetDocumentsId
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
	BudgetLevel TEXT
(
	150
) NULL DEFAULT NS,
	DocumentDate DATETIME NULL,
	DocumentType TEXT
(
	150
) NULL DEFAULT NS,
	DocumentNumber TEXT
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
	Budgeted DOUBLE NULL DEFAULT 0.0,
	Posted DOUBLE NULL DEFAULT 0.0,
	CarryoverOut DOUBLE NULL DEFAULT 0.0,
	CarryoverIn DOUBLE NULL DEFAULT 0.0,
	Recoveries DOUBLE NULL DEFAULT 0.0,
	Reimbursements DOUBLE NULL DEFAULT 0.0,
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
	CONSTRAINT BudgetDocumentsPrimaryKey) PRIMARY KEY
(
	BudgetDocumentsId
)
	);
