using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class TexturasSuelosTb
{
    public int IdTexturaSueloPk { get; set; }

    public string NombreTexturaSuelo { get; set; } = null!;

    public virtual ICollection<SuelosTb> SuelosTbs { get; } = new List<SuelosTb>();
}
