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

namespace Avituallamiento.gui.puesto
{
    /// <summary>
    /// Lógica de interacción para DialogoAvituallamientoDatos.xaml
    /// </summary>
    public partial class DialogoAvituallamientoDatos : Window
    {
        private Puesto puesto;
        private Carrera carrera;
        private int posicionCarrera;
        private int posicionPuesto;
        private Boolean modificar;
        private int error;
        private LogicaNegocio logicaNegocio;


        public DialogoAvituallamientoDatos(LogicaNegocio ln, int posCarrrera, Carrera c)
        {
            InitializeComponent();
            this.carrera = c;
            this.logicaNegocio = ln;
            this.posicionCarrera = posCarrrera;
            puesto = new Puesto();
            this.DataContext = puesto;
            cargarDespensa();
            rellenarComboTipo();
            modificar = false;
        }

        public DialogoAvituallamientoDatos(LogicaNegocio ln, int posCarrrera, int posicionPuesto, Puesto p)
        {
            InitializeComponent();
            this.logicaNegocio = ln;
            this.posicionCarrera = posCarrrera;
            this.carrera = logicaNegocio.listaCarrera[posCarrrera];
            this.puesto = p;
            this.DataContext = puesto;
            cargarDespensa();
            rellenarComboTipo();
            modificar = true;
        }

        public DialogoAvituallamientoDatos()
        {
            // TODO: Complete member initialization
        }

        public void rellenarComboTipo()
        {
            //Relleno del comboBox

            foreach (Persona p in logicaNegocio.listaPersonas)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = p;
                comboBoxPersona.Items.Add(p);
            }
        }


        public void cargarDespensa()
        {
            foreach (Material m in logicaNegocio.listaMaterial)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = m;
                listBoxDespensa.Items.Add(m);
            }
        }



        private void aniadir_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDespensa.SelectedIndex >= 0)
            {
                Material m = (Material)listBoxDespensa.SelectedItem;
                puesto.ListaMaterial.Add(m);

            } 
        }


        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxCarrera.SelectedIndex >= 0)
            {
                Material m = (Material)listBoxCarrera.SelectedItem;
                puesto.ListaMaterial.Remove(m);
            }
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (!modificar)
            {
                logicaNegocio.aniadirAvituallamiento(puesto, posicionCarrera);
                this.Close();
            }
            else {
                logicaNegocio.modificarAvituallamiento(posicionCarrera, posicionPuesto, puesto);
                this.Close();
            }
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

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelKM.Content = sliderKM.Value;
        }

    }
}
