--
-- PostgreSQL database dump
--

-- Dumped from database version 10.5
-- Dumped by pg_dump version 10.5

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: coupler; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.coupler (id, name) VALUES (1, 'Märklin Kurzkupplung');
INSERT INTO public.coupler (id, name) VALUES (2, 'Roco Univarsal');
INSERT INTO public.coupler (id, name) VALUES (3, 'ESU');


--
-- Data for Name: manufacturer; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.manufacturer (id, name) VALUES (1, 'Märklin');
INSERT INTO public.manufacturer (id, name) VALUES (2, 'Roco');
INSERT INTO public.manufacturer (id, name) VALUES (3, 'Piko');
INSERT INTO public.manufacturer (id, name) VALUES (4, 'Liliput');
INSERT INTO public.manufacturer (id, name) VALUES (5, 'LS Models');
INSERT INTO public.manufacturer (id, name) VALUES (6, 'Lux');


--
-- Data for Name: proto_coupler; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.proto_coupler (id, name) VALUES (1, 'UIC');
INSERT INTO public.proto_coupler (id, name) VALUES (2, 'Schwab');
INSERT INTO public.proto_coupler (id, name) VALUES (3, 'Scharfenberg');
INSERT INTO public.proto_coupler (id, name) VALUES (4, 'GF-Sécheron');


--
-- Data for Name: proto_manufacturer; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.proto_manufacturer (id, name) VALUES (1, 'Siemens');
INSERT INTO public.proto_manufacturer (id, name) VALUES (2, 'Stadler Rail');
INSERT INTO public.proto_manufacturer (id, name) VALUES (3, 'SLM');
INSERT INTO public.proto_manufacturer (id, name) VALUES (4, 'Bombardier Transporation');


--
-- Data for Name: proto_class; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (1, 'Re 460', 'locomotive', NULL, NULL, NULL, 1, 3, NULL, 200);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (2, 'ES64F4', 'locomotive', NULL, NULL, NULL, 1, 1, NULL, 140);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (4, 'Rilns', 'waggon', NULL, NULL, NULL, 1, NULL, NULL, 100);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (3, 'TRAXX AC3 F140', 'locomotive', NULL, NULL, NULL, 1, 4, NULL, 140);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (6, 'Habbiillns ', 'waggon', NULL, NULL, NULL, 1, NULL, NULL, 100);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (5, 'Hbbillns', 'waggon', NULL, NULL, NULL, 1, NULL, NULL, 100);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (7, 'Shimmns', 'waggon', NULL, NULL, NULL, 1, NULL, NULL, 100);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (8, 'Fas', 'waggon', NULL, NULL, NULL, NULL, NULL, NULL, 100);
INSERT INTO public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) VALUES (9, 'Habbiillnss', 'waggon', NULL, NULL, NULL, NULL, NULL, NULL, 120);


--
-- Data for Name: proto_rw_company; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.proto_rw_company (id, name) VALUES (1, 'SBB');
INSERT INTO public.proto_rw_company (id, name) VALUES (2, 'BLS');
INSERT INTO public.proto_rw_company (id, name) VALUES (3, 'SBB Personenverkehr');
INSERT INTO public.proto_rw_company (id, name) VALUES (4, 'SBB Cargo');
INSERT INTO public.proto_rw_company (id, name) VALUES (5, 'SBB Infra');
INSERT INTO public.proto_rw_company (id, name) VALUES (6, 'BLS Cargo');
INSERT INTO public.proto_rw_company (id, name) VALUES (7, 'Railpool');
INSERT INTO public.proto_rw_company (id, name) VALUES (8, 'SBB Cargo International');
INSERT INTO public.proto_rw_company (id, name) VALUES (9, 'MRCE');
INSERT INTO public.proto_rw_company (id, name) VALUES (10, 'Swiss Rail Traffic');
INSERT INTO public.proto_rw_company (id, name) VALUES (11, 'Railcare');
INSERT INTO public.proto_rw_company (id, name) VALUES (12, 'DB');
INSERT INTO public.proto_rw_company (id, name) VALUES (13, 'DB Cargo');
INSERT INTO public.proto_rw_company (id, name) VALUES (14, 'AAE');
INSERT INTO public.proto_rw_company (id, name) VALUES (15, 'Wascosa');
INSERT INTO public.proto_rw_company (id, name) VALUES (16, 'Die Schweizerische Post');


--
-- Data for Name: model_item; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (1, 'Re 460 Helvetia', NULL, NULL, NULL, 1, '39460', 1, NULL, 3, 3, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (2, 'SBB Re 474', NULL, NULL, NULL, 1, NULL, 2, NULL, 4, 8, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (3, 'BR 189', NULL, NULL, NULL, 1, NULL, 2, NULL, 13, 13, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (4, 'SBBCI BR 189', NULL, NULL, NULL, 1, NULL, 2, NULL, 9, 8, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (6, 'BLS BR 187', NULL, NULL, NULL, 1, NULL, 3, NULL, 7, 6, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (5, 'Rem 487 001', NULL, NULL, NULL, 1, NULL, 3, NULL, 10, 10, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (7, 'Schiebeplanenwagen', NULL, NULL, NULL, 1, '47061', 4, NULL, 14, 4, NULL);
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (8, 'Schiebeplanenwagen', NULL, NULL, NULL, 1, NULL, 4, NULL, 4, 4, NULL);
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (9, 'Schiebewandwagen', NULL, NULL, NULL, 1, '48025', 5, NULL, 4, 4, 'v');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (10, 'Schiebewandwagen', NULL, NULL, NULL, 1, '48055', 6, NULL, 4, 4, 'v');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (11, 'Teleskophaubenwagen', NULL, NULL, NULL, NULL, '46870-01', 7, NULL, 4, 4, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (12, 'Teleskophaubenwagen', NULL, NULL, NULL, NULL, '46870-02', 7, NULL, 4, 4, 'vi');
INSERT INTO public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) VALUES (13, 'Teleskophaubenwagen', NULL, NULL, NULL, NULL, '46870-03', 7, NULL, 4, 4, 'vi');


--
-- Data for Name: item; Type: TABLE DATA; Schema: public; Owner: tk_user
--

INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (1, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (2, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (3, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (4, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (5, 'Biene Maja', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (6, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (8, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (9, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (10, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (11, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (12, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (13, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (14, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (15, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (16, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (17, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (18, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (19, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (20, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) VALUES (21, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);


--
-- Data for Name: locomotive; Type: TABLE DATA; Schema: public; Owner: tk_user
--



--
-- Data for Name: multiple_unit; Type: TABLE DATA; Schema: public; Owner: tk_user
--



--
-- Data for Name: proto_class_loadable; Type: TABLE DATA; Schema: public; Owner: tk_user
--



--
-- Data for Name: proto_class_powered; Type: TABLE DATA; Schema: public; Owner: tk_user
--



--
-- Data for Name: subitem; Type: TABLE DATA; Schema: public; Owner: tk_user
--



--
-- Data for Name: waggon; Type: TABLE DATA; Schema: public; Owner: tk_user
--



--
-- Name: coupler_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.coupler_id_seq', 3, true);


--
-- Name: item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.item_id_seq', 21, true);


--
-- Name: manufacturer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.manufacturer_id_seq', 6, true);


--
-- Name: model_item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.model_item_id_seq', 13, true);


--
-- Name: proto_class_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.proto_class_id_seq', 9, true);


--
-- Name: proto_coupler_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.proto_coupler_id_seq', 4, true);


--
-- Name: proto_manufacturer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.proto_manufacturer_id_seq', 4, true);


--
-- Name: proto_rw_company_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.proto_rw_company_id_seq', 16, true);


--
-- Name: subitem_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.subitem_id_seq', 1, false);


--
-- PostgreSQL database dump complete
--

