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
    public partial class EditarTarefa : ContentPage
    {
        private Tarefa tarefa { get; set; }
        public EditarTarefa(Tarefa tarefa)
        {
            InitializeComponent();

            this.tarefa = tarefa;

            Nome.Text = tarefa.Nome;

            Descricao.Text = tarefa.Descricao;

            String caseSwitch = tarefa.PrioridadeString;

            switch (caseSwitch)
            {
                case "Urgente":
                    pickerPrioridade.SelectedIndex = 0;
                    break;
                case "Alta":
                    pickerPrioridade.SelectedIndex = 1;
                    break;
                case "Média":
                    pickerPrioridade.SelectedIndex = 2;
                    break;
                case "Baixa":
                    pickerPrioridade.SelectedIndex = 3;
                    break;
                default:
                    pickerPrioridade.SelectedIndex = 0;
                    break;
            }


            tarefa.PrioridadeString = pickerPrioridade.SelectedItem.ToString();

        }
        public void SalvarAction(object sender, EventArgs args)
        {
            tarefa.Nome = Nome.Text;

            tarefa.Descricao = Descricao.Text;

            tarefa.PrioridadeString = pickerPrioridade.SelectedItem.ToString();

            Database database = new Database();
            database.Atualizacao(tarefa);


            App.Current.MainPage = new NavigationPage(new ConsultarTarefa());
        }


        private void ActionMudarIndex(object sender, EventArgs args)
        {
            Picker obj = (Picker)sender;
            tarefa.PrioridadeString = pickerPrioridade.SelectedItem.ToString();
        }


    }
}