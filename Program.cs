namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

            var app = builder.Build();

            app.MapGet("/daniil_prib_gmail_com", (string? x, string? y) =>
            {
                if (!ulong.TryParse(x, out ulong valX) || !ulong.TryParse(y, out ulong valY))
                {
                    return Results.Text("NaN");
                }

                if (valX == 0 || valY == 0)
                {
                    return Results.Text("0");
                }                    

                static ulong GetGcd(ulong a, ulong b) => b == 0 ? a : GetGcd(b, a % b);

                try
                {
                    ulong gcd = GetGcd(valX, valY);
                    ulong lcm = checked((valX / gcd) * valY);
                    return Results.Text(lcm.ToString());
                }
                catch (OverflowException)
                {
                    return Results.Text("NaN");
                }
            });

            app.Run();
        }
    }
}
