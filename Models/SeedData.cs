using CamposDealer.Data;
using Microsoft.EntityFrameworkCore;

namespace CamposDealer.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new CamposDealerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CamposDealerContext>>());

        if (context.Cliente.Any())
        {
            return;
        }
        context.Cliente.AddRange(
            new Cliente
            {
                NmCliente = "Ian Gabriel Klapouch",
                Cidade = "Curitiba"
            }

        );
        context.SaveChanges();
    }
}
