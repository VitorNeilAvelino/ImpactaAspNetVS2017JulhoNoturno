CREATE PROCEDURE TarefaExcluir

@Id int

AS
BEGIN

Delete Tarefa where Id = @Id

END
