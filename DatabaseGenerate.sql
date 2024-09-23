USE [OT_Assessment_DB]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 9/24/2024 1:05:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Username] [nchar](50) NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY NONCLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Povider]    Script Date: 9/24/2024 1:05:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Povider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PoviderId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WagerEvent]    Script Date: 9/24/2024 1:05:49 AM ******/
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
ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_AccountId]  DEFAULT (newid()) FOR [AccountId]
GO
ALTER TABLE [dbo].[Povider] ADD  CONSTRAINT [DF_Povider_PoviderId]  DEFAULT (newid()) FOR [PoviderId]
GO
/****** Object:  StoredProcedure [dbo].[AddPlayer]    Script Date: 9/24/2024 1:05:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[AddPlayer] 
	-- Add the parameters for the stored procedure here
	@accountId uniqueidentifier, 
	@Username varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Player]
           ([AccountId],[Username])
     VALUES
           (@accountId,@Username)
END
GO
/****** Object:  StoredProcedure [dbo].[AddPlayerWager]    Script Date: 9/24/2024 1:05:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Thulani Ndlovu>
-- Create date: <Create Date,2024-09-14>
-- Description:	<Description,Inserts records of wagers a player has participated on>
-- =============================================
CREATE PROCEDURE  [dbo].[AddPlayerWager] 
	 @WagerId uniqueidentifier
	,@Theme nchar(50)
	,@Provider nchar (50)
	,@GameName nchar (50)
	,@TransactionId uniqueidentifier
	,@BrandId uniqueidentifier
	,@AccountId uniqueidentifier
	,@Username nchar (50)
	,@ExternalReferenceId uniqueidentifier
	,@TransactionTypeId uniqueidentifier
	,@Amount decimal(18,10)
	,@CreatedDateTime datetimeoffset
	,@NumberOfBets smallint
	,@CountryCode nchar(10)
	,@SessionData varchar (max)
	,@Duration bigint
AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO [dbo].[WagerEvent]
           ([WagerId]
           ,[Theme]
           ,[Provider]
           ,[GameName]
           ,[TransactionId]
           ,[BrandId]
           ,[AccountId]
           ,[Username]
           ,[ExternalReferenceId]
           ,[TransactionTypeId]
           ,[Amount]
           ,[CreatedDateTime]
           ,[NumberOfBets]
           ,[CountryCode]
           ,[SessionData]
           ,[Duration])
     VALUES
           (@WagerId
           ,@Theme
           ,@Provider
           ,@GameName
           ,@TransactionId
           ,@BrandId
           ,@AccountId
           ,@Username
           ,@ExternalReferenceId
           ,@TransactionTypeId
           ,@Amount
           ,@CreatedDateTime
           ,@NumberOfBets
           ,@CountryCode
           ,@SessionData
           ,@Duration
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[TopSpenders]    Script Date: 9/24/2024 1:05:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Thulani Ndlovu>
-- Create date: <Create Date,2024-09-14>
-- Description:	<Description,Inserts records of wagers a player has participated on>
-- =============================================
CREATE PROCEDURE  [dbo].[TopSpenders] 

	@numberOfPlayers int
	
AS
BEGIN

SET NOCOUNT ON;

SELECT TOP (@numberOfPlayers) [AccountId],[UserName],SUM([Amount]) as Amount
FROM [dbo].[WagerEvent]
Group By  [AccountId],[UserName]
Order by [UserName] asc
END
GO
