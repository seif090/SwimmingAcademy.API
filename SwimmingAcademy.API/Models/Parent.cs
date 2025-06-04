using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Parent", Schema = "Swimmers")]
public partial class Parent
{
    [Key]
    [Column("SwimmerID")]
    public long SwimmerId { get; set; }

    [StringLength(120)]
    public string SwimmerName { get; set; } = null!;

    [StringLength(11)]
    [Unicode(false)]
    public string PrimaryPhone { get; set; } = null!;

    [StringLength(11)]
    [Unicode(false)]
    public string? SecondaryPhone { get; set; }

    [StringLength(100)]
    public string PrimaryJop { get; set; } = null!;

    [StringLength(100)]
    public string? SecondaryJop { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public short? MemberOf { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? DiscountRate { get; set; }

    [StringLength(120)]
    public string Address { get; set; } = null!;

    [ForeignKey("MemberOf")]
    [InverseProperty("Parents")]
    public virtual AppCode? MemberOfNavigation { get; set; }

    [ForeignKey("SwimmerId")]
    [InverseProperty("Parent")]
    public virtual Info2 Swimmer { get; set; } = null!;
}
