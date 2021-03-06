﻿// <auto-generated />
using Lineee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Lineee.Migrations.Talk
{
    [DbContext(typeof(TalkContext))]
    [Migration("20180615135505_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lineee.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Lineee.Models.Talk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("FromNameID");

                    b.Property<int?>("ToNameID");

                    b.HasKey("ID");

                    b.HasIndex("FromNameID");

                    b.HasIndex("ToNameID");

                    b.ToTable("Talk");
                });

            modelBuilder.Entity("Lineee.Models.Talk", b =>
                {
                    b.HasOne("Lineee.Models.Account", "FromName")
                        .WithMany()
                        .HasForeignKey("FromNameID");

                    b.HasOne("Lineee.Models.Account", "ToName")
                        .WithMany()
                        .HasForeignKey("ToNameID");
                });
#pragma warning restore 612, 618
        }
    }
}
