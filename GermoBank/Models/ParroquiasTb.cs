using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class ParroquiasTb
{
    public string IdParroquiaPk { get; set; } = null!;

    public string NombreParroquia { get; set; } = null!;

    public string? IdCantonFk { get; set; }

    public virtual ICollection<DireccionesTb> DireccionesTbs { get; } = new List<DireccionesTb>();

    public virtual CantonesTb? IdCantonFkNavigation { get; set; }
}
