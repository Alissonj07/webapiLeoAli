using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAliLeo.Models;

namespace ProjetoAliLeo.Data
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);

        List<Evento> Listar();
    }
}