using BlazerSoft_SlotMachine;
using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPlayerInfoContext, PlayerInfoContext>();
builder.Services.AddTransient<IConfigurationContext, IConfigurationContext>();
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddCommandLine(args);
builder.Services.Configure<ConnectionSetting>(
    options =>
    {
        options.ConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
        options.Database = builder.Configuration.GetSection("MongoDB:Database").Value;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();