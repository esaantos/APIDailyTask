using APIDailyTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace APIGerenciadorTarefas.Data
{
    public class TarefaContext: DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> opts): base(opts)
        {

        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
