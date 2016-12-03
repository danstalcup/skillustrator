using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Skillustrator.Api.Infrastructure;

namespace app.Migrations
{
    [DbContext(typeof(SkillustratorContext))]
    [Migration("20161202223241_clearExistingTables")]
    partial class clearExistingTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ChangeDetector.SkipDetectChanges", "true")
                .HasAnnotation("ProductVersion", "1.0.1");
        }
    }
}
