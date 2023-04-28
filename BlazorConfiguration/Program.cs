using BlazorConfiguration;
using BlazorConfiguration.Data;
using BlazorConfiguration.Pages;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add config file
//builder.Configuration.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
builder.Configuration.AddXmlFile("web.config", optional: true, reloadOnChange: true);

//StyleSheetElementOptions options = new();
//builder.Configuration.GetSection("adeNet:styles").Bind(options);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();