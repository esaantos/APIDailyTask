using System.ComponentModel.DataAnnotations;

namespace APIGerenciadorTarefas.Data.Dtos
{
    public class CreateTarefaDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }        
        public bool Finalizado { get; set; } = false;
    }
}
