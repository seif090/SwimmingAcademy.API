using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

public partial class Coach
{
    [Key]
    [Column("CoachID")]
    public int CoachId { get; set; }

    [StringLength(120)]
    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public short Gender { get; set; }

    [Column("certificated")]
    public bool Certificated { get; set; }

    public short CoachType { get; set; }

    [Column("site")]
    public short Site { get; set; }

    [Column("createdAtSite")]
    public short CreatedAtSite { get; set; }

    [Column("createdBy")]
    public int CreatedBy { get; set; }

    [Column("createdAtDate", TypeName = "datetime")]
    public DateTime CreatedAtDate { get; set; }

    [Column("updatedAtDate")]
    public DateOnly? UpdatedAtDate { get; set; }

    [Column("updatedAtSite")]
    public short? UpdatedAtSite { get; set; }

    [Column("updatedBy")]
    public short? UpdatedBy { get; set; }

    [Column("mobileNumber")]
    [StringLength(11)]
    [Unicode(false)]
    public string MobileNumber { get; set; } = null!;

    [ForeignKey("CoachType")]
    [InverseProperty("CoachCoachTypeNavigations")]
    public virtual AppCode CoachTypeNavigation { get; set; } = null!;

    [ForeignKey("CreatedAtSite")]
    [InverseProperty("CoachCreatedAtSiteNavigations")]
    public virtual AppCode CreatedAtSiteNavigation { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Coaches")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Coach")]
    public virtual ICollection<Detail1> Detail1s { get; set; } = new List<Detail1>();

    [InverseProperty("Coach")]
    public virtual ICollection<Detail> Details { get; set; } = new List<Detail>();

    [ForeignKey("Gender")]
    [InverseProperty("CoachGenderNavigations")]
    public virtual AppCode GenderNavigation { get; set; } = null!;

    [InverseProperty("Coach")]
    public virtual ICollection<Info1> Info1s { get; set; } = new List<Info1>();

    [InverseProperty("Coach")]
    public virtual ICollection<Info> Infos { get; set; } = new List<Info>();

    [ForeignKey("Site")]
    [InverseProperty("CoachSiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("UpdatedAtSite")]
    [InverseProperty("CoachUpdatedAtSiteNavigations")]
    public virtual AppCode? UpdatedAtSiteNavigation { get; set; }

    [ForeignKey("UpdatedBy")]
    [InverseProperty("CoachUpdatedByNavigations")]
    public virtual AppCode? UpdatedByNavigation { get; set; }
}
