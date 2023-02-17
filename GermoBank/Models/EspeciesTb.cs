using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class EspeciesTb
{
    public int IdEspeciePk { get; set; }

    public string NombreEspecie { get; set; } = null!;

    public int? IdGeneroFk { get; set; }

    public virtual GenerosTb? IdGeneroFkNavigation { get; set; }

    public virtual ICollection<SubespeciesTb> SubespeciesTbs { get; } = new List<SubespeciesTb>();
}
