CREATE TABLE CompassErrors
(
	CompassErrorsId AUTOINCREMENT NOT NULL UNIQUE,
	Code            TEXT( 150 )   NULL DEFAULT NS,
	Message         TEXT( 150 )   NULL DEFAULT NS,
	Severity        TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	CompassErrorsPrimaryKey
)
	PRIMARY KEY
(
	CompassErrorsId
)
	);
