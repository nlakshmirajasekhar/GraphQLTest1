USE [ShopInventory1]
GO
/****** Object:  Table [dbo].[itemgroups]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemgroups](
	[grpid] [int] IDENTITY(1,100) NOT NULL,
	[grpname] [varchar](50) NULL,
	[maingrp] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[grpid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[itemid] [int] IDENTITY(1,10) NOT NULL,
	[itemname] [varchar](50) NULL,
	[grpid] [int] NULL,
	[uom] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materialmanagement]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materialmanagement](
	[transno] [int] IDENTITY(1,10000) NOT NULL,
	[sno] [int] NULL,
	[itemid] [int] NULL,
	[traid] [int] NULL,
	[tratype] [int] NULL,
	[qtyin] [int] NULL,
	[qtyout] [int] NULL,
	[rat] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[transno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pricelist]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pricelist](
	[itemid] [int] NOT NULL,
	[rat] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchasesheader]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchasesheader](
	[mir] [int] NOT NULL,
	[purchesesdate] [datetime] NULL,
	[supplier] [varchar](100) NULL,
	[mobile] [varchar](50) NULL,
	[baseamt] [float] NULL,
	[taxes] [float] NULL,
	[discount] [float] NULL,
	[totamt] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[mir] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchaseslines]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchaseslines](
	[mir] [int] NOT NULL,
	[sno] [int] NOT NULL,
	[pitem] [int] NULL,
	[qty] [int] NULL,
	[rat] [float] NULL,
	[itemno] [int] NULL,
 CONSTRAINT [cominationpk] PRIMARY KEY CLUSTERED 
(
	[mir] ASC,
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salesheader]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salesheader](
	[billno] [int] NOT NULL,
	[salesdate] [datetime] NULL,
	[cname] [varchar](100) NULL,
	[mobile] [varchar](50) NULL,
	[baseamt] [float] NULL,
	[taxes] [float] NULL,
	[discount] [float] NULL,
	[totamt] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[billno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[saleslines]    Script Date: 21-04-2021 08:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saleslines](
	[billno] [int] NOT NULL,
	[sno] [int] NOT NULL,
	[itemname] [int] NULL,
	[qty] [int] NULL,
	[rat] [float] NULL,
 CONSTRAINT [comination] PRIMARY KEY CLUSTERED 
(
	[billno] ASC,
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[purchasesheader] ADD  DEFAULT ('0') FOR [discount]
GO
ALTER TABLE [dbo].[salesheader] ADD  DEFAULT ('0') FOR [discount]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD FOREIGN KEY([grpid])
REFERENCES [dbo].[itemgroups] ([grpid])
GO
ALTER TABLE [dbo].[materialmanagement]  WITH CHECK ADD FOREIGN KEY([itemid])
REFERENCES [dbo].[items] ([itemid])
GO
ALTER TABLE [dbo].[pricelist]  WITH CHECK ADD  CONSTRAINT [item] FOREIGN KEY([itemid])
REFERENCES [dbo].[items] ([itemid])
GO
ALTER TABLE [dbo].[pricelist] CHECK CONSTRAINT [item]
GO
ALTER TABLE [dbo].[purchaseslines]  WITH CHECK ADD FOREIGN KEY([itemno])
REFERENCES [dbo].[items] ([itemid])
GO
ALTER TABLE [dbo].[purchaseslines]  WITH CHECK ADD FOREIGN KEY([mir])
REFERENCES [dbo].[purchasesheader] ([mir])
GO
ALTER TABLE [dbo].[saleslines]  WITH CHECK ADD FOREIGN KEY([billno])
REFERENCES [dbo].[salesheader] ([billno])
GO
ALTER TABLE [dbo].[saleslines]  WITH CHECK ADD  CONSTRAINT [itemname] FOREIGN KEY([itemname])
REFERENCES [dbo].[pricelist] ([itemid])
GO
ALTER TABLE [dbo].[saleslines] CHECK CONSTRAINT [itemname]
GO
