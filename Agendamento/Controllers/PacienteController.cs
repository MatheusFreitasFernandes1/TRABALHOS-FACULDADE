using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers;

public class PacienteController : Controller
{
    private readonly PacienteService _pacienteService;

    public PacienteController(PacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    public IActionResult Index()
    {
        var listaPacientes = _pacienteService.Listar();
        return View(listaPacientes);
    }


    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Inserir(Paciente paciente)
    {
        if (!ModelState.IsValid)
            return View(paciente);

        _pacienteService.Inserir(paciente);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Editar(int? id)
    {
        if (id == null)
            return NotFound();

        var obj = _pacienteService.EncontrarId(id.Value);

        if (obj == null)
            return NotFound();

        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Paciente paciente)
    {
        if (!ModelState.IsValid)
            return View(paciente);

        _pacienteService.Atualizar(paciente);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remover(int? id)
    {
        if (id == null)
            return NotFound();

        var obj = _pacienteService.EncontrarId(id.Value);

        if (obj == null)
            return NotFound();

        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remover(int id)
    {
        _pacienteService.Remover(id);

        return RedirectToAction(nameof(Index));
    }
}
