using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("log", Schema = "Swimmers")]
public partial class Log2
{
    [Key]
    [Column("LID")]
    public long Lid { get; set; }

    [Column("swimmerID")]
    public long SwimmerId { get; set; }

    [Column("ActionID")]
    public int ActionId { get; set; }

    [Column("createdAtsite")]
    public short CreatedAtsite { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAtDate { get; set; }

    [ForeignKey("ActionId")]
    [InverseProperty("Log2s")]
    public virtual Action Action { get; set; } = null!;

    [ForeignKey("CreatedAtsite")]
    [InverseProperty("Log2s")]
    public virtual AppCode CreatedAtsiteNavigation { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Log2s")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("SwimmerId")]
    [InverseProperty("Log2s")]
    public virtual Info2 Swimmer { get; set; } = null!;
}
