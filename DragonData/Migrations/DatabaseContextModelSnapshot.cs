﻿// <auto-generated />
using DragonData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DragonData.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("DragonData.Module.BlocklistModule", b =>
                {
                    b.Property<int>("blockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("blockTag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("userID")
                        .HasColumnType("INTEGER");

                    b.HasKey("blockID");

                    b.HasIndex("userID");

                    b.ToTable("blocklists");
                });

            modelBuilder.Entity("DragonData.Module.GuildBlockListModule", b =>
                {
                    b.Property<int>("blockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("blockTag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("guildID")
                        .HasColumnType("INTEGER");

                    b.HasKey("blockID");

                    b.HasIndex("guildID");

                    b.ToTable("GuildBlockLists");
                });

            modelBuilder.Entity("DragonData.Module.GuildModule", b =>
                {
                    b.Property<ulong>("guildID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("guildName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("guildID");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("DragonData.Module.UserModule", b =>
                {
                    b.Property<ulong>("userID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DragonData.Module.BlocklistModule", b =>
                {
                    b.HasOne("DragonData.Module.UserModule", "User")
                        .WithMany("Blocklists")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DragonData.Module.GuildBlockListModule", b =>
                {
                    b.HasOne("DragonData.Module.GuildModule", "Guild")
                        .WithMany("GuildblockLists")
                        .HasForeignKey("guildID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("DragonData.Module.GuildModule", b =>
                {
                    b.Navigation("GuildblockLists");
                });

            modelBuilder.Entity("DragonData.Module.UserModule", b =>
                {
                    b.Navigation("Blocklists");
                });
#pragma warning restore 612, 618
        }
    }
}
