using System;
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
using GroupBuilderApplication.Queries;
using GroupBuilderApplication.Queries.GetGroupDetails;
using GroupBuilderApplication.Commands.RemoveGroup;
using GroupBuilderApplication.Commands.AddGroupMember;
using GroupBuilderApplication.Commands.RemoveGroupMember;
using GroupBuilderApplication.Commands.LoginUser;
using GroupBuilder.Controllers.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GroupBuilderApplication.Commands.RandomizeRoom;
using GroupBuilderApplication.Factory.GroupRandomizer;

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
            services.AddScoped<ILoginUserCommand, LoginUserCommand>();


            //Room
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICreateRoomCommand, CreateRoomCommand>();
            services.AddScoped<IRemoveRoomCommand, RemoveRoomCommand>();
            services.AddScoped<IAddParticipantCommand, AddParticipantCommand>();
            services.AddScoped<IRemoveParticipantCommand, RemoveParticipantCommand>();

            services.AddScoped<IGetRoomListQuery, GetRoomListQuery>();
            services.AddScoped<IGetRoomDetailsQuery, GetRoomDetailsQuery>();

            services.AddScoped<IRandomizeRoomCommand, RandomizeRoomCommand>();
            services.AddScoped<IGroupRandomizerFactory, GroupRandomizerFactory>();

            //Group
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ICreateGroupCommand, CreateGroupCommand>();
            services.AddScoped<IRemoveGroupCommand, RemoveGroupCommand>();
            services.AddScoped<IAddGroupMemberCommand, AddGroupMemberCommand>();
            services.AddScoped<IRemoveGroupMemberCommand, RemoveGroupMemberCommand>();

            services.AddScoped<IGetGroupListQuery, GetGroupListQuery>();
            services.AddScoped<IGetGroupDetailsQuery, GetGroupDetailsQuery>();


            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            ConfigureJWT(services);

            //Avoid loops when serializing json
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }


        private void ConfigureJWT(IServiceCollection services) {
            // configure jwt authentication
            var authenticationSection = Configuration.GetSection("Authentication");
            services.Configure<Authentication>(authenticationSection);

            var authentication = authenticationSection.Get<Authentication>();
            var key = Encoding.ASCII.GetBytes(authentication.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        
                        var userQuery = context.HttpContext.RequestServices.GetRequiredService<IGetSingleUserQuery>();
                        var userId = int.Parse(context.Principal.Identity.Name);

                        var user = userQuery.Execute(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
