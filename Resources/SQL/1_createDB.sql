-- Author: nic547

DROP DATABASE IF EXISTS trainkeep;
DROP USER IF EXISTS tk_user;

CREATE USER tk_user WITH PASSWORD 'tk_user01';
CREATE DATABASE trainkeep WITH OWNER tk_user ENCODING 'UTF8';
\c trainkeep tk_user

\ir 2_createTables.sql