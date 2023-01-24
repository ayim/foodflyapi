using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace foodflyapi;

public partial class Food2dataContext : DbContext
{
    public Food2dataContext()
    {
    }

    public Food2dataContext(DbContextOptions<Food2dataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:food2data");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.AirlineId).HasName("PK__airlines__A016BF8034358ED5");

            entity.ToTable("airlines");

            entity.Property(e => e.AirlineId)
                .ValueGeneratedNever()
                .HasColumnName("airline_id");
            entity.Property(e => e.AirlineName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("airline_name");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.MealId).HasName("PK__meals__2910B00FC1EAA60C");

            entity.ToTable("meals");

            entity.Property(e => e.MealId)
                .ValueGeneratedNever()
                .HasColumnName("meal_id");
            entity.Property(e => e.MealName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("meal_name");
            entity.Property(e => e.PlaneId).HasColumnName("plane_id");
            entity.Property(e => e.RouteId).HasColumnName("route_id");

            entity.HasOne(d => d.Plane).WithMany(p => p.Meals)
                .HasForeignKey(d => d.PlaneId)
                .HasConstraintName("FK__meals__plane_id__66603565");

            entity.HasOne(d => d.Route).WithMany(p => p.Meals)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meals__route_id__656C112C");
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.PlaneId).HasName("PK__planes__4D11D7FD33EB8961");

            entity.ToTable("planes");

            entity.Property(e => e.PlaneId)
                .ValueGeneratedNever()
                .HasColumnName("plane_id");
            entity.Property(e => e.PlaneType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("plane_type");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reviews__3213E83FF7D615F1");

            entity.ToTable("reviews");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FlightDate)
                .HasColumnType("date")
                .HasColumnName("flight_date");
            entity.Property(e => e.MealId).HasColumnName("meal_id");
            entity.Property(e => e.OverallFeeling).HasColumnName("overall_feeling");
            entity.Property(e => e.Photos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photos");
            entity.Property(e => e.PortionSize).HasColumnName("portion_size");
            entity.Property(e => e.ServedAt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("served_at");
            entity.Property(e => e.Taste).HasColumnName("taste");
            entity.Property(e => e.Texture).HasColumnName("texture");

            entity.HasOne(d => d.Meal).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reviews__meal_id__693CA210");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__routes__28F706FEB236937F");

            entity.ToTable("routes");

            entity.Property(e => e.RouteId)
                .ValueGeneratedNever()
                .HasColumnName("route_id");
            entity.Property(e => e.AirlineId).HasColumnName("airline_id");
            entity.Property(e => e.DepartureAirport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("departure_airport");
            entity.Property(e => e.DestinationAirport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("destination_airport");

            entity.HasOne(d => d.Airline).WithMany(p => p.Routes)
                .HasForeignKey(d => d.AirlineId)
                .HasConstraintName("FK__routes__airline___60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
