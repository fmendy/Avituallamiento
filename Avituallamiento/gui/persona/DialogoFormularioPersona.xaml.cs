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
    /// Lógica de interacción para DialogoFormularioPersona.xaml
    /// </summary>
    public partial class DialogoFormularioPersona : Window
    {
        private LogicaNegocio logicaNegocio;
        private Persona persona;
        private int posicion;
        private Boolean modificar;

        //Este campo se crea para comprobar los errores a la hora de validar
        private int error=0;

        //Constructor para alta
        public DialogoFormularioPersona(LogicaNegocio logicaNegocio)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            persona = new Persona();
            /*Establezco el contexto, de este dialogo
             * Una vez establecido hay que realizar el binding entre
             * el campo del formulario y el objeto*/
            this.DataContext = persona;

            modificar = false;
        }

        //Constructor para Modificar
        public DialogoFormularioPersona(LogicaNegocio logicaNegocio, Persona persona, int posicion)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            this.persona = persona;
            this.posicion = posicion;
            /*Establezco el contexto, de este dialogo
             * Una vez establecido hay que realizar el binding entre
             * el campo del formulario y el objeto, con el PATH
             los 2 siguientes campos del bindgin, tienen que ver con la validacion
             */
            this.DataContext = persona;

            modificar = true;
        }

        /*
         * Para realizar un Binding, entre un 2 componente. 
         * En el elemento que queremos que copia, donde copiar, ej en TextBox seria en text, en Label en content, en spinner en Value, en combo SelectedItem
         * ElementName = nombre del elemento a copiar
         * Path = el atributo de ese elemento a copiar
         */

        private void jButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (modificar)
            {
                logicaNegocio.modificarPersona(persona, posicion);
                
            }
            else {
                logicaNegocio.aniadirPersona(persona);
            }
            persona = new Persona();
            this.DataContext = persona;
            this.Close();
        }

              private void jButtonCancelar_Click(object sender, RoutedEventArgs e)
              {
                  this.Close();
              }


                //Esta funcion de validacion, se llama cada que se cambia algo
                // en los texto a validar, para establecer la relacion, en el jText
              // se escribe Validation.Error="Validation_Error" donde Validation_Error,
            // es la funcion a llamar
              private void Validation_Error(object sender, ValidationErrorEventArgs e) {
                  if (e.Action == ValidationErrorEventAction.Added)
                  {
                      error++;
                  }
                  else { 
                    error--;
                  }
                  if (error == 0)
                  {
                      jButtonAceptar.IsEnabled = true;
                  }
                  else {
                      jButtonAceptar.IsEnabled = false;
                  }
              }
    }
}
        