using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using GermoBank.Models;
using GermoBank.Models.ModelsPersonalizados;
using Dapper;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using GermoBank.Datos;
using System.Data.SqlClient;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Metadata;
using GermoBank.Datos.DatosPersonalizados;

namespace GermoBank.Controllers.ControllersPersonalizados
{
    public class Accesion01Controller : Controller
    {

        private readonly GermoBankUtnContext _context;
        private string codigo_accesion;
        private string codigo_propiedad;
        AccesionDatos _accecionDatos = new AccesionDatos();

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
            Accesion02Model modelo = new Accesion02Model();
            modelo.texturasSuelosTbs = _context.TexturasSuelosTbs.ToList();
            return View(modelo);
        }


        public IActionResult Accesion03()
        {
            Accesion03Model modelo = new Accesion03Model();
            modelo.provincias = _context.ProvinciasTbs.ToList();
            modelo.formasGeograficasTbs=_context.FormasGeograficasTbs.ToList();
            return View(modelo);

        }

        public IActionResult Accesion04()
        {
            Accesion04Model modelo = new Accesion04Model();
            modelo.estadosGermoplasmas=_context.EstadosGermoplasmasTbs.ToList();
            modelo.metodosMuestreos=_context.MetodosMuestreosTbs.ToList();
            modelo.plagasEnfermedades = _context.PlagasEnfermedadesTbs.ToList();
            modelo.usos=_context.UsosTbs.ToList();
            modelo.practicasCulturales=_context.PracticasCulturalesTbs.ToList();
            return View(modelo);
        }




        public IActionResult ListarAccesiones()
        {
            Console.WriteLine("LLegando a funcion");

            List<AccesionesModel> resultados = new List<AccesionesModel>();
            using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=GermoBank_UTN;User Id=postgres;Password=root;"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT " +
                    "nombre_local_accesion, codigo_acc, fecha_ing," +
                    "nombre_fam, nombre_gen,nombre_esp,nombre_subes," +
                    "nombre_inst,detalle_inst,primer_nombre_col,primer_apellido_col,telefono_col,email_col," +
                    "nombre_us,nombre_practica_cul,nombre_plaga_enf,fecha_sie,fecha_cos,fecha_flo,fecha_fru,observacion_ant," +
                    "nombre_pro,nombre_prop,apellido_prop,telefono_prop,email_prop," +
                    "nombre_pai,nombre_prov,nombre_can,nombre_parr,calle_prin,calle_secu,referencia_dir," +
                    "latitud_pro,altitud_pro,longitud_pro,nombre_forma_geo,luz,temperatura_cli,humedad_cli," +
                    "nombre_textura_sue,col,drenaje_sue,erosion_sue,pedregosidad_sue," +
                    "nombre_estado_germoplasma,nombre_metodo_muestra " +
                    " FROM ACCESION_ULTIMA();", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Número de filas devueltas: " + reader.FieldCount);
                        Console.WriteLine("Antes de While");
                        while (reader.Read())
                        {
                            Console.WriteLine("Dentro del while");
                            AccesionesModel resultado = new AccesionesModel
                            {
                   
                                nombre_local_accesion =     reader.GetString(0),
                                id_accesion_pk =            reader.GetString(1),
                                fecha_ingreso =             reader.GetDateTime(2),

                                /*taxonomia*/
                                nombre_familia =            reader.GetString(3),
                                nombre_genero =             reader.GetString(4),
                                nombre_especie =            reader.GetString(5),
                                nombre_subespecie =         reader.GetString(6),

                                /*recolector*/
                                nombre_instituto =          reader.GetString(7),
                                detalle_instituto =         reader.GetString(8),
                                primer_nombre_colector =    reader.GetString(9),
                                primer_apellido_colector =  reader.GetString(10),
                                telefono_colecto =          reader.GetString(11),
                                email_colector =            reader.GetString(12),
                            
                                /*antecedentes*/
                                nombre_uso =                reader.GetString(13),
                                nombre_practica_cultural =  reader.GetString(14),
                                nombre_plaga_enfermedad =   reader.GetString(15),
                                fecha_siembra =             reader.GetDateTime(16),
                                fecha_cosecha =             reader.GetDateTime(17),
                                fecha_floracion =           reader.GetDateTime(18),
                                fecha_fructuacion =         reader.GetDateTime(19),
                                observacion_antecedente =   reader.GetString(20),


                                /*propiedad*/
                                nombre_propiedad =          reader.GetString(21),
                                nombre_propietario =        reader.GetString(22),
                                apellido_propietario =      reader.GetString(23),
                                telefono_propietario =      reader.GetString(24),
                                email_propietario =         reader.GetString(25),


                                /*ubicacion*/
                                nombre_pais =               reader.GetString(26),
                                nombre_provincia =          reader.GetString(27),
                                nombre_canton =             reader.GetString(28),
                                nombre_parroquia =          reader.GetString(29),
                                calle_principal =           reader.GetString(30),
                                calle_secundaria =          reader.GetString(31),
                                referencia_direcion =       reader.GetString(32),

                                /*detalles de la localidad*/
                                latitud_propiedad =         reader.GetString(33),
                                altitud_propiedad =         reader.GetString(34),
                                longitud_propiedad =        reader.GetString(35),
                                nombre_forma_geografica =   reader.GetString(36),
                                luz =                       reader.GetString(37),
                                temperatura_clima =         reader.GetString(38),
                                humedad_clima =             reader.GetString(39),

                                /*suelo*/
                                nombre_textura_suelo =      reader.GetString(40),
                                color =                     reader.GetString(41),
                                drenaje_suelo =             reader.GetBoolean(42),
                                erosion_suelo =             reader.GetBoolean(43),
                                pedregosidad_suelo =        reader.GetBoolean(44),

                                /*mas detalles */
                                nombre_estado_germoplasma = reader.GetString(45),
                                nombre_metodo_muestra =     reader.GetString(46)

                                // Añade más propiedades según los datos que devuelva tu función
                            };
                            resultados.Add(resultado);
                            Console.WriteLine(resultado.id_accesion_pk+"--------------");
                        }
                        Console.WriteLine("Fuera de While");

                    }
                }
            }
            return View(resultados);
        }

        public IActionResult ObtenerAccesion()
        {
            var oLista = _accecionDatos.ObtenerAccesion();
            return View(oLista);
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
            Random num_ram = new Random();
            int numero = num_ram.Next(100000);

            codigo_accesion = numero + "-" + nombre_comun;

            Console.WriteLine(nombre_comun);
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
                        command.Parameters.Add(new NpgsqlParameter("codigo_accesion", codigo_accesion.ToUpper()));
                        command.Parameters.Add(new NpgsqlParameter("nombre_comun", nombre_comun.ToUpper()));
                        command.Parameters.Add(new NpgsqlParameter("subespecie", subespecie.ToUpper()));
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


        [HttpPost]
        [Route("Accesion01/AgregarAccesion_02")]
        public IActionResult AgregarAccesion_02(string codigo_propietario, string nombre_propiedad, string nombre_propietario, string apellido_propietario, string telefono_propietario, string email_propietario, string color_suelo, bool drenaje_suelo, bool erosion_suelo, bool pedregosidad_suelo, string codigo_textura)
        {
            Console.WriteLine(nombre_propiedad);
            Random num_ram = new Random();
            int numero = num_ram.Next(100000);

            this.codigo_propiedad = codigo_propietario + ("-" + numero);
            using (var context = new GermoBankUtnContext())
            {

                var conn = context.Database.GetDbConnection();

                /*  try
                  {*/
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "AGREGAR_ACCESION_02_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    // agregar los parametros del procedimiento almacenado
                    command.Parameters.Add(new NpgsqlParameter("codigo_propiedad", codigo_propiedad));
                    command.Parameters.Add(new NpgsqlParameter("codigo_propietario", "" + numero));
                    command.Parameters.Add(new NpgsqlParameter("nombre_propiedad", nombre_propiedad.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("nombre_propietario", nombre_propietario.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("apellido_propietario", apellido_propietario.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("telefono_propietario", telefono_propietario));
                    command.Parameters.Add(new NpgsqlParameter("email_propietario", email_propietario.ToLower()));
                    command.Parameters.Add(new NpgsqlParameter("color_suelo", color_suelo.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("drenaje_suelo", drenaje_suelo));
                    command.Parameters.Add(new NpgsqlParameter("erosion_suelo", erosion_suelo));
                    command.Parameters.Add(new NpgsqlParameter("pedregosidad_suelo", pedregosidad_suelo));
                    command.Parameters.Add(new NpgsqlParameter("codigo_textura", Convert.ToInt32(codigo_textura)));


                    // agregar parametro de salida
                    /* var returnParam = new NpgsqlParameter("id_accesion_pk", NpgsqlDbType.Bigint);
                     returnParam.Direction = ParameterDirection.Output;
                     command.Parameters.Add(returnParam);*/

                    // ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // obtener el valor de retorno del procedimiento almacenado
                    /*idAccesion = (long)command.Parameters["id_accesion_pk"].Value;*/
                }
                /* }
                 finally
                 {*/
                conn.Close();
                /*}*/
            }


            return RedirectToAction("Accesion03", "Accesion01");
            // redirigir al usuario a la pagina de detalles de la nueva accesión


        }





        [HttpPost]
        public JsonResult ObtenerCantonesPorProvincia(string IdProvinciaPk)
        {
            Console.WriteLine(IdProvinciaPk);
            Console.WriteLine("**********-------------------------------********");
            List<CantonesTb> cantones = _context.CantonesTbs.Where(g => g.IdProvinciaFk == IdProvinciaPk).ToList();
            Console.WriteLine(cantones.Count);
            return Json(cantones);
        }

        [HttpPost]
        public JsonResult ObtenerParroquiasPorCantone(String IdCantonPk)
        {
            List<ParroquiasTb> parroquias = _context.ParroquiasTbs.Where(e => e.IdCantonFk == IdCantonPk).ToList();
            return Json(parroquias);
        }



        [HttpPost]
        [Route("Accesion01/AgregarAccesion_03")]
        public IActionResult AgregarAccesion_03(string codigo_parroquia, string c_principal, string c_secundaria, string referencia, string latitud, string altitud, string longitud, string temperatura, string humedad, string luz, int codigo_forma_geograficas)
        {
            Console.WriteLine(codigo_parroquia);
            Console.WriteLine(codigo_forma_geograficas);
            Console.WriteLine(humedad);
            Console.WriteLine(temperatura);

            using (var context = new GermoBankUtnContext())
            {

                var conn = context.Database.GetDbConnection();

                /*  try
                  {*/
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "AGREGAR_ACCESION_03_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    // agregar los parametros del procedimiento almacenado
                    command.Parameters.Add(new NpgsqlParameter("codigo_parroquia", codigo_parroquia));
                    command.Parameters.Add(new NpgsqlParameter("c_principal", c_principal.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("c_secundaria", c_secundaria.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("referencia", referencia.ToUpper()));
                    command.Parameters.Add(new NpgsqlParameter("latitud", latitud));
                    command.Parameters.Add(new NpgsqlParameter("altitud", altitud));
                    command.Parameters.Add(new NpgsqlParameter("longitud", longitud));
                    command.Parameters.Add(new NpgsqlParameter("temperatura", temperatura));
                    command.Parameters.Add(new NpgsqlParameter("humedad", humedad));
                    command.Parameters.Add(new NpgsqlParameter("luz", luz));
                    command.Parameters.Add(new NpgsqlParameter("codigo_forma_geografica", codigo_forma_geograficas));
                    command.ExecuteNonQuery();


                }
                /* }
                 finally
                 {*/
                conn.Close();
                /*}*/
            }


            return RedirectToAction("Accesion04", "Accesion01");
            // redirigir al usuario a la pagina de detalles de la nueva accesión


        }



        [HttpPost]
        [Route("Accesion01/AgregarAccesion_04")]
        public IActionResult AgregarAccesion_04(int codigo_estado, int codigo_muestra, DateTime fecha_sie, DateTime fecha_cos, DateTime fecha_flo, DateTime fecha_fru, int codigo_plaga, int codigo_uso, int codigo_practica, string observacion)
        {
            Console.WriteLine(codigo_estado);
            Console.WriteLine(fecha_sie);
            Console.WriteLine(codigo_muestra);
            Console.WriteLine(observacion);

            using (var context = new GermoBankUtnContext())
            {

                var conn = context.Database.GetDbConnection();

                /*  try
                  {*/
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "AGREGAR_ACCESION_04_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    // agregar los parametros del procedimiento almacenado
                    command.Parameters.Add(new NpgsqlParameter("codigo_estado", codigo_estado));
                    command.Parameters.Add(new NpgsqlParameter("codigo_muestra", codigo_muestra));
                    command.Parameters.Add(new NpgsqlParameter("fecha_sie", fecha_sie));
                    command.Parameters.Add(new NpgsqlParameter("fecha_cos", fecha_cos));
                    command.Parameters.Add(new NpgsqlParameter("fecha_flo", fecha_flo));
                    command.Parameters.Add(new NpgsqlParameter("fecha_fru", fecha_fru));
                    command.Parameters.Add(new NpgsqlParameter("codigo_plaga", codigo_plaga));
                    command.Parameters.Add(new NpgsqlParameter("codigo_uso", codigo_uso));
                    command.Parameters.Add(new NpgsqlParameter("codigo_practica", codigo_practica));
                    command.Parameters.Add(new NpgsqlParameter("observacion", observacion.ToUpper()));
                    command.ExecuteNonQuery();


                }
                /* }
                 finally
                 {*/
                conn.Close();
                /*}*/
            }


            return RedirectToAction("ListarAccesiones", "Accesion01");
            // redirigir al usuario a la pagina de detalles de la nueva accesión


        }

    }
}
