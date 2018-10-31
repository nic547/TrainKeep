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
7	HAG Classic
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
4	Rilns	wagon	\N	\N	\N	1	\N	\N	100
3	TRAXX AC3 F140	locomotive	\N	\N	\N	1	4	\N	140
6	Habbiillns 	wagon	\N	\N	\N	1	\N	\N	100
5	Hbbillns	wagon	\N	\N	\N	1	\N	\N	100
7	Shimmns	wagon	\N	\N	\N	1	\N	\N	100
9	Habbiillnss	wagon	\N	\N	\N	1	\N	\N	120
8	Fas	wagon	\N	\N	\N	1	\N	\N	100
10	Vectron MS	locomotive	\N	\N	\N	1	1	\N	200
11	TRAXX AC2 F140	locomotive	\N	\N	\N	1	4	\N	140
12	TRAXX AC1 F140	locomotive	\N	\N	\N	1	4	\N	140
13	KISS	multipleunit	\N	\N	150.000	2	2	\N	160
14	Bm 4/4	locomotive	\N	\N	\N	1	3	\N	\N
15	Eem 923	locomotive	\N	\N	\N	\N	2	\N	100
16	Re 620	locomotive	\N	\N	\N	\N	3	\N	140
17	Re 420	locomotive	\N	\N	\N	\N	3	\N	140
18	Ae 6/6	locomotive	\N	\N	\N	\N	\N	\N	125
19	Re 465	locomotive	\N	\N	\N	\N	\N	\N	200
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
5	Rem 487 001	\N	\N	\N	1	36635	3	\N	10	10	vi
6	BLS BR 187	\N	\N	\N	1	36631	3	\N	7	6	vi
20	RABe 511	\N	\N	\N	\N	\N	\N	511 025-5	3	3	vi
21	Eem 923 Tourbillon	\N	\N	\N	7	20021-32	15	97 85 1923 021-0	4	4	vi
2	SBB Re 474	\N	\N	\N	1	39893	2	474 014-8	4	8	vi
1	Re 460 Helvetia	\N	\N	\N	1	39460	1	91 85 4460 084-7	3	3	vi
22	Bm 4/4 18407	\N	\N	\N	5	17568 S	14	18407	\N	\N	vi
23	Re 482 'Alpäzähmer'	\N	\N	\N	1	36627	12	91 85 4482 022-1	4	4	\N
24	Re 482 036-1	\N	\N	\N	1	37446	11	91 85 4482 036-1	4	4	\N
25	Re 620 058-8	\N	\N	\N	1	37321	16	620 058-8	4	4	\N
26	Re 6/6 Balerna	\N	\N	\N	1	\N	16	11672	\N	\N	\N
27	Re 4/4	\N	\N	\N	1	37348	17	11229	\N	\N	\N
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
22	Butler Tourbillon	21	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
23	\N	22	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
24	Alpäzähmer	23	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
25	Re 482 Cargo 1	24	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
26	Re 482 Cargo 2	24	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
27	Re 620 Cargo	25	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
28	\N	26	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
29	\N	27	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
\.


--
-- Data for Name: locomotive; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.locomotive (item, dcc_address, f_light, le_light) FROM stdin;
\.


--
-- Data for Name: multiple_unit; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.multiple_unit (item, wagon_amount, dcc_address, capacity, f_light, le_light) FROM stdin;
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
-- Data for Name: wagon; Type: TABLE DATA; Schema: public; Owner: tk_user
--

COPY public.wagon (item, is_coach, capacity, maxweight) FROM stdin;
\.


--
-- Name: coupler_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.coupler_id_seq', 3, true);


--
-- Name: item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.item_id_seq', 29, true);


--
-- Name: manufacturer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.manufacturer_id_seq', 7, true);


--
-- Name: model_item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.model_item_id_seq', 27, true);


--
-- Name: proto_class_id_seq; Type: SEQUENCE SET; Schema: public; Owner: tk_user
--

SELECT pg_catalog.setval('public.proto_class_id_seq', 19, true);


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

