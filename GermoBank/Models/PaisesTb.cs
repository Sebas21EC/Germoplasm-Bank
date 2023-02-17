using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class PaisesTb
{
    public string IdPaisPk { get; set; } = null!;

    public string NombrePais { get; set; } = null!;

    public virtual ICollection<ProvinciasTb> ProvinciasTbs { get; } = new List<ProvinciasTb>();
}
