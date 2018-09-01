CREATE PROCEDURE [dbo].[TarefaInserir]

@Nome varchar(200)
,@Prioridade int
,@Concluida bit
,@Observacoes varchar(500)

AS
BEGIN

INSERT INTO [dbo].[Tarefa]
           ([Nome]
           ,[Prioridade]
           ,[Concluida]
           ,[Observacoes])
	output inserted.Id
     VALUES
           (@Nome
           ,@Prioridade
           ,@Concluida
           ,@Observacoes)

END
