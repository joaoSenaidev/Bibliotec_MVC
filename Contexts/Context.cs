using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

// ⠀⠀⠀⠀⠀⣀⣤⣶⣾⣿⣿⠉⠐⠒⠠⢄⡀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠈⠑⢄⠀⠀⠀⠀⠀
// ⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⢡⡆⢾⠐⠄⠀⠤⠀⠑⢄⠀⠀⠀
// ⠀⣼⣿⣿⣿⣿⣿⣿⣿⡿⣿⣟⠓⡞⢳⡖⣒⡂⠀⠀⠀⢃⠀⠀
// ⠀⣿⣿⣿⣿⣿⣿⣿⣿⣬⣿⡞⠀⠣⡹⣼⣛⡂⠀⠀⠀⠈⡆⠀
// ⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣡⣶⣬⡷⡄⠀⠀⠂⠀⠀⠸⠀
// ⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣘⣛⣀⡀⢹⡀⠈⠀⠀⠀⠀⡇
// ⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣤⣬⣭⠟⠘⠇⠀⠀⠀⢀⠜⠀
// ⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠉⠈⠁⠀⡀⠀⠀⠀⡠⠊⠀⠀
// ⠀⠀⠀⠈⠙⠻⣿⣿⣿⣿⣿⣿⣦⣀⣀⡠⢇⣠⡔⠊⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣷⣶⣶⣾⡿⠛⠇⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢸⠀⠀⠀⠀⠀
// ⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠸⠀⠀⠀⠀⠀

namespace Bibliotec.Contexts
{
    public class Context : DbContext
    {
        // Criar um metodo construtor
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        // OnConfiguring -> possui a configuração
        // da conexão com
        // O banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //colocar as informacoes do banco
            //As configuracoes existem?
            if (!optionsBuilder.IsConfigured)
            {
                //a string da conexão do banco de dados
                //Data Source => Nome do Servidor do banco de dados
                //Initial Catalog -> Nome do Banco de dados
                optionsBuilder.UseSqlServer(@"Data Source=NOTE34-S28\\SQLEXPRESS;
                Initial Catalog = ;
                User Id = sa ;
                Password = 123;
                Integrated Security=true;
                TrustServerCertificate = true; ");
                
            }
        }

        //as referencias das nossas tabelas no banco de dados
        public DbSet<Categoria> Categoria { get; set; }
        //Curso
        public DbSet<Curso> Curso { get; set; }
        //Livro
        public DbSet<Livro> Livro { get; set; }
        //Usuario
        public DbSet<Usuario> Usuario { get; set; }
        //LivroCategoria
        public DbSet<LivroCategoria> LivroCategoria{ get; set; }
        //LivroReserva
        public DbSet<LivroReserva> LivroReserva { get; set; }
    
    
    
    
    
    }
}
