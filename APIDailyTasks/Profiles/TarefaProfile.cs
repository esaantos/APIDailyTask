using APIDailyTasks.Models;
using APIGerenciadorTarefas.Data.Dtos;
using AutoMapper;

namespace APIGerenciadorTarefas.Profiles
{
    public class TarefaProfile: Profile
    {
        public TarefaProfile()
        {
            CreateMap<CreateTarefaDto, Tarefa>();
            CreateMap<UpdateTarefaDto, Tarefa>();
            CreateMap<Tarefa, UpdateTarefaDto>();
            CreateMap<Tarefa, ReadTarefaDto>();
        }
    }
}
