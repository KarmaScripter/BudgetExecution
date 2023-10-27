CREATE TABLE SupplementalOutlayEstimates
(
	SupplementalOutlayEstimatesId AUTOINCREMENT NOT NULL UNIQUE,
	BFY                           TEXT( 150 )   NULL DEFAULT NS,
	EFY                           TEXT( 150 )   NULL DEFAULT NS,
	MainAccount                   TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode             TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName             TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode           TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountName           TEXT( 150 )   NULL DEFAULT NS,
	Program                       TEXT( 150 )   NULL DEFAULT NS,
	Authority                     DOUBLE        NULL DEFAULT 0.0,
	FY22                          DOUBLE        NULL DEFAULT 0.0,
	FY23                          DOUBLE        NULL DEFAULT 0.0,
	FY24                          DOUBLE        NULL DEFAULT 0.0,
	FY25                          DOUBLE        NULL DEFAULT 0.0,
	FY26                          DOUBLE        NULL DEFAULT 0.0,
	FY2731                        DOUBLE        NULL DEFAULT 0.0,
	Supplemental                  TEXT( 150 )   NULL DEFAULT NS,
	FundCode                      TEXT( 150 )   NULL DEFAULT NS,
	FundName                      TEXT( 150 )   NULL DEFAULT NS,
	PRIMARY KEY ( SupplementalOutlayEstimatesId AUTOINCREMENT )
);