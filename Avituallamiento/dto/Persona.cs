using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avituallamiento.dto
{
    public class Persona : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        private String nombre;
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        private String telefono;
        public String Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Telefono"));
            }
        }

        public Persona(String nombre, String telefono) { 
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public Persona(){}

        public event PropertyChangedEventHandler PropertyChanged;


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get { 
                //Aplicacion de validaciones
                String result = "";
                //Un if por cada columna/campo
                if (columnName == "Nombre") { 
                    //Detro de cada columna, validamos lo que queremos,
                    //en caso de error se rellana el result
                    if (string.IsNullOrEmpty(nombre)){
                        result = "Debe introducir el nombre";
                    }
                }
                if (columnName == "Telefono") {
                    if (string.IsNullOrEmpty(telefono)||telefono.Length<9 )
                    {
                        result = "Debe introducir un telefono correcto";
                    }
                }
                return result;
            }
        }

        public override string ToString()
        {
            return this.nombre;
        }
    }
}
