using System.Data.Entity;
using MAutoSS.DataModels.SQLite.Models;

namespace MAutoSS.Data.SQLite.Contracts
{
    public interface IMAutoSSDbContextSQLite
    {
        IDbSet<Car> Cars { get; set; }

        IDbSet<ServiceInfo> ServiceInfos { get; set; }
    }
}
