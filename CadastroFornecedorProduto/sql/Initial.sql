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

CREATE TABLE [FORNECEDORES] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    [Documento] VARCHAR(14) NOT NULL,
    [TipoFornecedor] int NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_FORNECEDORES] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ENDERECOS] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Logradouro] VARCHAR(200) NOT NULL,
    [Numero] VARCHAR(50) NOT NULL,
    [Complemento] VARCHAR(250) NOT NULL,
    [Cep] VARCHAR(8) NOT NULL,
    [Bairro] VARCHAR(100) NOT NULL,
    [Cidade] VARCHAR(100) NOT NULL,
    [Estado] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_ENDERECOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ENDERECOS_FORNECEDORES_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [FORNECEDORES] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [PRODUTOS] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    [Descricao] VARCHAR(100) NOT NULL,
    [Imagem] VARCHAR(100) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_PRODUTOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PRODUTOS_FORNECEDORES_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [FORNECEDORES] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_ENDERECOS_FornecedorId] ON [ENDERECOS] ([FornecedorId]);
GO

CREATE INDEX [IX_PRODUTOS_FornecedorId] ON [PRODUTOS] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210817224125_Initial', N'5.0.9');
GO

COMMIT;
GO

