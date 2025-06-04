using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

[Table("Users_Priv")]
public partial class UsersPriv
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ActionID")]
    public int ActionId { get; set; }

    [Column("UserTypeID")]
    public short UserTypeId { get; set; }

    [ForeignKey("ActionId")]
    [InverseProperty("UsersPrivs")]
    public virtual Action Action { get; set; } = null!;

    [ForeignKey("UserTypeId")]
    [InverseProperty("UsersPrivs")]
    public virtual AppCode UserType { get; set; } = null!;
}
