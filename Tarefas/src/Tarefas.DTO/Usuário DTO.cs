using System;

namespace Tarefa.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string? Email { get; set; }        

        public string? Senha { get; set; }  

        public string? Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
