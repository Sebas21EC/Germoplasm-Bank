using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class DireccionesTb
{
    public int IdDireccionPk { get; set; }

    public string CallePrincipal { get; set; } = null!;

    public string CalleSecundaria { get; set; } = null!;

    public string ReferenciaDirecion { get; set; } = null!;

    public string? IdParroquiaFk { get; set; }

    public virtual ICollection<ColectoresTb> ColectoresTbs { get; } = new List<ColectoresTb>();

    public virtual ParroquiasTb? IdParroquiaFkNavigation { get; set; }

    public virtual ICollection<IntitutosColectoresTb> IntitutosColectoresTbs { get; } = new List<IntitutosColectoresTb>();

    public virtual ICollection<LocalidadesTb> LocalidadesTbs { get; } = new List<LocalidadesTb>();
}
