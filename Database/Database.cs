using api.Models;

namespace api.Database
{
    public class Database
    {
        public string cs{get;}

        public Database()
        {
            ConnectionString connectString = new ConnectionString();
            cs = connectString.cs;
        }
    }
}