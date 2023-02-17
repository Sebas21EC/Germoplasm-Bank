using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class IntitutosColectoresTb
{
    public string IdInstitutoPk { get; set; } = null!;

    public string NombreInstituto { get; set; } = null!;

    public string? DetalleInstituto { get; set; }

    public int? IdDireccionFk { get; set; }

    public virtual ICollection<ColectoresTb> ColectoresTbs { get; } = new List<ColectoresTb>();

    public virtual DireccionesTb? IdDireccionFkNavigation { get; set; }
}
