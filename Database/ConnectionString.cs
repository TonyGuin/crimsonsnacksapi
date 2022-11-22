namespace api.Database
{
    public class ConnectionString
    {
        //Database hosted on heroku
        public string cs {get;}
        private string server= "cwe1u6tjijexv3r6.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
        private string database = "flthtavws41rzyz5";
        private string userName = "bd7yp4vunh2i9kdx";
        private string port = "3306";
        private string password = "jbgsmb5h4flm6tbu";

        public ConnectionString()
        {
            cs = $"server={server};port={port};database={database};user={userName};password={password};";
        }
    }
}