USE [OT_Assessment_DB]
GO

ALTER TABLE [dbo].[Player] DROP CONSTRAINT [DF_Player_AccountId]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 9/14/2024 11:27:41 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Player]') AND type in (N'U'))
DROP TABLE [dbo].[Player]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 9/14/2024 11:27:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Username] [nchar](10) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_AccountId]  DEFAULT (newid()) FOR [AccountId]
GO

