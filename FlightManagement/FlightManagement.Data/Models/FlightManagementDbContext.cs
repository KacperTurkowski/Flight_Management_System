using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

    public virtual DbSet<AirPlane> AirPlanes { get; set; }

    public virtual DbSet<CrewMember> CrewMembers { get; set; }

    public virtual DbSet<CrewToFlightAssoc> CrewToFlightAssocs { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(JsonConvert.DeserializeObject<DbConfig>(File.ReadAllText(".//dbConfig.json"))?.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirPlane>(entity =>
        {
            entity.HasKey(e => e.AipId).HasName("PK__AirPlane__61CDFAE6B524812A");

            entity.Property(e => e.AipId).HasColumnName("AIP_ID");
            entity.Property(e => e.AipFuelUsage).HasColumnName("AIP_FuelUsage");
            entity.Property(e => e.AipIsActivated).HasColumnName("AIP_IsActivated");
            entity.Property(e => e.AipIsNarrowBody).HasColumnName("AIP_IsNarrowBody");
            entity.Property(e => e.AipMaxPassengers).HasColumnName("AIP_MaxPassengers");
            entity.Property(e => e.AipMaxWeight).HasColumnName("AIP_MaxWeight");
            entity.Property(e => e.AipName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AIP_Name");
            entity.Property(e => e.AipProducer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AIP_Producer");
        });

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
            entity.Property(e => e.CrwIsActive).HasColumnName("CRW_IsActive");
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

        modelBuilder.Entity<CrewToFlightAssoc>(entity =>
        {
            entity.HasKey(e => e.CtfId).HasName("PK__CrewToFl__503C2CA530AEC607");

            entity.ToTable("CrewToFlightAssoc");

            entity.Property(e => e.CtfId).HasColumnName("CTF_ID");
            entity.Property(e => e.CrwId).HasColumnName("CRW_ID");
            entity.Property(e => e.FliId).HasColumnName("FLI_ID");

            entity.HasOne(d => d.Crw).WithMany(p => p.CrewToFlightAssocs)
                .HasForeignKey(d => d.CrwId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewToFli__CRW_I__5812160E");

            entity.HasOne(d => d.Fli).WithMany(p => p.CrewToFlightAssocs)
                .HasForeignKey(d => d.FliId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewToFli__FLI_I__571DF1D5");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FliId).HasName("PK__Flights__7DCCABB9BA820BBD");

            entity.Property(e => e.FliId).HasColumnName("FLI_ID");
            entity.Property(e => e.AipId).HasColumnName("AIP_ID");
            entity.Property(e => e.CrwId).HasColumnName("CRW_ID");
            entity.Property(e => e.FliEndAirport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLI_EndAirport");
            entity.Property(e => e.FliEndPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLI_EndPlace");
            entity.Property(e => e.FliFlightLength).HasColumnName("FLI_FlightLength");
            entity.Property(e => e.FliSoldCargo).HasColumnName("FLI_SoldCargo");
            entity.Property(e => e.FliSoldTickets).HasColumnName("FLI_SoldTickets");
            entity.Property(e => e.FliStartAirport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLI_StartAirport");
            entity.Property(e => e.FliStartDate)
                .HasColumnType("datetime")
                .HasColumnName("FLI_StartDate");
            entity.Property(e => e.FliStartPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLI_StartPlace");
            entity.Property(e => e.FliTicketPrice).HasColumnName("FLI_TicketPrice");

            entity.HasOne(d => d.Aip).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AipId)
                .HasConstraintName("FK__Flights__AIP_ID__4D94879B");

            entity.HasOne(d => d.Crw).WithMany(p => p.Flights)
                .HasForeignKey(d => d.CrwId)
                .HasConstraintName("FK__Flights__CRW_ID__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
