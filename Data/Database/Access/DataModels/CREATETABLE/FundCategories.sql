CREATE TABLE FundCategories
(
	FundCategoriesId AUTOINCREMENT NOT NULL UNIQUE,
	Code             TEXT( 150 )   NULL DEFAULT NS,
	Name             TEXT( 150 )   NULL DEFAULT NS,
	ShortName        TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	FundCategoriesPrimaryKey
)
	PRIMARY KEY
(
	FundCategoriesId
)
	);
