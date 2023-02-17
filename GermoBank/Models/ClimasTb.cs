using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class ClimasTb
{
    public int IdClimaPk { get; set; }

    public decimal TemperaturaClima { get; set; }

    public decimal HumedadClima { get; set; }

    public string Luz { get; set; } = null!;

    public virtual ICollection<LocalidadesTb> LocalidadesTbs { get; } = new List<LocalidadesTb>();
}
