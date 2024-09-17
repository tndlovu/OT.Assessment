USE [OT_Assessment_DB]
GO

/****** Object:  Table [dbo].[WagerEvent2]    Script Date: 9/14/2024 12:07:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WagerEvent]') AND type in (N'U'))
DROP TABLE [dbo].[WagerEvent]
GO

/****** Object:  Table [dbo].[WagerEvent2]    Script Date: 9/14/2024 12:07:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WagerEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WagerId] [uniqueidentifier] NOT NULL,
	[Theme] [nchar](50) NULL,
	[Provider] [nchar](50) NULL,
	[GameName] [nchar](50) NULL,
	[TransactionId] [uniqueidentifier] NOT NULL,
	[BrandId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Username] [nchar](50) NULL,
	[ExternalReferenceId] [uniqueidentifier] NOT NULL,
	[TransactionTypeId] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 10) NULL,
	[CreatedDateTime] [datetimeoffset](7) NOT NULL,
	[NumberOfBets] [smallint] NOT NULL,
	[CountryCode] [nchar](10) NOT NULL,
	[SessionData] [varchar](max) NULL,
	[Duration] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


