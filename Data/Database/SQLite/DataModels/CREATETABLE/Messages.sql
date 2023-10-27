CREATE TABLE IF NOT EXISTS Messages
(
	MessageId
	INTEGER
	NOT
	NULL
	UNIQUE,
	Message
	TEXT
(
	255
) NULL DEFAULT NS,
	Type TEXT
(
	150
) NULL DEFAULT NS,
	Form TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT MessagesPrimaryKey
	PRIMARY KEY
(
	MessageId
)
	);
