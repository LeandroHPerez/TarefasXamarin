using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

using Xamarin.Forms;
using AppTarefasXamarin.Modelo;

namespace AppTarefasXamarin.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Tarefa>();
        }

        public List<Tarefa> Consultar()
        {
            return _conexao.Table<Tarefa>().ToList();
        }
        public List<Tarefa> Pesquisar(string palavra)
        {
            return _conexao.Table<Tarefa>().Where(a => a.Nome.Contains(palavra)).ToList();
        }
        public Tarefa ObterVagaPorId(int id)
        {
            return _conexao.Table<Tarefa>().Where(a => a.Id == id).FirstOrDefault();
        }
        public void Cadastro(Tarefa tarefa)
        {
            _conexao.Insert(tarefa);
        }
        public void Atualizacao(Tarefa tarefa)
        {
            _conexao.Update(tarefa);
        }
        public void Exclusao(Tarefa tarefa)
        {
            _conexao.Delete(tarefa);
        }
    }
}