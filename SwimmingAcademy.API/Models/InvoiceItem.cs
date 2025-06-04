using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Invoice_Item")]
public partial class InvoiceItem
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    public string ItemName { get; set; } = null!;

    public short? Site { get; set; }

    [Column("ProductID")]
    public short? ProductId { get; set; }

    public short? DurationInMonths { get; set; }

    [Column("ActionID")]
    public int ActionId { get; set; }

    public short CreatedAtSite { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAtDate { get; set; }

    public int? UpdateBy { get; set; }

    public short? UpdatedAtSite { get; set; }

    public DateOnly? UpdatedAtDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [ForeignKey("ActionId")]
    [InverseProperty("InvoiceItems")]
    public virtual Action Action { get; set; } = null!;

    [ForeignKey("CreatedAtSite")]
    [InverseProperty("InvoiceItemCreatedAtSiteNavigations")]
    public virtual AppCode CreatedAtSiteNavigation { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("InvoiceItemCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("InvoiceItemProducts")]
    public virtual AppCode? Product { get; set; }

    [ForeignKey("Site")]
    [InverseProperty("InvoiceItemSiteNavigations")]
    public virtual AppCode? SiteNavigation { get; set; }

    [ForeignKey("UpdateBy")]
    [InverseProperty("InvoiceItemUpdateByNavigations")]
    public virtual User? UpdateByNavigation { get; set; }

    [ForeignKey("UpdatedAtSite")]
    [InverseProperty("InvoiceItemUpdatedAtSiteNavigations")]
    public virtual AppCode? UpdatedAtSiteNavigation { get; set; }
}
