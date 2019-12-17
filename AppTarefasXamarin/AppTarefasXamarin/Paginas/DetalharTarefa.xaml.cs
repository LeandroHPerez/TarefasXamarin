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
    public partial class DetalharTarefa : ContentPage
    {
        public DetalharTarefa(Tarefa tarefa)
        {
            InitializeComponent();

            BindingContext = tarefa;

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
        }
    }
}