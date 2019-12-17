using AppTarefasXamarin.Banco;
using AppTarefasXamarin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTarefasXamarin.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarTarefa : ContentPage
    {
        List<Tarefa> Lista { get; set; }
        public ConsultarTarefa()
        {
            InitializeComponent();

            Database database = new Database();
            Lista = database.Consultar();
            ListaTarefas.ItemsSource = Lista;

            lblCount.Text = "Registros: " + Lista.Count.ToString();


        }

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarTarefa());
        }


        public void MaisDetalheAction(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;

            Navigation.PushAsync(new DetalharTarefa(tarefa));
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaTarefas.ItemsSource = Lista.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
            lblCount.Text = "Registros: " + Lista.Where(a => a.Nome.Contains(args.NewTextValue)).ToList().Count.ToString();
        }



        public void FinalizarAction(object sender, EventArgs args)
        {
            Label lblFinalizar = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblFinalizar.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;
            tarefa.DataFinalizacao = DateTime.Now;
            tarefa.IsEmAndamento = false;

            Database database = new Database();
            database.Atualizacao(tarefa);

            ConsultarTarefasMetodo();
        }



        public void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;

            Navigation.PushAsync(new EditarTarefa(tarefa));
        }
        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;

            Database database = new Database();
            database.Exclusao(tarefa);
            ConsultarTarefasMetodo();
        }



        private void ConsultarTarefasMetodo()
        {


            Database database = new Database();
            Lista = database.Consultar();
            ListaTarefas.ItemsSource = Lista;



            lblCount.Text = "Registros: " + Lista.Count.ToString();

        }



    }
}