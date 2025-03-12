namespace ProjectRazer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar servi�os de sess�o
            builder.Services.AddDistributedMemoryCache(); // Usando mem�ria como armazenamento para sess�o
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo limite da sess�o
                options.Cookie.HttpOnly = true; // Seguran�a: n�o permitir acesso via JavaScript
                options.Cookie.IsEssential = true; // O cookie � essencial para a opera��o
            });

            // Adiciona Razor Pages
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configurar o pipeline de requisi��o
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Adiciona o middleware de sess�o antes do UseRouting
            app.UseSession(); // Ativa o uso de sess�o

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
