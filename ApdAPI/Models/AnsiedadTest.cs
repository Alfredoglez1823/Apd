using System;
using System.Collections.Generic;

namespace ApdAPI.Models;

public partial class AnsiedadTest
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Fecha { get; set; }

    public byte? TorpeEntumecido { get; set; }

    public byte? Acalorado { get; set; }

    public byte? TemblorPiernas { get; set; }

    public byte? IncapazRelajarse { get; set; }

    public byte? TemorOcurrirPeor { get; set; }

    public byte? Mareado { get; set; }

    public byte? LatidosFuertesAcelerados { get; set; }

    public byte? Inestable { get; set; }

    public byte? Atemorizado { get; set; }

    public byte? Nervioso { get; set; }

    public byte? SensacionBloqueo { get; set; }

    public byte? TembloresManos { get; set; }

    public byte? InquietoInseguro { get; set; }

    public byte? MiedoPerderControl { get; set; }

    public byte? SensacionAhogo { get; set; }

    public byte? TemorMorir { get; set; }

    public byte? Miedo { get; set; }

    public byte? ProblemasDigestivos { get; set; }

    public byte? Desvanecimientos { get; set; }

    public byte? RuborFacial { get; set; }

    public byte? SudoresFriosCalientes { get; set; }

    public int? PuntuacionAnsiedad { get; set; }
}
