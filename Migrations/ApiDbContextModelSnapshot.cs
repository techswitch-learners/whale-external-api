// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhaleExtApi.Database;

#nullable disable

namespace WhaleExtApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SightingSpecies", b =>
                {
                    b.Property<int>("SightingsId")
                        .HasColumnType("integer");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("integer");

                    b.HasKey("SightingsId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("SightingSpecies");
                });

            modelBuilder.Entity("WhaleExtApi.Models.Database.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WhaleExtApi.Models.Database.Sighting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Sightings");
                });

            modelBuilder.Entity("WhaleExtApi.Models.Database.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EndangeredStatus")
                        .HasColumnType("text");

                    b.Property<string>("LatinName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("SightingSpecies", b =>
                {
                    b.HasOne("WhaleExtApi.Models.Database.Sighting", null)
                        .WithMany()
                        .HasForeignKey("SightingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhaleExtApi.Models.Database.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhaleExtApi.Models.Database.Sighting", b =>
                {
                    b.HasOne("WhaleExtApi.Models.Database.Location", "Location")
                        .WithMany("Sightings")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("WhaleExtApi.Models.Database.Location", b =>
                {
                    b.Navigation("Sightings");
                });
#pragma warning restore 612, 618
        }
    }
}
