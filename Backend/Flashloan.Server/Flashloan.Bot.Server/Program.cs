using Flashloan.Application;
using Flashloan.Bot.Server.Backgrounds;
using Flashloan.Bot.Server.Components;
using Flashloan.Domain;
using Flashloan.Infrastructure;
using MudBlazor.Services;
using UniswapV2.Network.BinanceSmartChain;
using UniswapV2.Network.Ethereum;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddUniswapV2Ethereum(builder.Configuration);
builder.Services.AddUniswapV2BinanceSmartChain(builder.Configuration);


builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.AddStreaming();
    siloBuilder.AddMemoryStreams("StreamProvider");

    siloBuilder.UseAdoNetClustering(clusteringOptions =>
    {
        clusteringOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        clusteringOptions.Invariant = "System.Data.SqlClient";
    });


    siloBuilder.AddAdoNetGrainStorage("Default", configureOptions =>
    {
        configureOptions.Invariant = "System.Data.SqlClient";
        configureOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    });


    siloBuilder.AddAdoNetGrainStorage("PubSubStore", configureOptions =>
    {
        configureOptions.Invariant = "System.Data.SqlClient";
        configureOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    });

    siloBuilder.AddAdoNetGrainStorage("PairGapStore", configureOptions =>
    {
        configureOptions.Invariant = "System.Data.SqlClient";
        configureOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    });
    siloBuilder.AddAdoNetGrainStorageAsDefault();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<StreamBackground>();
builder.Services.AddMudServices();
var app = builder.Build();

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
