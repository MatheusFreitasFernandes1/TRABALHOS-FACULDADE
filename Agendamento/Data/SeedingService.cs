using Agendamento.Models;

namespace Agendamento.Data;

public class SeedingService
{
    private readonly AppDbContext _context;

    public SeedingService(AppDbContext context)
    {
        _context = context;
    }

    public void Popula()
    {
        if (_context.Pacientes.Any())
            return;

        var pacientes = new List<Paciente>
        {
            new Paciente
            {
                Nome = "Matheus",
                Cpf = "123.456.789-00",
                Telefone = "(18) 99123-4567",
                Endereco = "Rua algo, 123",
                DataNascimento = new DateTime(2007, 8, 28)
            },
            new Paciente
            {
                Nome = "Kubola",
                Cpf = "987.654.321-00",
                Telefone = "(18) 99876-5432",
                Endereco = "rua algo2, 456",
                DataNascimento = new DateTime(2003, 11, 30)
            },
            new Paciente
            {
                Nome = "Jasmin",
                Cpf = "456.123.789-00",
                Telefone = "(18) 99456-1234",
                Endereco = "Rua algo3, 789",
                DataNascimento = new DateTime(2005, 2, 6)
            }
        };

        _context.Pacientes.AddRange(pacientes);
        _context.SaveChanges();
    }
}
