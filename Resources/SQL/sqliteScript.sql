CREATE TABLE manufacturer (
	id							INTEGER PRIMARY KEY AUTOINCREMENT,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE proto_manufacturer (
	id							INTEGER PRIMARY KEY AUTOINCREMENT,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE proto_rw_company (
	id							INTEGER PRIMARY KEY AUTOINCREMENT,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE proto_class (
	id							INTEGER PRIMARY KEY AUTOINCREMENT,
	name						TEXT NOT NULL UNIQUE,
	species						INTEGER,
	proto_manufacturer			INTEGER REFERENCES proto_manufacturer(id),
	proto_weight				INTEGER,
	proto_speed					INTEGER,
	engine_tractive_effort		INTEGER,
	egine_power					INTEGER
);

CREATE TABLE model_item (
	id							INTEGER PRIMARY KEY AUTOINCREMENT,
	name						TEXT,
	image						BLOB,
	image_preview				BLOB,
	manufacturer				INTEGER REFERENCES manufacturer(id),
	item_code					TEXT,	
	proto_class					INTEGER REFERENCES proto_class(id),
	proto_serial_number			TEXT,
	proto_owner					INTEGER REFERENCES proto_rw_company(id),
	proto_user					INTEGER REFERENCES proto_rw_company(id),
	epoch						INTEGER
);

CREATE TABLE item (
	id							INTEGER PRIMARY KEY AUTOINCREMENT,
	name						TEXT,
	model_item					INTEGER REFERENCES model_item(id),
	image						BLOB,
	image_preview				BLOB,
	price						NUMERIC,
	date_purchased				TEXT,
	notes					TEXT,
	dcc							INTEGER
);