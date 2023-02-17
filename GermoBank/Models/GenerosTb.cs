using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class GenerosTb
{
    public int IdGeneroPk { get; set; }

    public string NombreGenero { get; set; } = null!;

    public int? IdFamiliaFk { get; set; }

    public virtual ICollection<EspeciesTb> EspeciesTbs { get; } = new List<EspeciesTb>();

    public virtual FamiliasTb? IdFamiliaFkNavigation { get; set; }
}
