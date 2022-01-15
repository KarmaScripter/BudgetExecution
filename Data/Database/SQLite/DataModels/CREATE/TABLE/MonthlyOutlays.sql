CREATE TABLE "MonthlyOutlays" 
(
	"MonthlyOutlaysId"	INTEGER NOT NULL UNIQUE,
	"FiscalYear"	TEXT,
	"LineNumber"	TEXT,
	"LineTitle"	TEXT,
	"TaxationCode"	TEXT,
	"TreasuryAgency"	TEXT,
	"TreasuryAccount"	TEXT,
	"SubAccount"	TEXT,
	"BFY"	TEXT,
	"EFY"	TEXT,
	"OmbAgency"	TEXT,
	"OmbBureau"	TEXT,
	"OmbAccount"	TEXT,
	"AgencySequence"	TEXT,
	"BureauSequence"	TEXT,
	"AccountSequence"	TEXT,
	"AgencyTitle"	TEXT,
	"BureauTitle"	TEXT,
	"OmbAccountTitle"	TEXT,
	"TreasuryAccountTitle"	TEXT,
	"October"	REAL,
	"November"	REAL,
	"December"	REAL,
	"January"	REAL,
	"Feburary"	REAL,
	"March"	REAL,
	"April"	REAL,
	"May"	REAL,
	"June"	REAL,
	"July"	REAL,
	"August"	REAL,
	"September"	REAL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);