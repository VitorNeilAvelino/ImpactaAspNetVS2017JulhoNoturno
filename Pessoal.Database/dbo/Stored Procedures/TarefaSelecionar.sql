CREATE PROCEDURE TarefaSelecionar

@Id int = null

AS
BEGIN

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacoes]
  FROM [dbo].[Tarefa]
  Where Id = ISNULL(@Id, Id)

END
