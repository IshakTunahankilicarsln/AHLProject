using AhlCourseProject.WebUI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. itk
builder.Services.AddControllersWithViews();
builder.Services.AddSession();


builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpApiService,HttpApiService>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/AdminPanel/Auth/Login"; // Giriþ sayfasýnýn yolu
    // Diðer ayarlar itk
});

var app = builder.Build();

// Configure the itk HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapAreaControllerRoute(
    name: "adminPanelDefault",
    areaName: "AdminPanel",
    pattern: "{area}/{controller=Auth}/{action=LogIn}/{id?}"
    );



app.Run();
