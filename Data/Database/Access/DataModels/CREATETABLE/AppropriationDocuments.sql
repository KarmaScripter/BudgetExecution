CREATE TABLE AppropriationDocuments
(
	AppropriationDocumentsId      AUTOINCREMENT NOT NULL UNIQUE,
	FiscalYear                    TEXT( 150 )   NULL DEFAULT NS,
	BFY                           TEXT( 150 )   NULL DEFAULT NS,
	EFY                           TEXT( 150 )   NULL DEFAULT NS,
	FundCode                      TEXT( 150 )   NULL DEFAULT NS,
	AppropriationFund             TEXT( 150 )   NULL DEFAULT NS,
	DocumentType                  TEXT( 150 )   NULL DEFAULT NS,
	DocumentNumber                TEXT( 150 )   NULL DEFAULT NS,
	DocumentDate                  DATETIME      NULL,
	BudgetLevel                   TEXT( 150 )   NULL DEFAULT NS,
	BudgetingControls             TEXT( 150 )   NULL DEFAULT NS,
	PostingControls               TEXT( 150 )   NULL DEFAULT NS,
	PreCommitmentControls         TEXT( 150 )   NULL DEFAULT NS,
	CommitmentControls            TEXT( 150 )   NULL DEFAULT NS,
	ObligationControls            TEXT( 150 )   NULL DEFAULT NS,
	AccrualControls               TEXT( 150 )   NULL DEFAULT NS,
	ExpenditureControls           TEXT( 255 )   NULL DEFAULT NS,
	ExpenseControls               TEXT( 150 )   NULL DEFAULT NS,
	ReimbursementControls         TEXT( 150 )   NULL DEFAULT NS,
	ReimbursableAgreementControls TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode           TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountName           TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode             TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName             TEXT( 150 )   NULL DEFAULT NS,
	Budgeted                      DOUBLE        NULL DEFAULT 0.0,
	Posted                        DOUBLE        NULL DEFAULT 0.0,
	CarryoverOut                  DOUBLE        NULL DEFAULT 0.0,
	CarryoverIn                   DOUBLE        NULL DEFAULT 0.0,
	Reimbursements                DOUBLE        NULL DEFAULT 0.0,
	Recoveries                    DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	AppropriationDocumentsPrimaryKey
)
	PRIMARY KEY
(
	AppropriationDocumentsId
)
	);
