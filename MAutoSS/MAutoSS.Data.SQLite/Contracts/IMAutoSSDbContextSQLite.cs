using MAutoSS.DataModels.SQLite.Models;
using System.Data.Entity;

namespace MAutoSS.Data.SQLite.Contracts
{
    public interface IMAutoSSDbContextSQLite
    {
        IDbSet<Car> Cars { get; set; }

        IDbSet<ServiceInfo> ServiceInfos { get; set; }
    }
}
