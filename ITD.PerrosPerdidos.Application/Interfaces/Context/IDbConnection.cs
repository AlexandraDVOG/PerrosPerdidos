using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Application.Interfaces.Presenters
{
    public interface IDbConnection
    {
        IDbConnection CreateConnection();
        string Connection { get; set; }
        int ConnectionTimeout { get; }
        string Database { get; }
        ConnectionState State { get; }

        IDbTransaction BeginTransaction();
        IDbTransaction BeginTransaction(IsolationLevel il);

        void ChangeDatabase(string databaseName);
        void Close();
        IDbCommand CreateCommand();
        void Open();
    }
}
