using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avituallamiento.dto
{
    public class Carrera : INotifyPropertyChanged, ICloneable, IDataErrorInfo
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

        private ObservableCollection<Puesto> listaAvituallamiento;
        public ObservableCollection<Puesto> ListaAvituallamiento {
            get {
                return this.listaAvituallamiento;
            }

            set {
                this.listaAvituallamiento = value;
            }
        }

        public Carrera(String nombre) {
            this.nombre = nombre;
            listaAvituallamiento = new ObservableCollection<Puesto>();
        }

        public Carrera() {
            listaAvituallamiento = new ObservableCollection<Puesto>();
        }

        public override string ToString() {
            return this.nombre;
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
                return result;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
