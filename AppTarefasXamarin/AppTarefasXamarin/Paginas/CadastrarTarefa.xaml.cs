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
    public partial class CadastrarTarefa : ContentPage
    {
        public CadastrarTarefa()
        {
            InitializeComponent();

            pickerPrioridade.SelectedIndex = 0;
        }
        public void SalvarAction(object sender, EventArgs args)
        {

            Tarefa tarefa = new Tarefa();

            tarefa.Nome = Nome.Text;
            tarefa.Descricao = Descricao.Text;
            tarefa.IsEmAndamento = true;


            tarefa.PrioridadeString = pickerPrioridade.SelectedItem.ToString();



            Database database = new Database();
            database.Cadastro(tarefa);

            App.Current.MainPage = new NavigationPage(new ConsultarTarefa());
        }


        private void ActionMudarIndex(object sender, EventArgs args)
        {
            Picker obj = (Picker)sender;
            String prioridadeSelecionada = obj.SelectedItem.ToString() + " - " + obj.SelectedIndex.ToString();
        }


    }
}