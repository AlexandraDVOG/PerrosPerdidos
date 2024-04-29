
using System.Data;


namespace ITD.PerrosPerdidos.Application.Interfaces.Context
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
