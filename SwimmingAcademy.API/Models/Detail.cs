using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Details", Schema = "PreTeam")]
public partial class Detail
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PTeamID")]
    public long PteamId { get; set; }

    [Column("SwimmerID")]
    public long SwimmerId { get; set; }

    [Column("CoachID")]
    public int CoachId { get; set; }

    public short SwimmerLevel { get; set; }

    public short LastStar { get; set; }

    [Column("site")]
    public short Site { get; set; }

    [StringLength(10)]
    public string? Attendence { get; set; }

    [ForeignKey("CoachId")]
    [InverseProperty("Details")]
    public virtual Coach Coach { get; set; } = null!;

    [ForeignKey("PteamId")]
    [InverseProperty("Details")]
    public virtual Info Pteam { get; set; } = null!;

    [ForeignKey("Site")]
    [InverseProperty("DetailSiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("SwimmerId")]
    [InverseProperty("Details")]
    public virtual Info2 Swimmer { get; set; } = null!;

    [ForeignKey("SwimmerLevel")]
    [InverseProperty("DetailSwimmerLevelNavigations")]
    public virtual AppCode SwimmerLevelNavigation { get; set; } = null!;
}
