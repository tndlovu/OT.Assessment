using System.Reflection;
using OT.Assessment.Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckl
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AssessmentDbContext>(
    options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(o => o.AddPolicy("OT.Assessment.App", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<IWagerService, WagerService>();
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();
builder.Services.AddScoped<IProviderService,ProviderService>();
builder.Services.AddScoped<IGameervice, Gameervice>();
builder.Services.AddScoped<IPlayerervice, Playerervice>();

builder.Services.AddScoped<IRabbitMQReposistory, RabbitMQReposistory>();
builder.Services.AddScoped<IProviderReposistory, ProviderReposistory>();
builder.Services.AddScoped<IPlayerReposistory, PlayerReposistory>();
builder.Services.AddScoped<IGameReposistory, GameReposistory>();
builder.Services.AddScoped<IWagerReposistory, WagerReposistory>();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.EnableTryItOutByDefault();
        opts.DocumentTitle = "OT Assessment App";
        opts.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
     name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
