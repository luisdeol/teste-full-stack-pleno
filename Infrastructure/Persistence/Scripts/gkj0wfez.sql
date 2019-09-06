IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [db_Comportamento] (
    [Id] uniqueidentifier NOT NULL,
    [Ip] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [Browser] nvarchar(max) NULL,
    [Parametros] nvarchar(max) NULL,
    CONSTRAINT [PK_db_Comportamento] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190906011326_PrimeiraMigration', N'2.1.11-servicing-32099');

GO

