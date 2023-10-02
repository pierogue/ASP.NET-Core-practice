
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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


app.Use(async (context, next) =>
{
    await next.Invoke();

    if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
    {
        var method = context.Request.Method;
        var uri = context.Request.Path + context.Request.QueryString;

        var message = $"{method}:{uri} not supported";

        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync(message);
    }
});    

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dict}/{action=Index}/{id?}");



app.Run();