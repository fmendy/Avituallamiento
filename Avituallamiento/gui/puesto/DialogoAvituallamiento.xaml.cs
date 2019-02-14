using Avituallamiento.dto;
using Avituallamiento.gui.puesto;
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

namespace Avituallamiento.gui.Avituallamiento
{
    /// <summary>
    /// Lógica de interacción para DialogoAvituallamiento.xaml
    /// </summary>
    public partial class DialogoAvituallamiento : Window
    {
        private LogicaNegocio logicaNegocio;
        private Carrera carrera;
        private int posicionCarrera;
        public DialogoAvituallamiento(LogicaNegocio ln, Carrera c, int p)
        {
            InitializeComponent();
            this.logicaNegocio = ln;
            this.carrera = c;
            this.posicionCarrera = p;
            this.DataContext = carrera;
        }

        private void buttonAniadir_Click(object sender, RoutedEventArgs e)
        {
            DialogoAvituallamientoDatos dad = new DialogoAvituallamientoDatos(logicaNegocio, posicionCarrera, carrera);
            dad.Show();
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (datagridAvituallamiento.SelectedIndex != -1)
            {
                logicaNegocio.eliminarAvituallamiento(posicionCarrera, datagridAvituallamiento.SelectedIndex);
            }
            else {
                MessageBox.Show("Seleccione un puesto");
            }
        }

        private void buttonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (datagridAvituallamiento.SelectedIndex != -1)
            {
                Puesto p = (Puesto)datagridAvituallamiento.SelectedItem;
                DialogoAvituallamientoDatos dad = new DialogoAvituallamientoDatos(this.logicaNegocio, this.posicionCarrera, datagridAvituallamiento.SelectedIndex, (Puesto)p.Clone());
                dad.Show();
            }
            else {
                MessageBox.Show("Seleccione un puesto");
            }
        }
    }
}
