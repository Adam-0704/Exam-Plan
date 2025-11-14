using ClassLibrary.DataAccess;
using ClassLibrary.Repository;
using ClassLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace ExamPlan

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ExamContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );

            // Register Repository and Service layers
            builder.Services.AddScoped<PersonRepo>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            
            builder.Services.AddScoped<HoldRepo>();
            builder.Services.AddScoped<IHoldService, HoldService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
