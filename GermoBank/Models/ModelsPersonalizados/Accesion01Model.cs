using MessagePack;
using GermoBank.Models.ModelsPersonalizados;
using System.ComponentModel.DataAnnotations;

namespace GermoBank.Models.ModelsPersonalizados
{
    public class Accesion01Model
    {

        public List<FamiliasTb> familia { get; set; }   
        public List<GenerosTb> genero { get; set; }   
        public List<EspeciesTb> especie { get; set; }   
        public List<SubespeciesTb> subespecie { get; set; }



        //public List<AccecionesTb> accesion { get; set; }

     
        

    }
}
