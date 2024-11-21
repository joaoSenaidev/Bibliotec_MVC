using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Contexts;

namespace Bibliotec.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public string? Nome { get; set; }


    }
}