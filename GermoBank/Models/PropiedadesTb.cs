using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class PropiedadesTb
{
    public int IdPropiedadPk { get; set; }

    public string NombrePropiedad { get; set; } = null!;

    public string IdPropietarioFk { get; set; } = null!;

    public int? IdSueloFk { get; set; }

    public int? IdLocalidadFk { get; set; }

    public virtual LocalidadesTb? IdLocalidadFkNavigation { get; set; }

    public virtual PropietariosTb IdPropietarioFkNavigation { get; set; } = null!;

    public virtual SuelosTb? IdSueloFkNavigation { get; set; }
}
