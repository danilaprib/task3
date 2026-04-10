namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/daniil_prib_gmail_com", (string? x, string? y) =>
            {
                if (!long.TryParse(x, out long valX) || !long.TryParse(y, out long valY) || valX < 0 || valY < 0)
                {
                    return Results.Text("NaN");
                }

                if (valX == 0 || valY == 0) return Results.Text("0");

                long gcd(long a, long b) => b == 0 ? a : gcd(b, a % b);
                long lcm = (valX * valY) / gcd(valX, valY);

                return Results.Text(lcm.ToString());
            });

            app.Run();
        }
    }
}
