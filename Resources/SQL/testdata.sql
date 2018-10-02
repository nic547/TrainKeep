--
-- PostgreSQL database dump
--

-- Dumped from database version 10.3
-- Dumped by pg_dump version 10.3

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

COPY public.coupler (id, name) FROM stdin;
1	Märklin Kurzkupplung
2	Roco Univarsal
3	ESU
\.


--
-- Data for Name: manufacturer; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.manufacturer (id, name) FROM stdin;
1	Märklin
2	Roco
3	Piko
4	Liliput
5	LS Models
6	Lux
\.


--
-- Data for Name: proto_coupler; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.proto_coupler (id, name) FROM stdin;
1	UIC
2	Schwab
3	Scharfenberg
4	GF-Sécheron
\.


--
-- Data for Name: proto_manufacturer; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.proto_manufacturer (id, name) FROM stdin;
1	Siemens
2	Stadler Rail
3	SLM
4	Bombardier Transporation
\.


--
-- Data for Name: proto_class; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.proto_class (id, name, species, proto_height, proto_width, proto_lenght_over_buffers, proto_coupler, proto_manufacturer, proto_weight, proto_speed) FROM stdin;
1	Re 460	locomotive	\N	\N	\N	1	3	\N	200
2	ES64F4	locomotive	\N	\N	\N	1	1	\N	140
4	Rilns	waggon	\N	\N	\N	1	\N	\N	100
3	TRAXX AC3 F140	locomotive	\N	\N	\N	1	4	\N	140
6	Habbiillns 	waggon	\N	\N	\N	1	\N	\N	100
5	Hbbillns	waggon	\N	\N	\N	1	\N	\N	100
7	Shimmns	waggon	\N	\N	\N	1	\N	\N	100
8	Fas	waggon	\N	\N	\N	\N	\N	\N	100
9	Habbiillnss	waggon	\N	\N	\N	\N	\N	\N	120
\.


--
-- Data for Name: proto_rw_company; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.proto_rw_company (id, name) FROM stdin;
1	SBB
2	BLS
3	SBB Personenverkehr
4	SBB Cargo
5	SBB Infra
6	BLS Cargo
7	Railpool
8	SBB Cargo International
9	MRCE
10	Swiss Rail Traffic
11	Railcare
12	DB
13	DB Cargo
14	AAE
15	Wascosa
16	Die Schweizerische Post
\.


--
-- Data for Name: model_item; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.model_item (id, name, image, image_preview, image_updated, manufacturer, item_code, proto_class, proto_serial_number, proto_owner, proto_user, epoch) FROM stdin;
1	Re 460 Helvetia	\N	\N	\N	1	39460	1	\N	3	3	vi
3	BR 189	\N	\N	\N	1	\N	2	\N	13	13	vi
4	SBBCI BR 189	\N	\N	\N	1	\N	2	\N	9	8	vi
9	Schiebewandwagen	\N	\N	\N	1	48025	5	\N	4	4	v
10	Schiebewandwagen	\N	\N	\N	1	48055	6	\N	4	4	v
7	Schiebeplanenwagen	\N	\N	\N	1	47060	4	\N	14	4	\N
8	Schiebeplanenwagen	\N	\N	\N	1	47061	4	\N	4	4	\N
11	Teleskophaubenwagen	\N	\N	\N	1	46870-01	7	\N	4	4	vi
12	Teleskophaubenwagen	\N	\N	\N	1	46870-02	7	\N	4	4	vi
13	Teleskophaubenwagen	\N	\N	\N	1	46870-03	7	\N	4	4	vi
14	Hochbordwagen	\N	\N	\N	1	46912-01	8	\N	4	4	\N
15	Hochbordwagen	\N	\N	\N	1	46912-02	8	\N	4	4	\N
16	Hochbordwagen	\N	\N	\N	1	46912-03	8	\N	4	4	\N
17	Hochbordwagen	\N	\N	\N	1	46912-04	8	\N	4	4	\N
18	Hochbordwagen	\N	\N	\N	1	46912-05	8	\N	4	4	\N
19	Hochbordwagen	\N	\N	\N	1	46912-06	8	\N	4	4	\N
2	SBB Re 474	\N	\N	\N	1	39893	2	\N	4	8	vi
5	Rem 487 001	\N	\N	\N	1	36635	3	\N	10	10	vi
6	BLS BR 187	\N	\N	\N	1	36631	3	\N	7	6	vi
\.


--
-- Data for Name: item; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.item (id, name, model_item, image, image_preview, image_updated, price, date_purchased, coupler, light, int_light, end_light, condition, div_notes, date_created, date_last_changed) FROM stdin;
1	\N	1	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
2	\N	2	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
3	\N	3	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
4	\N	4	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
5	Biene Maja	5	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
6	\N	6	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	\N	7	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
9	\N	7	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
10	\N	7	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
11	\N	7	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
12	\N	7	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
13	\N	8	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
14	\N	8	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
15	\N	9	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
16	\N	9	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
17	\N	9	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
18	\N	9	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
19	\N	9	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
20	\N	10	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
21	\N	10	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
\.


--
-- Data for Name: locomotive; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.locomotive (item, dcc_address, f_light, le_light) FROM stdin;
\.


--
-- Data for Name: multiple_unit; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.multiple_unit (item, waggon_amount, dcc_address, capacity, f_light, le_light) FROM stdin;
\.


--
-- Data for Name: proto_class_loadable; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.proto_class_loadable (id, is_coach, capactiy) FROM stdin;
\.


--
-- Data for Name: proto_class_powered; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.proto_class_powered (id, tractive_force_start, power_cont, power_short, traction_type) FROM stdin;
\.


--
-- Data for Name: subitem; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.subitem (id, item, name, price) FROM stdin;
\.


--
-- Data for Name: waggon; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.waggon (item, is_coach, capacity, maxweight) FROM stdin;
\.


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

SELECT pg_catalog.setval('public.model_item_id_seq', 19, true);


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

