# Trabalho 1 - Dev. Web com .NET — Gerenciamento de Pacientes

Este projeto implementa a funcionalidade pedida no Trabalho 1: CRUD (listar,
inserir, editar e remover) de **Pacientes**, seguindo a mesma arquitetura
usada em sala para Médicos (Aulas 5 e 6): `AppDbContext` → `PacienteService`
→ `PacienteController` → Views.

## O que já está pronto

1. ✅ Classe `Paciente` (`Models/Paciente.cs`) com as propriedades pedidas:
   Nome, CPF, Telefone, Endereço e Data de Nascimento;
2. ✅ *Data Annotations* validando as propriedades (`[Required]`,
   `[StringLength]`, `[RegularExpression]` no CPF, `[DataType(DataType.Date)]`
   na data de nascimento);
3. ⚠️ Migration: **precisa ser criada por você** (veja o passo a passo abaixo)
   — não é possível gerar/aplicar migrations sem o SDK/NuGet do seu ambiente;
4. ✅ `SeedingService.Popula()` (`Data/SeedingService.cs`) com 3 pacientes
   iniciais, seguindo o mesmo padrão do `SeedingService` de médicos;
5. ✅ Telas do CRUD completas: `Index` (listar), `Inserir`, `Editar` e
   `Remover`, em `Views/Paciente/`.

## Como abrir e rodar no Visual Studio Community

1. Abra o arquivo **`Agendamento.sln`** no Visual Studio Community
   (ele já referencia o projeto `Agendamento\Agendamento.csproj`).
2. Aguarde o Visual Studio restaurar os pacotes NuGet automaticamente
   (`Microsoft.EntityFrameworkCore.SqlServer`, `.Tools` e `.Design`).
   Se não restaurar sozinho, clique com o botão direito na Solution →
   **Restaurar Pacotes NuGet**.
3. O projeto está configurado para usar o **LocalDB** do SQL Server
   (`appsettings.json`, banco `AgendamentoDb`). Se você usa outro SQL Server
   local, ajuste a `ConnectionStrings:DefaultConnection`.

## Criando a migration (passo 3 do trabalho)

No **Console do Gerenciador de Pacotes** (Package Manager Console) do
Visual Studio, com o projeto `Agendamento` selecionado como *Default project*:

```powershell
Add-Migration InicialPacientes
Update-Database
```

Isso vai gerar a pasta `Migrations/` e criar a tabela `Pacientes` no banco.

Se preferir usar o terminal (CLI do .NET), dentro da pasta `Agendamento`:

```bash
dotnet ef migrations add InicialPacientes
dotnet ef database update
```

> Se o comando `dotnet ef` não for reconhecido, instale a ferramenta global:
> `dotnet tool install --global dotnet-ef`

## Rodando a aplicação

Pressione **F5** (ou Ctrl+F5) no Visual Studio. O navegador abrirá direto na
tela de listagem de pacientes (`/Paciente`), já com os 3 pacientes do seeding
cadastrados automaticamente na primeira execução.

## Estrutura de pastas

```
Agendamento/
├── Controllers/
│   └── PacienteController.cs      # Listar, Inserir, Editar, Remover
├── Data/
│   ├── AppDbContext.cs            # DbSet<Paciente>
│   └── SeedingService.cs          # Popula() com pacientes iniciais
├── Models/
│   └── Paciente.cs                # Nome, Cpf, Telefone, Endereco, DataNascimento
├── Services/
│   └── PacienteService.cs         # Listar, Inserir, EncontrarId, Atualizar, Remover
├── Views/
│   ├── Paciente/
│   │   ├── Index.cshtml           # Listagem
│   │   ├── Inserir.cshtml         # Formulário de cadastro
│   │   ├── Editar.cshtml          # Formulário de edição
│   │   └── Remover.cshtml         # Confirmação de exclusão
│   └── Shared/_Layout.cshtml
├── Program.cs
└── appsettings.json
```

## Checklist do enunciado (Trabalho 1)

- [x] Criação da classe `Paciente`
- [x] Data Annotations para validar as propriedades
- [ ] Criação e aplicação de migrations (rode `Add-Migration` / `Update-Database`)
- [x] Seeding com pacientes iniciais
- [x] Telas do CRUD: listar, inserir, editar e remover
