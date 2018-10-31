-- Author: nic547
create type traction_type as enum ('steam_coal', 'steam_oil', 'diesel_mechanical', 'diesel_electric', 'diesel_hydraulic', 'gas_turbine', 'electric', 'hybrid', 'other');
create type tk_species as enum ('wagon', 'locomotive', 'multipleunit');
CREATE TYPE epoch AS ENUM ('i', 'ii', 'iii', 'iv', 'v', 'vi');
CREATE TYPE condition AS ENUM ( 'perfect', 'very_good', 'good', 'medium', 'bad', 'very_bad', 'trash');
CREATE TYPE light_tech AS ENUM ('none', 'light_bulb', 'led_unspecified', 'led_yellow', 'led_white', 'led_cold_white', 'led_warm_white');
CREATE TYPE frontlight AS ENUM ('none', 'single', 'double', 'a_light');
CREATE TYPE endlight AS ENUM ('none', 'single_white', 'single_red', 'double_red');
CREATE TYPE locoendlight AS ENUM ('none', 'single_white');

----------------------------
--Lookup Tables
----------------------------
CREATE TABLE manufacturer (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE proto_manufacturer (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE proto_rw_company (-- Railway companies, for the user and owner of the stock
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE proto_coupler (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT NOT NULL UNIQUE
);

CREATE TABLE coupler (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT NOT NULL UNIQUE
);

----------------------------
-- Tables related to the actual real things
----------------------------

CREATE TABLE proto_class (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT NOT NULL UNIQUE,
    species						tk_species,
	proto_height				NUMERIC(4, 3), -- x.xxx m
	proto_width					NUMERIC(4, 3),
	proto_lenght_over_buffers	NUMERIC(6, 3), --x.xx m
	proto_coupler				INTEGER REFERENCES proto_coupler(id),
	proto_manufacturer			INTEGER REFERENCES proto_manufacturer,
	proto_weight				INTEGER,
	proto_speed					SMALLINT
);

CREATE TABLE proto_class_powered (
	id							INTEGER PRIMARY KEY REFERENCES proto_class(id),
	tractive_force_start		SMALLINT,
	power_cont					INTEGER,
	power_short					INTEGER,
	traction_type				TRACTION_TYPE
);

CREATE TABLE proto_class_loadable (
	id							INTEGER PRIMARY KEY REFERENCES proto_class(id),
	is_coach					BOOLEAN,
	capactiy					SMALLINT
);

CREATE TABLE model_item (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT,
	image						BYTEA,
    image_preview               BYTEA,
    image_updated               TIMESTAMP,
	manufacturer				INTEGER REFERENCES manufacturer(id),
	item_code					TEXT,	
    proto_class                 INTEGER REFERENCES proto_class(id),
	proto_serial_number			TEXT,
	proto_owner					INTEGER REFERENCES proto_rw_company(id),
	proto_user					INTEGER REFERENCES proto_rw_company(id),
    epoch						epoch
);

CREATE TABLE item (
	id							INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	name						TEXT, -- Only for special names, otherwise use the name from the model_item
	model_item					INTEGER REFERENCES model_item(id),
		image					BYTEA,
    image_preview               BYTEA,
    image_updated               TIMESTAMP,
	price						MONEY,
	date_purchased				DATE,
	coupler						INTEGER REFERENCES coupler(id),
	light						light_tech,
	int_light					BOOLEAN,
	end_light					endlight,
	condition					condition,
	div_notes					TEXT,
	date_created				TIMESTAMP,
	date_last_changed			TIMESTAMP
);

CREATE TABLE subitem ( -- Any item that belongs to another item, ex. Decoder
	id		INTEGER PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	item	INTEGER REFERENCES item(id),
	name	TEXT,
	price	MONEY

);

CREATE TABLE wagon (
	item						INTEGER PRIMARY KEY REFERENCES item(id),
	is_coach					BOOLEAN,
	capacity					INTEGER, -- m³ or seats
	maxWeight					INTEGER -- kg
);


CREATE TABLE locomotive (
	item						INTEGER PRIMARY KEY REFERENCES item(id),
	dcc_address					INTEGER,
	f_light						frontlight,
	le_light					locoendlight
);

CREATE TABLE multiple_unit (
	item						INTEGER PRIMARY KEY REFERENCES item(id),
	wagon_amount				INTEGER,
	dcc_address					INTEGER,
	capacity					INTEGER,
	f_light						frontlight,
    le_light					locoendlight
);