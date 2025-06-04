using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Details", Schema = "Schools")]
public partial class Detail1
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("SchoolID")]
    public long SchoolId { get; set; }

    [Column("SwimmerID")]
    public long SwimmerId { get; set; }

    [Column("CoachID")]
    public int CoachId { get; set; }

    public short SwimmerLevel { get; set; }

    [Column("site")]
    public short Site { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Attendence { get; set; }

    [ForeignKey("CoachId")]
    [InverseProperty("Detail1s")]
    public virtual Coach Coach { get; set; } = null!;

    [ForeignKey("SchoolId")]
    [InverseProperty("Detail1s")]
    public virtual Info1 School { get; set; } = null!;

    [ForeignKey("Site")]
    [InverseProperty("Detail1SiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("SwimmerId")]
    [InverseProperty("Detail1s")]
    public virtual Info2 Swimmer { get; set; } = null!;

    [ForeignKey("SwimmerLevel")]
    [InverseProperty("Detail1SwimmerLevelNavigations")]
    public virtual AppCode SwimmerLevelNavigation { get; set; } = null!;
}
