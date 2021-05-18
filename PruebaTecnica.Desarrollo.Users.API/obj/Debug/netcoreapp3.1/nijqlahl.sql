IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Rol] (
    [Id] nvarchar(50) NOT NULL,
    [Nombre] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Rol] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] nvarchar(50) NOT NULL,
    [Nombre] nvarchar(100) NOT NULL,
    [Apellido] nvarchar(100) NOT NULL,
    [NombreUsuario] nvarchar(15) NOT NULL,
    [Clave] nvarchar(500) NOT NULL,
    [FechaCreacion] datetime2 NOT NULL,
    [RolId] nvarchar(50) NOT NULL,
    [RoleEntityRoleId] nvarchar(50) NULL,
    [Activo] bit NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuario_Rol_RoleEntityRoleId] FOREIGN KEY ([RoleEntityRoleId]) REFERENCES [Rol] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'14095c34-9018-40ca-b25b-6d547d1cdf98', N'Usuario');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'991817b6-b223-4f10-9c16-ca4e46fe37a7', N'Administrador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

CREATE INDEX [IX_Usuario_RoleEntityRoleId] ON [Usuario] ([RoleEntityRoleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210501195118_v0', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Usuario] DROP CONSTRAINT [FK_Usuario_Rol_RoleEntityRoleId];
GO

DROP INDEX [IX_Usuario_RoleEntityRoleId] ON [Usuario];
GO

DELETE FROM [Rol]
WHERE [Id] = N'14095c34-9018-40ca-b25b-6d547d1cdf98';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Rol]
WHERE [Id] = N'991817b6-b223-4f10-9c16-ca4e46fe37a7';
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuario]') AND [c].[name] = N'RoleEntityRoleId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuario] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Usuario] DROP COLUMN [RoleEntityRoleId];
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'd6936187-791b-418d-b904-02e1e19b4651', N'Usuario');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'd9b62fdd-bbd3-4a6d-a628-9bd8fa07757d', N'Administrador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

CREATE INDEX [IX_Usuario_RolId] ON [Usuario] ([RolId]);
GO

ALTER TABLE [Usuario] ADD CONSTRAINT [FK_Usuario_Rol_RolId] FOREIGN KEY ([RolId]) REFERENCES [Rol] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210518170145_v1.0', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Rol]
WHERE [Id] = N'd6936187-791b-418d-b904-02e1e19b4651';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Rol]
WHERE [Id] = N'd9b62fdd-bbd3-4a6d-a628-9bd8fa07757d';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'00473af4-f55e-4ebd-b7a0-5c0830432d53', N'Usuario');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'd6901889-c81c-47e6-b9fd-0e6be56d1dca', N'Administrador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210518182451_v1.1', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Rol]
WHERE [Id] = N'00473af4-f55e-4ebd-b7a0-5c0830432d53';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Rol]
WHERE [Id] = N'd6901889-c81c-47e6-b9fd-0e6be56d1dca';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'bdc2741d-f7f2-4d6b-8db3-f79b0581fb7d', N'Usuario');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] ON;
INSERT INTO [Rol] ([Id], [Nombre])
VALUES (N'8a0de7cb-47b3-4c33-8904-59875b5d1263', N'Administrador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Rol]'))
    SET IDENTITY_INSERT [Rol] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210518182644_v1.2', N'5.0.5');
GO

COMMIT;
GO

