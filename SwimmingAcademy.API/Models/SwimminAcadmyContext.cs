using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAcademy.API.Models;

public partial class SwimminAcadmyContext : DbContext
{
    public SwimminAcadmyContext()
    {
    }

    public SwimminAcadmyContext(DbContextOptions<SwimminAcadmyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<AppCode> AppCodes { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Detail> Details { get; set; }

    public virtual DbSet<Detail1> Details1 { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<Info1> Infos1 { get; set; }

    public virtual DbSet<Info2> Infos2 { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Log1> Logs1 { get; set; }

    public virtual DbSet<Log2> Logs2 { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Technical> Technicals { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersPriv> UsersPrivs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=SwimminAcadmy;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__Actions__FFE3F4B9FF23B4F3");
        });

        modelBuilder.Entity<AppCode>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("PK__AppCodes__694106B082539A84");
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("PK__Coaches__F411D9A18D02D016");

            entity.HasOne(d => d.CoachTypeNavigation).WithMany(p => p.CoachCoachTypeNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coaches__CoachTy__3C69FB99");

            entity.HasOne(d => d.CreatedAtSiteNavigation).WithMany(p => p.CoachCreatedAtSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coaches__created__3D5E1FD2");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Coaches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coaches__created__3E52440B");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.CoachGenderNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coaches__Gender__3F466844");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.CoachSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coaches__site__403A8C7D");

            entity.HasOne(d => d.UpdatedAtSiteNavigation).WithMany(p => p.CoachUpdatedAtSiteNavigations).HasConstraintName("FK__Coaches__updated__662B2B3B");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.CoachUpdatedByNavigations).HasConstraintName("FK__Coaches__updated__671F4F74");
        });

        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Details__3214EC2716204D81");

            entity.HasOne(d => d.Coach).WithMany(p => p.Details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__CoachID__43D61337");

            entity.HasOne(d => d.Pteam).WithMany(p => p.Details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__PTeamID__41EDCAC5");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.DetailSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__site__45BE5BA9");

            entity.HasOne(d => d.Swimmer).WithMany(p => p.Details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__Swimmer__42E1EEFE");

            entity.HasOne(d => d.SwimmerLevelNavigation).WithMany(p => p.DetailSwimmerLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__Swimmer__44CA3770");
        });

        modelBuilder.Entity<Detail1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Details__3214EC270D648956");

            entity.HasOne(d => d.Coach).WithMany(p => p.Detail1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__CoachID__2DE6D218");

            entity.HasOne(d => d.School).WithMany(p => p.Detail1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__SchoolI__2BFE89A6");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.Detail1SiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__site__2FCF1A8A");

            entity.HasOne(d => d.Swimmer).WithMany(p => p.Detail1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__Swimmer__2CF2ADDF");

            entity.HasOne(d => d.SwimmerLevelNavigation).WithMany(p => p.Detail1SwimmerLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details__Swimmer__2EDAF651");
        });

        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => e.PteamId).HasName("PK__Info__C79A741AF2980D16");

            entity.HasOne(d => d.Coach).WithMany(p => p.Infos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__CoachID__3493CFA7");

            entity.HasOne(d => d.CreatedAtSiteNavigation).WithMany(p => p.InfoCreatedAtSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__createdAtS__367C1819");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InfoCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__createdBy__37703C52");

            entity.HasOne(d => d.PteamLevelNavigation).WithMany(p => p.InfoPteamLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__PTeamLevel__339FAB6E");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.InfoSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__site__3587F3E0");

            entity.HasOne(d => d.UpdatedAtSiteNavigation).WithMany(p => p.InfoUpdatedAtSiteNavigations).HasConstraintName("FK__Info__updatedAtS__3864608B");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InfoUpdatedByNavigations).HasConstraintName("FK__Info__updatedBy__395884C4");
        });

        modelBuilder.Entity<Info1>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__info__3DA4677BD433C5F5");

            entity.HasOne(d => d.Coach).WithMany(p => p.Info1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__info__CoachID__1CBC4616");

            entity.HasOne(d => d.CreatedAtSiteNavigation).WithMany(p => p.Info1CreatedAtSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__info__createdAtS__1F98B2C1");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Info1CreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__info__createdBy__208CD6FA");

            entity.HasOne(d => d.SchoolLevelNavigation).WithMany(p => p.Info1SchoolLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__info__schoolLeve__1BC821DD");

            entity.HasOne(d => d.SchoolTypeNavigation).WithMany(p => p.Info1SchoolTypeNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__info__SchoolType__1DB06A4F");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.Info1SiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__info__site__1EA48E88");

            entity.HasOne(d => d.UpdatedAtSiteNavigation).WithMany(p => p.Info1UpdatedAtSiteNavigations).HasConstraintName("FK__info__updatedAtS__2180FB33");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Info1UpdatedByNavigations).HasConstraintName("FK__info__updatedBy__22751F6C");
        });

        modelBuilder.Entity<Info2>(entity =>
        {
            entity.HasKey(e => e.SwimmerId).HasName("PK__Info__E8BD7A652CB82250");

            entity.HasOne(d => d.ClubNavigation).WithMany(p => p.Info2ClubNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__CLub__7D439ABD");

            entity.HasOne(d => d.CreatedAtSiteNavigation).WithMany(p => p.Info2CreatedAtSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__CreatedAtS__7E37BEF6");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Info2CreatedByNavigations).HasConstraintName("FK__Info__CreatedBy__7F2BE32F");

            entity.HasOne(d => d.CurrentLevelNavigation).WithMany(p => p.Info2CurrentLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__CurrentLev__7A672E12");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Info2GenderNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__Gender__7C4F7684");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.Info2SiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__Site__7B5B524B");

            entity.HasOne(d => d.StartLevelNavigation).WithMany(p => p.Info2StartLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Info__StartLevel__797309D9");

            entity.HasOne(d => d.UpdatedAtSiteNavigation).WithMany(p => p.Info2UpdatedAtSiteNavigations).HasConstraintName("FK__Info__UpdatedAtS__00200768");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Info2UpdatedByNavigations).HasConstraintName("FK__Info__UpdatedBy__01142BA1");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Invoice___727E83EB2E050C43");

            entity.HasOne(d => d.Action).WithMany(p => p.InvoiceItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice_I__Actio__02C769E9");

            entity.HasOne(d => d.CreatedAtSiteNavigation).WithMany(p => p.InvoiceItemCreatedAtSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice_I__Creat__03BB8E22");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InvoiceItemCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice_I__Creat__04AFB25B");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceItemProducts).HasConstraintName("FK__Invoice_I__Produ__01D345B0");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.InvoiceItemSiteNavigations).HasConstraintName("FK__Invoice_It__Site__00DF2177");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.InvoiceItemUpdateByNavigations).HasConstraintName("FK__Invoice_I__Updat__05A3D694");

            entity.HasOne(d => d.UpdatedAtSiteNavigation).WithMany(p => p.InvoiceItemUpdatedAtSiteNavigations).HasConstraintName("FK__Invoice_I__Updat__0697FACD");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__log__C65557219DB6DF1E");

            entity.HasOne(d => d.Action).WithMany(p => p.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__ActionID__7A3223E8");

            entity.HasOne(d => d.CreatedAtSiteNavigation).WithMany(p => p.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__CreatedAtSi__7C1A6C5A");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__createdby__7D0E9093");

            entity.HasOne(d => d.Pteam).WithMany(p => p.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__PteamID__793DFFAF");

            entity.HasOne(d => d.Swimmer).WithMany(p => p.Logs).HasConstraintName("FK__log__SwimmerID__7B264821");
        });

        modelBuilder.Entity<Log1>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__log__C6555721D313A0E7");

            entity.HasOne(d => d.Action).WithMany(p => p.Log1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__ActionID__73852659");

            entity.HasOne(d => d.CreatedAtsiteNavigation).WithMany(p => p.Log1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__createdAtsi__756D6ECB");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Log1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__CreatedBy__76619304");

            entity.HasOne(d => d.School).WithMany(p => p.Log1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__schoolID__72910220");

            entity.HasOne(d => d.Swimmer).WithMany(p => p.Log1s).HasConstraintName("FK__log__swimmerID__74794A92");
        });

        modelBuilder.Entity<Log2>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__log__C6555721C4CDAF7A");

            entity.HasOne(d => d.Action).WithMany(p => p.Log2s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__ActionID__6DCC4D03");

            entity.HasOne(d => d.CreatedAtsiteNavigation).WithMany(p => p.Log2s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__createdAtsi__6EC0713C");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Log2s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__CreatedBy__6FB49575");

            entity.HasOne(d => d.Swimmer).WithMany(p => p.Log2s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__swimmerID__6CD828CA");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.SwimmerId).HasName("PK__Parent__E8BD7A65A62F86BB");

            entity.Property(e => e.SwimmerId).ValueGeneratedNever();

            entity.HasOne(d => d.MemberOfNavigation).WithMany(p => p.Parents).HasConstraintName("FK__Parent__MemberOf__0A9D95DB");

            entity.HasOne(d => d.Swimmer).WithOne(p => p.Parent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Parent__SwimmerI__09A971A2");
        });

        modelBuilder.Entity<Technical>(entity =>
        {
            entity.HasKey(e => e.SwimmerId).HasName("PK__Technica__E8BD7A65C169533B");

            entity.Property(e => e.SwimmerId).ValueGeneratedNever();

            entity.HasOne(d => d.AddedbyNavigation).WithMany(p => p.TechnicalAddedbyNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technical__Added__690797E6");

            entity.HasOne(d => d.CurrentLevelNavigation).WithMany(p => p.TechnicalCurrentLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technical__Curre__0F624AF8");

            entity.HasOne(d => d.FirstSpNavigation).WithMany(p => p.TechnicalFirstSpNavigations).HasConstraintName("FK__Technical__First__114A936A");

            entity.HasOne(d => d.LastStarNavigation).WithMany(p => p.TechnicalLastStarNavigations).HasConstraintName("FK__Technical__LastS__10566F31");

            entity.HasOne(d => d.SecondSpNavigation).WithMany(p => p.TechnicalSecondSpNavigations).HasConstraintName("FK__Technical__Secon__123EB7A3");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.TechnicalSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technical__Site__0E6E26BF");

            entity.HasOne(d => d.Swimmer).WithOne(p => p.Technical)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technical__Swimm__0D7A0286");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TechnicalUpdatedByNavigations).HasConstraintName("FK__Technical__Updat__69FBBC1F");
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__Times__C456D7296CF66AEE");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.Times)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Times__AddedBY__18EBB532");

            entity.HasOne(d => d.Race).WithMany(p => p.TimeRaces)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Times__RaceID__17036CC0");

            entity.HasOne(d => d.RacePlace).WithMany(p => p.TimeRacePlaces)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Times__RacePlace__17F790F9");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.TimeSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Times__Site__160F4887");

            entity.HasOne(d => d.Swimmer).WithMany(p => p.Times)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Times__SwimmerID__151B244E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B2575DDDE890");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__CreatedBy__681373AD");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.UserSiteNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__Site__398D8EEE");

            entity.HasOne(d => d.UserType).WithMany(p => p.UserUserTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__UserTypeI__607251E5");
        });

        modelBuilder.Entity<UsersPriv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Pr__3214EC270E3A9EF0");

            entity.HasOne(d => d.Action).WithMany(p => p.UsersPrivs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users_Pri__Actio__6442E2C9");

            entity.HasOne(d => d.UserType).WithMany(p => p.UsersPrivs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users_Pri__UserT__65370702");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
