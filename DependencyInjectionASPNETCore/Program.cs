using DependencyInjectionASPNETCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register Services to our Container as a Scoped
// Configure both Interface and the implementation, because you can create a Interface and have many class implementng that interface.
//Transient objects are always different; a new instance is provided to every controller and every service.
// AddScoped -> How long active instance of service will be available, For example when you make http request this EmailSenderService will
// get used and when you make new http request there will be new EmailSenderService
//Sigleton -> It will get shared between the request
// How the instance of the object will get created, used and how long it will alive. lifetime of a service 
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();  // Add our services to the dependency Injection system

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
