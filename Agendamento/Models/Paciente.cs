using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models;

public class Paciente
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(14)]
    [Display(Name = "CPF")]
    public string Cpf { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    [Display(Name = "Telefone")]
    public string Telefone { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    [Display(Name = "Endereço")]
    public string Endereco { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }
}
