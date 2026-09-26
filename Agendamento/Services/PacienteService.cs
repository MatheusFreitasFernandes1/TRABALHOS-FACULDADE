using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services;

public class PacienteService
{
    private readonly AppDbContext _context;

    public PacienteService(AppDbContext context)
    {
        _context = context;
    }

    public List<Paciente> Listar()
    {
        return _context.Pacientes.OrderBy(p => p.Id).ToList();
    }

    public void Inserir(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
    }

    public Paciente? EncontrarId(int id)
    {
        return _context.Pacientes.Find(id);
    }

    public void Atualizar(Paciente paciente)
    {
        _context.Pacientes.Update(paciente);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var obj = _context.Pacientes.Find(id);

        if (obj == null)
        {
            return;
        }

        _context.Pacientes.Remove(obj);
        _context.SaveChanges();
    }
}
