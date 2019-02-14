using Avituallamiento.dto;
using Avituallamiento.gui.Avituallamiento;
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
    /// Lógica de interacción para DialogoCarrera.xaml
    /// </summary>
    public partial class DialogoCarrera : Window
    {
        private LogicaNegocio logicaNegocio;
        //Este campo se crea para comprobar los errores a la hora de validar
        private int error = 0;
        public DialogoCarrera(LogicaNegocio lg)
        {
            InitializeComponent();
            this.logicaNegocio = lg;
            this.DataContext = logicaNegocio;
        }

        private void buttonAniadir_Click(object sender, RoutedEventArgs e)
        {
            DialogoCarreraFormulario dcf = new DialogoCarreraFormulario(logicaNegocio);
            dcf.Show();
        }

        private void buttonAvituallamiento_Click(object sender, RoutedEventArgs e)
        {
            //Primero Comprobar si hay algo seleccionado
            if (DataGridCarreras.SelectedIndex != -1)
            {
                //Si hay algo, casteamos 
                Carrera carrera = (Carrera)DataGridCarreras.SelectedItem;

                //Llamamos al formulario, con el constructor, logica-material-posicion
                DialogoAvituallamiento da = new DialogoAvituallamiento(
                    logicaNegocio,carrera, DataGridCarreras.SelectedIndex);
                da.Show();
            }
        }

        private void buttonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCarreras.SelectedIndex != -1)
            {
                //Si hay algo, casteamos 
                Carrera c = (Carrera)DataGridCarreras.SelectedItem;

                //Llamamos al formulario, con el constructor, logica-material-posicion
                DialogoCarreraFormulario dcp = new DialogoCarreraFormulario(
                    logicaNegocio, (Carrera)c.Clone(), DataGridCarreras.SelectedIndex);
                dcp.Show();
            }
            else {
                MessageBox.Show("Seleccione una carrera");
            }
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCarreras.SelectedIndex != -1)
            {
                logicaNegocio.eliminarCarrera(DataGridCarreras.SelectedIndex);
            }
            else {
                MessageBox.Show("Seleccione una carrera");
            }
        }
    }
}
