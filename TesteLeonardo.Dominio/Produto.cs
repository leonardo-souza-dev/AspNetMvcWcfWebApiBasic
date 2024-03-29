﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLeonardo.Dominio
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DisplayName("Id")]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
    }
}
