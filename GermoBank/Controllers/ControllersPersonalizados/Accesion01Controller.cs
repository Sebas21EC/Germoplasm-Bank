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
            Accesion01Model modelo = new Accesion01Model();
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

    }
}
