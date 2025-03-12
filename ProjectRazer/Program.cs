namespace ProjectRazer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar serviços de sessão
            builder.Services.AddDistributedMemoryCache(); // Usando memória como armazenamento para sessão
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo limite da sessão
                options.Cookie.HttpOnly = true; // Segurança: não permitir acesso via JavaScript
                options.Cookie.IsEssential = true; // O cookie é essencial para a operação
            });

            // Adiciona Razor Pages
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configurar o pipeline de requisição
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Adiciona o middleware de sessão antes do UseRouting
            app.UseSession(); // Ativa o uso de sessão

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
