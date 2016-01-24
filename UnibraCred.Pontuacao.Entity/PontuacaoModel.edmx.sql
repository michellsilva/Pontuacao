
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2016 12:11:28
-- Generated from EDMX file: C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao\trunk\UnibraCred.Pontuacao\UnibraCred.Pontuacao.Entity\PontuacaoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PontuacaoTaxaConversao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PontuacaoSet] DROP CONSTRAINT [FK_PontuacaoTaxaConversao];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PontuacaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PontuacaoSet];
GO
IF OBJECT_ID(N'[dbo].[TaxaConversaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaxaConversaoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PontuacaoSet'
CREATE TABLE [dbo].[PontuacaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tipo] int  NOT NULL,
    [Validade] datetime  NOT NULL,
    [FaturaId] int  NOT NULL,
    [PontosQtd] float  NOT NULL,
    [TaxaConversaoId] int  NOT NULL
);
GO

-- Creating table 'TaxaConversaoSet'
CREATE TABLE [dbo].[TaxaConversaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TaxaValor] decimal(18,0)  NOT NULL,
    [DataInicioVigencia] datetime  NOT NULL,
    [DataInclusao] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PontuacaoSet'
ALTER TABLE [dbo].[PontuacaoSet]
ADD CONSTRAINT [PK_PontuacaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaxaConversaoSet'
ALTER TABLE [dbo].[TaxaConversaoSet]
ADD CONSTRAINT [PK_TaxaConversaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TaxaConversaoId] in table 'PontuacaoSet'
ALTER TABLE [dbo].[PontuacaoSet]
ADD CONSTRAINT [FK_PontuacaoTaxaConversao]
    FOREIGN KEY ([TaxaConversaoId])
    REFERENCES [dbo].[TaxaConversaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PontuacaoTaxaConversao'
CREATE INDEX [IX_FK_PontuacaoTaxaConversao]
ON [dbo].[PontuacaoSet]
    ([TaxaConversaoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------