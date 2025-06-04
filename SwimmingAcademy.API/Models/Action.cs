using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

public partial class Action
{
    [Key]
    [Column("ActionID")]
    public int ActionId { get; set; }

    [StringLength(100)]
    public string ActionName { get; set; } = null!;

    public bool? SameSite { get; set; }

    public bool Disabled { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Module { get; set; } = null!;

    public bool IsInv { get; set; }

    [InverseProperty("Action")]
    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    [InverseProperty("Action")]
    public virtual ICollection<Log1> Log1s { get; set; } = new List<Log1>();

    [InverseProperty("Action")]
    public virtual ICollection<Log2> Log2s { get; set; } = new List<Log2>();

    [InverseProperty("Action")]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    [InverseProperty("Action")]
    public virtual ICollection<UsersPriv> UsersPrivs { get; set; } = new List<UsersPriv>();
}
