using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class FormasGeograficasTb
{
    public int IdFormaGeograficaPk { get; set; }

    public string NombreFormaGeografica { get; set; } = null!;

    public virtual ICollection<LocalidadesTb> LocalidadesTbs { get; } = new List<LocalidadesTb>();
}
