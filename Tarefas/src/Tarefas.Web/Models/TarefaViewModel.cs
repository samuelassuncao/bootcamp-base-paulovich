using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    
    [MinLength(5, ErrorMessage = "Informe um título com, ao menos, 5 caracteres")]
    [Required(ErrorMessage = "Por favor, informe o título")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    
    [Required(ErrorMessage = "Por favor, informe a descrição")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  
    
    [Required(ErrorMessage = "Por favor, informe o status de conclusão")]
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}