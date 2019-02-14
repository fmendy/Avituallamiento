using Avituallamiento.gui;
using Avituallamiento.gui.carrera;
using Avituallamiento.gui.material;
using Avituallamiento.gui.persona;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avituallamiento
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogicaNegocio logicaNegocio;

        public MainWindow()
        {
            InitializeComponent();
            logicaNegocio = new LogicaNegocio();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogoMaterial dm = new DialogoMaterial(logicaNegocio);
            dm.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DialogoPersona dp = new DialogoPersona(logicaNegocio);
            dp.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DialogoMaterial dm = new DialogoMaterial(logicaNegocio);
            dm.Show();
        }

        private void buttonCarreras_Click(object sender, RoutedEventArgs e)
        {
            DialogoCarrera dc = new DialogoCarrera(logicaNegocio);
            dc.Show();
        }
    }
}
