using System.Data;
using System.Data.SqlClient;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{
    public class dee : IDbConnection
    {
        private string _connection;
        private ConnectionState _state;

        public dee(string Connection)
        {
            _connection = Connection;
            _state = ConnectionState.Closed;
        }

        public string Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public int ConnectionTimeout => 15;

        public string Database => throw new NotImplementedException();

        public ConnectionState State => _state;

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            _state = ConnectionState.Closed;
        }

        public IDbCommand CreateCommand()
        {
            return new SqlCommand(this);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            _state = ConnectionState.Open;
        }
    }
}