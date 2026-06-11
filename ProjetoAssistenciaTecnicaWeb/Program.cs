using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Services;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

// Para deixar o sistema em portugues br (moeda)
var cultureInfo = new CultureInfo("pt-BR");

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Vincular o BD
builder.Services.AddDbContext<ProjetoAssistenciaTecnicaWebContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ProjetoAssistenciaTecnicaWebContext"),
        new MySqlServerVersion(new Version(8, 0, 34))
    )
);


// Vincular o Seeding Service
builder.Services.AddScoped<SeedingService>();

// Vincular o ClienteService
builder.Services.AddScoped<ClienteService>();

// Vincular o FuncionarioService
builder.Services.AddScoped<FuncionarioService>();

// Vincular o PecaService
builder.Services.AddScoped<PecaService>();

// Vincular o ProdutoService
builder.Services.AddScoped<ProdutoService>();

// Vincular o OrdemServicoService
builder.Services.AddScoped<OrdemServicoService>();

// Vincular o OrcamentoService
builder.Services.AddScoped<OrcamentoService>();

// Vincular o UsuarioService
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Aqui, caso o projeto esteja rodando de forma de desenvolvimento,ira chamar o seeding service, se nao, ira apresentar o erro
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
