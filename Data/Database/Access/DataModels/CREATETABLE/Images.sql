CREATE TABLE Images
(
	ImagesId      AUTOINCREMENT NOT NULL UNIQUE,
	FileName      TEXT( 150 )   NULL DEFAULT NS,
	FilePath      TEXT( 150 )   NULL DEFAULT NS,
	FileExtension TEXT( 150 )   NULL DEFAULT NS,
	ImageFile     image         NULL,
	Attachments   TEXT( MAX )   NULL DEFAULT NS, CONSTRAINT
(
	ImagesPrimaryKey
)
	PRIMARY KEY
(
	ImagesId
)
	);
