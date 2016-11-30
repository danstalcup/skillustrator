using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApplication.Infrastructure;

namespace app.Migrations
{
    [DbContext(typeof(SkillustratorContext))]
    partial class SkillustratorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("ConsoleApplication.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ConsoleApplication.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ConsoleApplication.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("ConsoleApplication.Entities.Skill", b =>
                {
                    b.HasOne("ConsoleApplication.Entities.Person")
                        .WithMany("Skills")
                        .HasForeignKey("PersonId");
                });
        }
    }
}
