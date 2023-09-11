using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Registro_Prioridad1.DAL;
using Registro_Prioridad1.BLL;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
{
	// Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

	var ConStr = builder.Configuration.GetConnectionString("ConStr");

	builder.Services.AddDbContext<PrioridadContext>(Options => Options.UseSqlite(ConStr));

	builder.Services.AddScoped<SistemasBLL>();

	builder.Services.AddScoped<DialogService>();
	builder.Services.AddScoped<NotificationService>();
	builder.Services.AddScoped<TooltipService>();
	builder.Services.AddScoped<ContextMenuService>();
}

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();