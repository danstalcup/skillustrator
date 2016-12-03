using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Skillustrator.Api.Infrastructure;

namespace app.Migrations
{
    [DbContext(typeof(SkillustratorContext))]
    [Migration("20161203044559_PopulateSkillLevelAndTimePeriod")]
    partial class PopulateSkillLevelAndTimePeriod
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Skillustrator.Api.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("OrganizationId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.PersonSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.Property<int>("SkillId");

                    b.Property<int?>("SkillLevelId");

                    b.Property<int?>("TimeSinceUsedId");

                    b.Property<int?>("TimeUsedId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SkillId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("TimeSinceUsedId");

                    b.HasIndex("TimeUsedId");

                    b.ToTable("PersonSkill");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.SkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("SkillLevel");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.SkillTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SkillId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("TagId");

                    b.ToTable("SkillTag");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.TimePeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("TimePeriod");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.Person", b =>
                {
                    b.HasOne("Skillustrator.Api.Entities.Organization", "Organization")
                        .WithMany("People")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.PersonSkill", b =>
                {
                    b.HasOne("Skillustrator.Api.Entities.Person", "Person")
                        .WithMany("Skills")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Skillustrator.Api.Entities.Skill", "Skill")
                        .WithMany("People")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Skillustrator.Api.Entities.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId");

                    b.HasOne("Skillustrator.Api.Entities.TimePeriod", "TimeSinceUsed")
                        .WithMany()
                        .HasForeignKey("TimeSinceUsedId");

                    b.HasOne("Skillustrator.Api.Entities.TimePeriod", "TimeUsed")
                        .WithMany()
                        .HasForeignKey("TimeUsedId");
                });

            modelBuilder.Entity("Skillustrator.Api.Entities.SkillTag", b =>
                {
                    b.HasOne("Skillustrator.Api.Entities.Skill", "Skill")
                        .WithMany("Tags")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Skillustrator.Api.Entities.Tag", "Tag")
                        .WithMany("Skills")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
