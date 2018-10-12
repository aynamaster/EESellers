using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EESellers.Models
{
    [Table(name: "TBL_PRODUTO")]
    public class Produto
    {
        [Column(name: "CD_PRODUTO"), Key]
        public long cdProduto { get; set; }

        [Column(name: "DS_PRODUTO"), MaxLength(200)]
        public string dsProduto { get; set; }

        [Column(name: "VLR_UNITARIO")]
        public long vlrUnitario { get; set; }

        [Column(name: "QTD_ESTOQUE")]
        public decimal qtdEstoque { get; set; }

        [Column(name: "FL_FISICO")]
        public bool flFisico { get; set; }
    }
}
