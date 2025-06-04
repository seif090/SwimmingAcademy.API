using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Technical", Schema = "Swimmers")]
public partial class Technical
{
    [Key]
    [Column("SwimmerID")]
    public long SwimmerId { get; set; }

    public short Site { get; set; }

    public short CurrentLevel { get; set; }

    [Column("ISSchool")]
    public bool? Isschool { get; set; }

    [Column("ISPreTeam")]
    public bool? IspreTeam { get; set; }

    public short? LastStar { get; set; }

    [Column("ISTeam")]
    public bool? Isteam { get; set; }

    public bool? IsShort { get; set; }

    [Column("FirstSP")]
    public short? FirstSp { get; set; }

    [Column("SecondSP")]
    public short? SecondSp { get; set; }

    [Column("IsIM")]
    public bool? IsIm { get; set; }

    public bool? IsFs { get; set; }

    public bool? IsLong { get; set; }

    public bool? IsFins { get; set; }

    public bool? IsMono { get; set; }

    public int Addedby { get; set; }

    public DateOnly AddedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    [ForeignKey("Addedby")]
    [InverseProperty("TechnicalAddedbyNavigations")]
    public virtual User AddedbyNavigation { get; set; } = null!;

    [ForeignKey("CurrentLevel")]
    [InverseProperty("TechnicalCurrentLevelNavigations")]
    public virtual AppCode CurrentLevelNavigation { get; set; } = null!;

    [ForeignKey("FirstSp")]
    [InverseProperty("TechnicalFirstSpNavigations")]
    public virtual AppCode? FirstSpNavigation { get; set; }

    [ForeignKey("LastStar")]
    [InverseProperty("TechnicalLastStarNavigations")]
    public virtual AppCode? LastStarNavigation { get; set; }

    [ForeignKey("SecondSp")]
    [InverseProperty("TechnicalSecondSpNavigations")]
    public virtual AppCode? SecondSpNavigation { get; set; }

    [ForeignKey("Site")]
    [InverseProperty("TechnicalSiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("SwimmerId")]
    [InverseProperty("Technical")]
    public virtual Info2 Swimmer { get; set; } = null!;

    [ForeignKey("UpdatedBy")]
    [InverseProperty("TechnicalUpdatedByNavigations")]
    public virtual User? UpdatedByNavigation { get; set; }
}
