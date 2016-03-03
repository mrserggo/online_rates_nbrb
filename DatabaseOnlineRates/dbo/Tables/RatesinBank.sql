CREATE TABLE [dbo].[RatesinBank](
	[RateBankId] [int] IDENTITY(1,1) NOT NULL,
	[IdBank] [int] NOT NULL,
	[USD_Buying] [float] NOT NULL,
	[USD_Selling] [float] NOT NULL,
	[EUR_Buying] [float] NOT NULL,
	[EUR_Selling] [float] NOT NULL,
	[RUB_Buying] [float] NOT NULL,
	[RUB_Selling] [float] NOT NULL,
	[DateofRate] [datetime] NOT NULL,
 CONSTRAINT [PK_RatesinBank] PRIMARY KEY CLUSTERED 
(
	[RateBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[RatesinBank]  WITH CHECK ADD  CONSTRAINT [FK_RatesinBank_Bank] FOREIGN KEY([IdBank])
REFERENCES [dbo].[Bank] ([BankId])
GO

ALTER TABLE [dbo].[RatesinBank] CHECK CONSTRAINT [FK_RatesinBank_Bank]