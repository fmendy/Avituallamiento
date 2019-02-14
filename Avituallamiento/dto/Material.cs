using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avituallamiento.dto
{
    /*El using es igual al import
    INo... sirve para n datagrid
    se actualice automaticamente las propiedades*/
    public class Material : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        private String nombre;
        public String Nombre {
            get {
                return nombre;
            }
            set {
                nombre = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        private String tipo;
        public String Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Tipo"));
            }
        }

        private double precio;
        public double Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Precio"));
            }
        }

        public Material() { }

        public Material(String nombre, String tipo, double precio) {
            this.nombre = nombre;
            this.tipo = tipo;
            this.precio = precio;
        }


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
            get
            {
                //Aplicacion de validaciones
                String result = "";
                //Un if por cada columna/campo
                if (columnName == "Nombre")
                {
                    //Detro de cada columna, validamos lo que queremos,
                    //en caso de error se rellana el result
                    if (string.IsNullOrEmpty(nombre))
                    {
                        result = "Debe introducir el nombre";
                    }
                }
                if (columnName == "Tipo")
                {
                    if (string.IsNullOrEmpty(tipo))
                    {
                        result = "Debe introducir un tipo correcto";
                    }
                }
                if (columnName == "Precio")
                {
                    if (precio <= 0)
                    {
                        result = "Debe introducir un precio correcto";
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
