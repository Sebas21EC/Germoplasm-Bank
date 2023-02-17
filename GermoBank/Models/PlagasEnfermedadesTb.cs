using System;
using System.Collections.Generic;

namespace GermoBank.Models;

public partial class PlagasEnfermedadesTb
{
    public int IdPlagaEnfermedadPk { get; set; }

    public string NombrePlagaEnfermedad { get; set; } = null!;

    public virtual ICollection<AntecedentesTb> AntecedentesTbs { get; } = new List<AntecedentesTb>();
}
