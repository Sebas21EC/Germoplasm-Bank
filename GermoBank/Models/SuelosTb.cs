using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class SuelosTb
{
    public int IdSueloPk { get; set; }

    public string ColorSuelo { get; set; } = null!;

    public bool DrenajeSuelo { get; set; }

    public bool ErosionSuelo { get; set; }

    public bool PedregosidadSuelo { get; set; }

    public int? IdTexturaSueloFk { get; set; }

    public virtual TexturasSuelosTb? IdTexturaSueloFkNavigation { get; set; }

    public virtual ICollection<PropiedadesTb> PropiedadesTbs { get; } = new List<PropiedadesTb>();
}
