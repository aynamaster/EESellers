using EESellers.CustomAttribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EESellers.Models
{
    [Table(name: "TBL_VENDEDOR_PESSOA")]
    public class Vendedor
    {
        [Column(name: "CD_VENDEDOR"), Key, LabelForm("Id")]
        public int id { get; set; }

        [Column(name: "DS_VENDEDOR"), LabelForm("Nome do Vendedor")]
        [MaxLength(20, ErrorMessage = "O campo nome do Vendedor deve ter no maximo 20 caracteres")]
        public string dsVendedor { get; set; }

        [Column(name: "VLR_SALDO"), LabelForm("Saldo do Vendedor")]
        public string vlrSaldo { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime? dataCriacao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? dataUltimaAlteracao { get; set; }
        
    }
}