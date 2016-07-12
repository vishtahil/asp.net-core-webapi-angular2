using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AzureDemo2.Models;

namespace AzureDemo2.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20160710044548_MyfirstMigration")]
    partial class MyfirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("AzureDemo2.Models.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("Dob");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("Contacts");
                });
        }
    }
}
