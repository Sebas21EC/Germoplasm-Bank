using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using GermoBank.Models;
using GermoBank.Models.ModelsPersonalizados;

namespace GermoBank.Controllers.ControllersPersonalizados
{
    public class Accesion01Controller : Controller
    {

        private readonly GermoBankUtnContext _context;

        public Accesion01Controller(GermoBankUtnContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var modelo = new Accesion01Model();

            modelo.familia = _context.FamiliasTbs.ToList();

            return View(modelo);
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

        [HttpPost]
        public JsonResult ObtenerGeneosPorFamilia(int idFamilia)
        {
            var generos = _context.GenerosTbs
                .FromSqlInterpolated($"SELECT * FROM ObtenerRegionesPorPais({idFamilia})")
                .ToList();

            return Json(generos);
        }


        [HttpPost]
            public JsonResult ObtenerEspeciesPorGeneros(int id_generos)
            {
                var especies = _context.EspeciesTbs
                    .FromSqlInterpolated($"SELECT * FROM ObtenerEspeciesPorGeneros({id_generos})")
                    .ToList();

                return Json(especies);
            }

            [HttpPost]
            public JsonResult ObtenerBarriosPorCiudad(int id_especie)
            {
                var subespecie = _context.SubespeciesTbs
                    .FromSqlInterpolated($"SELECT * FROM ObtenerSubespeciesPorEspecies({id_especie})")
                    .ToList();

                return Json(subespecie);
            }
    }
}
