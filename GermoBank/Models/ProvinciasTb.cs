using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class ProvinciasTb
{
    public string IdProvinciaPk { get; set; } = null!;

    public string NombreProvincia { get; set; } = null!;

    public string? IdPaisFk { get; set; }

    public virtual ICollection<CantonesTb> CantonesTbs { get; } = new List<CantonesTb>();

    public virtual PaisesTb? IdPaisFkNavigation { get; set; }
}
