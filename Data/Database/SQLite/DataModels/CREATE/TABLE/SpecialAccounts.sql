CREATE TABLE "SpecialAccounts" 
(
	"SpecialAccountsId"	INTEGER NOT NULL UNIQUE,
	"BFY"	TEXT,
	"RpioCode"	TEXT,
	"FundCode"	TEXT,
	"SpecialAccountFund"	TEXT,
	"SpecialAccountNumber"	TEXT,
	"SpecialAccountName"	TEXT,
	"AccountStatus"	TEXT,
	"NplStatusCode"	TEXT,
	"NplStatusName"	TEXT,
	"SiteId"	TEXT,
	"CerclisId"	TEXT,
	"SiteCode"	TEXT,
	"SiteName"	TEXT,
	"OperableUnit"	TEXT,
	"PipelineCode"	TEXT,
	"PipelineDescription"	TEXT,
	"AccountCode"	TEXT,
	"BocCode"	TEXT,
	"BocName"	TEXT,
	"TransactionType"	TEXT,
	"TransactionTypeName"	TEXT,
	"FocCode"	TEXT,
	"FocName"	TEXT,
	"TransactionDate"	TEXT,
	"AvailableBalance"	REAL,
	"OpenCommitments"	REAL,
	"Obligations"	REAL,
	"ULO"	REAL,
	"Disbursements"	REAL,
	"UnpaidBalances"	REAL,
	"Collections"	REAL,
	"CumulativeReceipts"	REAL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);