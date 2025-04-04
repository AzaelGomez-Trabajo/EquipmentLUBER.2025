using Equipment.Backend.Data;
using Equipment.Backend.Repositories.Implementations;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Implementations;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Para quitar las referencias circulares
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=CadenaSQL2"));
builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));

builder.Services.AddScoped<IBranchOfficesRepository, BranchOfficesRepository>();
builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddScoped<IEmploymentsRepository, EmploymentsRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IFixedAssetsRepository, FixedAssetRepository>();

builder.Services.AddScoped<IBranchOfficesUnitOfWork, BranchOfficesUnitOfWork>();
builder.Services.AddScoped<IDepartmentsUnitOfWork, DepartmentsUnitOfWork>();
builder.Services.AddScoped<IEmployeesUnitOfWork, EmployeesUnitOfWork>();
builder.Services.AddScoped<IEmploymentsUnitOfWork, EmploymentsUnitOfWork>();
builder.Services.AddScoped<IFixedAssetsUnitOfWork, FixedAssetsUnitOfWork>();


var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();