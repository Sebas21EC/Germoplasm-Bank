using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class SubespeciesTb
{
    public int IdSubespeciePk { get; set; }

    public string NombreSubespecie { get; set; } = null!;

    public int? IdEspecieFk { get; set; }

    public virtual EspeciesTb? IdEspecieFkNavigation { get; set; }
}
