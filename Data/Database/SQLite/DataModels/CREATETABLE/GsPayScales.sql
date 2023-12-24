CREATE TABLE IF NOT EXISTS GsPayScales
(
	GsPayScalesId INTEGER NOT NULL UNIQUE,
	LOCNAME TEXT(150) NULL DEFAULT NS,
	GRADE DOUBLE NULL DEFAULT 0.0,
	ANNUAL1 DOUBLE NULL DEFAULT 0.0,
	HOURLY1 TEXT(150) NULL DEFAULT NS,
	OVERTIME1 TEXT(150) NULL DEFAULT NS,
	ANNUAL2 DOUBLE NULL DEFAULT 0.0,
	HOURLY2 TEXT(150) NULL DEFAULT NS,
	OVERTIME2 TEXT(150) NULL DEFAULT NS,
	ANNUAL3 DOUBLE NULL DEFAULT 0.0,
	HOURLY3 TEXT(150) NULL DEFAULT NS,
	OVERTIME3 TEXT(150) NULL DEFAULT NS,
	ANNUAL4 DOUBLE NULL DEFAULT 0.0,
	HOURLY4 TEXT(150) NULL DEFAULT NS,
	OVERTIME4 TEXT(150) NULL DEFAULT NS,
	ANNUAL5 DOUBLE NULL DEFAULT 0.0,
	HOURLY5 TEXT(150) NULL DEFAULT NS,
	OVERTIME5 TEXT(150) NULL DEFAULT NS,
	ANNUAL6 DOUBLE NULL DEFAULT 0.0,
	HOURLY6 TEXT(150) NULL DEFAULT NS,
	OVERTIME6 TEXT(150) NULL DEFAULT NS,
	ANNUAL7 DOUBLE NULL DEFAULT 0.0,
	HOURLY7 TEXT(150) NULL DEFAULT NS,
	OVERTIME7 TEXT(150) NULL DEFAULT NS,
	ANNUAL8 DOUBLE NULL DEFAULT 0.0,
	HOURLY8 TEXT(150) NULL DEFAULT NS,
	OVERTIME8 TEXT(150) NULL DEFAULT NS,
	ANNUAL9 DOUBLE NULL DEFAULT 0.0,
	HOURLY9 TEXT(150) NULL DEFAULT NS,
	OVERTIME9 TEXT(150) NULL DEFAULT NS,
	ANNUAL10 DOUBLE NULL DEFAULT 0.0,
	HOURLY10 TEXT(150) NULL DEFAULT NS,
	OVERTIME10 TEXT(150) NULL DEFAULT NS,
	CONSTRAINT GsPayScalesPrimaryKey 
		PRIMARY KEY(GsPayScalesId)
);
