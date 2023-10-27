CREATE TABLE IF NOT EXISTS SchemaTypes
(
	SchemaTypesId
	INTEGER
	NOT
	NULL
	UNIQUE,
	TypeName
	TEXT
(
	150
) NULL DEFAULT NS,
	Database TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT SchemaTypesPrimaryKey
	PRIMARY KEY
(
	SchemaTypesId
)
	);
