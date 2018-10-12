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
    [Table(name: "TBL_VENDAS")]
    public class Vendas
    {
        [Column(name: "CD_VENDA"), Key, LabelForm("Id")]
        public int id { get; set; }

        [Column(name: "CD_VENDEDOR")]
        public int cdVendedor { get; set; }

        [Column(name: "CD_PRODUTO")]
        public int cdProduto { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime? dataCriacao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? dataUltimaAlteracao { get; set; }

        [Column(name: "VLR_COMISSAO")]
        public double vlrComissao { get; set; }
    }
}