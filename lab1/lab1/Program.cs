using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder();
 
var app = builder.Build();

app.Run(HandleRequest);

async Task HandleRequest(HttpContext context)
{
    var path = context.Request.Path;
    var res = context.Response;
    var req = context.Request;
    var method = req.Method;
    
    if (path == "/PAE" && method == "GET")
    {
        var parmA = req.Query["parmA"];
        var parmB = req.Query["parmB"];
        res.Headers.ContentType = "text/plain";
        await res.WriteAsync($"GET-Http-PAE:ParmA = {parmA},ParmB = {parmB}");
    }
    else if (path == "/PAE" && method == "POST")
    {
        var parmA = req.Query["parmA"];
        var parmB = req.Query["parmB"];
        res.Headers.ContentType = "text/plain";
        await res.WriteAsync($"POST-Http-PAE:ParmA = {parmA},PArmB = {parmB}");
    }
    else if (path == "/PAE" && method == "PUT")
    {
        var parmA = req.Query["parmA"];
        var parmB = req.Query["parmB"];
        res.Headers.ContentType = "text/plain";
        await res.WriteAsync($"PUT-Http-PAE:ParmA = {parmA},PArmB = {parmB}");
    }
    else if (path == "/add" && method == "GET")
    {
        var x = Convert.ToInt32(req.Query["x"]);
        var y = Convert.ToInt32(req.Query["y"]);
        await res.WriteAsync($"{x + y}");
    }
    else if (path == "/add" && method == "POST")
    {
        res.ContentType = "application/json";
        var x = Convert.ToInt32(req.Form["xm"]);
        var y = Convert.ToInt32(req.Form["ym"]);
        
        await res.WriteAsync($"{x * y}");
    }
    else if (path == "/addwpf" && method == "POST")
    {
       
        // var x = Convert.ToInt32(req.Form["xm"]);
        // var y = Convert.ToInt32(req.Form["ym"]);

        using (var reader = new StreamReader(req.Body))
        {
            var query = await reader.ReadToEndAsync();
            JObject js = JObject.Parse(query);
            var varx = Convert.ToInt32(js["x"]);
            var vary = Convert.ToInt32(js["y"]);
            await res.WriteAsync($"{varx * vary}");
        }
        
        // await res.WriteAsync($"{x * y}");
    }
    else if(path == "/addwpf" && method == "GET")
    {

        var varx = Convert.ToInt32(req.Query["x"]);
        var vary = Convert.ToInt32(req.Query["y"]);

        await res.WriteAsync($"{varx + vary}");
    }
    else
    {
        
        await res.SendFileAsync("html\\main.html");
    }
}

app.Run();