﻿using GroupBuilderDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderPersistence.Shared
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Participants
            builder.Entity<RoomParticipant>().HasKey(rg => new { rg.UserId, rg.RoomId });
            builder.Entity<RoomParticipant>().HasOne<Room>(rp => rp.Room).WithMany(r => r.Participants).HasForeignKey(rp => rp.RoomId);
            builder.Entity<RoomParticipant>().HasOne<User>(rp => rp.User).WithMany(u => u.Rooms).HasForeignKey(rp => rp.UserId);


            builder.Entity<Group>().HasOne<Room>(g => g.Room).WithMany(r => r.Groups).HasForeignKey(g => g.RoomId);

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomParticipant> RoomParticipants { get; set; }
        public DbSet<Group> Groups { get;set; }


        public void Save()
        {
            this.SaveChanges();
        }
    }
}
