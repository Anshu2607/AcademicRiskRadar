
using AcademicRiskRadar.Web.Components;
using AcademicRiskRadar.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Blazor services
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

// Shared academic student records
builder.Services.AddScoped<AcademicDataService>();

// Shared academic alerts and mentoring workflows
builder.Services.AddScoped<AcademicWorkflowService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Error",
        createScopeForErrors: true
    );

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
