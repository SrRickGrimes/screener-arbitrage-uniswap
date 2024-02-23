using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.ResponseCompression;
using Flashloan.Infrastructure;
using Flashloan.Server.Backgrounds;
using Orleans.Hosting;
using Orleans.Storage;
using Orleans.Providers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orleans.Configuration;
using Flashloan.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddDomain();
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

    siloBuilder.AddAdoNetGrainStorageAsDefault();
});
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<StreamBackground>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
