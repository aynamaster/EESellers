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
    [Table(name: "TBL_USUARIO")]
    public class Usuario
    {
        [Column(name: "CD_USUARIO"), Key, LabelForm("Id")]
        public int id { get; set; }

        [Column(name: "DS_USUARIO"), LabelForm("Nome do Usuário")]
        [MaxLength(20, ErrorMessage = "O campo nome do Usuario deve ter no maximo 20 caracteres")]
        public string dsUsuario { get; set; }

        [Column(name: "DS_LOGIN"), LabelForm("Login")]
        [MaxLength(30, ErrorMessage = "O campo login do Usuario deve ter no maixmo 30 caracteres"), Index("IX_TBL_USUARIO_LOGIN", IsUnique = true)]
        public string dsLogin { get; set; }

        [JsonIgnoreAttribute]
        [Column(name: "DS_SENHA"), MaxLength(200), LabelForm("Senha")]
        public string senha { get; set; }

        [Column(name: "DS_OBSERVACAO"), LabelForm("Observação")]
        [MaxLength(100, ErrorMessage = "O campo Senha do Usuario deve ter no maximo 20 caracteres")]
        public string observacao { get; set; }

        [NotMapped]
        public bool alterarSenha { get; set; }
        [Column("DT_CRIACAO")]

        public DateTime? dataCriacao { get; set; }
        [Column("CD_USUARIO_CRIACAO")]
        public int? idUsuarioCriacao { get; set; }

        [Column("CD_USUARIO_ULTIMA_ALTERACAO")]
        public int? idUsuarioAlteracao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? dataUltimaAlteracao { get; set; }

        [NotMapped]
        public Usuario usuarioCriacao { get; set; }

        [NotMapped]
        public Usuario usuarioUltimaAlteracao { get; set; }

        [NotMapped]
        public string senhaDecrypted { get; set; }
    }
}