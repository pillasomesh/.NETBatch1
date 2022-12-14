using ErrorHandling.Core.Contract.Service;
using ErrorHandling.Infrastructure.Service;
using ErrorHandling.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IEmployee), typeof(EmployeeService));
// Add services to the container.

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
//Register Exception handler Middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
