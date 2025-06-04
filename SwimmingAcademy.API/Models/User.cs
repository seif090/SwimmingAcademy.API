using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    [Column("fullname")]
    [StringLength(120)]
    public string Fullname { get; set; } = null!;

    public short Site { get; set; }

    [Column("disabled")]
    public bool Disabled { get; set; }

    [Column("UserTypeID")]
    public short UserTypeId { get; set; }

    public short CreatedBy { get; set; }

    [StringLength(20)]
    public string Password { get; set; } = null!;

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserCreatedByNavigations")]
    public virtual AppCode CreatedByNavigation { get; set; } = null!;

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Info1> Info1CreatedByNavigations { get; set; } = new List<Info1>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Info1> Info1UpdatedByNavigations { get; set; } = new List<Info1>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Info2> Info2CreatedByNavigations { get; set; } = new List<Info2>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Info2> Info2UpdatedByNavigations { get; set; } = new List<Info2>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Info> InfoCreatedByNavigations { get; set; } = new List<Info>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Info> InfoUpdatedByNavigations { get; set; } = new List<Info>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InvoiceItem> InvoiceItemCreatedByNavigations { get; set; } = new List<InvoiceItem>();

    [InverseProperty("UpdateByNavigation")]
    public virtual ICollection<InvoiceItem> InvoiceItemUpdateByNavigations { get; set; } = new List<InvoiceItem>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Log1> Log1s { get; set; } = new List<Log1>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Log2> Log2s { get; set; } = new List<Log2>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    [ForeignKey("Site")]
    [InverseProperty("UserSiteNavigations")]
    public virtual AppCode SiteNavigation { get; set; } = null!;

    [InverseProperty("AddedbyNavigation")]
    public virtual ICollection<Technical> TechnicalAddedbyNavigations { get; set; } = new List<Technical>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Technical> TechnicalUpdatedByNavigations { get; set; } = new List<Technical>();

    [InverseProperty("AddedByNavigation")]
    public virtual ICollection<Time> Times { get; set; } = new List<Time>();

    [ForeignKey("UserTypeId")]
    [InverseProperty("UserUserTypes")]
    public virtual AppCode UserType { get; set; } = null!;
}

    