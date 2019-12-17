using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace AppTarefasXamarin.Modelo
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public Boolean IsEmAndamento { get; set; }
        //public byte Prioridade { get; set; }
        public string PrioridadeString { get; set; }
    }
}