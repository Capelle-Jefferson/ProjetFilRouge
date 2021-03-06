using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Services;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge
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
            services.AddCors();
            services.AddControllers();
            //Injection service
            services.AddScoped<QuizzQuestionService, QuizzQuestionService>();
            services.AddScoped<QuizzesServices, QuizzesServices>();
            services.AddScoped<AnswerServices, AnswerServices>();
            services.AddScoped<CandidatesServices, CandidatesServices>();
            services.AddScoped<CategoriesServices, CategoriesServices>();
            services.AddScoped<LevelServices, LevelServices>();
            services.AddScoped<QuestionsServices, QuestionsServices>();
            services.AddScoped<RolesServices, RolesServices>();
            services.AddScoped<UsersServices, UsersServices>();
            services.AddScoped<EmailService, EmailService>();
            //Injection repository
            services.AddScoped<QuizzRepository, QuizzRepository>();
            services.AddScoped<AnswerRepository, AnswerRepository>();
            services.AddScoped<CandidateRepository, CandidateRepository>();
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<ChoiceAnswerRepository, ChoiceAnswerRepository>();
            services.AddScoped<LevelRepository, LevelRepository>();
            services.AddScoped<QuestionsRepository, QuestionsRepository>();
            services.AddScoped<QuizzQuestionRepository, QuizzQuestionRepository>();
            services.AddScoped<RolesRepository, RolesRepository>();
            services.AddScoped<UserRepository, UserRepository>();
            //Injection QueryBuilder
            services.AddScoped<QueryBuilder, QueryBuilder>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetFilRouge", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetFilRouge v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
