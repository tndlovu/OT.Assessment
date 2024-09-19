USE [OT_Assessment_DB]
GO

ALTER TABLE [dbo].[Player] DROP CONSTRAINT [DF_Player_AccountId]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Player]') AND type in (N'U'))
DROP TABLE [dbo].[Player]
GO

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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WagerEvent]') AND type in (N'U'))
DROP TABLE [dbo].[WagerEvent]
GO

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
USE [OT_Assessment_DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


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



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


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

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


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


