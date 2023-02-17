using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class LocalidadesTb
{
    public int IdLocalidadPk { get; set; }

    public string LatitudPropiedad { get; set; } = null!;

    public string AltitudPropiedad { get; set; } = null!;

    public string LongitudPropiedad { get; set; } = null!;

    public int? IdDireccionFk { get; set; }

    public int? IdFormaGeograficaFk { get; set; }

    public int? IdClimaFk { get; set; }

    public virtual ClimasTb? IdClimaFkNavigation { get; set; }

    public virtual DireccionesTb? IdDireccionFkNavigation { get; set; }

    public virtual FormasGeograficasTb? IdFormaGeograficaFkNavigation { get; set; }

    public virtual ICollection<PropiedadesTb> PropiedadesTbs { get; } = new List<PropiedadesTb>();
}
