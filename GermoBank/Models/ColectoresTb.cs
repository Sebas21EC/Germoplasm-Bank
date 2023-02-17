using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class ColectoresTb
{
    public string IdColectorPk { get; set; } = null!;

    public string PrimerNombreColector { get; set; } = null!;

    public string? SegundoNombreColector { get; set; }

    public string PrimerApellidoColector { get; set; } = null!;

    public string? SegundoApellidoColector { get; set; }

    public string TelefonoColecto { get; set; } = null!;

    public string EmailColector { get; set; } = null!;

    public string ContaseniaColector { get; set; } = null!;

    public string? IdInstitutoFk { get; set; }

    public int? IdDireccionFk { get; set; }

    public virtual DireccionesTb? IdDireccionFkNavigation { get; set; }

    public virtual IntitutosColectoresTb? IdInstitutoFkNavigation { get; set; }
}
