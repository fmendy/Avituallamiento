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

namespace Avituallamiento.gui.persona
{
    /// <summary>
    /// Lógica de interacción para DialogoPersona.xaml
    /// </summary>
    public partial class DialogoPersona : Window
    {
        //Cada Pantalla ha de tener un objeto Logica de Negocio
        private LogicaNegocio logicaNegocio;
        public DialogoPersona(LogicaNegocio logicaNegocio)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;

            /* Pasando el context a logica negocio
             * permite que a la hora de hacer un Binding, 
             * llamemos directamente a los objeto que esta clase contiene
             * en este caso llamaremos al atributo listaPersonas
             */
            DataGridPersonas.DataContext = logicaNegocio;
        }

        private void jButtonNuevo_Click(object sender, RoutedEventArgs e)
        {
            DialogoFormularioPersona dfp = new DialogoFormularioPersona(logicaNegocio);
            dfp.Show();
        }

        private void jButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Primero Comprobar si hay algo seleccionado
            if (DataGridPersonas.SelectedIndex != -1)
            {
                //Si hay algo, casteamos la persona
                Persona persona = (Persona)DataGridPersonas.SelectedItem;

                //Llamamos al formulario, con el constructor, logica-persona-posicion
                DialogoFormularioPersona dfp = new DialogoFormularioPersona(
                    logicaNegocio, (Persona)persona.Clone(), DataGridPersonas.SelectedIndex);
                dfp.Show();
            }
            else {
                MessageBox.Show("Seleccione una persona");
            }
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPersonas.SelectedIndex != -1)
            {
                if (!logicaNegocio.eliminarPersona(DataGridPersonas.SelectedIndex)) {
                    MessageBox.Show("La persona seleccionada pertenece a una carrera, eliminela de esta, para poder elimarla");
                }
            }
            else {
                MessageBox.Show("Seleccione una persona");
            }
        }

    }
}
