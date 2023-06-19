CREATE TABLE IF NOT EXISTS FederalHolidays 
(
	FederalHolidaysId	INTEGER NOT NULL UNIQUE,
	BFY	TEXT(80) NULL DEFAULT NS,
	ColumbusDay	TEXT(80) NULL DEFAULT NS,
	VeteransDay	TEXT(80) NULL DEFAULT NS,
	ThanksgivingDay	TEXT(80) NULL DEFAULT NS,
	ChristmasDay	TEXT(80) NULL DEFAULT NS,
	NewYearsDay	TEXT(80) NULL DEFAULT NS,
	MartinLutherKingDay	TEXT(80) NULL DEFAULT NS,
	WashingtonsDay	TEXT(80) NULL DEFAULT NS,
	MemorialDay	TEXT(80) NULL DEFAULT NS,
	JuneteenthDay	TEXT(80) NULL DEFAULT NS,
	IndependenceDay	TEXT(80) NULL DEFAULT NS,
	LaborDay	TEXT(80) NULL DEFAULT NS,
	PRIMARY KEY(FederalHolidaysId AUTOINCREMENT)
);