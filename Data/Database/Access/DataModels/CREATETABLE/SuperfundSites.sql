CREATE TABLE SuperfundSites
(
	SuperfundSitesId AUTOINCREMENT NOT NULL UNIQUE,
	RpioCode         TEXT( 150 )   NULL DEFAULT NS,
	RpioName         TEXT( 150 )   NULL DEFAULT NS,
	City             TEXT( 150 )   NULL DEFAULT NS,
	State            TEXT( 150 )   NULL DEFAULT NS,
	SSID             TEXT( 150 )   NULL DEFAULT NS,
	SiteProjectName  TEXT( 150 )   NULL DEFAULT NS,
	EpaSiteId        TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	SuperfundSitesPrimaryKey
)
	PRIMARY KEY
(
	SuperfundSitesId
)
	);
