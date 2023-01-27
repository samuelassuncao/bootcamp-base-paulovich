using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaDAO _tarefaDAO;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaDAO tarefaDAO, IMapper mapper)
        {
            _tarefaDAO = tarefaDAO;
            _mapper = mapper;
        }

        public List<TarefaViewModel> listaDeTarefas { get; set; }
        
        public IActionResult Details(int id)
        { 
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            return View (tarefa);

        }
        
        public IActionResult Index()
        {
            var listaDeTarefasDTO = _tarefaDAO.Consultar();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
            }
            return View(listaDeTarefas);
        }

        public IActionResult Create()        
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefaViewModel)
        {
            //foi necessário criar a variável tarefaViewModel
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefaViewModel);

            _tarefaDAO.Criar(tarefaDTO);


            if(!ModelState.IsValid)
            {
                return View();
            }


            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefaViewModel)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefaViewModel);
            _tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefaViewModel = _mapper.Map<TarefaDTO>(tarefaDTO);

            return View(tarefaViewModel);
        }
        public IActionResult Delete(int id)
        {
            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}