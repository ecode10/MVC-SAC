USE [iSAC]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[CHUsu] [int] IDENTITY(1,1) NOT NULL,
	[NOUsu] [nvarchar](max) NOT NULL,
	[EMUsu] [nvarchar](max) NOT NULL,
	[DTNascUsu] [datetime] NOT NULL,
	[CHSite] [int] NOT NULL,
	[PWUsu] [nvarchar](300) NULL,
	[PerfilUsu] [char](1) NULL,
 CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED 
(
	[CHUsu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[CHPais] [bigint] IDENTITY(1,1) NOT NULL,
	[NOPais] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[CHPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estadoes]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estadoes](
	[CHEstado] [bigint] IDENTITY(1,1) NOT NULL,
	[CHPais] [bigint] NOT NULL,
	[NOEstado] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[CHEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cidades]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cidades](
	[CHCidade] [bigint] IDENTITY(1,1) NOT NULL,
	[CHEstado] [bigint] NOT NULL,
	[NOCidade] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[CHCidade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chamadoes]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chamadoes](
	[CHChamado] [int] IDENTITY(1,1) NOT NULL,
	[TITChamado] [nvarchar](50) NOT NULL,
	[DESCChamado] [nvarchar](4000) NOT NULL,
	[DTChamado] [date] NOT NULL,
	[SITChamado] [char](1) NOT NULL,
	[CHUsu] [int] NOT NULL,
 CONSTRAINT [PK_Chamado] PRIMARY KEY CLUSTERED 
(
	[CHChamado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sites]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sites](
	[CHSite] [int] IDENTITY(1,1) NOT NULL,
	[NOSite] [nvarchar](max) NOT NULL,
	[SITSite] [nvarchar](max) NOT NULL,
	[Usuario_CHUsu] [int] NULL,
 CONSTRAINT [PK_dbo.Sites] PRIMARY KEY CLUSTERED 
(
	[CHSite] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respostas]    Script Date: 01/14/2013 18:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respostas](
	[CHRes] [int] IDENTITY(1,1) NOT NULL,
	[DESCRes] [nvarchar](4000) NOT NULL,
	[DTRes] [date] NOT NULL,
	[CHUsu] [int] NOT NULL,
	[CHChamado] [int] NOT NULL,
 CONSTRAINT [PK_Resposta] PRIMARY KEY CLUSTERED 
(
	[CHRes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Chamado_Usuarios]    Script Date: 01/14/2013 18:17:21 ******/
ALTER TABLE [dbo].[Chamadoes]  WITH CHECK ADD  CONSTRAINT [FK_Chamado_Usuarios] FOREIGN KEY([CHUsu])
REFERENCES [dbo].[Usuarios] ([CHUsu])
GO
ALTER TABLE [dbo].[Chamadoes] CHECK CONSTRAINT [FK_Chamado_Usuarios]
GO
/****** Object:  ForeignKey [FK_Resposta_Usuarios]    Script Date: 01/14/2013 18:17:21 ******/
ALTER TABLE [dbo].[Respostas]  WITH CHECK ADD  CONSTRAINT [FK_Resposta_Usuarios] FOREIGN KEY([CHUsu])
REFERENCES [dbo].[Usuarios] ([CHUsu])
GO
ALTER TABLE [dbo].[Respostas] CHECK CONSTRAINT [FK_Resposta_Usuarios]
GO
/****** Object:  ForeignKey [FK_Respostas_Chamadoes]    Script Date: 01/14/2013 18:17:21 ******/
ALTER TABLE [dbo].[Respostas]  WITH CHECK ADD  CONSTRAINT [FK_Respostas_Chamadoes] FOREIGN KEY([CHChamado])
REFERENCES [dbo].[Chamadoes] ([CHChamado])
GO
ALTER TABLE [dbo].[Respostas] CHECK CONSTRAINT [FK_Respostas_Chamadoes]
GO
/****** Object:  ForeignKey [FK_dbo.Sites_dbo.Usuarios_Usuario_CHUsu]    Script Date: 01/14/2013 18:17:21 ******/
ALTER TABLE [dbo].[Sites]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sites_dbo.Usuarios_Usuario_CHUsu] FOREIGN KEY([Usuario_CHUsu])
REFERENCES [dbo].[Usuarios] ([CHUsu])
GO
ALTER TABLE [dbo].[Sites] CHECK CONSTRAINT [FK_dbo.Sites_dbo.Usuarios_Usuario_CHUsu]
GO
