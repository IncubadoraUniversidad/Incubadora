
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/25/2022 13:39:20
-- Generated from EDMX file: C:\Users\erikg\source\repos\Incubadora-1\Incubadora.Repository\IncubadoraModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IncubadoraDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetRoleClaims_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserClaims_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserLogins_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserTokens_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[fk_cat_carrera_catua]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatCarreras] DROP CONSTRAINT [fk_cat_carrera_catua];
GO
IF OBJECT_ID(N'[dbo].[fk_cat_carrera_status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatCarreras] DROP CONSTRAINT [fk_cat_carrera_status];
GO
IF OBJECT_ID(N'[dbo].[fk_colab_emprendedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Colaboradores] DROP CONSTRAINT [fk_colab_emprendedor];
GO
IF OBJECT_ID(N'[dbo].[fk_colab_proyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Colaboradores] DROP CONSTRAINT [fk_colab_proyecto];
GO
IF OBJECT_ID(N'[dbo].[fk_colonia_municipio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatColonias] DROP CONSTRAINT [fk_colonia_municipio];
GO
IF OBJECT_ID(N'[dbo].[fk_datoslab_carrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DatosLaborales] DROP CONSTRAINT [fk_datoslab_carrera];
GO
IF OBJECT_ID(N'[dbo].[fk_datoslab_cuatrimestre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DatosLaborales] DROP CONSTRAINT [fk_datoslab_cuatrimestre];
GO
IF OBJECT_ID(N'[dbo].[fk_datoslab_status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DatosLaborales] DROP CONSTRAINT [fk_datoslab_status];
GO
IF OBJECT_ID(N'[dbo].[fk_datoslab_ua]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DatosLaborales] DROP CONSTRAINT [fk_datoslab_ua];
GO
IF OBJECT_ID(N'[dbo].[fk_dir_colonia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direcciones] DROP CONSTRAINT [fk_dir_colonia];
GO
IF OBJECT_ID(N'[dbo].[fk_dir_estado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direcciones] DROP CONSTRAINT [fk_dir_estado];
GO
IF OBJECT_ID(N'[dbo].[fk_dir_municipio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direcciones] DROP CONSTRAINT [fk_dir_municipio];
GO
IF OBJECT_ID(N'[dbo].[fk_emprendedor_avatar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emprendedores] DROP CONSTRAINT [fk_emprendedor_avatar];
GO
IF OBJECT_ID(N'[dbo].[fk_emprendedor_datolab]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emprendedores] DROP CONSTRAINT [fk_emprendedor_datolab];
GO
IF OBJECT_ID(N'[dbo].[fk_emprendedor_direccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emprendedores] DROP CONSTRAINT [fk_emprendedor_direccion];
GO
IF OBJECT_ID(N'[dbo].[fk_emprendedor_status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emprendedores] DROP CONSTRAINT [fk_emprendedor_status];
GO
IF OBJECT_ID(N'[dbo].[fk_emprendedor_telefono]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emprendedores] DROP CONSTRAINT [fk_emprendedor_telefono];
GO
IF OBJECT_ID(N'[dbo].[fk_estado_pais]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatEstados] DROP CONSTRAINT [fk_estado_pais];
GO
IF OBJECT_ID(N'[dbo].[fk_municipio_estado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatMunicipios] DROP CONSTRAINT [fk_municipio_estado];
GO
IF OBJECT_ID(N'[dbo].[fk_proyecto_catfase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proyectos] DROP CONSTRAINT [fk_proyecto_catfase];
GO
IF OBJECT_ID(N'[dbo].[fk_proyecto_catgiro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proyectos] DROP CONSTRAINT [fk_proyecto_catgiro];
GO
IF OBJECT_ID(N'[dbo].[fk_proyecto_emprendedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proyectos] DROP CONSTRAINT [fk_proyecto_emprendedor];
GO
IF OBJECT_ID(N'[dbo].[fk_recursos_proy_proyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecursosProyectos] DROP CONSTRAINT [fk_recursos_proy_proyecto];
GO
IF OBJECT_ID(N'[dbo].[fk_ser_univ_catservicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiciosUniversitarios] DROP CONSTRAINT [fk_ser_univ_catservicio];
GO
IF OBJECT_ID(N'[dbo].[fk_ser_univ_proyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiciosUniversitarios] DROP CONSTRAINT [fk_ser_univ_proyecto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoleClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoleClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserTokens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserTokens];
GO
IF OBJECT_ID(N'[dbo].[CatAvatars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatAvatars];
GO
IF OBJECT_ID(N'[dbo].[CatCarreras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatCarreras];
GO
IF OBJECT_ID(N'[dbo].[CatColonias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatColonias];
GO
IF OBJECT_ID(N'[dbo].[CatCuatrimestres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatCuatrimestres];
GO
IF OBJECT_ID(N'[dbo].[CatEstados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatEstados];
GO
IF OBJECT_ID(N'[dbo].[CatFases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatFases];
GO
IF OBJECT_ID(N'[dbo].[CatGiros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatGiros];
GO
IF OBJECT_ID(N'[dbo].[CatModalidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatModalidades];
GO
IF OBJECT_ID(N'[dbo].[CatMunicipios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatMunicipios];
GO
IF OBJECT_ID(N'[dbo].[CatPaises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatPaises];
GO
IF OBJECT_ID(N'[dbo].[CatServicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatServicios];
GO
IF OBJECT_ID(N'[dbo].[CatUnidadesAcademicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatUnidadesAcademicas];
GO
IF OBJECT_ID(N'[dbo].[Colaboradores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colaboradores];
GO
IF OBJECT_ID(N'[dbo].[DatosLaborales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DatosLaborales];
GO
IF OBJECT_ID(N'[dbo].[Direcciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Direcciones];
GO
IF OBJECT_ID(N'[dbo].[Emprendedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emprendedores];
GO
IF OBJECT_ID(N'[dbo].[Logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logs];
GO
IF OBJECT_ID(N'[dbo].[Proyectos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proyectos];
GO
IF OBJECT_ID(N'[dbo].[RecursosProyectos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecursosProyectos];
GO
IF OBJECT_ID(N'[dbo].[ServiciosUniversitarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiciosUniversitarios];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Telefonos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Telefonos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoleClaims'
CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] nvarchar(450)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(450)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(450)  NOT NULL,
    [ProviderKey] nvarchar(450)  NOT NULL,
    [ProviderDisplayName] nvarchar(max)  NULL,
    [UserId] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'AspNetUserTokens'
CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId] nvarchar(450)  NOT NULL,
    [LoginProvider] nvarchar(450)  NOT NULL,
    [Name] nvarchar(450)  NOT NULL,
    [Value] nvarchar(max)  NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventDateTime] datetime  NOT NULL,
    [EventLevel] nvarchar(100)  NOT NULL,
    [UserName] nvarchar(100)  NOT NULL,
    [MachineName] nvarchar(100)  NOT NULL,
    [EventMessage] nvarchar(max)  NOT NULL,
    [ErrorSource] nvarchar(100)  NULL,
    [ErrorClass] nvarchar(500)  NULL,
    [ErrorMethod] nvarchar(max)  NULL,
    [ErrorMessage] nvarchar(max)  NULL,
    [InnerErrorMessage] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(450)  NOT NULL,
    [Name] nvarchar(256)  NULL,
    [NormalizedName] nvarchar(256)  NULL,
    [ConcurrencyStamp] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] nvarchar(450)  NOT NULL,
    [RoleId] nvarchar(450)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(450)  NOT NULL,
    [UserName] nvarchar(256)  NULL,
    [NormalizedUserName] nvarchar(256)  NULL,
    [Email] nvarchar(256)  NULL,
    [NormalizedEmail] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [ConcurrencyStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEnd] datetimeoffset  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL
);
GO

-- Creating table 'CatAvatars'
CREATE TABLE [dbo].[CatAvatars] (
    [Id] nvarchar(450)  NOT NULL,
    [StrUrl] nvarchar(1000)  NOT NULL
);
GO

-- Creating table 'CatCarreras'
CREATE TABLE [dbo].[CatCarreras] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(150)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL,
    [IdStatus] int  NOT NULL,
    [IdUnidadAcademica] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'CatColonias'
CREATE TABLE [dbo].[CatColonias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StrNombre] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(200)  NULL,
    [StrCodigoPostal] varchar(5)  NOT NULL,
    [IdMunicipio] int  NOT NULL
);
GO

-- Creating table 'CatCuatrimestres'
CREATE TABLE [dbo].[CatCuatrimestres] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'CatEstados'
CREATE TABLE [dbo].[CatEstados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StrNombre] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(200)  NULL,
    [IdPais] int  NOT NULL
);
GO

-- Creating table 'CatMunicipios'
CREATE TABLE [dbo].[CatMunicipios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StrNombre] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(200)  NULL,
    [IdEstado] int  NOT NULL
);
GO

-- Creating table 'CatPaises'
CREATE TABLE [dbo].[CatPaises] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StrNombre] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(200)  NULL
);
GO

-- Creating table 'CatUnidadesAcademicas'
CREATE TABLE [dbo].[CatUnidadesAcademicas] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'Direcciones'
CREATE TABLE [dbo].[Direcciones] (
    [Id] nvarchar(450)  NOT NULL,
    [StrCalle] varchar(150)  NOT NULL,
    [IdEstado] int  NOT NULL,
    [IdMunicipio] int  NOT NULL,
    [IdColonia] int  NOT NULL,
    [IntNumeroInterior] int  NULL,
    [IntNumeroExterior] int  NULL
);
GO

-- Creating table 'Emprendedores'
CREATE TABLE [dbo].[Emprendedores] (
    [Id] nvarchar(450)  NOT NULL,
    [StrNombre] varchar(100)  NOT NULL,
    [StrApellidoPaterno] varchar(100)  NOT NULL,
    [StrApellidoMaterno] varchar(100)  NOT NULL,
    [StrCurp] nvarchar(18)  NOT NULL,
    [StrFechaNacimiento] datetime  NULL,
    [StrEmail] varchar(150)  NOT NULL,
    [StrFotoUrl] nvarchar(1000)  NULL,
    [IdTelefono] nvarchar(450)  NOT NULL,
    [IdDireccion] nvarchar(450)  NOT NULL,
    [IdStatus] int  NOT NULL,
    [IdAvatar] nvarchar(450)  NULL,
    [IdDatoLaboral] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'Telefonos'
CREATE TABLE [dbo].[Telefonos] (
    [Id] nvarchar(450)  NOT NULL,
    [StrTelefonoFijo] varchar(10)  NOT NULL,
    [StrTelefonoCelular] varchar(10)  NOT NULL
);
GO

-- Creating table 'DatosLaborales'
CREATE TABLE [dbo].[DatosLaborales] (
    [Id] nvarchar(450)  NOT NULL,
    [IntOcupacion] int  NOT NULL,
    [StrObservaciones] varchar(255)  NULL,
    [IdUnidadAcademica] nvarchar(450)  NULL,
    [IdCarrera] nvarchar(450)  NULL,
    [IdCuatrimestre] nvarchar(450)  NULL,
    [IdStatus] int  NOT NULL
);
GO

-- Creating table 'CatFases'
CREATE TABLE [dbo].[CatFases] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'CatGiros'
CREATE TABLE [dbo].[CatGiros] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'CatModalidades'
CREATE TABLE [dbo].[CatModalidades] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'CatServicios'
CREATE TABLE [dbo].[CatServicios] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL
);
GO

-- Creating table 'Proyectos'
CREATE TABLE [dbo].[Proyectos] (
    [Id] nvarchar(450)  NOT NULL,
    [StrNombre] varchar(150)  NOT NULL,
    [StrNombreEmpresa] varchar(150)  NULL,
    [IdGiro] nvarchar(450)  NOT NULL,
    [StrDescripcion] varchar(255)  NOT NULL,
    [IdFase] nvarchar(450)  NOT NULL,
    [IntConstituidaLegal] int  NOT NULL,
    [StrObservaciones] varchar(100)  NULL,
    [StrRFC] varchar(13)  NULL,
    [DtFechaRegistro] datetime  NOT NULL,
    [IdEmprendedor] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'RecursosProyectos'
CREATE TABLE [dbo].[RecursosProyectos] (
    [Id] nvarchar(450)  NOT NULL,
    [StrValor] varchar(100)  NOT NULL,
    [StrDescripcion] varchar(255)  NULL,
    [StrNombrePersona] varchar(150)  NOT NULL,
    [IdProyecto] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'ServiciosUniversitarios'
CREATE TABLE [dbo].[ServiciosUniversitarios] (
    [Id] nvarchar(450)  NOT NULL,
    [IdProyecto] nvarchar(450)  NOT NULL,
    [IdServicio] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'Colaboradores'
CREATE TABLE [dbo].[Colaboradores] (
    [Id] nvarchar(450)  NOT NULL,
    [StrNombre] varchar(100)  NOT NULL,
    [IdProyecto] nvarchar(450)  NOT NULL,
    [IdLiderEmprendedor] nvarchar(450)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoleClaims'
ALTER TABLE [dbo].[AspNetRoleClaims]
ADD CONSTRAINT [PK_AspNetRoleClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [Name] in table 'AspNetUserTokens'
ALTER TABLE [dbo].[AspNetUserTokens]
ADD CONSTRAINT [PK_AspNetUserTokens]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [Name] ASC);
GO

-- Creating primary key on [Id] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatAvatars'
ALTER TABLE [dbo].[CatAvatars]
ADD CONSTRAINT [PK_CatAvatars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatCarreras'
ALTER TABLE [dbo].[CatCarreras]
ADD CONSTRAINT [PK_CatCarreras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatColonias'
ALTER TABLE [dbo].[CatColonias]
ADD CONSTRAINT [PK_CatColonias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatCuatrimestres'
ALTER TABLE [dbo].[CatCuatrimestres]
ADD CONSTRAINT [PK_CatCuatrimestres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatEstados'
ALTER TABLE [dbo].[CatEstados]
ADD CONSTRAINT [PK_CatEstados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatMunicipios'
ALTER TABLE [dbo].[CatMunicipios]
ADD CONSTRAINT [PK_CatMunicipios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatPaises'
ALTER TABLE [dbo].[CatPaises]
ADD CONSTRAINT [PK_CatPaises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatUnidadesAcademicas'
ALTER TABLE [dbo].[CatUnidadesAcademicas]
ADD CONSTRAINT [PK_CatUnidadesAcademicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [PK_Direcciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emprendedores'
ALTER TABLE [dbo].[Emprendedores]
ADD CONSTRAINT [PK_Emprendedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Telefonos'
ALTER TABLE [dbo].[Telefonos]
ADD CONSTRAINT [PK_Telefonos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DatosLaborales'
ALTER TABLE [dbo].[DatosLaborales]
ADD CONSTRAINT [PK_DatosLaborales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatFases'
ALTER TABLE [dbo].[CatFases]
ADD CONSTRAINT [PK_CatFases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatGiros'
ALTER TABLE [dbo].[CatGiros]
ADD CONSTRAINT [PK_CatGiros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatModalidades'
ALTER TABLE [dbo].[CatModalidades]
ADD CONSTRAINT [PK_CatModalidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CatServicios'
ALTER TABLE [dbo].[CatServicios]
ADD CONSTRAINT [PK_CatServicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proyectos'
ALTER TABLE [dbo].[Proyectos]
ADD CONSTRAINT [PK_Proyectos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecursosProyectos'
ALTER TABLE [dbo].[RecursosProyectos]
ADD CONSTRAINT [PK_RecursosProyectos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiciosUniversitarios'
ALTER TABLE [dbo].[ServiciosUniversitarios]
ADD CONSTRAINT [PK_ServiciosUniversitarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Colaboradores'
ALTER TABLE [dbo].[Colaboradores]
ADD CONSTRAINT [PK_Colaboradores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'AspNetRoleClaims'
ALTER TABLE [dbo].[AspNetRoleClaims]
ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetRoleClaims_AspNetRoles_RoleId'
CREATE INDEX [IX_FK_AspNetRoleClaims_AspNetRoles_RoleId]
ON [dbo].[AspNetRoleClaims]
    ([RoleId]);
GO

-- Creating foreign key on [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetRoles'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetRoles]
ON [dbo].[AspNetUserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserClaims_AspNetUsers_UserId'
CREATE INDEX [IX_FK_AspNetUserClaims_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserLogins_AspNetUsers_UserId'
CREATE INDEX [IX_FK_AspNetUserLogins_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserTokens'
ALTER TABLE [dbo].[AspNetUserTokens]
ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdAvatar] in table 'Emprendedores'
ALTER TABLE [dbo].[Emprendedores]
ADD CONSTRAINT [fk_emprendedor_avatar]
    FOREIGN KEY ([IdAvatar])
    REFERENCES [dbo].[CatAvatars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_emprendedor_avatar'
CREATE INDEX [IX_fk_emprendedor_avatar]
ON [dbo].[Emprendedores]
    ([IdAvatar]);
GO

-- Creating foreign key on [IdUnidadAcademica] in table 'CatCarreras'
ALTER TABLE [dbo].[CatCarreras]
ADD CONSTRAINT [fk_cat_carrera_catua]
    FOREIGN KEY ([IdUnidadAcademica])
    REFERENCES [dbo].[CatUnidadesAcademicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cat_carrera_catua'
CREATE INDEX [IX_fk_cat_carrera_catua]
ON [dbo].[CatCarreras]
    ([IdUnidadAcademica]);
GO

-- Creating foreign key on [IdStatus] in table 'CatCarreras'
ALTER TABLE [dbo].[CatCarreras]
ADD CONSTRAINT [fk_cat_carrera_status]
    FOREIGN KEY ([IdStatus])
    REFERENCES [dbo].[Status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cat_carrera_status'
CREATE INDEX [IX_fk_cat_carrera_status]
ON [dbo].[CatCarreras]
    ([IdStatus]);
GO

-- Creating foreign key on [IdMunicipio] in table 'CatColonias'
ALTER TABLE [dbo].[CatColonias]
ADD CONSTRAINT [fk_colonia_municipio]
    FOREIGN KEY ([IdMunicipio])
    REFERENCES [dbo].[CatMunicipios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_colonia_municipio'
CREATE INDEX [IX_fk_colonia_municipio]
ON [dbo].[CatColonias]
    ([IdMunicipio]);
GO

-- Creating foreign key on [IdColonia] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [fk_dir_colonia]
    FOREIGN KEY ([IdColonia])
    REFERENCES [dbo].[CatColonias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_dir_colonia'
CREATE INDEX [IX_fk_dir_colonia]
ON [dbo].[Direcciones]
    ([IdColonia]);
GO

-- Creating foreign key on [IdEstado] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [fk_dir_estado]
    FOREIGN KEY ([IdEstado])
    REFERENCES [dbo].[CatEstados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_dir_estado'
CREATE INDEX [IX_fk_dir_estado]
ON [dbo].[Direcciones]
    ([IdEstado]);
GO

-- Creating foreign key on [IdPais] in table 'CatEstados'
ALTER TABLE [dbo].[CatEstados]
ADD CONSTRAINT [fk_estado_pais]
    FOREIGN KEY ([IdPais])
    REFERENCES [dbo].[CatPaises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_estado_pais'
CREATE INDEX [IX_fk_estado_pais]
ON [dbo].[CatEstados]
    ([IdPais]);
GO

-- Creating foreign key on [IdEstado] in table 'CatMunicipios'
ALTER TABLE [dbo].[CatMunicipios]
ADD CONSTRAINT [fk_municipio_estado]
    FOREIGN KEY ([IdEstado])
    REFERENCES [dbo].[CatEstados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_municipio_estado'
CREATE INDEX [IX_fk_municipio_estado]
ON [dbo].[CatMunicipios]
    ([IdEstado]);
GO

-- Creating foreign key on [IdMunicipio] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [fk_dir_municipio]
    FOREIGN KEY ([IdMunicipio])
    REFERENCES [dbo].[CatMunicipios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_dir_municipio'
CREATE INDEX [IX_fk_dir_municipio]
ON [dbo].[Direcciones]
    ([IdMunicipio]);
GO

-- Creating foreign key on [IdDireccion] in table 'Emprendedores'
ALTER TABLE [dbo].[Emprendedores]
ADD CONSTRAINT [fk_emprendedor_direccion]
    FOREIGN KEY ([IdDireccion])
    REFERENCES [dbo].[Direcciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_emprendedor_direccion'
CREATE INDEX [IX_fk_emprendedor_direccion]
ON [dbo].[Emprendedores]
    ([IdDireccion]);
GO

-- Creating foreign key on [IdStatus] in table 'Emprendedores'
ALTER TABLE [dbo].[Emprendedores]
ADD CONSTRAINT [fk_emprendedor_status]
    FOREIGN KEY ([IdStatus])
    REFERENCES [dbo].[Status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_emprendedor_status'
CREATE INDEX [IX_fk_emprendedor_status]
ON [dbo].[Emprendedores]
    ([IdStatus]);
GO

-- Creating foreign key on [IdTelefono] in table 'Emprendedores'
ALTER TABLE [dbo].[Emprendedores]
ADD CONSTRAINT [fk_emprendedor_telefono]
    FOREIGN KEY ([IdTelefono])
    REFERENCES [dbo].[Telefonos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_emprendedor_telefono'
CREATE INDEX [IX_fk_emprendedor_telefono]
ON [dbo].[Emprendedores]
    ([IdTelefono]);
GO

-- Creating foreign key on [IdCarrera] in table 'DatosLaborales'
ALTER TABLE [dbo].[DatosLaborales]
ADD CONSTRAINT [fk_datoslab_carrera]
    FOREIGN KEY ([IdCarrera])
    REFERENCES [dbo].[CatCarreras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_datoslab_carrera'
CREATE INDEX [IX_fk_datoslab_carrera]
ON [dbo].[DatosLaborales]
    ([IdCarrera]);
GO

-- Creating foreign key on [IdCuatrimestre] in table 'DatosLaborales'
ALTER TABLE [dbo].[DatosLaborales]
ADD CONSTRAINT [fk_datoslab_cuatrimestre]
    FOREIGN KEY ([IdCuatrimestre])
    REFERENCES [dbo].[CatCuatrimestres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_datoslab_cuatrimestre'
CREATE INDEX [IX_fk_datoslab_cuatrimestre]
ON [dbo].[DatosLaborales]
    ([IdCuatrimestre]);
GO

-- Creating foreign key on [IdUnidadAcademica] in table 'DatosLaborales'
ALTER TABLE [dbo].[DatosLaborales]
ADD CONSTRAINT [fk_datoslab_ua]
    FOREIGN KEY ([IdUnidadAcademica])
    REFERENCES [dbo].[CatUnidadesAcademicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_datoslab_ua'
CREATE INDEX [IX_fk_datoslab_ua]
ON [dbo].[DatosLaborales]
    ([IdUnidadAcademica]);
GO

-- Creating foreign key on [IdStatus] in table 'DatosLaborales'
ALTER TABLE [dbo].[DatosLaborales]
ADD CONSTRAINT [fk_datoslab_status]
    FOREIGN KEY ([IdStatus])
    REFERENCES [dbo].[Status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_datoslab_status'
CREATE INDEX [IX_fk_datoslab_status]
ON [dbo].[DatosLaborales]
    ([IdStatus]);
GO

-- Creating foreign key on [IdDatoLaboral] in table 'Emprendedores'
ALTER TABLE [dbo].[Emprendedores]
ADD CONSTRAINT [fk_emprendedor_datolab]
    FOREIGN KEY ([IdDatoLaboral])
    REFERENCES [dbo].[DatosLaborales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_emprendedor_datolab'
CREATE INDEX [IX_fk_emprendedor_datolab]
ON [dbo].[Emprendedores]
    ([IdDatoLaboral]);
GO

-- Creating foreign key on [IdFase] in table 'Proyectos'
ALTER TABLE [dbo].[Proyectos]
ADD CONSTRAINT [fk_proyecto_catfase]
    FOREIGN KEY ([IdFase])
    REFERENCES [dbo].[CatFases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_proyecto_catfase'
CREATE INDEX [IX_fk_proyecto_catfase]
ON [dbo].[Proyectos]
    ([IdFase]);
GO

-- Creating foreign key on [IdGiro] in table 'Proyectos'
ALTER TABLE [dbo].[Proyectos]
ADD CONSTRAINT [fk_proyecto_catgiro]
    FOREIGN KEY ([IdGiro])
    REFERENCES [dbo].[CatGiros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_proyecto_catgiro'
CREATE INDEX [IX_fk_proyecto_catgiro]
ON [dbo].[Proyectos]
    ([IdGiro]);
GO

-- Creating foreign key on [IdServicio] in table 'ServiciosUniversitarios'
ALTER TABLE [dbo].[ServiciosUniversitarios]
ADD CONSTRAINT [fk_ser_univ_catservicio]
    FOREIGN KEY ([IdServicio])
    REFERENCES [dbo].[CatServicios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_ser_univ_catservicio'
CREATE INDEX [IX_fk_ser_univ_catservicio]
ON [dbo].[ServiciosUniversitarios]
    ([IdServicio]);
GO

-- Creating foreign key on [IdEmprendedor] in table 'Proyectos'
ALTER TABLE [dbo].[Proyectos]
ADD CONSTRAINT [fk_proyecto_emprendedor]
    FOREIGN KEY ([IdEmprendedor])
    REFERENCES [dbo].[Emprendedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_proyecto_emprendedor'
CREATE INDEX [IX_fk_proyecto_emprendedor]
ON [dbo].[Proyectos]
    ([IdEmprendedor]);
GO

-- Creating foreign key on [IdProyecto] in table 'RecursosProyectos'
ALTER TABLE [dbo].[RecursosProyectos]
ADD CONSTRAINT [fk_recursos_proy_proyecto]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Proyectos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_recursos_proy_proyecto'
CREATE INDEX [IX_fk_recursos_proy_proyecto]
ON [dbo].[RecursosProyectos]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdProyecto] in table 'ServiciosUniversitarios'
ALTER TABLE [dbo].[ServiciosUniversitarios]
ADD CONSTRAINT [fk_ser_univ_proyecto]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Proyectos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_ser_univ_proyecto'
CREATE INDEX [IX_fk_ser_univ_proyecto]
ON [dbo].[ServiciosUniversitarios]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdLiderEmprendedor] in table 'Colaboradores'
ALTER TABLE [dbo].[Colaboradores]
ADD CONSTRAINT [fk_colab_emprendedor]
    FOREIGN KEY ([IdLiderEmprendedor])
    REFERENCES [dbo].[Emprendedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_colab_emprendedor'
CREATE INDEX [IX_fk_colab_emprendedor]
ON [dbo].[Colaboradores]
    ([IdLiderEmprendedor]);
GO

-- Creating foreign key on [IdProyecto] in table 'Colaboradores'
ALTER TABLE [dbo].[Colaboradores]
ADD CONSTRAINT [fk_colab_proyecto]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Proyectos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_colab_proyecto'
CREATE INDEX [IX_fk_colab_proyecto]
ON [dbo].[Colaboradores]
    ([IdProyecto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------