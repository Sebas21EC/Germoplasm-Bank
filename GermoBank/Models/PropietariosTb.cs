using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class PropietariosTb
{
    public string IdPropietarioPk { get; set; } = null!;

    public string NombrePropietario { get; set; } = null!;

    public string ApellidoPropietario { get; set; } = null!;

    public string? TelefonoPropietario { get; set; }

    public string? EmailPropietario { get; set; }

    public virtual ICollection<PropiedadesTb> PropiedadesTbs { get; } = new List<PropiedadesTb>();
}
