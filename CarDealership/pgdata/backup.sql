--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Admins; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Admins" (
    "Id" bigint NOT NULL,
    "Login" character varying(100) NOT NULL,
    "FullName" character varying(150) NOT NULL,
    "Role" character varying(50) NOT NULL,
    "Password" character varying(200) NOT NULL,
    "ImageUrl" character varying(1000),
    "DateLastAuth" timestamp without time zone,
    "CountClosedOrders" bigint DEFAULT 0 NOT NULL
);


ALTER TABLE public."Admins" OWNER TO postgres;

--
-- Name: Admins_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Admins" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Admins_Id_seq"
    START WITH 2
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Cars; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Cars" (
    "Id" bigint NOT NULL,
    "Name" character varying(200) NOT NULL,
    "Power" integer NOT NULL,
    "Price" numeric NOT NULL,
    "Exists" boolean NOT NULL,
    "MainUrlImage" text NOT NULL,
    "Description" character varying(2000) NOT NULL,
    "Year" integer NOT NULL
);


ALTER TABLE public."Cars" OWNER TO postgres;

--
-- Name: Cars_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Cars" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Cars_Id_seq"
    START WITH 20
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Orders" (
    "Id" bigint NOT NULL,
    "PhoneNumber" character varying(25) NOT NULL,
    "Message" character varying(1000),
    "Name" character varying(100) NOT NULL,
    "Checked" boolean NOT NULL,
    "DateCreated" timestamp without time zone NOT NULL,
    "Referrer" character varying(200)
);


ALTER TABLE public."Orders" OWNER TO postgres;

--
-- Name: Orders_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Orders" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Orders_Id_seq"
    START WITH 2
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: UrlImagesOfCars; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UrlImagesOfCars" (
    "Id" bigint NOT NULL,
    "Url" text NOT NULL,
    "IdCar" bigint NOT NULL
);


ALTER TABLE public."UrlImagesOfCars" OWNER TO postgres;

--
-- Name: UrlImagesOfCars_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."UrlImagesOfCars" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."UrlImagesOfCars_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: Admins; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Admins" ("Id", "Login", "FullName", "Role", "Password", "ImageUrl", "DateLastAuth", "CountClosedOrders") FROM stdin;
9	avenee27	Петров Иван Петрович3	manager	$2a$11$nhEjqsv6zy04w4wGqo364OA0RBEEAe/.oQa0zH63Sk8FsVYAysRtu	https://storage.yandexcloud.net/cloudstorage27/ImagesOfAdminsProfiles/d0b223fd-80cd-456d-9f5f-470fbbae9b47.jpg	\N	0
8	avenee27a	Иванов Пётр Иванович	admin	$2a$11$0Prw8GyIw/hDaDBDH/VLjuG3L4HBCyjP3tZ4pIdBQ7cfOLtkSrtW.	https://storage.yandexcloud.net/cloudstorage27/ImagesOfAdminsProfiles/b781a230-bd01-46b4-9754-7dd78eb264f2.jpg	2024-05-13 20:27:55.655252	3
\.


--
-- Data for Name: Cars; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Cars" ("Id", "Name", "Power", "Price", "Exists", "MainUrlImage", "Description", "Year") FROM stdin;
43	Mercedes SLK 250	184	2500000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/3d7b544c-9062-47c0-ad8b-aaa0cc3cd0c8.jpg	Mercedes-Benz SLK 250 - это легкий спортивный родстер с мягким верхом, выпускаемый немецким автопроизводителем Mercedes-Benz. Он оснащен бензиновым двигателем мощностью 250 л.с. и имеет задний привод.\r\n\r\nMercedes-Benz SLK 250 имеет динамичный и элегантный дизайн, а также комфортабельный и роскошный салон, оснащенный современной электроникой и высококачественными материалами. Автомобиль имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как система помощи при парковке, адаптивная подвеска и многое другое.	2012
44	BMW 520D	190	9000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/75755045-3d69-4e96-a9bd-46bcf15fa4f0.jpg	BMW 520d - это автомобиль бизнес-класса, выпускаемый немецкой компанией BMW. Он оснащен дизельным двигателем мощностью 190 л.с. и имеет задний или полный привод. Автомобиль имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как адаптивная подвеска, адаптивный круиз-контроль, система помощи при парковке и многое другое. BMW 520d имеет комфортабельный и роскошный салон, оснащенный высококачественными материалами и современной электроникой. Автомобиль доступен в кузове седан и универсал. BMW 520d - это идеальный выбор для тех, кто ценятся комфорт, динамику и стиль. Автомобиль имеет современный и элегантный дизайн, а также высокую производительность двигателя, что делает его одним из лучших автомобилей в своем классе.	2022
45	Mercedes-Benz E-Class 123	191	8499330	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/eeaa78d4-3ae0-424c-a617-5f7c23833234.jpg	Mercedes-Benz E-Class - это седан бизнес-класса, производимый немецкой компанией Mercedes-Benz. Автомобиль известен своим комфортом, роскошью и высоким уровнем безопасности. Mercedes-Benz E-Class имеет несколько вариантов двигателей, включая бензиновые и дизельные, а также гибридные и электрические версии. Автомобиль оснащен широким спектром технологий, таких как автономная парковка, адаптивная подвеска и система предупреждения столкновений. В салоне Mercedes-Benz E-Class используются высококачественные материалы, такие как натуральная кожа и дерево, чтобы создать роскошную и комфортную атмосферу. Автомобиль доступен в нескольких вариантах кузова, включая седан и универсал.	2023
46	Audi А5	245	2900000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/af66374c-46f7-4b89-b36a-fc2052e416f3.jpg	Audi A5 автомобиль среднего класса, выпускаемый немецким автопроизводителем Audi. Он доступен в кузове хетчбэк и спортивный купе. Audi A5 оснащен различными двигателями, в том числе бензиновыми и дизельными, и имеет передний или полный привод.\r\n\r\nAudi A5 известен своим динамичным и элегантным дизайном, а также высоким уровнем комфорта и безопасности. В салоне автомобиля используются высококачественные материалы, такие как натуральная кожа и алюминий, и установлена современная электроника, включая систему мультимедиа, навигацию и помощь во время вождения.\r\n\r\nAudi A5 имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как адаптивная подвеска, круиз-контроль, система помощи при парковке и многое другое.	2016
47	Zeekr 001	553	6500000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4490751d-5f37-4b84-9141-2e624a421e67.jpg	Zeekr 001 - это электрический автомобиль (EV), производимый Zeekr, новым брендом электромобилей под китайским автомобильным гигантом Geely. Zeekr 001 - это премиальный электромобиль высокого класса, который был впервые представлен в 2021 году. Это впечатляющий электромобиль, который сочетает в себе футуристический дизайн, высокие технические характеристики и премиальный интерьер. С его доступной ценой и большим запасом хода, этот автомобиль может стать серьезным конкурентом для других премиальных электромобилей на рынке.	2023
53	Mercedes-Benz G-Class 350D\t	249	15000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6fa86141-a5ee-4b22-988d-ed75c198333d.jpeg	Mercedes-Benz G-Class 350D - это роскошный внедорожник, производимый компанией Mercedes-Benz. Он входит в линейку G-Class, которая производится с 1979 года.\r\n\r\nМодель 350D оснащена 3,0-литровым V6 турбодизельным двигателем, который развивает мощность 224 лошадиных силы и крутящий момент 369 фунт-футов. Этот двигатель сочетается с 7-ступенчатой автоматической коробкой передач и имеет полный привод 4MATIC. G-Class 350D известен своей прочностью, долговечностью и внедорожными возможностями, благодаря своему крепкому каркасу из рамы, трем дифференциалам блокировки и низкопередаточному редуктору.\r\n\r\nВ плане интерьера G-Class 350D предлагает роскошный салон с высококачественными материалами и широким спектром современных удобств. Он оснащен кожаной обивкой, подогревом сидений, премиальной аудиосистемой и мультимедийным интерфейсом с навигацией. Автомобиль также предлагает достаточно места для пассажиров и багажа, делая его подходящим как для ежедневных поездок, так и для приключений на природе.\r\n\r\nВ целом, Mercedes-Benz G-Class 350D - это мощный и способный внедорожник, который сочетает в себе роскошь и прочность в уникальном сочетании. Он является популярным выбором среди тех, кто ценит как производительность, так и комфорт в своих автомобилях.	2020
48	Rolls-Royce Wraith Black Badge	632	25000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/eb3c73c3-6aab-4d28-8a21-18cc6a4a2190.jpeg	Rolls-Royce Wraith Black Badge - это роскошный купе, производимый британской компанией Rolls-Royce Motor Cars. Он был представлен в 2016 году и является частью серии Black Badge, которая предлагает более спортивные и темные версии стандартных моделей Rolls-Royce.\r\n\r\nWraith Black Badge оснащен 6,6-литровым V12 битурбо двигателем, который развивает мощность 624 лошадиных силы и крутящий момент 642 фунт-футов. Этот двигатель сочетается с 8-ступенчатой автоматической коробкой передач и имеет задний привод. Wraith Black Badge также оснащен улучшенной подвеской и тормозной системой, чтобы обеспечить более спортивное вождение.\r\n\r\nВ плане дизайна Wraith Black Badge имеет темный и изысканный внешний вид с характерными черными элементами дизайна, такими как решетка радиатора, колесные диски и эмблема Spirit of Ecstasy. Интерьер также впеатляет высококачественными материалами, такими как кожа и алькантара, и широким спектром передовых технологических функций, таких как 12,3-дюймовый экран информационно-развлекательной системы и премиальная аудиосистема.\r\n\r\nWraith Black Badge также предлагает много места для пассажиров и груза, с возможностью размещения до четырех человек и максимальной грузоподъемностью 13,4 кубических фута. Системы безопасности включают предупреждение об уходе со следующей полосы, мониторинг слепых зон, адаптивный круиз-контроль и систему предупреждения о столкновении впереди.\r\n\r\nВ целом, Rolls-Royce Wraith Black Badge - это роскошное купе, которое сочетает в себе спортивную производительность и изысканный дизайн. Его темный внешний вид, просторный интерьер и передовые технологические функции делают его уникальным выбором среди любителей роскоши и скорости.	2020
49	Lamborghini Urus	666	31500000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/05003746-e300-4fed-b675-eea10850bcf3.jpeg	Lamborghini Urus - это суперкар-кроссовер, производимый итальянской компанией Lamborghini. Он был представлен в 2017 году и является первым кроссовером в истории Lamborghini.\r\n\r\nUrus оснащен 4,0-литровым V8 битурбо двигателем, который развивает мощность 650 лошадиных сил и крутящий момент 627 фунт-футов. Этот двигатель сочетается с 8-ступенчатой автоматической коробкой передач и имеет полный привод. Urus также оснащен системой активной подвески и системой тормозов с карбоно-керамическими дисками.\r\n\r\nВ плане дизайна Urus имеет агрессивный и спортивный внешний вид с характерными стилистическими элементами Lamborghini, такими как Y-образные фары и задние фонари в форме тонкого треугольника. Интерьер также впечатляет высококачественными материалами, спортивными сиденьями и широким спектром передовых технологических функций, таких как 12,3-дюймовый экран информационно-развлекательной системы и система камер обзора 360 градусов.\r\nUrus также предлагает много места для пассажиров и груза, с возможностью размещения до пяти человек и максимальной грузоподъемностью 61,2 кубических фута. Системы безопасности включают адаптивный круиз-контроль, предупреждение об уходе со следующей полосы, мониторинг слепых зон и систему предупреждения о столкновении впереди.\r\n\r\nВ целом, Lamborghini Urus - это суперкар-кроссовер, который сочетает в себе спортивную производительность и комфорт. Его агрессивный дизайн, просторный интерьер и передовые технологические функции делают его уникальным выбором среди любителей скорости и роскоши.	2023
51	Bentley Bentayga	550	30000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/9317eb85-bd15-4f48-b075-1d29644000d7.jpg	Bentley Bentayga - роскошный внедорожник, производимый британским автопроизводителем Бентли Моторс. Он был впервые представлен в 2015 году и в настоящее время находится в первом поколении.\r\n\r\nБентайга оснащен 6,0-литровым двигателем W12, который развивает мощность 600 лошадиных сил и крутящий момент 664 фунт-футов. Этот двигатель сочетается с 8-ступенчатой автоматической коробкой передач и имеет полный привод. Бентайга известен своей мощной производительностью, ловкими движениями и роскошным интерьером.\r\n\r\nВ плане дизайна Бентайга имеет изящный и элегантный внешний вид с характерными стилистическими элементами Бентли, такими как матричная решетка радиатора, четырехфарные фары и мускулистые линии. Интерьер также впечатляет высококачественными материалами, ручной швейной кожаной обивкой и широким спектром передовых технологических функций, таких как 12,3-дюймовый экран информационно-развлекательной системы, головной дисплей и 20-динамическая аудиосистема Naim.\r\n\r\nБентайга также предлагает много места для пассажиров и груза, с возможностью размещения до семи человек и максимальной грузоподъемностью 63,3 кубических фута. Системы безопасности включают адаптивный круиз-контроль, предупреждение об уходе со следующей полосы, распознавание дорожных знаков и систему ночного видения.\r\n\r\nВ целом, Бентли Бентайга - это роскошный внедорожник, который предлагает уникальное сочетание мощи, производительности и роскоши. Его изящный дизайн, просторный интерьер и передовые технологические функции делают его популярным выбором среди покупателей роскошных внедорожников.	2021
52	Cadillac Escalade	420	18000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/95c3fa75-4d41-4d21-a093-d7b2f68943cc.jpg	Cadillac Escalade 2023 - это роскошный полноразмерный SUV, производимый американской автомобильной компанией Cadillac. Это пятое поколение Escalade, которое дебютировало в 2020 году и имеет множество улучшений и новых функций по сравнению со своим предшественником.\r\n\r\nEscalade 2023 оснащен двигателем V8 объемом 6,2 литра с системой отключения цилиндров, который развивает мощность в 420 лошадиных сил и крутящий момент в 460 фунто-фут. Двигатель работает в паре с 10-ступенчатой автоматической трансмиссией, которая обеспечивает плавный и эффективный расход топлива.	2023
54	BMW М8 Competition Gran Coupe	625	15000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d4a33474-f4be-48d9-9c82-d3b1f5b665ab.jpg	BMW M8 Competition Coupe - это спортивный купе, выпускаемый немецким автопроизводителем BMW. Он оснащён бензиновым двигателем мощностью 625 л.с. и имеет задний привод. BMW M8 Competition Coupe имеет динамичный и элегантный дизайн, а также комфортабельный и спортивный салон, оснащенный современной электроникой и высококачественными материалами. Автомобиль имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как адаптивная подвеска, система помощи при парковке, система предупреждения столкновений и многое другое.\r\n\r\nBMW M8 Competition Coupe предлагает водителям и пассажирам удовольствие от спортивной езды и высоких скоростей. Автомобиль имеет мощный двигатель и трансмиссию, которые обеспечивают быстрый разгон и хорошую управляемость. BMW M8 Competition Coupe также имеет хорошую тормозную систему, которая обеспечивает безопасную остановку автомобиля даже при высоких скоростях.	2020
55	Tank 500	299	5500000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e2f0b335-a6c8-4da0-83e2-d7bfdba894c9.jpg	Tank 500 - это бронетранспортёр, разработанный американской компанией International Armored Group (IAG). Он оснащён дизельным двигателем мощностью 350 л.с. и имеет полный привод. Tank 500 имеет высокий уровень защиты и может выдерживать огонь из стрелкового оружия, взрывы гранат и подрывы мин. Автомобиль имеет просторный и комфортабельный салон, оснащенный современной электроникой и высококачественными материалами.\r\n\r\nTank 500 предназначен для обеспечения безопасности и защиты людей в зонах конфликтов и кризисов. Автомобиль имеет бронированный корпус и бронированные стёкла, которые защищают от пуль и осколков. Tank 500 также оснащён системой кондиционирования воздуха, системой связи и системой навигации.	2023
56	Porsche Boxter S cabrio	295	5500000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/8655bdb3-58a1-49bd-88bf-3600483e8883.jpg	Porsche Boxter S - это спортивный кабриолет, выпускаемый немецким автопроизводителем Porsche. Он оснащен бензиновым двигателем мощностью 350 л.с. и имеет задний привод. Porsche Boxter S имеет динамичный и элегантный дизайн, а также комфортабельный и роскошный салон, оснащенный современной электроникой и высококачественными материалами. Автомобиль имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как адаптивная подвеска, система помощи при парковке и многое другое.\r\n\r\nPorsche Boxter S предлагает водителям и пассажирам удовольствие от открытой езды и спортивного вождения. Автомобиль имеет мягкий верх, который можно открыть или закрыть всего за несколько секунд, и обеспечивает хорошую вентиляцию и комфорт во время поездки.	2012
57	BMW 7	249	8500000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/55f0870e-9647-47de-a608-9ec1ed90e734.jpg	BMW 7 - это представительский седан бизнес-класса, выпускаемый немецким автопроизводителем BMW. Он оснащен мощными бензиновыми и дизельными двигателями и имеет полный привод. BMW 7 имеет большой и роскошный салон, оснащенный высококачественными материалами и современной электроникой. Автомобиль имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как адаптивная подвеска, система помощи при парковке, система предупреждения столкновений и многое другое.\r\n\r\nBMW 7 предлагает пассажирам большой комфорт и роскошь, а также множество функций для облегчения поездок. В салоне автомобиля установлены комфортабельные кресла, оснащенные функцией массажа и вентиляции, а также многоместные столы и откидные экраны для развлечений. Автомобиль также оснащен системой кондиционирования воздуха и звукоизоляцией, чтобы обеспечить комфорт и спокойствие во время поездки.	2020
58	Mercedes-Benz V-Class VIP	163	19000000	t	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/88c61e3e-1e1b-4199-aee2-2670a3143187.jpg	Mercedes-Benz V-Class VIP - это представительский минивэн, выпускаемый немецким автопроизводителем Mercedes-Benz. Он оснащен мощными дизельными двигателями и имеет полный привод. Mercedes-Benz V-Class VIP имеет большой и комфортабельный салон, оснащенный высококачественными материалами и современной электроникой. Автомобиль имеет хорошую динамику и управляемость, а также богатый набор технологий, таких как адаптивная подвеска, система помощи при парковке, система предупреждения столкновений и многое другое.\r\n\r\nMercedes-Benz V-Class VIP предлагает пассажирам большой комфорт и роскошь, а также множество функций для облегчения поездок. В салоне автомобиля установлены комфортабельные кресла, оснащенные функцией массажа и вентиляции, а также многоместные столы и откидные экраны для развлечений. Автомобиль также оснащен системой кондиционирования воздуха и звукоизоляцией, чтобы обеспечить комфорт и спокойствие во время поездки.	2023
\.


--
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Orders" ("Id", "PhoneNumber", "Message", "Name", "Checked", "DateCreated", "Referrer") FROM stdin;
2	44	ауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауцауц	0	t	2000-01-01 00:00:00	\N
0	79107776655	Здравствуйте! Хочу вас купить авто!	Олег\n	t	2000-01-01 00:00:00	\N
1	12345678910	\N	Петька	t	2000-01-01 00:00:00	\N
3	fewfwef	wfefewfe	fdsfdf	t	2024-03-29 00:00:00	\N
4	fewfwef	wfefewfe	fdsfdf	t	2024-03-29 00:00:00	\N
5	fewfwef	wfefewfe	fdsfdf	t	2024-03-29 04:22:11.108109	\N
11	fewfewfewf	ewfwefewffe	fewfwef	t	2024-04-19 18:01:27.457385	Mercedes-Benz E-Class
12	ewrewrwer	fewfewfewfwefwef	rewrewr	t	2024-04-21 14:37:44.21989	Mercedes-Benz E-Class
15	74340004211	А скидка есть?	Олег	t	2024-04-24 17:00:17.953986	Lamborghini Urus
14	79107447743	Здравствуйте, хочу получить консультацию по поводу этого автомобиля	Виталий	t	2024-04-24 16:59:56.759676	Mercedes-Benz GLS 400D
13	7757657	Хочу приобрести авто	Иван	t	2024-04-24 16:58:21.19972	BMW 520D
16	fewfwef	fewfwefewf	fsdfsd	t	2024-05-13 19:22:44.760067	BMW 520D
17	fewfew	fewfewfewf	fewfwe	t	2024-05-13 19:22:59.449812	BMW 520D
18	vf	vf	fv	t	2024-05-13 19:29:39.73367	BMW 520D
19	wdq	fewfwe	vas	t	2024-05-13 19:29:44.096563	BMW 520D
\.


--
-- Data for Name: UrlImagesOfCars; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UrlImagesOfCars" ("Id", "Url", "IdCar") FROM stdin;
120	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/deb2247a-9d7d-4239-adf9-8d8097639e13.jpg	47
121	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/8ea87fa9-5bfe-42d0-aee0-df01b7923a09.jpg	47
122	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/39709e8e-15b6-4f11-86e0-61f26e3332a7.jpg	47
123	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/eedb426b-ec82-47fc-a090-ba222d674802.jpg	47
124	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/29d46b51-5dc6-42c1-b75f-f26948c9ec5a.jpg	47
125	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/37565570-61a8-4788-9216-48f0ff4a4c96.jpg	47
126	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f726da16-9cbd-49a0-b82e-ca9377374223.jpg	47
127	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/49cf766f-d358-4246-97ad-6f52ce8c155b.jpg	47
128	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/2e35d423-9e4f-4070-9903-e9c1a8bf5df2.jpg	47
129	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/2417bc95-da50-44ca-b8a2-f978c8649911.jpg	47
130	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ef97a263-8f81-41cb-8a38-626e11e1c837.jpg	47
131	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6f0d6d03-08a3-4b95-a929-817535b72e02.jpg	47
132	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/baca0dc6-865f-409d-9623-a693336d4c69.jpg	47
133	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/1e6cc8be-edc8-47a9-976e-060d081c404a.jpg	47
134	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/dd6fe795-d961-49a7-9c51-0c8b1021e8df.jpg	47
135	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/5d008870-d92c-40ee-a0c3-ce84ffe89976.jpg	47
141	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/0443cda5-afe2-4b1a-942c-e352f1710f78.jpg	51
142	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/da816486-2c4a-48fb-88ca-413683f419d6.jpg	52
143	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/395b7552-4ca7-4c12-b67c-28045865e355.jpg	52
144	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/fdcd45f6-cc0d-46a6-ab0d-3a3693ebe269.jpg	52
145	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f3178363-95e8-4297-bd70-bd360cf1a4be.jpg	52
146	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/5c023d93-038f-4c9f-8173-6e21abe34afc.jpg	52
147	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/074956b6-5b2d-4464-834c-84e9c1899496.jpg	52
148	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/10fdd26b-575d-45d2-b8ad-decb34d422c2.jpg	52
149	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c6b51592-3df8-4249-a39e-54bf9f465d14.jpg	52
150	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e82443c3-3b85-4fbc-8661-607d643af84a.jpg	52
151	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/efb7435d-3a82-4945-b3ce-fd84b4435544.jpg	52
152	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/cbca11b0-8fbb-4088-8a72-6bdc8d07bc94.jpg	52
153	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/3cde7f4e-fbfb-48bd-a9e0-4feb6d95864a.jpg	52
154	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/9541b6bb-b4e6-4c1d-aa49-0ebaaac0cf2f.jpg	52
155	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/10dc0bf2-16a4-43d2-9ec5-86adee0440ec.jpg	52
156	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/0bcf6952-06dc-47d5-8f23-e81bf175d827.jpeg	53
157	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/cf751e71-41b2-4986-99da-161644625ab6.jpeg	53
158	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/44c9c7fa-a7b2-4a47-9dc2-022fb076ef49.jpeg	53
159	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/70ed8326-3b04-4bfb-b388-34e69444cddd.jpeg	53
160	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/381a0be6-cfc3-4986-a60c-ce5ee27f7454.jpeg	53
161	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a95b994e-1d77-4ee5-b199-7b414254eb21.jpeg	53
162	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/b2b9854e-04ff-4d62-91b9-4c4fe77b9538.jpeg	53
136	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/652bccba-31c2-49c6-b1ce-beafa980dd44.jpeg	48
137	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4c9746ef-4a12-4dee-b302-6b5335139f6b.jpeg	48
138	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/3211801a-aa7a-4676-9ea0-b4d56e97683a.jpeg	48
139	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/cfdea57a-18ca-4564-a986-63a9d9c02609.jpeg	49
163	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/7730d35c-9bae-4a65-90cd-12cd376f3de6.jpeg	53
164	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/b9634d3a-b35b-4a1a-ac38-0dac9e105b89.jpeg	53
74	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/9afdbde7-1c1c-464b-a0af-d3277aed3aab.jpg	43
75	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/46940ad3-5db7-481c-8954-6f292a1d9fd1.jpg	43
76	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f00bcc53-ab76-45d1-9127-6f60faf5c168.jpg	43
77	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/bac1bbef-2656-4cbb-a59e-3a5d08f5af8a.jpg	43
78	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a4618551-f985-4815-97a4-b2c03b99bd73.jpg	43
79	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f9511838-5ca8-4d93-98ab-814d0aaf6fef.jpg	43
80	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ad55e15a-7d32-471f-aebd-9a97c559b149.jpg	43
81	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/82a52af1-b5d0-4e0d-9fe1-2da945b36b16.jpg	43
82	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/74e7fb46-cbc2-4753-a0d0-26d68482591a.jpg	43
83	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c8f6660e-6a15-4ff6-aeb4-bf23df776d5d.jpg	43
84	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/49586714-c6db-4fd2-8818-356d248f1bdc.jpg	44
85	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d92d46ac-1b62-4384-ad63-3df40539744c.jpg	44
86	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/67c6fe23-6ab2-45cd-9e8e-c3d05987ad5f.jpg	44
87	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/14e97bbf-9127-409e-980a-a32eff6d08b5.jpg	44
88	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/53910dee-22d7-4caa-9757-5d6dd8a40f16.jpg	44
89	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6ae90a44-8603-4872-8261-fd7c328477cd.jpg	44
90	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/8e1b3172-5cc5-47b1-83ef-3e4f4eb2446b.jpg	44
91	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e44bbf2d-6bc2-49a3-920f-8c57f3240050.jpg	44
92	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d1cbcf7c-6769-4afc-b3a8-bdfa80dfaad8.jpg	44
93	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a25b819a-116f-4f15-80d3-f9a9122a91d1.jpg	45
94	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/5b00c40e-2e22-433e-a892-c035672ca9c4.jpg	45
95	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/0e91a1ec-7133-469e-be75-3c11407f43bb.jpg	45
96	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/dff873e1-e4d4-4d71-b39d-24b7f29f9442.jpg	45
97	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f9df5ca4-b191-41bc-836d-19154ca86a2f.jpg	45
98	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/1d4541ea-9fd8-4e44-9f75-7490be8b9a55.jpg	45
99	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f49ecd16-8cfd-49f9-9a51-fbdc02adff5a.jpg	45
100	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e1fa2408-4933-459d-b9f9-a03a5a8e599f.jpg	45
101	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ae037f13-1e29-4ce3-82b4-a05f73e96982.jpg	45
102	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6742bd5f-c7f0-4b4c-9d00-fec6360afe7b.jpg	45
103	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/13954c84-07a0-4fa6-b96e-c0c738a85dc7.jpg	45
104	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a797218e-e96f-4c85-a73c-48b45590bbc3.jpg	45
105	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/3b554d13-b0ed-4570-a53a-01fc9f7289bc.jpg	45
106	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/42b6e036-b367-4196-9078-c57cae5f1159.jpg	45
107	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6d4443aa-9492-4782-9754-a344fea61e1f.jpg	45
108	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/81a3f5eb-dad6-4d26-b4e2-c2453ebb833e.jpg	45
109	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/caf00e21-e198-46ee-a576-17933b86a96a.jpg	46
110	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/26134582-f948-49e0-ad8e-39128d20dff2.jpg	46
111	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/75f31a35-6c8a-4b65-bc14-af43ca7f500d.jpg	46
112	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4f2faf8b-8f43-463a-80c6-deaabbf7b248.jpg	46
113	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/802c001f-71ef-4bb8-b037-98fa6b07d9f5.jpg	46
114	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d4b39235-9faf-419e-a3f9-a8764150a80c.jpg	46
115	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/12c793ac-5758-4803-bc04-bc971553f30b.jpg	46
116	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/2608a96b-bd08-43c6-a234-b1fed9744a70.jpg	46
117	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/71cddac3-0a3d-4d15-bb17-4cecb5755341.jpg	46
118	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6c9131fe-fc5f-4058-b075-18312bf5821f.jpg	46
119	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/09b84c62-022e-4ea5-966b-8bfdbb06f04c.jpg	46
165	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/0b70d70f-2233-4e8d-bdcc-b9eb5ddd0a73.jpeg	53
166	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ec255769-7023-4fff-ba9b-720ac9bf5997.jpeg	53
167	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/baee93fb-149d-4443-94f0-264720c04c57.jpg	54
168	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4b790214-5eb0-4674-b311-deccef5a44ec.jpg	54
169	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c19a5b5c-6457-4135-8e9b-9b1e807f3806.jpg	54
170	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/cd9518ed-f2af-4d5f-b569-c0ddb774d973.jpg	54
171	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/89ec2f81-f8e2-4119-890a-0b651e57ab3a.jpg	54
172	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/12822651-2212-44c9-b698-45ef8efb0886.jpg	54
173	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/0bf333c4-57e7-46ea-8122-7d72b689ddc4.jpg	54
174	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/cd180f0c-2b00-4461-b13f-4aecf06cff6d.jpg	54
175	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/2d85d5f3-f43f-459f-9909-0de05094a8bc.jpg	54
176	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/0af080e0-6239-4653-916b-15c7b8528f2d.jpg	54
177	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6c231932-2f23-4798-9df2-c1d5578e3a7f.jpg	54
178	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6115a50e-9374-406f-856f-b7528609962d.jpg	54
179	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/eb32c82d-db9a-4bd1-a818-1225f6372f8b.jpg	54
180	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c421042f-eb49-47cf-96b0-2281dc9f277b.jpg	55
181	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/320ff609-2fc5-4b5f-9b31-7737c4a48c70.jpg	55
182	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/b1fcdaeb-8a3e-4971-911c-e8ebe6ebb65c.jpg	56
183	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/bfd981ef-6528-4f52-91ad-230be50d9d43.jpg	56
184	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/79626daf-2c3e-4926-b82d-ab9aec10b51b.jpg	56
185	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4d73fcbb-342d-4eef-b644-1488318ff5c8.jpg	56
186	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/7291e698-1a0e-4d29-b9ea-0540464b180c.jpg	56
187	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/1df3aa74-ee9d-4f47-91c6-54c01a13e70c.jpg	56
188	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/71d644e0-4986-4cd7-a494-3eb24852c8c6.jpg	56
189	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/eeee60ef-8589-4adb-8407-05c330292ba3.jpg	56
190	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/9177b382-ff66-4568-8c99-a01c0a204f41.jpg	56
191	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e59efb94-1b58-4ab4-be14-e45bc4d1549b.jpg	57
192	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d5cc9214-1db3-42cc-9104-9e223c44b659.jpg	57
193	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c656cf13-9774-44a4-8a18-9498b19616f3.jpg	57
194	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a33744c8-9f2d-4017-b6ac-b92d5df3e0a2.jpg	57
195	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f6d86b5f-4f34-47ed-b3d0-7998e3cc0d97.jpg	57
196	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/744c23ca-4be0-4a6c-a8f7-d48bdeb2108b.jpg	57
197	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4faa245e-8704-43c8-ba8a-3d9eb2d0c9f8.jpg	57
198	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6f93b255-fb93-4eac-8741-f3bb024d225a.jpg	57
199	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/236c29cd-c7a1-4b1c-8b69-e44b89250701.jpg	57
200	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/82ea38f3-c9c4-4f86-beb2-200487bcda69.jpg	57
201	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e76b22fb-6bd1-46bb-b6d5-846ad7625b57.jpg	57
202	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/02584ecc-253b-4faf-bf98-460d010dc589.jpg	57
203	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ed4498fa-7ee4-46ba-8c9b-069ff9a07bb9.jpg	57
204	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d84a0739-2fa0-4973-a98b-21118d15cb3f.jpg	57
205	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/6e76a917-a7c8-4b20-8c34-e4e91d75ff77.jpg	57
206	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d21ac2f3-c485-4f4d-9d83-eb332474cddf.jpg	57
207	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a506b4f1-7097-45fb-81d0-0f25bdf03b1d.jpg	57
208	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/54882064-d6e0-4ab8-aa32-18a808494647.jpg	57
209	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/5ca64fd4-bb33-484a-9141-f0f1227d4b29.jpg	57
210	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/172297bc-a89d-49a3-8156-e31fd453a2c5.jpg	58
211	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c13dc86c-d013-4b59-96d7-e3c736c27eb6.jpg	58
212	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/f2524b0b-45de-4ab7-a298-aae52f44e457.jpg	58
213	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/9dee6e46-0390-4a36-a9ca-5f0e1c3d7ec7.jpg	58
214	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ba518ee8-087e-43c5-b734-469a362f7897.jpg	58
215	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/92e59e87-d128-4e10-91a5-52472df8c163.jpg	58
216	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/e499679a-fa05-4003-bba8-0422f8175a8d.jpg	58
217	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/1990f9c1-78e6-4b80-8d01-f58d0c30c604.jpg	58
218	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/7c1073fc-3f0d-49a7-8e73-80b7f3f45db6.jpg	58
219	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c8c7af74-a8d0-4c14-a6ef-aabfd822cc93.jpg	58
220	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/a5dd2585-776e-416d-b599-ffd81d7b745c.jpg	58
221	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/d16bb8e4-05c3-41c0-a07f-0fa2a68caf80.jpg	58
222	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/4d2ec5e7-1b3a-4915-9105-3aeee4583bf2.jpg	58
223	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/c198df17-211b-483d-a455-4c54c1dcd7cc.jpg	58
224	https://storage.yandexcloud.net/cloudstorage27/ImagesOfCars/ba352639-64fb-41d3-9a69-79f146969424.jpg	58
\.


--
-- Name: Admins_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Admins_Id_seq"', 14, true);


--
-- Name: Cars_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Cars_Id_seq"', 58, true);


--
-- Name: Orders_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Orders_Id_seq"', 19, true);


--
-- Name: UrlImagesOfCars_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UrlImagesOfCars_Id_seq"', 224, true);


--
-- Name: Cars Cars_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cars"
    ADD CONSTRAINT "Cars_pkey" PRIMARY KEY ("Id");


--
-- Name: Orders Orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "Orders_pkey" PRIMARY KEY ("Id");


--
-- Name: UrlImagesOfCars UrlImagesOfCars_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UrlImagesOfCars"
    ADD CONSTRAINT "UrlImagesOfCars_pkey" PRIMARY KEY ("Id");


--
-- Name: Admins Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admins"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- Name: Admins unique_login; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admins"
    ADD CONSTRAINT unique_login UNIQUE ("Login");


--
-- Name: UrlImagesOfCars Cars_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UrlImagesOfCars"
    ADD CONSTRAINT "Cars_fk" FOREIGN KEY ("IdCar") REFERENCES public."Cars"("Id") NOT VALID;


--
-- PostgreSQL database dump complete
--

