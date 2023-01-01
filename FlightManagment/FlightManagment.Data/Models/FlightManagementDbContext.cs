using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Data.Models;

public partial class FlightManagementDbContext : DbContext
{
    public FlightManagementDbContext()
    {
    }

    public FlightManagementDbContext(DbContextOptions<FlightManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CrewMember> CrewMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=FlightManagementDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CrewMember>(entity =>
        {
            entity.HasKey(e => e.CrwId).HasName("PK__CrewMemb__F4AB00FB731AA4A4");

            entity.Property(e => e.CrwId).HasColumnName("CRW_ID");
            entity.Property(e => e.CrwCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_City");
            entity.Property(e => e.CrwEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_Email");
            entity.Property(e => e.CrwFirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_FirstName");
            entity.Property(e => e.CrwHouseNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_HouseNumber");
            entity.Property(e => e.CrwLastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_LastName");
            entity.Property(e => e.CrwPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_Password");
            entity.Property(e => e.CrwPhoneNumber).HasColumnName("CRW_PhoneNumber");
            entity.Property(e => e.CrwPosition)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_Position");
            entity.Property(e => e.CrwPostalCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_PostalCode");
            entity.Property(e => e.CrwSocialSecurityNumber).HasColumnName("CRW_SocialSecurityNumber");
            entity.Property(e => e.CrwStreet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRW_Street");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
