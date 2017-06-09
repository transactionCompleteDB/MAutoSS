using MAutoSS.Data.SQLite.Contracts;
using MAutoSS.DataModels.SQLite.Models;
using System.Data.Entity;

namespace MAutoSS.Data.SQLite
{
    public class MAutoSSDbContextSQLite : DbContext, IMAutoSSDbContextSQLite
    {
        public MAutoSSDbContextSQLite() : base("MAutoSSSQLiteConnection") { }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<ServiceInfo> ServiceInfos { get; set; }
    }
}
