using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;


namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaDAO tarefaDAO;

        public TarefaController()
        {
            tarefaDAO = new TarefaDAO();
        }
        public List<TarefaViewModel> listaDeTarefas { get; set; }
        
        public IActionResult Details(int id)
        { 
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id =tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };
                return View(tarefa);
        }
        
        public IActionResult Index()
        {
            var listaDeTarefasDTO = tarefaDAO.Consultar();

            var listaDeTarefas= new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add(new TarefaViewModel()
            {
                Id=tarefaDTO.Id,
                Titulo=tarefaDTO.Titulo,
                Descricao=tarefaDTO.Descricao,
                Concluida=tarefaDTO.Concluida
            });
            }
            return View(listaDeTarefas);
        }

        public IActionResult Create()        
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefa)
        {
            var tarefaDTO = new TarefaDTO 
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            tarefaDAO.Criar(tarefaDTO);

            return RedirectToAction("Index");

            if(!ModelState.IsValid)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa)
        {
            var tarefaDTO = new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");

            if(!ModelState.IsValid)
            {
                return View();
            }
        }

        public IActionResult Update(int id)
        {
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id =tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };

            return View(tarefa);
        }
        public IActionResult Delete(int id)
        {
            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}