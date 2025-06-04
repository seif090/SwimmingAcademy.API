using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Times", Schema = "Swimmers")]
public partial class Time
{
    [Key]
    [Column("TID")]
    public long Tid { get; set; }

    [Column("SwimmerID")]
    public long SwimmerId { get; set; }

    public short Site { get; set; }

    [Column("RaceID")]
    public short RaceId { get; set; }

    [Column("Time", TypeName = "decimal(18, 0)")]
    public decimal Time1 { get; set; }

    [Column("RacePlaceID")]
    public short RacePlaceId { get; set; }

    public DateOnly RaceDate { get; set; }

    [Column("AddedBY")]
    public int AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AddedAt { get; set; }

    [ForeignKey("AddedBy")]
    [InverseProperty("Times")]
    public virtual User AddedByNavigation { get; set; } = null!;

    [ForeignKey("RaceId")]
    [InverseProperty("TimeRaces")]
    public virtual AppCode Race { get; set; } = null!;

    [ForeignKey("RacePlaceId")]
    [InverseProperty("TimeRacePlaces")]
    public virtual AppCode RacePlace { get; set; } = null!;

    [ForeignKey("Site")]
    [InverseProperty("TimeSiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [ForeignKey("SwimmerId")]
    [InverseProperty("Times")]
    public virtual Info2 Swimmer { get; set; } = null!;
}
