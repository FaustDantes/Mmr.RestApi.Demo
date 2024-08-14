using Mmr.RestApi.Demo.Services;
using Serilog;
using System.Reflection;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddSingleton<IFileStorage>(new FileStorage("A"));
builder.Services.AddHealthChecks();

var index = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-dev-{DateTime.UtcNow:yyyy-MM}";
Console.WriteLine(index);

builder.Services.AddSerilog(config =>
{
    config.ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        IndexFormat = index,
        BatchAction = ElasticOpType.Create,
    })
    .Enrich.WithProperty("application", "mmr-demo");
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
