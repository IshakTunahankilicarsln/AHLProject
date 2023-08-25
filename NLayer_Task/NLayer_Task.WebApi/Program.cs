using NLayer_Task.Business.Extension.AlExtension;
using NLayer_Task.WebApi.Extensions;
using NLayer_Task.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddService();

//IOC-----------------------------------------------------------------------------------------------------------------------------------------------------------IshakTunahankýlýcarslan

builder.Services.AddBusinessService();
/*builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductBS, ProductBS>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryBS, CategoryBS>(); 
builder.Services.AddScoped<IAddresRepository, AddresRepository>();
builder.Services.AddScoped<IAddresBS, AddresBS>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerBS, CustomerBS>();*/

//-------------------------------------------------------------------------------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCustomException();

app.Run();