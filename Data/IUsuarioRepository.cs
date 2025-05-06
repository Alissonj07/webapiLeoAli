using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAliLeo.Models;

namespace ProjetoAliLeo.Data
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        List<Usuario> Listar();

        Usuario? BuscarUsuarioPorEmailSenha(string email, string senha);
    }
}