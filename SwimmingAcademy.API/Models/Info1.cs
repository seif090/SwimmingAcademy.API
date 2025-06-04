using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("info", Schema = "Schools")]
public partial class Info1
{
    [Key]
    [Column("SchoolID")]
    public long SchoolId { get; set; }

    [Column("schoolLevel")]
    public short SchoolLevel { get; set; }

    [Column("CoachID")]
    public int CoachId { get; set; }

    [StringLength(10)]
    public string FirstDay { get; set; } = null!;

    [StringLength(10)]
    public string SecondDay { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal StartTime { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal EndTime { get; set; }

    public short SchoolType { get; set; }

    [Column("site")]
    public short Site { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? NumberOfSwimmers { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string MaxNumber { get; set; } = null!;

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
    [InverseProperty("Info1s")]
    public virtual Coach Coach { get; set; } = null!;

    [ForeignKey("CreatedAtSite")]
    [InverseProperty("Info1CreatedAtSiteNavigations")]
    public virtual AppCode CreatedAtSiteNavigation { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Info1CreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("School")]
    public virtual ICollection<Detail1> Detail1s { get; set; } = new List<Detail1>();

    [InverseProperty("School")]
    public virtual ICollection<Log1> Log1s { get; set; } = new List<Log1>();

    [ForeignKey("SchoolLevel")]
    [InverseProperty("Info1SchoolLevelNavigations")]
    public virtual AppCode SchoolLevelNavigation { get; set; } = null!;

    [ForeignKey("SchoolType")]
    [InverseProperty("Info1SchoolTypeNavigations")]
    public virtual AppCode SchoolTypeNavigation { get; set; } = null!;

    [ForeignKey("Site")]
    [InverseProperty("Info1SiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("UpdatedAtSite")]
    [InverseProperty("Info1UpdatedAtSiteNavigations")]
    public virtual AppCode? UpdatedAtSiteNavigation { get; set; }

    [ForeignKey("UpdatedBy")]
    [InverseProperty("Info1UpdatedByNavigations")]
    public virtual User? UpdatedByNavigation { get; set; }
}
