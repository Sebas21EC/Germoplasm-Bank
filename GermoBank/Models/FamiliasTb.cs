using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermoBank.Models;

public partial class FamiliasTb
{
    public int IdFamiliaPk { get; set; }
    public string NombreFamilia { get; set; } = null!;

    public virtual ICollection<GenerosTb> GenerosTbs { get; } = new List<GenerosTb>();
}
