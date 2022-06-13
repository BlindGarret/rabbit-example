using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

//MQ
var connectionFactory = new ConnectionFactory() {HostName = "localhost"};
builder.Services.AddSingleton(connectionFactory);
builder.Services.AddScoped(_ => connectionFactory.CreateConnection());

// Add services to the container here

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
