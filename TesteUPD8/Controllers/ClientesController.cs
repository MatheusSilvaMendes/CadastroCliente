using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TesteUPD8.Data;
using TesteUPD8.Models;
using TesteUPD8.Models.ViewModel;

namespace TesteUPD8.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ClientesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<ClientesController> logger)

        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();            
        }

        public IActionResult Cadastrar()
        {
            ViewData["UFSiglaId"] = new SelectList(_context.UF, "UFId", "Nome");
           // ViewData["Sexo"] = new SelectList(_context.Sexo, "Id", "Genero");

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteViewModel agendamentoViewModel)
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = agendamentoViewModel.ClienteId;
            cliente.CPF = agendamentoViewModel.CPF;
            cliente.Nome = agendamentoViewModel.Nome;
            cliente.DataNascimento  = agendamentoViewModel.DataNascimento;
            cliente.Sexo = new Sexo()
            {
                Genero = agendamentoViewModel.Sexo.Genero,
            };
            cliente.Endereco = new Endereco()
            {
                Cep = agendamentoViewModel.Endereco.Cep,
                Logradouro = agendamentoViewModel.Endereco.Logradouro,
                Numero = agendamentoViewModel.Endereco.Numero,
                Complemento = agendamentoViewModel.Endereco.Complemento,
                Bairro = agendamentoViewModel.Endereco.Bairro,
                Cidade = agendamentoViewModel.Endereco.Cidade,
                UFSiglaId = agendamentoViewModel.Endereco.UFSiglaId,
            };
            

            _context.Clientes.AddAsync(cliente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Listar));

        }

        // GET: Agendamentos
        public async Task<IActionResult> Listar()
        {
            var appDbContext = await _context.Clientes.Include(a => a.Endereco).Include(a => a.Sexo).Include(a=>a.Endereco.UFSigla).ToListAsync();


            return View(appDbContext.OrderBy(x => x.Nome).ToList());
        }


    }
}
