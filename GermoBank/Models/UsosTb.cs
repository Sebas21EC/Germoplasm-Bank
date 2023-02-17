using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class UsosTb
{
    public int IdUsoPk { get; set; }

    public string NombreUso { get; set; } = null!;

    public virtual ICollection<AntecedentesTb> AntecedentesTbs { get; } = new List<AntecedentesTb>();
}
