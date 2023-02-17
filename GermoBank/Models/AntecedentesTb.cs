using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class AntecedentesTb
{
    public int IdAntecedentePk { get; set; }

    public string ObservacionAntecedente { get; set; } = null!;

    public DateOnly? FechaSiembra { get; set; }

    public DateOnly? FechaCosecha { get; set; }

    public DateOnly? FechaFloracion { get; set; }

    public DateOnly? FechaFructuacion { get; set; }

    public int? IdPlagaEnfermedadFk { get; set; }

    public int? IdUsoFk { get; set; }

    public int? IdPracticaCulturalFk { get; set; }

    public virtual PlagasEnfermedadesTb? IdPlagaEnfermedadFkNavigation { get; set; }

    public virtual PracticasCulturalesTb? IdPracticaCulturalFkNavigation { get; set; }

    public virtual UsosTb? IdUsoFkNavigation { get; set; }
}
