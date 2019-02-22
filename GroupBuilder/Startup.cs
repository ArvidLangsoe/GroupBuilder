﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetUserList;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GroupBuilderPersistence;
using GroupBuilderPersistence.Shared;
using Microsoft.EntityFrameworkCore;
using GroupBuilderApplication.Commands.CreateUser;
using AutoMapper;
using GroupBuilderApplication.Queries.GetSingleUser;
using GroupBuilderApplication.Commands.RemoveUser;
using GroupBuilderApplication.Commands.CreateRoom;
using GroupBuilderApplication.Queries.GetRoomList;
using GroupBuilderApplication.Queries.GetRoomDetails;
using GroupBuilderApplication.Commands.RemoveRoom;
using GroupBuilderApplication.Commands.AddParticipant;
using GroupBuilderApplication.Commands.RemoveParticipant;
using GroupBuilderApplication.Commands.CreateGroup;

namespace GroupBuilder
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGetUserListQuery, GetUserListQuery>();
            services.AddScoped<IGetSingleUserQuery, GetSingleUserQuery>();
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IRemoveUserCommand, RemoveUserCommand>();


            //Room
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICreateRoomCommand, CreateRoomCommand>();
            services.AddScoped<IRemoveRoomCommand, RemoveRoomCommand>();
            services.AddScoped<IAddParticipantCommand, AddParticipantCommand>();
            services.AddScoped<IRemoveParticipantCommand, RemoveParticipantCommand>();

            services.AddScoped<IGetRoomListQuery, GetRoomListQuery>();
            services.AddScoped<IGetRoomDetailsQuery, GetRoomDetailsQuery>();

            //Group
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ICreateGroupCommand, CreateGroupCommand>();


            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
