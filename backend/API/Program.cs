using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/pause", async (HttpClient client) =>
{
	var response = await client.GetAsync($"http://{builder.Configuration.GetValue<string>("PiHoles:PiHole0:URL")}/admin/api.php?disable=60&auth={builder.Configuration.GetValue<string>("PiHoles:PiHole0:APIKey")}");

	return response;
});

app.MapGet("/unpause", async (HttpClient client) =>
{
	var response = await client.GetAsync($"http://{builder.Configuration.GetValue<string>("PiHoles:PiHole0:URL")}/admin/api.php?enable&auth={builder.Configuration.GetValue<string>("PiHoles:PiHole0:APIKey")}");

	return response;
});

app.MapGet("/status", async (HttpClient client) =>
{
	var response = await client.GetAsync($"http://{builder.Configuration.GetValue<string>("PiHoles:PiHole0:URL")}/admin/api.php?summaryRaw&auth={builder.Configuration.GetValue<string>("PiHoles:PiHole0:APIKey")}");

	return response;
});


app.Run();