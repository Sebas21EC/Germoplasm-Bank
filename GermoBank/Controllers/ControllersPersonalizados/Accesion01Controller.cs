using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using GermoBank.Models;
using GermoBank.Models.ModelsPersonalizados;
using GermoBank.Models.ModelosAuxiliares;
using Dapper;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using GermoBank.Datos;
using System.Data.SqlClient;

namespace GermoBank.Controllers.ControllersPersonalizados
{
    public class Accesion01Controller : Controller
    {

        private readonly GermoBankUtnContext _context;
        private string codigo_accesion;

        public Accesion01Controller(GermoBankUtnContext context)
        {
            codigo_accesion = "";
            _context = context;
        }


        public IActionResult Index()
        {
            Accesion01Model modelo = new Accesion01Model();
            modelo.familia = _context.FamiliasTbs.ToList();
            return View(modelo);
        }

        public IActionResult Accesion02()
        {
            // código para la vista "OtraVista"
            return View();
        }


        /*
        [HttpPost]
        public JsonResult ObtenerGeneosPorFamilia(int idFamilia)
        {
            var connection = _context.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "ObtenerGeneosPorFamilia";
            command.CommandType = CommandType.StoredProcedure;

            var idRegionParameter = new NpgsqlParameter("idFamilia", NpgsqlDbType.Integer);
            idRegionParameter.Value = idFamilia;
            command.Parameters.Add(idRegionParameter);

            var generos = new List<GenerosTb>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var genero = new GenerosTb
                    {
                        IdGeneroPk = reader.GetInt32(0),
                        NombreGenero = reader.GetString(1)
                    };
                    generos.Add(genero);
                }
            }

            return Json(generos);
        }*/


        [HttpGet]
        [Route("ControllersPersonalizados/Accesion01/ObtenerGeneosPorFamilia/{IdFamilia}")]
        public JsonResult ObtenerGeneosPorFamilia(int IdFamilia)
        {
            Console.WriteLine(IdFamilia);
            Console.WriteLine("*****************************************");
            List<GenerosTb> generos = _context.GenerosTbs.Where(g => g.IdFamiliaFk == IdFamilia).ToList();
            Console.WriteLine(generos.Count);
            return Json(generos);
        }

        [HttpPost]
        public JsonResult ObtenerEspeciesPorGeneros(int idGeneroPk)
        {
            List<EspeciesTb> especies = _context.EspeciesTbs.Where(e => e.IdGeneroFk == idGeneroPk).ToList();
            return Json(especies);
        }



        [HttpPost]
        public JsonResult ObtenerSubespeciesPorEspecies(int idEspeciePk)
        {
            List<SubespeciesTb> subespecies = _context.SubespeciesTbs.Where(s => s.IdEspecieFk == idEspeciePk).ToList();
            return Json(subespecies);
        }

        [HttpPost]
        [Route("ControllersPersonalizados/Accesion01/AgregarAccesion")]

        public IActionResult AgregarAccesion(string subespecie, string nombre_comun, DateTime fecha_recoleccion, bool ejemplar_herbario, bool aislamiento_poblacional, bool cultivos_vecinos)
        {

            Console.WriteLine(subespecie);

             codigo_accesion = "SEBAS-"+ nombre_comun;
            using (var context = new GermoBankUtnContext())
                {



                    var conn = context.Database.GetDbConnection();

                    try
                    {
                        conn.Open();

                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = "AGREGAR_ACCESION_01_SP";
                            command.CommandType = CommandType.StoredProcedure;


                        // agregar los parametros del procedimiento almacenado
                        command.Parameters.Add(new NpgsqlParameter("codigo_accesion", codigo_accesion));
                            command.Parameters.Add(new NpgsqlParameter("nombre_comun", nombre_comun));
                        command.Parameters.Add(new NpgsqlParameter("subespecie", subespecie));
                        command.Parameters.Add(new NpgsqlParameter("ejemplar_herbario", ejemplar_herbario));
                            command.Parameters.Add(new NpgsqlParameter("aislamiento_poblacional", aislamiento_poblacional));
                            command.Parameters.Add(new NpgsqlParameter("cultivos_vecinos", cultivos_vecinos));
                            command.Parameters.Add(new NpgsqlParameter("fecha_recoleccion", fecha_recoleccion));

                            // agregar parametro de salida
                            /* var returnParam = new NpgsqlParameter("id_accesion_pk", NpgsqlDbType.Bigint);
                             returnParam.Direction = ParameterDirection.Output;
                             command.Parameters.Add(returnParam);*/

                            // ejecutar el procedimiento almacenado
                            command.ExecuteNonQuery();

                            // obtener el valor de retorno del procedimiento almacenado
                            /*idAccesion = (long)command.Parameters["id_accesion_pk"].Value;*/
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }


                return RedirectToAction("Accesion02", "Accesion01");
                // redirigir al usuario a la pagina de detalles de la nueva accesión

        }




        public IActionResult AgregarAccesion_02(string nombre_propiedad, string nombre_propietario, string apellido_propietario, string telefono_propietario, string email_propietario,string codigo_parroquia, string calle_principal,string calle_secundaria, string referencia_cercana)
        {

            Console.WriteLine(nombre_propiedad);

            codigo_accesion = "SEBAS-" + nombre_propiedad;
            using (var context = new GermoBankUtnContext())
            {



                var conn = context.Database.GetDbConnection();

                try
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "AGREGAR_ACCESION_01_SP";
                        command.CommandType = CommandType.StoredProcedure;


                        // agregar los parametros del procedimiento almacenado
                        command.Parameters.Add(new NpgsqlParameter("codigo_accesion", codigo_accesion));
                        command.Parameters.Add(new NpgsqlParameter("nombre_comun", nombre_comun));
                        command.Parameters.Add(new NpgsqlParameter("subespecie", subespecie));
                        command.Parameters.Add(new NpgsqlParameter("ejemplar_herbario", ejemplar_herbario));
                        command.Parameters.Add(new NpgsqlParameter("aislamiento_poblacional", aislamiento_poblacional));
                        command.Parameters.Add(new NpgsqlParameter("cultivos_vecinos", cultivos_vecinos));
                        command.Parameters.Add(new NpgsqlParameter("fecha_recoleccion", fecha_recoleccion));

                        // agregar parametro de salida
                        /* var returnParam = new NpgsqlParameter("id_accesion_pk", NpgsqlDbType.Bigint);
                         returnParam.Direction = ParameterDirection.Output;
                         command.Parameters.Add(returnParam);*/

                        // ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();

                        // obtener el valor de retorno del procedimiento almacenado
                        /*idAccesion = (long)command.Parameters["id_accesion_pk"].Value;*/
                    }
                }
                finally
                {
                    conn.Close();
                }
            }


            return RedirectToAction("Accesion02", "Accesion01");
            // redirigir al usuario a la pagina de detalles de la nueva accesión

        }

    }
}
