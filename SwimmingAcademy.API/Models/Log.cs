using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("log", Schema = "PreTeam")]
public partial class Log
{
    [Key]
    [Column("LID")]
    public long Lid { get; set; }

    [Column("PteamID")]
    public long PteamId { get; set; }

    [Column("ActionID")]
    public int ActionId { get; set; }

    [Column("SwimmerID")]
    public long? SwimmerId { get; set; }

    public short CreatedAtSite { get; set; }

    [Column("createdby")]
    public int Createdby { get; set; }

    [Column("createdAtDate")]
    public DateOnly CreatedAtDate { get; set; }

    [ForeignKey("ActionId")]
    [InverseProperty("Logs")]
    public virtual Action Action { get; set; } = null!;

    [ForeignKey("CreatedAtSite")]
    [InverseProperty("Logs")]
    public virtual AppCode CreatedAtSiteNavigation { get; set; } = null!;

    [ForeignKey("Createdby")]
    [InverseProperty("Logs")]
    public virtual User CreatedbyNavigation { get; set; } = null!;

    [ForeignKey("PteamId")]
    [InverseProperty("Logs")]
    public virtual Info Pteam { get; set; } = null!;

    [ForeignKey("SwimmerId")]
    [InverseProperty("Logs")]
    public virtual Info2? Swimmer { get; set; }
}
