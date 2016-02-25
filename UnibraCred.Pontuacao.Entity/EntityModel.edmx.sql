
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2016 20:22:38
-- Generated from EDMX file: C:\Users\Mario\Documents\Visual Studio 2012\Projects\Unibracredv4\trunk\UnibraCred.Pontuacao.Entity\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Unibracred3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Pontuacao_TaxaConversao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PontuacaoFatura] DROP CONSTRAINT [FK_Pontuacao_TaxaConversao];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DebitoPontos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DebitoPontos];
GO
IF OBJECT_ID(N'[dbo].[PontuacaoFatura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PontuacaoFatura];
GO
IF OBJECT_ID(N'[dbo].[TaxaConversao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaxaConversao];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DebitoPontos'
CREATE TABLE [dbo].[DebitoPontos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fatura_id] int  NOT NULL,
    [cartao_id] int  NOT NULL,
    [pontosQtd] int  NOT NULL,
    [dtUtilizacao] datetime  NOT NULL
);
GO

-- Creating table 'PontuacaoFatura'
CREATE TABLE [dbo].[PontuacaoFatura] (
    [id] int IDENTITY(1,1) NOT NULL,
    [taxaConversao_id] int  NOT NULL,
    [fatura_id] int  NOT NULL,
    [pontosQtd] int  NOT NULL,
    [cartao_id] int  NOT NULL,
    [dtInclusao] datetime2  NOT NULL,
    [dtVigencia] datetime2  NOT NULL
);
GO

-- Creating table 'TaxaConversao'
CREATE TABLE [dbo].[TaxaConversao] (
    [id] int IDENTITY(1,1) NOT NULL,
    [taxaValor] decimal(10,2)  NOT NULL,
    [dtInclusao] datetime  NOT NULL,
    [dtVigencia] datetime  NOT NULL,
    [diasValidade] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'DebitoPontos'
ALTER TABLE [dbo].[DebitoPontos]
ADD CONSTRAINT [PK_DebitoPontos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PontuacaoFatura'
ALTER TABLE [dbo].[PontuacaoFatura]
ADD CONSTRAINT [PK_PontuacaoFatura]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TaxaConversao'
ALTER TABLE [dbo].[TaxaConversao]
ADD CONSTRAINT [PK_TaxaConversao]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [taxaConversao_id] in table 'PontuacaoFatura'
ALTER TABLE [dbo].[PontuacaoFatura]
ADD CONSTRAINT [FK_Pontuacao_TaxaConversao]
    FOREIGN KEY ([taxaConversao_id])
    REFERENCES [dbo].[TaxaConversao]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pontuacao_TaxaConversao'
CREATE INDEX [IX_FK_Pontuacao_TaxaConversao]
ON [dbo].[PontuacaoFatura]
    ([taxaConversao_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------