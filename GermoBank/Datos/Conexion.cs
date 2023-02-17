using System.Data.SqlClient;
namespace GermoBank.Datos
{
    public class Conexion
    {
        private string cadena_sql = string.Empty;

        public Conexion() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadena_sql += builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public string GetCadenaSql()
        {
            return cadena_sql;

        }
    }
}
