using chat_bot_demo.Services;
using OpenAI.Net;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

// Add services to the container.
// Add services to the container.
builder.Services.AddOpenAIServices(options =>
{
    options.ApiKey = builder.Configuration["OpenAI:ApiKey"];
    options.ApiUrl = builder.Configuration["OpenAI:Url"];
});

// Register the ChatBotService
builder.Services.AddSingleton<IChatBotService, ChatBotService>();
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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
