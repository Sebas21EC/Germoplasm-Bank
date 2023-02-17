

using GermoBank.Models.ModelsPersonalizados;
using NuGet.Protocol.Plugins;
using System.Data.Sql;
using System.Data.SqlClient;


namespace GermoBank.Datos.DatosPersonalizados

{
    public class Accesion01Datos
    { /*
        public class Familia
        {
            public int id_familia { get; set; }
            public string nombre { get; set; }
        }

        public class Genero { 
            public int id_genero { get; set; }
            public string nombre { get; set; }
            public int id_familia { get; set; }
        }

        public class Especie
        {
            public int id_especie { get; set; }
            public string nombre { get; set; }
            public int id_genero { get; set; }
        }

        public class Subespecie
        {
            public int id_subespecie { get; set; }
            public string nombre { get; set; }
            public int id_especie { get; set; }
        }

        public class Accesion
        {
            public int id_accesion { get; set; }
            public DateOnly fecha_recoleccion { get; set; }
            public bool ejemplar_hervario { get; set; }
            public bool aislamiento_poblacional { get; set; }
            public bool cultivos_cercanos { get; set; }
            public byte[] fotografia { get; set; }

        }*/

        /*

        public bool guardarAccesion01(Accesion01Model accesion01)
        {
            bool respuest;

            try
            {
                var CN = new Conexion();

                using (var conexion = new SqlConnection(CN.GetCadenaSql()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("AGREGAR_ACCESION_SP", conexion);
                    cmd.Parameters.AddWithValue("SUBESPECIE",accesion01.subespecie);
                    cmd.Parameters.AddWithValue("NOMBRE_COMUN",);
                    cmd.Parameters.AddWithValue("EJEMPLO_HERVARIO");
                    cmd.Parameters.AddWithValue("AISLAMIENTO_POBLACIONAL");
                    cmd.Parameters.AddWithValue("CULTIVOS_VECINOS");
                    cmd.Parameters.AddWithValue("FECHA_RECOLECCION");

                }


            }
            catch(Exception ex)
            {

            }


            return respuest;

        }*/

    }
}
