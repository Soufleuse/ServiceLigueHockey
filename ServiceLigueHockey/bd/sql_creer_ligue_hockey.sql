USE [master]
GO

/****** Object:  Database [LigueHockey]    Script Date: 2021-03-15 18:44:14 ******/
CREATE DATABASE [LigueHockey]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LigueHockey', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LigueHockey.mdf' , SIZE = 81920KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LigueHockey_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LigueHockey_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LigueHockey].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LigueHockey] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LigueHockey] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LigueHockey] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LigueHockey] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LigueHockey] SET ARITHABORT OFF 
GO

ALTER DATABASE [LigueHockey] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LigueHockey] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LigueHockey] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LigueHockey] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LigueHockey] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LigueHockey] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LigueHockey] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LigueHockey] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LigueHockey] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LigueHockey] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LigueHockey] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LigueHockey] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LigueHockey] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LigueHockey] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LigueHockey] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LigueHockey] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LigueHockey] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LigueHockey] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [LigueHockey] SET  MULTI_USER 
GO

ALTER DATABASE [LigueHockey] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LigueHockey] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LigueHockey] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LigueHockey] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [LigueHockey] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [LigueHockey] SET QUERY_STORE = OFF
GO

ALTER DATABASE [LigueHockey] SET  READ_WRITE 
GO

-- Commandes pour créer les tables
USE [LigueHockey]
GO

/****** Object:  Table [dbo].[Equipe]    Script Date: 2021-03-15 18:46:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Equipe](
	[No_Equipe] [int] NOT NULL,
	[Nom_Equipe] [varchar](50) NOT NULL,
	[Ville] [varchar](50) NOT NULL,
	[Annee_debut] [int] NOT NULL,
	[Annee_fin] [int] NULL,
	[Est_Devenue_Equipe] [int] NULL,
 CONSTRAINT [PK_Equipe] PRIMARY KEY CLUSTERED 
(
	[No_Equipe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CU_Equipe] UNIQUE NONCLUSTERED 
(
	[Nom_Equipe] ASC,
	[Ville] ASC,
	[Annee_debut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'S''assurer de ne pas avoir deux équipes avec le même nom/ville/année de début.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipe', @level2type=N'CONSTRAINT',@level2name=N'CU_Equipe'
GO

CREATE TABLE [dbo].[Joueur](
	[No_Joueur] [int] NOT NULL,
	[Prenom] [varchar](50) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Date_Naissance] [date] NOT NULL,
	[ville_naissance] [varchar](50) NOT NULL,
	[pays_origine] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Joueur] PRIMARY KEY CLUSTERED 
(
	[No_Joueur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CU_Joueur] UNIQUE NONCLUSTERED 
(
	[Prenom] ASC,
	[Nom] ASC,
	[Date_Naissance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'S''assurer de ne pas avoir deux joueurs avec le même nom/prénom/date de naissance.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Joueur', @level2type=N'CONSTRAINT',@level2name=N'CU_Joueur'
GO

CREATE TABLE [dbo].[equipe_joueur](
	[no_equipe] [int] NOT NULL,
	[no_joueur] [int] NOT NULL,
	[date_debut_avec_equipe] [date] NOT NULL,
	[date_fin_avec_equipe] [nchar](10) NULL,
	[no_dossard] [smallint] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[equipe_joueur]  WITH CHECK ADD  CONSTRAINT [FK_equipe_joueur_Equipe] FOREIGN KEY([no_equipe])
REFERENCES [dbo].[Equipe] ([No_Equipe])
GO

ALTER TABLE [dbo].[equipe_joueur] CHECK CONSTRAINT [FK_equipe_joueur_Equipe]
GO

ALTER TABLE [dbo].[equipe_joueur]  WITH CHECK ADD  CONSTRAINT [FK_equipe_joueur_Joueur] FOREIGN KEY([no_joueur])
REFERENCES [dbo].[Joueur] ([No_Joueur])
GO

ALTER TABLE [dbo].[equipe_joueur] CHECK CONSTRAINT [FK_equipe_joueur_Joueur]
GO

