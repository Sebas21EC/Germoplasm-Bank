using Microsoft.EntityFrameworkCore;
using GermoBank.Models;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<GermoBankUtnContext>(options =>
        options.UseNpgsql("Host=localhost; Port=5432; Pooling=true; Database=germobank_utn; User Id=postgres; Password=root"));
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("Ayuda", async context =>
    {
        var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();
        await context.Response.WriteAsync(await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "html", "Ayuda.cshtml"))
);
    });

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accesion01}/{action=Accesion03}/{id?}");
    /*pattern: "{controller=Home}/{action=Index}/{id?}");*/
});



app.UseAuthorization();



app.Run();
