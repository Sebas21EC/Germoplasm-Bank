using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class PracticasCulturalesTb
{
    public int IdPracticaCulturalPk { get; set; }

    public string NombrePracticaCultural { get; set; } = null!;

    public virtual ICollection<AntecedentesTb> AntecedentesTbs { get; } = new List<AntecedentesTb>();
}
