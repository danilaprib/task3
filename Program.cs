using System;
using System.Numerics;

namespace task3;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
        builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

        var app = builder.Build();

        app.MapGet("/daniil_prib_gmail_com", (string? x, string? y) =>
        {
            if (!BigInteger.TryParse(x, out BigInteger valX) ||
                !BigInteger.TryParse(y, out BigInteger valY) ||
                valX <= 0 || valY <= 0)
            {
                return Results.Text("NaN");
            }

            static BigInteger GetGcd(BigInteger a, BigInteger b) => b == 0 ? a : GetGcd(b, a % b);

            BigInteger gcd = GetGcd(valX, valY);
            BigInteger lcm = (valX / gcd) * valY;

            return Results.Text(lcm.ToString());
        });

        app.Run();
    }
}
