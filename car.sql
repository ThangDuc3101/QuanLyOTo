USE [quanlyxe]
GO
/****** Object:  Table [dbo].[tbl_car]    Script Date: 5/1/2022 9:14:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_car](
	[Id] [int] NOT NULL,
	[name] [varchar](2550) NULL,
	[number] [int] NULL,
	[original] [varchar](20) NULL,
	[price] [decimal](18, 0) NULL,
	[daBan] [int] NULL,
	[conLai] [int] NULL
) ON [PRIMARY]
GO
