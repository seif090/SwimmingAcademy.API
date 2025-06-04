using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Info", Schema = "PreTeam")]
public partial class Info
{
    [Key]
    [Column("PTeamID")]
    public long PteamId { get; set; }

    [Column("PTeamLevel")]
    public short PteamLevel { get; set; }

    [Column("CoachID")]
    public int CoachId { get; set; }

    [StringLength(10)]
    public string FirstDay { get; set; } = null!;

    [StringLength(10)]
    public string SecondDay { get; set; } = null!;

    [StringLength(10)]
    public string ThirdDay { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal StartTime { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal EndTime { get; set; }

    [Column("site")]
    public short Site { get; set; }

    [Column("createdAtSite")]
    public short CreatedAtSite { get; set; }

    [Column("createdBy")]
    public int CreatedBy { get; set; }

    [Column("createdAtDate", TypeName = "datetime")]
    public DateTime CreatedAtDate { get; set; }

    [Column("updatedAtSite")]
    public short? UpdatedAtSite { get; set; }

    [Column("updatedBy")]
    public int? UpdatedBy { get; set; }

    [Column("updatedAtDate", TypeName = "datetime")]
    public DateTime? UpdatedAtDate { get; set; }

    [ForeignKey("CoachId")]
    [InverseProperty("Infos")]
    public virtual Coach Coach { get; set; } = null!;

    [ForeignKey("CreatedAtSite")]
    [InverseProperty("InfoCreatedAtSiteNavigations")]
    public virtual AppCode CreatedAtSiteNavigation { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("InfoCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Pteam")]
    public virtual ICollection<Detail> Details { get; set; } = new List<Detail>();

    [InverseProperty("Pteam")]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    [ForeignKey("PteamLevel")]
    [InverseProperty("InfoPteamLevelNavigations")]
    public virtual AppCode PteamLevelNavigation { get; set; } = null!;

    [ForeignKey("Site")]
    [InverseProperty("InfoSiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("UpdatedAtSite")]
    [InverseProperty("InfoUpdatedAtSiteNavigations")]
    public virtual AppCode? UpdatedAtSiteNavigation { get; set; }

    [ForeignKey("UpdatedBy")]
    [InverseProperty("InfoUpdatedByNavigations")]
    public virtual User? UpdatedByNavigation { get; set; }
}
