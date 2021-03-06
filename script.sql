USE [WOW_GAMES]
GO
/****** Object:  Table [dbo].[Balance]    Script Date: 17/05/2019 09:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Balance](
	[BalanceId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 2) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK__Balance__A760D5BE224278C0] PRIMARY KEY CLUSTERED 
(
	[BalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PARTNER]    Script Date: 17/05/2019 09:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PARTNER](
	[PartnerId] [int] NOT NULL,
	[Partner] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PURCHASE]    Script Date: 17/05/2019 09:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PURCHASE](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[Serial] [varchar](50) NOT NULL,
	[Token] [varchar](50) NOT NULL,
	[SuggestedSalePrice] [varchar](50) NOT NULL,
	[PaidPrice] [varchar](50) NOT NULL,
	[PartnerId] [int] NOT NULL,
	[Sku] [varchar](50) NOT NULL,
 CONSTRAINT [PK__PURCHASE__6B0A6BBE975BD560] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Balance] ON 

INSERT [dbo].[Balance] ([BalanceId], [Amount], [Date]) VALUES (3, CAST(300.00 AS Decimal(18, 2)), CAST(N'2019-04-17T08:29:31.207' AS DateTime))
INSERT [dbo].[Balance] ([BalanceId], [Amount], [Date]) VALUES (4, CAST(-15.37 AS Decimal(18, 2)), CAST(N'2019-04-17T08:29:45.960' AS DateTime))
INSERT [dbo].[Balance] ([BalanceId], [Amount], [Date]) VALUES (5, CAST(8.79 AS Decimal(18, 2)), CAST(N'2019-04-17T08:30:02.780' AS DateTime))
INSERT [dbo].[Balance] ([BalanceId], [Amount], [Date]) VALUES (6, CAST(200.89 AS Decimal(18, 2)), CAST(N'2019-04-17T10:28:36.670' AS DateTime))
SET IDENTITY_INSERT [dbo].[Balance] OFF
INSERT [dbo].[PARTNER] ([PartnerId], [Partner]) VALUES (1, N'RIXTY')
SET IDENTITY_INSERT [dbo].[PURCHASE] ON 

INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (1, CAST(N'2019-03-15T16:39:23.360' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10.00', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (2, CAST(N'2019-04-16T08:27:35.287' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (3, CAST(N'2019-04-16T08:27:35.713' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (4, CAST(N'2019-04-16T08:27:36.100' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (5, CAST(N'2019-04-16T08:27:36.333' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (6, CAST(N'2019-04-16T08:27:36.587' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (7, CAST(N'2019-04-16T08:27:36.787' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (8, CAST(N'2019-04-16T08:27:36.990' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (9, CAST(N'2019-04-16T08:27:37.140' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (10, CAST(N'2019-04-16T08:27:37.660' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (11, CAST(N'2019-04-16T08:27:37.773' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (12, CAST(N'2019-04-16T08:27:37.863' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (13, CAST(N'2019-04-16T08:27:37.953' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (14, CAST(N'2019-04-16T08:27:38.057' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (15, CAST(N'2019-04-16T08:27:38.143' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (16, CAST(N'2019-04-16T08:27:38.250' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (17, CAST(N'2019-04-16T08:27:38.350' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (18, CAST(N'2019-04-16T08:27:38.440' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (19, CAST(N'2019-04-16T08:27:38.567' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (20, CAST(N'2019-04-16T08:27:38.677' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (21, CAST(N'2019-04-16T08:27:38.777' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (22, CAST(N'2019-04-16T08:27:38.887' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (23, CAST(N'2019-04-16T08:27:39.023' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (24, CAST(N'2019-04-16T08:27:39.163' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (25, CAST(N'2019-04-16T08:27:39.283' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (26, CAST(N'2019-04-16T08:27:39.417' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (27, CAST(N'2019-04-16T08:27:39.527' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (28, CAST(N'2019-04-16T08:27:39.640' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (29, CAST(N'2019-04-16T08:27:39.777' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
INSERT [dbo].[PURCHASE] ([PurchaseId], [PurchaseDate], [Serial], [Token], [SuggestedSalePrice], [PaidPrice], [PartnerId], [Sku]) VALUES (30, CAST(N'2019-04-16T08:27:39.880' AS DateTime), N'1ROGESP3MD85W1', N'6658-2191-8727-8063', N'10', N'9.40', 1, N'RXT-01000-BRL-P')
SET IDENTITY_INSERT [dbo].[PURCHASE] OFF
ALTER TABLE [dbo].[PURCHASE]  WITH CHECK ADD  CONSTRAINT [FK__PURCHASE__Partne__276EDEB3] FOREIGN KEY([PartnerId])
REFERENCES [dbo].[PARTNER] ([PartnerId])
GO
ALTER TABLE [dbo].[PURCHASE] CHECK CONSTRAINT [FK__PURCHASE__Partne__276EDEB3]
GO
/****** Object:  StoredProcedure [dbo].[GET_BALANCE]    Script Date: 17/05/2019 09:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_BALANCE]
@DAYS INT = 0
AS
BEGIN
	CREATE TABLE #BALANCE (RID INT, DATE DATETIME, AMOUNT DECIMAL(18,2), [DESC] VARCHAR(500))

	INSERT INTO #BALANCE
	SELECT ROW_NUMBER() OVER (ORDER BY DATE) AS RID,*
			FROM 
			(
			SELECT PurchaseDate AS DATE,CAST(PaidPrice AS DECIMAL(18,2))* -1 AS AMOUNT, Sku AS [DESC] FROM PURCHASE
			UNION ALL
			SELECT DATE,AMOUNT ,
			CASE WHEN AMOUNT > 0 THEN 'Crédito' ELSE 'Débito' END AS  [DESC]
			FROM BALANCE
			) UN


	SELECT * FROM 
	(SELECT A.RID,a.DATE, a.AMOUNT, (SELECT SUM(b.AMOUNT)
						   FROM #BALANCE b
						   WHERE b.RID <= a.RID
						  ) AS BALANCE,A.[DESC]
	FROM  #BALANCE a
	) X
	WHERE X.DATE >= GETDATE() - @DAYS
	ORDER BY RID DESC
	DROP TABLE #BALANCE
END
GO
