using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCRUDStudent.Tools
{
    public class DataBase
    {
        private static string chaine = @"Server=vps748191.ovh.net;User=c0DotNetUser;Password=zD7#ig6P;DataBase=c0DotNetBDD";

        public static MySqlConnection Connection { get => new MySqlConnection(chaine); }
    }
}
