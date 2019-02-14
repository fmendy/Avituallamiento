using Avituallamiento.dto;
using Avituallamiento.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avituallamiento.gui.carrera
{
    /// <summary>
    /// Lógica de interacción para DialogoCarreraFormulario.xaml
    /// </summary>
    public partial class DialogoCarreraFormulario : Window
    {
        private LogicaNegocio logicaNegocio;
        private int error;
        private Carrera carrera;
        private Boolean modificar;
        private int posicionCarrera;
        public DialogoCarreraFormulario(LogicaNegocio lg)
        {
            InitializeComponent();
            this.logicaNegocio = lg;
            carrera = new Carrera();
            this.DataContext = carrera;
            this.modificar = false;
        }


        public DialogoCarreraFormulario(LogicaNegocio lg, Carrera c, int posicion) {
            InitializeComponent();
            this.logicaNegocio = lg;
            this.carrera = c;
            this.posicionCarrera = posicion;
            this.modificar = true;
            this.DataContext = carrera;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                error++;
            }
            else
            {
                error--;
      
            }
            if (error == 0)
            {
                buttonAceptar.IsEnabled = true;
            }
            else
            {
                buttonAceptar.IsEnabled = false;
            }
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (!modificar)
            {
                this.logicaNegocio.listaCarrera.Add(carrera);
                this.Close();
            }
            else {
                this.logicaNegocio.modificarCarrera(carrera, posicionCarrera);
                this.Close();
            }
        }
    }
}
