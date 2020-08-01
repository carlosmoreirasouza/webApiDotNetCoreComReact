using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }


        [Column(TypeName = "varchar(100)")]
        public string Cpf { get; set; }


        [Column(TypeName = "varchar(100)")]
        public string Ativo { get; set; }
    }
}
