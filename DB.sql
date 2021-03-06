USE [BitirmeProjem]
GO
/****** Object:  Table [dbo].[Ilceler]    Script Date: 26.01.2019 17:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ilceler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[SehirID] [smallint] NOT NULL,
 CONSTRAINT [PK_Ilceler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[UstID] [int] NULL,
	[SeoUrl] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kuponlar]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kuponlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Kodu] [nvarchar](10) NOT NULL,
	[Oran] [int] NOT NULL,
	[BitisTarihi] [date] NOT NULL,
 CONSTRAINT [PK_Kuponlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sehirler]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sehirler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sehirler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](250) NOT NULL,
	[KategoriID] [int] NOT NULL,
	[Fiyat] [float] NOT NULL,
	[Stok] [int] NOT NULL,
	[Goruntulenme] [int] NULL,
	[Yildiz] [smallint] NULL,
	[KapakResmi] [nvarchar](250) NULL,
	[Detay] [text] NULL,
	[SeoUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UyeAdres]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UyeAdres](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UyeID] [int] NOT NULL,
	[Baslik] [nvarchar](50) NOT NULL,
	[SehirID] [int] NOT NULL,
	[IlceID] [int] NOT NULL,
	[Adres] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UyeAdres] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uyeler]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uyeler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Soyadi] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Uyeler_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yorumlar]    Script Date: 26.01.2019 17:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yorumlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NOT NULL,
	[UyeID] [int] NOT NULL,
	[Yorum] [nvarchar](50) NOT NULL,
	[Puan] [smallint] NOT NULL,
	[Onay] [bit] NOT NULL,
 CONSTRAINT [PK_Yorumlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Ilceler] ON 

INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (1, N'SEYHAN', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (2, N'CEYHAN', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (3, N'FEKE', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (4, N'KARAİSALI', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (5, N'KARATAŞ', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (6, N'KOZAN', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (7, N'POZANTI', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (8, N'SAİMBEYLİ', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (9, N'TUFANBEYLİ', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (10, N'YUMURTALIK', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (11, N'YÜREĞİR', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (12, N'ALADAĞ', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (13, N'İMAMOĞLU', 1)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (14, N'ADIYAMAN MERKEZ', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (15, N'BESNİ', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (16, N'ÇELİKHAN', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (17, N'GERGER', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (18, N'GÖLBAŞI', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (19, N'KAHTA', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (20, N'SAMSAT', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (21, N'SİNCİK', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (22, N'TUT', 2)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (23, N'AFYONMERKEZ', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (24, N'BOLVADİN', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (25, N'ÇAY', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (26, N'DAZKIRI', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (27, N'DİNAR', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (28, N'EMİRDAĞ', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (29, N'İHSANİYE', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (30, N'SANDIKLI', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (31, N'SİNANPAŞA', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (32, N'SULDANDAĞI', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (33, N'ŞUHUT', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (34, N'BAŞMAKÇI', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (35, N'BAYAT', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (36, N'İŞCEHİSAR', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (37, N'ÇOBANLAR', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (38, N'EVCİLER', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (39, N'HOCALAR', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (40, N'KIZILÖREN', 3)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (41, N'AKSARAY MERKEZ', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (42, N'ORTAKÖY', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (43, N'AĞAÇÖREN', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (44, N'GÜZELYURT', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (45, N'SARIYAHŞİ', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (46, N'ESKİL', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (47, N'GÜLAĞAÇ', 68)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (48, N'AMASYA MERKEZ', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (49, N'GÖYNÜÇEK', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (50, N'GÜMÜŞHACIKÖYÜ', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (51, N'MERZİFON', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (52, N'SULUOVA', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (53, N'TAŞOVA', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (54, N'HAMAMÖZÜ', 5)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (55, N'ALTINDAĞ', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (56, N'AYAS', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (57, N'BALA', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (58, N'BEYPAZARI', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (59, N'ÇAMLIDERE', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (60, N'ÇANKAYA', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (61, N'ÇUBUK', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (62, N'ELMADAĞ', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (63, N'GÜDÜL', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (64, N'HAYMANA', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (65, N'KALECİK', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (66, N'KIZILCAHAMAM', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (67, N'NALLIHAN', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (68, N'POLATLI', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (69, N'ŞEREFLİKOÇHİSAR', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (70, N'YENİMAHALLE', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (71, N'GÖLBAŞI', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (72, N'KEÇİÖREN', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (73, N'MAMAK', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (74, N'SİNCAN', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (75, N'KAZAN', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (76, N'AKYURT', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (77, N'ETİMESGUT', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (78, N'EVREN', 6)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (79, N'ANSEKİ', 7)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (80, N'ALANYA', 7)
INSERT [dbo].[Ilceler] ([ID], [Adi], [SehirID]) VALUES (81, N'ANTALYA MERKEZİ', 7)
SET IDENTITY_INSERT [dbo].[Ilceler] OFF
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (28, N'Giyim ve Ayakkabı', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (29, N'Ayakkabı ve Çanta', 28, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (30, N'Kadın Giyim', 28, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (31, N'Erkek Giyim', 28, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (32, N'Çocuk Giyim', 28, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (33, N'Güneş Gözlüğü', 28, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (36, N'Kadın Ayakkabı', 29, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (37, N'Erkek Ayakkabı', 29, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (38, N'Çocuk Ayakkabı', 29, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (39, N'Kadın Çanta', 29, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (40, N'Erkek Çanta', 29, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (41, N'İç Giyim', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (42, N'Tesettür Giyim', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (43, N'Tişört ve Atlet', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (44, N'Elbise ve Tulum', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (45, N'Aksesuarlar', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (46, N'Triko', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (47, N'Pantolon ve Tayt', 30, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (48, N'Tişört ve Atlet', 31, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (49, N'Eşofman', 31, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (50, N'Aksesuarlar', 31, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (51, N'İç Giyim', 31, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (52, N'Gömlek', 31, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (53, N'Erkek Çocuk', 32, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (54, N'Kız Çocuk', 32, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (55, N'Aksesuarlar', 32, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (56, N'Kadın Güneş Gözlüğü', 33, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (57, N'Erkek Güneş Gözlüğü', 33, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (58, N'Çocuk Güneş Gözlüğü', 33, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (62, N'Elektronik', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (63, N'Telefon ve Aksesuarları', 62, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (64, N'Bilgisayar', 62, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (65, N'Televizyon', 62, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (66, N'Beyaz Eşya', 62, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (67, N'Aksesuarlar', 63, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (68, N'Yedek Parça', 63, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (69, N'Cep Telefonu', 63, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (70, N'Telsiz', 63, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (71, N'Tuşlu Telefon', 63, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (73, N'Aksesuar', 64, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (74, N'Yedek Parça', 64, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (75, N'Bilgisayar Billeşenleri', 64, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (76, N'Çevre Birimleri', 64, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (77, N'Dizüstü Bilgisayar', 64, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (78, N'Masaüstü Bilgisayar', 64, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (79, N'Aksesuarlar', 65, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (80, N'Uydu Sistemleri', 65, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (81, N'Televizyon', 65, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (82, N'Isıtme ve Soğutma', 66, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (83, N'Aspiratör', 66, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (84, N'Buzdolabı', 66, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (85, N'Çamaşır Makinesi', 66, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (86, N'Ev ve Yaşam', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (87, N'Anne ve Bebek', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (88, N'Kozmetik', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (89, N'Mücevher ve Saat', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (90, N'Spor ve Outdoor', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (91, N'Kitap, Müzik, Film, Oyun', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (92, N'Bilet, Tatil ve Eğlence', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (93, N'Otomotiv ve Motosiklet', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (94, N'Bisiklet', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (96, N'Kırtasiye', NULL, NULL)
INSERT [dbo].[Kategoriler] ([ID], [Adi], [UstID], [SeoUrl]) VALUES (97, N'Diğer', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
SET IDENTITY_INSERT [dbo].[Kuponlar] ON 

INSERT [dbo].[Kuponlar] ([ID], [Kodu], [Oran], [BitisTarihi]) VALUES (4, N'10303', 10, CAST(N'2019-02-07' AS Date))
SET IDENTITY_INSERT [dbo].[Kuponlar] OFF
SET IDENTITY_INSERT [dbo].[Sehirler] ON 

INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (1, N'ADANA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (2, N'ADIYAMAN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (3, N'AFYON')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (4, N'AĞRI')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (5, N'AMASYA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (6, N'ANKARA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (7, N'ANTALYA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (8, N'ARTVİN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (9, N'AYDIN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (10, N'BALIKESİR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (11, N'BİLECİK')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (12, N'BİNGÖL')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (13, N'BİTLİS')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (14, N'BOLU')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (15, N'BURDUR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (16, N'BURSA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (17, N'ÇANAKKALE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (18, N'ÇANKIRI')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (19, N'ÇORUM')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (20, N'DENİZLİ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (21, N'DİYARBAKIR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (22, N'EDİRNE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (23, N'ELAZIĞ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (24, N'ERZİNCAN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (25, N'ERZURUM')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (26, N'ESKİŞEHİR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (27, N'GAZİANTEP')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (28, N'GİRESUN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (29, N'GÜMÜŞHANE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (30, N'HAKKARİ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (31, N'HATAY')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (32, N'ISPARTA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (33, N'İÇEL')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (34, N'İSTANBUL')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (35, N'İZMİR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (36, N'KARS')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (37, N'KASTAMONU')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (38, N'KAYSERİ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (39, N'KIRKLARELİ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (40, N'KIRŞEHİR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (41, N'KOCAELİ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (42, N'KONYA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (43, N'KÜTAHYA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (44, N'MALATYA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (45, N'MANİSA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (46, N'KAHRAMANMARAŞ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (47, N'MARDİN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (48, N'MUĞLA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (49, N'MUŞ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (50, N'NEVŞEHİR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (51, N'NİĞDE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (52, N'ORDU')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (53, N'RİZE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (54, N'SAKARYA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (55, N'SAMSUN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (56, N'SİİRT')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (57, N'SİNOP')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (58, N'SİVAS')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (59, N'TEKİRDAĞ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (60, N'TOKAT')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (61, N'TRABZON')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (62, N'TUNCELİ')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (63, N'ŞANLIURFA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (64, N'UŞAK')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (65, N'VAN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (66, N'YOZGAT')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (67, N'ZONGULDAK')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (68, N'AKSARAY')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (69, N'BAYBURT')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (70, N'KARAMAN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (71, N'KIRIKKALE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (72, N'BATMAN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (73, N'ŞIRNAK')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (74, N'BARTIN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (75, N'ARDAHAN')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (76, N'IĞDIR')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (77, N'YALOVA')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (78, N'KARABÜK')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (79, N'KİLİS')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (80, N'OSMANİYE')
INSERT [dbo].[Sehirler] ([ID], [Adi]) VALUES (81, N'DÜZCE')
SET IDENTITY_INSERT [dbo].[Sehirler] OFF
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([ID], [Adi], [KategoriID], [Fiyat], [Stok], [Goruntulenme], [Yildiz], [KapakResmi], [Detay], [SeoUrl]) VALUES (1002, N'Suyıka Şampiyon Plus Şofben', 82, 375, 50, NULL, 4, N'suyika.jpg', N'<section class="tabPanelItem features" style="clear: both; padding: 0px 5px; overflow: hidden; color: rgb(32, 32, 32); font-family: Arial, Helvetica, sans-serif; font-size: 12px;"><h4 style="margin-right: -5px; margin-bottom: 15px; margin-left: -5px; padding: 0px; border: 0px; font-size: 16px; position: relative; background: rgb(242, 242, 242); font-weight: 700; line-height: 30px; text-indent: 10px;">Ürün Özellikleri</h4><div style="margin: 0px; padding: 0px; border: 0px; position: relative; float: left; width: 433px; overflow: hidden;"><div class="feaItem" style="margin: 5px 0px; padding: 0px; border: 0px; position: relative; width: 433px; display: inline-block;"><span class="label" style="margin: 0px 10px 0px 0px; padding: 0px; border: 0px; position: relative; word-break: break-all; width: 120px; color: gray; float: left; overflow-wrap: break-word; display: inline !important;">Marka</span><a class="data" href="https://www.n11.com/beyaz-esya/isitma-ve-sogutma/sofben?m=Simfer" style="margin: 0px -2px 0px 0px; padding: 0px; border: 0px; position: relative; outline: 0px; cursor: pointer; color: rgb(0, 102, 204); display: inline-block; word-break: break-all; overflow: hidden;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative; word-break: break-all;">Simfer</span></a></div></div><div style="margin: 0px; padding: 0px; border: 0px; position: relative; float: left; width: 433px;"><div class="feaItem" style="margin: 5px 0px; padding: 0px; border: 0px; position: relative; width: 433px; display: inline-block;"><span class="label" style="margin: 0px 10px 0px 0px; padding: 0px; border: 0px; position: relative; word-break: break-all; width: 120px; color: gray; float: left; overflow-wrap: break-word; display: inline !important;">Enerji Sınıfı</span><a class="data" href="https://www.n11.com/beyaz-esya/isitma-ve-sogutma/sofben?ens=A" style="margin: 0px -2px 0px 0px; padding: 0px; border: 0px; position: relative; outline: 0px; cursor: pointer; color: rgb(0, 102, 204); display: inline-block; word-break: break-all; overflow: hidden;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative; word-break: break-all;">A</span></a></div></div><div style="margin: 0px; padding: 0px; border: 0px; position: relative; float: left; width: 433px;"><div class="feaItem" style="margin: 5px 0px; padding: 0px; border: 0px; position: relative; width: 433px; display: inline-block;"><span class="label" style="margin: 0px 10px 0px 0px; padding: 0px; border: 0px; position: relative; word-break: break-all; width: 120px; color: gray; float: left; overflow-wrap: break-word; display: inline !important;">Yakıt Tipi</span><a class="data" href="https://www.n11.com/beyaz-esya/isitma-ve-sogutma/sofben?sbt=Elektrikli" style="margin: 0px -2px 0px 0px; padding: 0px; border: 0px; position: relative; outline: 0px; cursor: pointer; color: rgb(0, 102, 204); display: inline-block; word-break: break-all; overflow: hidden;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative; word-break: break-all;">Elektrikli</span></a></div></div></section><section class="tabPanelItem productHistories" style="position: relative; cursor: pointer; clear: both; padding: 40px 5px 0px; overflow: hidden; color: rgb(32, 32, 32); font-family: Arial, Helvetica, sans-serif; font-size: 12px;"><h4 class="title" style="margin-right: -5px; margin-bottom: 15px; margin-left: -5px; padding: 0px; border: 0px; font-size: 16px; position: relative; background: rgb(242, 242, 242); font-weight: 700; line-height: 30px; text-indent: 10px; color: rgb(237, 29, 38);">Fiyat Takibi<div class="accordion-arrow active" style="margin: 0px; padding: 0px; border: 0px; position: absolute; width: 14px; height: 9px; display: inline-block; background: url(&quot;../../img/layout/downArrow.svg&quot;) center center no-repeat; right: 17px; top: 10px; cursor: pointer;"></div></h4></section><section class="tabPanelItem details" style="clear: both; padding: 40px 5px 0px; overflow: hidden; color: rgb(32, 32, 32); font-family: Arial, Helvetica, sans-serif; font-size: 12px;"><h4 class="title" style="margin-right: -5px; margin-bottom: 15px; margin-left: -5px; padding: 0px; border: 0px; font-size: 16px; position: relative; background: rgb(242, 242, 242); font-weight: 700; line-height: 30px; text-indent: 10px;">Ayrıntılar</h4><div style="margin: 0px; padding: 0px; border: 0px; position: relative; overflow: hidden;"><div style="margin: 0px; padding: 0px 10px; border: 0px; position: relative;"><div style="margin: 0px; padding: 0px; border: 0px; position: relative;"><table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin: 0px; padding: 0px; border: 0px; position: relative; border-spacing: 0px;"><tbody style="margin: 0px; padding: 0px; border: 0px; position: relative;"><tr style="margin: 0px; padding: 0px; border: 0px; position: relative;"><td style="margin: 0px; padding: 0px; border: 0px; position: relative;"><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">Ürün Boyutu</strong></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;"><br></strong></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">En&nbsp;</strong></span></span>&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;">: 21,5 cm&nbsp; &nbsp;&nbsp;</span></span>&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">Boy</strong></span></span>&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;">&nbsp;: 27,5 cm&nbsp; &nbsp;&nbsp;</span></span>&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">Derinlik</strong></span></span>&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;">&nbsp;: 11 cm</span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><br></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">T<span style="margin: 0px; padding: 0px; border: 0px; position: relative;">eknik Özellikleri</span></strong></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">*&nbsp;<strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">8000 watt ile 9000 watt özel düfüzyonlu rezistans</strong></strong></span></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">* Campolyamid cam elyaf karışımlı hammadde 170 dereceye kadar dayanmaktadır.</strong></strong></span></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">* Dış ABS malzemeden imal edilmiştir.</strong></strong></span></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">* 2 yıl garantilidir.</strong></strong></span></span></span></p><p style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><span style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;"><strong style="margin: 0px; padding: 0px; border: 0px; position: relative;">* Avrupa Altın kalite ödüllü dünyanın ilk elektrikli şohbenidir</strong></strong></span></span></span></p></td></tr></tbody></table></div></div><div style="margin: 0px; padding: 0px 10px; border: 0px; position: relative;"><div style="margin: 15px 0px; padding: 0px 10px; border: 0px; position: relative;"></div></div></div></section><section class="tabPanelItem delInfo" style="clear: both; padding: 40px 5px 0px; overflow: hidden; color: rgb(32, 32, 32); font-family: Arial, Helvetica, sans-serif; font-size: 12px;"><h4 class="title" style="margin-right: -5px; margin-bottom: 15px; margin-left: -5px; padding: 0px; border: 0px; font-size: 16px; position: relative; background: rgb(242, 242, 242); font-weight: 700; line-height: 30px; text-indent: 10px;">Teslimat Bilgileri</h4></section>', N'suyika-sampiyon-plus-sofben')
SET IDENTITY_INSERT [dbo].[Urunler] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [UserName], [Password], [Name]) VALUES (2, N'admin', N'3a4218d82a8ccecc6f9ff75c091a210b', N'Zehra Karahan')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Uyeler] ON 

INSERT [dbo].[Uyeler] ([ID], [Adi], [Soyadi], [Email], [Sifre]) VALUES (1014, N'Zehra', N'Karahan', N'zehra@selcuk.edu.tr', N'827ccb0eea8a706c4c34a16891f84e7b')
SET IDENTITY_INSERT [dbo].[Uyeler] OFF
SET IDENTITY_INSERT [dbo].[Yorumlar] ON 

INSERT [dbo].[Yorumlar] ([ID], [UrunID], [UyeID], [Yorum], [Puan], [Onay]) VALUES (1002, 1002, 1014, N'Aldım çok memnunum', 5, 1)
SET IDENTITY_INSERT [dbo].[Yorumlar] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Kuponlar]    Script Date: 26.01.2019 17:08:13 ******/
ALTER TABLE [dbo].[Kuponlar] ADD  CONSTRAINT [IX_Kuponlar] UNIQUE NONCLUSTERED 
(
	[Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_UserName_Users]    Script Date: 26.01.2019 17:08:13 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UK_UserName_Users] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Uyeler]    Script Date: 26.01.2019 17:08:13 ******/
ALTER TABLE [dbo].[Uyeler] ADD  CONSTRAINT [IX_Uyeler] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_Goruntulenme]  DEFAULT ((1)) FOR [Goruntulenme]
GO
ALTER TABLE [dbo].[Ilceler]  WITH CHECK ADD  CONSTRAINT [FK_Ilceler_Sehirler] FOREIGN KEY([ID])
REFERENCES [dbo].[Sehirler] ([ID])
GO
ALTER TABLE [dbo].[Ilceler] CHECK CONSTRAINT [FK_Ilceler_Sehirler]
GO
ALTER TABLE [dbo].[Kategoriler]  WITH CHECK ADD  CONSTRAINT [FK_Kategoriler_Kategoriler] FOREIGN KEY([UstID])
REFERENCES [dbo].[Kategoriler] ([ID])
GO
ALTER TABLE [dbo].[Kategoriler] CHECK CONSTRAINT [FK_Kategoriler_Kategoriler]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Kategoriler] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategoriler] ([ID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Kategoriler]
GO
ALTER TABLE [dbo].[UyeAdres]  WITH CHECK ADD  CONSTRAINT [FK_UyeAdres_Ilceler] FOREIGN KEY([IlceID])
REFERENCES [dbo].[Ilceler] ([ID])
GO
ALTER TABLE [dbo].[UyeAdres] CHECK CONSTRAINT [FK_UyeAdres_Ilceler]
GO
ALTER TABLE [dbo].[UyeAdres]  WITH CHECK ADD  CONSTRAINT [FK_UyeAdres_Sehirler] FOREIGN KEY([SehirID])
REFERENCES [dbo].[Sehirler] ([ID])
GO
ALTER TABLE [dbo].[UyeAdres] CHECK CONSTRAINT [FK_UyeAdres_Sehirler]
GO
ALTER TABLE [dbo].[Yorumlar]  WITH CHECK ADD  CONSTRAINT [FK_Yorumlar_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[Yorumlar] CHECK CONSTRAINT [FK_Yorumlar_Urunler]
GO
ALTER TABLE [dbo].[Yorumlar]  WITH CHECK ADD  CONSTRAINT [FK_Yorumlar_Uyeler] FOREIGN KEY([UyeID])
REFERENCES [dbo].[Uyeler] ([ID])
GO
ALTER TABLE [dbo].[Yorumlar] CHECK CONSTRAINT [FK_Yorumlar_Uyeler]
GO
