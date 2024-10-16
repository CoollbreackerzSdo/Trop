﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trop.Infrastructure.Context;

#nullable disable

namespace Trop.Api.Migrations
{
    [DbContext(typeof(TropContext))]
    [Migration("20241017033810_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trop.Domain.Models.User.UserEntity", b =>
                {
                    b.Property<Guid>("Key")
                        .HasColumnType("uuid")
                        .HasColumnName("key");

                    b.Property<DateOnly>("RegisterDateAtUtc")
                        .HasColumnType("date")
                        .HasColumnName("register_date_utc");

                    b.Property<TimeOnly>("RegisterTimeAtUtc")
                        .HasColumnType("time without time zone")
                        .HasColumnName("register_time_utc");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("user_name");

                    b.ComplexProperty<Dictionary<string, object>>("Security", "Trop.Domain.Models.User.UserEntity.Security#UserSecurity", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("password");
                        });

                    b.HasKey("Key");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Trop.Domain.Models.User.UserEntity", b =>
                {
                    b.OwnsOne("Trop.Domain.Models.User.UserDetail", "Detail", b1 =>
                        {
                            b1.Property<Guid>("UserEntityKey")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .HasColumnType("text");

                            b1.HasKey("UserEntityKey");

                            b1.ToTable("Users");

                            b1.ToJson("detail");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityKey");
                        });

                    b.Navigation("Detail");
                });
#pragma warning restore 612, 618
        }
    }
}
