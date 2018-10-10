using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Entity
{
    public partial class PoknoEntities
    {
        public PoknoEntities(string connectionString)
            : base(connectionString)
        {
        }

        //public PoknoEntities(string filename) 
        //     : base(new SQLiteConnection() { ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = filename, ForeignKeys = true }.ConnectionString }, true)
        //{
        //}

        //public PoknoEntities(string connectionString)
        //    : base(new SQLiteConnection() { ConnectionString = connectionString }, true)
        //{
        //}






    }
}
