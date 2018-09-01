﻿CREATE TABLE [dbo].[Tarefa] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (200) NOT NULL,
    [Prioridade]  INT            NOT NULL,
    [Concluida]   BIT            NOT NULL,
    [Observacoes] NVARCHAR (500) NULL,
    CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

