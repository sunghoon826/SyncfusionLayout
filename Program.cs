using Syncfusion.Blazor;
using SyncfusionLayout.Components;
using SyncfusionLayout.Interfaces;
using SyncfusionLayout.Models;
using SyncfusionLayout.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<TdmsFilesContext>();
builder.Services.AddScoped<IDatabase<TdmsFile>, TdmsFileService>();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
//Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA1NTU2NEAzMjM0MmUzMDJlMzBkbmQ2aGZTcHVmOFRXdlprbi8wYUZoOS9QQTNQWDduZjZDM0E0Zm5CbWhvPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
