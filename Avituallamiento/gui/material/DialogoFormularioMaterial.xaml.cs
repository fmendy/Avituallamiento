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
    /// Lógica de interacción para DialogoFormularioMaterial.xaml
    /// </summary>
    public partial class DialogoFormularioMaterial : Window
    {
        private LogicaNegocio logicaNegocio;
        private Material material;
        private int posicion;
        private Boolean modificar;

        private int error;


        public DialogoFormularioMaterial(LogicaNegocio logicaNegocio)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            material = new Material();
            this.DataContext=this.material;
            modificar = false;

            rellenarComboTipo();
        }

        //Constructor para Modificar
        public DialogoFormularioMaterial(LogicaNegocio logicaNegocio, Material material, int posicion)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            this.material = material;
            this.posicion = posicion;
            /*Establezco el contexto, de este dialogo
             * Una vez establecido hay que realizar el binding entre
             * el campo del formulario y el objeto, con el PATH
             los 2 siguientes campos del bindgin, tienen que ver con la validacion
             */
            this.DataContext = this.material;
            modificar = true;
            rellenarComboTipo();

        }


           public void rellenarComboTipo() {
           //Relleno del comboBox
           List<String> listaTipos = new List<string>();
           listaTipos.Add("Bebida");
           listaTipos.Add("Comida");
           listaTipos.Add("Material Sanitario");

           foreach (String s in listaTipos)
           {
               ComboBoxItem cbi = new ComboBoxItem();
               cbi.Content = s;
               comboTipo.Items.Add(s);
           }
       }

           private void Button_Click_1(object sender, RoutedEventArgs e)
           {
               if (modificar)
               {
                   logicaNegocio.modificarMaterial(material, posicion);
               }
               else {
                   logicaNegocio.aniadirMaterial(material);
               }
               this.Close();
           }

           //Esta funcion de validacion, se llama cada que se cambia algo
           // en los texto a validar, para establecer la relacion, en el jText
           // se escribe Validation.Error="Validation_Error" donde Validation_Error,
           // es la funcion a llamar
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
                   buttonAniadir.IsEnabled = true;
               }
               else
               {
                   buttonAniadir.IsEnabled = false;
               }
           }

           private void buttonCancelar_Click(object sender, RoutedEventArgs e)
           {
               this.Close();
           }


            
    }
}
