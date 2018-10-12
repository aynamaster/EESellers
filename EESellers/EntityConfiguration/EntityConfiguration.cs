using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EESellers.Models
{
    public partial class DbContext : System.Data.Entity.DbContext
    {

        public DbContext() : base("DefaultConnection")
        {

        }

        public DbContext(DbConnection existingConnection, bool contextOwnsConnection)
       : base(existingConnection, contextOwnsConnection)
        {

        }
        

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Vendedor> Vendedores { get; set; }
        public virtual DbSet<Vendas> Vendas { get; set; }

    }
}