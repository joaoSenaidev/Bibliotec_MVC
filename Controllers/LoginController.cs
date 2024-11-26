using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Contexts;
using Bibliotec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibliotec.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        Context context = new Context();


        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            //criar duas variaveis para armazenar as informacoes do formulario 
            string? EmailInformado = form["Email"];
            string? SenhaInformada = form["Senha"];


            //busca no banco de dados 
            Usuario usuarioBuscado = context.Usuario.FirstOrDefault(usuario => usuario.Email == EmailInformado && usuario.Senha == SenhaInformada)!;


            //de outra forma:
            //criei uma lista de usuarios
            // List<Usuario> listaUsuario = context.Usuario.ToList();

            // foreach (Usuario usuario_ in listaUsuario)
            // {
            //     if (usuario_.Email == EmailInformado && usuario_.Senha == SenhaInformada)
            //     {
            //         //usuario logado
            //     }else
            //     {
            //         //usuario nao encontrado
            //     }
            // }

            //se meu usuario for igual a nulo
            if (usuarioBuscado == null)
            {
                Console.WriteLine($"Dados invalidos!");
                return LocalRedirect("~/Login");
            }
            else
            {
                Console.WriteLine($"Bem - vindo");
                HttpContext.Session.SetString("Aluno", usuarioBuscado.UsuarioID.ToString());
                HttpContext.Session.SetString("Admin", usuarioBuscado.Admin.ToString());
                return LocalRedirect("~/Livro");
            }
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}