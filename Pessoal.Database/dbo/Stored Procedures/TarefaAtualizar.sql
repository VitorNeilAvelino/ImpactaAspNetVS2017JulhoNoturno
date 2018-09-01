CREATE PROCEDURE TarefaAtualizar

@Id int
,@Nome varchar(200)
,@Prioridade int
,@Concluida bit
,@Observacoes varchar(500)

AS
BEGIN

UPDATE [dbo].[Tarefa]
   SET [Nome] = @Nome
      ,[Prioridade] = @Prioridade
      ,[Concluida] = @Concluida
      ,[Observacoes] = @Observacoes
 WHERE Id = @Id


END
