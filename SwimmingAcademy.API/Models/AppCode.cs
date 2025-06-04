using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

public partial class AppCode
{
    [Column("main_id")]
    public short MainId { get; set; }

    [Key]
    [Column("sub_id")]
    public short SubId { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [Column("disabled")]
    public bool Disabled { get; set; }

    [InverseProperty("CoachTypeNavigation")]
    public virtual ICollection<Coach> CoachCoachTypeNavigations { get; set; } = new List<Coach>();

    [InverseProperty("CreatedAtSiteNavigation")]
    public virtual ICollection<Coach> CoachCreatedAtSiteNavigations { get; set; } = new List<Coach>();

    [InverseProperty("GenderNavigation")]
    public virtual ICollection<Coach> CoachGenderNavigations { get; set; } = new List<Coach>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Coach> CoachSiteNavigations { get; set; } = new List<Coach>();

    [InverseProperty("UpdatedAtSiteNavigation")]
    public virtual ICollection<Coach> CoachUpdatedAtSiteNavigations { get; set; } = new List<Coach>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Coach> CoachUpdatedByNavigations { get; set; } = new List<Coach>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Detail1> Detail1SiteNavigations { get; set; } = new List<Detail1>();

    [InverseProperty("SwimmerLevelNavigation")]
    public virtual ICollection<Detail1> Detail1SwimmerLevelNavigations { get; set; } = new List<Detail1>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Detail> DetailSiteNavigations { get; set; } = new List<Detail>();

    [InverseProperty("SwimmerLevelNavigation")]
    public virtual ICollection<Detail> DetailSwimmerLevelNavigations { get; set; } = new List<Detail>();

    [InverseProperty("CreatedAtSiteNavigation")]
    public virtual ICollection<Info1> Info1CreatedAtSiteNavigations { get; set; } = new List<Info1>();

    [InverseProperty("SchoolLevelNavigation")]
    public virtual ICollection<Info1> Info1SchoolLevelNavigations { get; set; } = new List<Info1>();

    [InverseProperty("SchoolTypeNavigation")]
    public virtual ICollection<Info1> Info1SchoolTypeNavigations { get; set; } = new List<Info1>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Info1> Info1SiteNavigations { get; set; } = new List<Info1>();

    [InverseProperty("UpdatedAtSiteNavigation")]
    public virtual ICollection<Info1> Info1UpdatedAtSiteNavigations { get; set; } = new List<Info1>();

    [InverseProperty("ClubNavigation")]
    public virtual ICollection<Info2> Info2ClubNavigations { get; set; } = new List<Info2>();

    [InverseProperty("CreatedAtSiteNavigation")]
    public virtual ICollection<Info2> Info2CreatedAtSiteNavigations { get; set; } = new List<Info2>();

    [InverseProperty("CurrentLevelNavigation")]
    public virtual ICollection<Info2> Info2CurrentLevelNavigations { get; set; } = new List<Info2>();

    [InverseProperty("GenderNavigation")]
    public virtual ICollection<Info2> Info2GenderNavigations { get; set; } = new List<Info2>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Info2> Info2SiteNavigations { get; set; } = new List<Info2>();

    [InverseProperty("StartLevelNavigation")]
    public virtual ICollection<Info2> Info2StartLevelNavigations { get; set; } = new List<Info2>();

    [InverseProperty("UpdatedAtSiteNavigation")]
    public virtual ICollection<Info2> Info2UpdatedAtSiteNavigations { get; set; } = new List<Info2>();

    [InverseProperty("CreatedAtSiteNavigation")]
    public virtual ICollection<Info> InfoCreatedAtSiteNavigations { get; set; } = new List<Info>();

    [InverseProperty("PteamLevelNavigation")]
    public virtual ICollection<Info> InfoPteamLevelNavigations { get; set; } = new List<Info>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Info> InfoSiteNavigations { get; set; } = new List<Info>();

    [InverseProperty("UpdatedAtSiteNavigation")]
    public virtual ICollection<Info> InfoUpdatedAtSiteNavigations { get; set; } = new List<Info>();

    [InverseProperty("CreatedAtSiteNavigation")]
    public virtual ICollection<InvoiceItem> InvoiceItemCreatedAtSiteNavigations { get; set; } = new List<InvoiceItem>();

    [InverseProperty("Product")]
    public virtual ICollection<InvoiceItem> InvoiceItemProducts { get; set; } = new List<InvoiceItem>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<InvoiceItem> InvoiceItemSiteNavigations { get; set; } = new List<InvoiceItem>();

    [InverseProperty("UpdatedAtSiteNavigation")]
    public virtual ICollection<InvoiceItem> InvoiceItemUpdatedAtSiteNavigations { get; set; } = new List<InvoiceItem>();

    [InverseProperty("CreatedAtsiteNavigation")]
    public virtual ICollection<Log1> Log1s { get; set; } = new List<Log1>();

    [InverseProperty("CreatedAtsiteNavigation")]
    public virtual ICollection<Log2> Log2s { get; set; } = new List<Log2>();

    [InverseProperty("CreatedAtSiteNavigation")]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    [InverseProperty("MemberOfNavigation")]
    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    [InverseProperty("CurrentLevelNavigation")]
    public virtual ICollection<Technical> TechnicalCurrentLevelNavigations { get; set; } = new List<Technical>();

    [InverseProperty("FirstSpNavigation")]
    public virtual ICollection<Technical> TechnicalFirstSpNavigations { get; set; } = new List<Technical>();

    [InverseProperty("LastStarNavigation")]
    public virtual ICollection<Technical> TechnicalLastStarNavigations { get; set; } = new List<Technical>();

    [InverseProperty("SecondSpNavigation")]
    public virtual ICollection<Technical> TechnicalSecondSpNavigations { get; set; } = new List<Technical>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Technical> TechnicalSiteNavigations { get; set; } = new List<Technical>();

    [InverseProperty("RacePlace")]
    public virtual ICollection<Time> TimeRacePlaces { get; set; } = new List<Time>();

    [InverseProperty("Race")]
    public virtual ICollection<Time> TimeRaces { get; set; } = new List<Time>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<Time> TimeSiteNavigations { get; set; } = new List<Time>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<User> UserCreatedByNavigations { get; set; } = new List<User>();

    [InverseProperty("SiteNavigation")]
    public virtual ICollection<User> UserSiteNavigations { get; set; } = new List<User>();

    [InverseProperty("UserType")]
    public virtual ICollection<User> UserUserTypes { get; set; } = new List<User>();

    [InverseProperty("UserType")]
    public virtual ICollection<UsersPriv> UsersPrivs { get; set; } = new List<UsersPriv>();
}
