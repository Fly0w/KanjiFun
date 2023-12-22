using SignalRWebpack.Hubs;
using ViteDotNet;
using ViteDotNet.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddViteIntegration(builder.Configuration); //Allow Vite.NET to read your configuration.
builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.RunViteDevServer("./ClientApp"); //Middleware for running your Vite app alongside your ASP.NET Core app.
app.MapHub<ChatHub>("/hub");

app.Run();
