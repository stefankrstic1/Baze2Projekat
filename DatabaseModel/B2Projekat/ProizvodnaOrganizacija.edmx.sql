
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 21:32:53
-- Generated from EDMX file: D:\Fax\baze2\Projekat\DatabaseModel\B2Projekat\ProizvodnaOrganizacija.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SQLBazeProjekat];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PakerPaket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pakets] DROP CONSTRAINT [FK_PakerPaket];
GO
IF OBJECT_ID(N'[dbo].[FK_ProizvodjacProizvodi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodis] DROP CONSTRAINT [FK_ProizvodjacProizvodi];
GO
IF OBJECT_ID(N'[dbo].[FK_MagacionerMagacin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Magacioner] DROP CONSTRAINT [FK_MagacionerMagacin];
GO
IF OBJECT_ID(N'[dbo].[FK_PaketMagacin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pakets] DROP CONSTRAINT [FK_PaketMagacin];
GO
IF OBJECT_ID(N'[dbo].[FK_PaketDostavljac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pakets] DROP CONSTRAINT [FK_PaketDostavljac];
GO
IF OBJECT_ID(N'[dbo].[FK_ProizvodProizvodi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodis] DROP CONSTRAINT [FK_ProizvodProizvodi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProizvodPaket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvods] DROP CONSTRAINT [FK_ProizvodPaket];
GO
IF OBJECT_ID(N'[dbo].[FK_UProizvodnjiMasina]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_UProizvodnji] DROP CONSTRAINT [FK_UProizvodnjiMasina];
GO
IF OBJECT_ID(N'[dbo].[FK_Paker_inherits_Masina]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masinas_Paker] DROP CONSTRAINT [FK_Paker_inherits_Masina];
GO
IF OBJECT_ID(N'[dbo].[FK_Proizvodjac_inherits_Masina]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masinas_Proizvodjac] DROP CONSTRAINT [FK_Proizvodjac_inherits_Masina];
GO
IF OBJECT_ID(N'[dbo].[FK_Magacioner_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Magacioner] DROP CONSTRAINT [FK_Magacioner_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Dostavljac_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Dostavljac] DROP CONSTRAINT [FK_Dostavljac_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_UProizvodnji_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_UProizvodnji] DROP CONSTRAINT [FK_UProizvodnji_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[Masinas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Masinas];
GO
IF OBJECT_ID(N'[dbo].[Magacins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Magacins];
GO
IF OBJECT_ID(N'[dbo].[Pakets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pakets];
GO
IF OBJECT_ID(N'[dbo].[Proizvodis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodis];
GO
IF OBJECT_ID(N'[dbo].[Proizvods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvods];
GO
IF OBJECT_ID(N'[dbo].[Masinas_Paker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Masinas_Paker];
GO
IF OBJECT_ID(N'[dbo].[Masinas_Proizvodjac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Masinas_Proizvodjac];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Magacioner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Magacioner];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Dostavljac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Dostavljac];
GO
IF OBJECT_ID(N'[dbo].[Radniks_UProizvodnji]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_UProizvodnji];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [MBR] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [AdresaStanovanja] nvarchar(max)  NOT NULL,
    [DatumZaposlenja] datetime  NOT NULL,
    [DatumRodjenja] datetime  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Masinas'
CREATE TABLE [dbo].[Masinas] (
    [IDMasina] int IDENTITY(1,1) NOT NULL,
    [Proizvodjac] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [BrzinaRada] int  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Magacins'
CREATE TABLE [dbo].[Magacins] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Kapacitet] int  NOT NULL,
    [Stanje] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pakets'
CREATE TABLE [dbo].[Pakets] (
    [IdPaketa] int IDENTITY(1,1) NOT NULL,
    [PakerIDMasina] int  NOT NULL,
    [MagacinID] int  NOT NULL,
    [Tezina] nvarchar(max)  NOT NULL,
    [DostavljacMBR] int  NULL
);
GO

-- Creating table 'Proizvodis'
CREATE TABLE [dbo].[Proizvodis] (
    [ProizvodjacIDMasina] int  NOT NULL,
    [ProizvodIdProizvoda1] int  NOT NULL
);
GO

-- Creating table 'Proizvods'
CREATE TABLE [dbo].[Proizvods] (
    [IdProizvoda] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Vrsta] nvarchar(max)  NOT NULL,
    [PaketIdPaketa] int  NULL
);
GO

-- Creating table 'Masinas_Paker'
CREATE TABLE [dbo].[Masinas_Paker] (
    [IDMasina] int  NOT NULL
);
GO

-- Creating table 'Masinas_Proizvodjac'
CREATE TABLE [dbo].[Masinas_Proizvodjac] (
    [IDMasina] int  NOT NULL
);
GO

-- Creating table 'Radniks_Magacioner'
CREATE TABLE [dbo].[Radniks_Magacioner] (
    [MagacinID] int  NULL,
    [MBR] int  NOT NULL
);
GO

-- Creating table 'Radniks_UProizvodnji'
CREATE TABLE [dbo].[Radniks_UProizvodnji] (
    [BrojRadnihSati] nvarchar(max)  NOT NULL,
    [MasinaIDMasina] int  NOT NULL,
    [MBR] int  NOT NULL
);
GO

-- Creating table 'Radniks_Dostavljac'
CREATE TABLE [dbo].[Radniks_Dostavljac] (
    [MBR] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MBR] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([MBR] ASC);
GO

-- Creating primary key on [IDMasina] in table 'Masinas'
ALTER TABLE [dbo].[Masinas]
ADD CONSTRAINT [PK_Masinas]
    PRIMARY KEY CLUSTERED ([IDMasina] ASC);
GO

-- Creating primary key on [ID] in table 'Magacins'
ALTER TABLE [dbo].[Magacins]
ADD CONSTRAINT [PK_Magacins]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [IdPaketa] in table 'Pakets'
ALTER TABLE [dbo].[Pakets]
ADD CONSTRAINT [PK_Pakets]
    PRIMARY KEY CLUSTERED ([IdPaketa] ASC);
GO

-- Creating primary key on [ProizvodjacIDMasina], [ProizvodIdProizvoda1] in table 'Proizvodis'
ALTER TABLE [dbo].[Proizvodis]
ADD CONSTRAINT [PK_Proizvodis]
    PRIMARY KEY CLUSTERED ([ProizvodjacIDMasina], [ProizvodIdProizvoda1] ASC);
GO

-- Creating primary key on [IdProizvoda] in table 'Proizvods'
ALTER TABLE [dbo].[Proizvods]
ADD CONSTRAINT [PK_Proizvods]
    PRIMARY KEY CLUSTERED ([IdProizvoda] ASC);
GO

-- Creating primary key on [IDMasina] in table 'Masinas_Paker'
ALTER TABLE [dbo].[Masinas_Paker]
ADD CONSTRAINT [PK_Masinas_Paker]
    PRIMARY KEY CLUSTERED ([IDMasina] ASC);
GO

-- Creating primary key on [IDMasina] in table 'Masinas_Proizvodjac'
ALTER TABLE [dbo].[Masinas_Proizvodjac]
ADD CONSTRAINT [PK_Masinas_Proizvodjac]
    PRIMARY KEY CLUSTERED ([IDMasina] ASC);
GO

-- Creating primary key on [MBR] in table 'Radniks_Magacioner'
ALTER TABLE [dbo].[Radniks_Magacioner]
ADD CONSTRAINT [PK_Radniks_Magacioner]
    PRIMARY KEY CLUSTERED ([MBR] ASC);
GO

-- Creating primary key on [MBR] in table 'Radniks_UProizvodnji'
ALTER TABLE [dbo].[Radniks_UProizvodnji]
ADD CONSTRAINT [PK_Radniks_UProizvodnji]
    PRIMARY KEY CLUSTERED ([MBR] ASC);
GO

-- Creating primary key on [MBR] in table 'Radniks_Dostavljac'
ALTER TABLE [dbo].[Radniks_Dostavljac]
ADD CONSTRAINT [PK_Radniks_Dostavljac]
    PRIMARY KEY CLUSTERED ([MBR] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PakerIDMasina] in table 'Pakets'
ALTER TABLE [dbo].[Pakets]
ADD CONSTRAINT [FK_PakerPaket]
    FOREIGN KEY ([PakerIDMasina])
    REFERENCES [dbo].[Masinas_Paker]
        ([IDMasina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PakerPaket'
CREATE INDEX [IX_FK_PakerPaket]
ON [dbo].[Pakets]
    ([PakerIDMasina]);
GO

-- Creating foreign key on [ProizvodjacIDMasina] in table 'Proizvodis'
ALTER TABLE [dbo].[Proizvodis]
ADD CONSTRAINT [FK_ProizvodjacProizvodi]
    FOREIGN KEY ([ProizvodjacIDMasina])
    REFERENCES [dbo].[Masinas_Proizvodjac]
        ([IDMasina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MagacinID] in table 'Radniks_Magacioner'
ALTER TABLE [dbo].[Radniks_Magacioner]
ADD CONSTRAINT [FK_MagacionerMagacin]
    FOREIGN KEY ([MagacinID])
    REFERENCES [dbo].[Magacins]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MagacionerMagacin'
CREATE INDEX [IX_FK_MagacionerMagacin]
ON [dbo].[Radniks_Magacioner]
    ([MagacinID]);
GO

-- Creating foreign key on [MagacinID] in table 'Pakets'
ALTER TABLE [dbo].[Pakets]
ADD CONSTRAINT [FK_PaketMagacin]
    FOREIGN KEY ([MagacinID])
    REFERENCES [dbo].[Magacins]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaketMagacin'
CREATE INDEX [IX_FK_PaketMagacin]
ON [dbo].[Pakets]
    ([MagacinID]);
GO

-- Creating foreign key on [ProizvodIdProizvoda1] in table 'Proizvodis'
ALTER TABLE [dbo].[Proizvodis]
ADD CONSTRAINT [FK_ProizvodProizvodi]
    FOREIGN KEY ([ProizvodIdProizvoda1])
    REFERENCES [dbo].[Proizvods]
        ([IdProizvoda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProizvodProizvodi'
CREATE INDEX [IX_FK_ProizvodProizvodi]
ON [dbo].[Proizvodis]
    ([ProizvodIdProizvoda1]);
GO

-- Creating foreign key on [PaketIdPaketa] in table 'Proizvods'
ALTER TABLE [dbo].[Proizvods]
ADD CONSTRAINT [FK_ProizvodPaket]
    FOREIGN KEY ([PaketIdPaketa])
    REFERENCES [dbo].[Pakets]
        ([IdPaketa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProizvodPaket'
CREATE INDEX [IX_FK_ProizvodPaket]
ON [dbo].[Proizvods]
    ([PaketIdPaketa]);
GO

-- Creating foreign key on [MasinaIDMasina] in table 'Radniks_UProizvodnji'
ALTER TABLE [dbo].[Radniks_UProizvodnji]
ADD CONSTRAINT [FK_UProizvodnjiMasina]
    FOREIGN KEY ([MasinaIDMasina])
    REFERENCES [dbo].[Masinas]
        ([IDMasina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UProizvodnjiMasina'
CREATE INDEX [IX_FK_UProizvodnjiMasina]
ON [dbo].[Radniks_UProizvodnji]
    ([MasinaIDMasina]);
GO

-- Creating foreign key on [DostavljacMBR] in table 'Pakets'
ALTER TABLE [dbo].[Pakets]
ADD CONSTRAINT [FK_PaketDostavljac]
    FOREIGN KEY ([DostavljacMBR])
    REFERENCES [dbo].[Radniks_Dostavljac]
        ([MBR])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaketDostavljac'
CREATE INDEX [IX_FK_PaketDostavljac]
ON [dbo].[Pakets]
    ([DostavljacMBR]);
GO

-- Creating foreign key on [IDMasina] in table 'Masinas_Paker'
ALTER TABLE [dbo].[Masinas_Paker]
ADD CONSTRAINT [FK_Paker_inherits_Masina]
    FOREIGN KEY ([IDMasina])
    REFERENCES [dbo].[Masinas]
        ([IDMasina])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDMasina] in table 'Masinas_Proizvodjac'
ALTER TABLE [dbo].[Masinas_Proizvodjac]
ADD CONSTRAINT [FK_Proizvodjac_inherits_Masina]
    FOREIGN KEY ([IDMasina])
    REFERENCES [dbo].[Masinas]
        ([IDMasina])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MBR] in table 'Radniks_Magacioner'
ALTER TABLE [dbo].[Radniks_Magacioner]
ADD CONSTRAINT [FK_Magacioner_inherits_Radnik]
    FOREIGN KEY ([MBR])
    REFERENCES [dbo].[Radniks]
        ([MBR])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MBR] in table 'Radniks_UProizvodnji'
ALTER TABLE [dbo].[Radniks_UProizvodnji]
ADD CONSTRAINT [FK_UProizvodnji_inherits_Radnik]
    FOREIGN KEY ([MBR])
    REFERENCES [dbo].[Radniks]
        ([MBR])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MBR] in table 'Radniks_Dostavljac'
ALTER TABLE [dbo].[Radniks_Dostavljac]
ADD CONSTRAINT [FK_Dostavljac_inherits_Radnik]
    FOREIGN KEY ([MBR])
    REFERENCES [dbo].[Radniks]
        ([MBR])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------