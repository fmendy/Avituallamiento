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

namespace Avituallamiento.gui.material
{
    /// <summary>
    /// Lógica de interacción para DialogoMaterial.xaml
    /// </summary>
    public partial class DialogoMaterial : Window
    {
        private LogicaNegocio logicaNegocio;
        //Este campo se crea para comprobar los errores a la hora de validar
        private int error = 0;

        public DialogoMaterial(LogicaNegocio logicaNegocio)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            this.DataContext = logicaNegocio;

        }


        private void jButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            DialogoFormularioMaterial dfm = new DialogoFormularioMaterial(logicaNegocio);
            dfm.Show();
        }

        private void jButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            //Primero Comprobar si hay algo seleccionado
            if (dataGridMaterial.SelectedIndex != -1)
            {
                //Si hay algo, casteamos 
                Material material = (Material)dataGridMaterial.SelectedItem;

                //Llamamos al formulario, con el constructor, logica-material-posicion
                DialogoFormularioMaterial dfp = new DialogoFormularioMaterial(
                    logicaNegocio, (Material)material.Clone(), dataGridMaterial.SelectedIndex);
                dfp.Show();
            }
            else {
                MessageBox.Show("Seleccione un material");
            }
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMaterial.SelectedIndex != -1)
            {
                if (!logicaNegocio.eliminarMaterial(dataGridMaterial.SelectedIndex)) {
                    MessageBox.Show("El material seleccionado pertenece a una carrera, eliminelo de esta, para poder elimnarlo");
                }
            }
            else {
                MessageBox.Show("Seleccione un material");
            }
        }

        



    }
}
