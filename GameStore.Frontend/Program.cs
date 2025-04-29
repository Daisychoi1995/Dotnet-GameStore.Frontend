using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{ //if not in development env
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //thie app can only work with HTTPS
    app.UseHsts();
}
//thie app can only work with HTTPS
// app.UseHttpsRedirection();

//protect our website 
app.UseAntiforgery();
//if its not dynaamic, supply as they are. static files(http, css etc)
app.MapStaticAssets();
//configure middleware, figure all of component from here
app.MapRazorComponents<App>();
//ready to service app
app.Run();
