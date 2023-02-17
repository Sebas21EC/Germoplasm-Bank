using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class CantonesTb
{
    public string IdCantonPk { get; set; } = null!;

    public string NombreCanton { get; set; } = null!;

    public string? IdProvinciaFk { get; set; }

    public virtual ProvinciasTb? IdProvinciaFkNavigation { get; set; }

    public virtual ParroquiasTb? ParroquiasTb { get; set; }
}
