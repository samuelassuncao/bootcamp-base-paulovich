using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;
using Tarefa.DTO;

namespace Tarefas.DAO
{

    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {

        public UsuarioDAO()
        {
           
        }

        public void Criar(UsuarioDTO usuario)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Usuario
                    (Email, Senha, Nome, Ativo) VALUES
                    (@Email, @Senha, @Nome, @Ativo);", usuario
                );
            }
        }
    }
}
       