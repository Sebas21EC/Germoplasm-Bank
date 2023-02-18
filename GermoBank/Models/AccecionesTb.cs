using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermoBank.Models;

public partial class AccecionesTb
{
    public string IdAccesionPk { get; set; } = null!;

 
    public DateOnly FechaRecoleccionAccesion { get; set; }

    
    public string NombreLocalAccesion { get; set; } = null!;


    public bool AislamientoPoblacional { get; set; }

    public bool CultivosCernanos { get; set; }

    public bool EjemplarHerbario { get; set; }

    public byte[]? Fotografia { get; set; }

    public int? IdMetodoMuestraFk { get; set; }

    public int? IdEstadoGermoplasmaFk { get; set; }

    public int? IdSubespecieFk { get; set; }

    public int? IdAntecedenteFk { get; set; }

    public int? IdPropiedadFk { get; set; }

    public string? IdColectorFk { get; set; }

    public virtual AntecedentesTb? IdAntecedenteFkNavigation { get; set; }

    public virtual ColectoresTb? IdColectorFkNavigation { get; set; }

    public virtual EstadosGermoplasmasTb? IdEstadoGermoplasmaFkNavigation { get; set; }

    public virtual MetodosMuestreosTb? IdMetodoMuestraFkNavigation { get; set; }

    public virtual PropiedadesTb? IdPropiedadFkNavigation { get; set; }

    public virtual SubespeciesTb? IdSubespecieFkNavigation { get; set; }
}
