using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Info", Schema = "Swimmers")]
public partial class Info2
{
    [Key]
    [Column("SwimmerID")]
    public long SwimmerId { get; set; }

    [StringLength(120)]
    public string FulllName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public short StartLevel { get; set; }

    public short CurrentLevel { get; set; }

    public short Site { get; set; }

    public short Gender { get; set; }

    [Column("CLub")]
    public short Club { get; set; }

    public short CreatedAtSite { get; set; }

    public int? CreatedBy { get; set; }

    [Column("createdAtDate", TypeName = "datetime")]
    public DateTime CreatedAtDate { get; set; }

    public short? UpdatedAtSite { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAtDate { get; set; }

    [ForeignKey("Club")]
    [InverseProperty("Info2ClubNavigations")]
    public virtual AppCode ClubNavigation { get; set; } = null!;

    [ForeignKey("CreatedAtSite")]
    [InverseProperty("Info2CreatedAtSiteNavigations")]
    public virtual AppCode CreatedAtSiteNavigation { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Info2CreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("CurrentLevel")]
    [InverseProperty("Info2CurrentLevelNavigations")]
    public virtual AppCode CurrentLevelNavigation { get; set; } = null!;

    [InverseProperty("Swimmer")]
    public virtual ICollection<Detail1> Detail1s { get; set; } = new List<Detail1>();

    [InverseProperty("Swimmer")]
    public virtual ICollection<Detail> Details { get; set; } = new List<Detail>();

    [ForeignKey("Gender")]
    [InverseProperty("Info2GenderNavigations")]
    public virtual AppCode GenderNavigation { get; set; } = null!;

    [InverseProperty("Swimmer")]
    public virtual ICollection<Log1> Log1s { get; set; } = new List<Log1>();

    [InverseProperty("Swimmer")]
    public virtual ICollection<Log2> Log2s { get; set; } = new List<Log2>();

    [InverseProperty("Swimmer")]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    [InverseProperty("Swimmer")]
    public virtual Parent? Parent { get; set; }

    [ForeignKey("Site")]
    [InverseProperty("Info2SiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("StartLevel")]
    [InverseProperty("Info2StartLevelNavigations")]
    public virtual AppCode StartLevelNavigation { get; set; } = null!;

    [InverseProperty("Swimmer")]
    public virtual Technical? Technical { get; set; }

    [InverseProperty("Swimmer")]
    public virtual ICollection<Time> Times { get; set; } = new List<Time>();

    [ForeignKey("UpdatedAtSite")]
    [InverseProperty("Info2UpdatedAtSiteNavigations")]
    public virtual AppCode? UpdatedAtSiteNavigation { get; set; }

    [ForeignKey("UpdatedBy")]
    [InverseProperty("Info2UpdatedByNavigations")]
    public virtual User? UpdatedByNavigation { get; set; }
}
