using System.Data.Entity;
using MAutoSS.Data.SQLite.Contracts;
using MAutoSS.DataModels.SQLite.Models;

namespace MAutoSS.Data.SQLite
{
    public class MAutoSSDbContextSQLite : DbContext, IMAutoSSDbContextSQLite
    {
        public MAutoSSDbContextSQLite() 
            : base("MAutoSSSQLiteConnection")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<ServiceInfo> ServiceInfos { get; set; }
    }
}
