using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avituallamiento.dto
{
    public class Puesto : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        private int km;
        public int KM {
            get {
                return km;
            }
            set {
                km = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("KM"));
            }
        }

        private Persona persona;
        public Persona Persona {
            get
            {
                return persona;
            }
            set
            {
                persona = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Persona"));
            }
        }

        public Carrera carrera;

        private ObservableCollection<Material> listaMaterial;
        public ObservableCollection<Material> ListaMaterial {
            get {
                return this.listaMaterial;
            }

            set {
                this.listaMaterial = value; 
                this.PropertyChanged(this, new PropertyChangedEventArgs("ListaMaterial"));
            }
        }


        public Puesto() {
            this.listaMaterial = new ObservableCollection<Material>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
                if (columnName == "Persona")
                {
                    //Detro de cada columna, validamos lo que queremos,
                    //en caso de error se rellana el result
                    if (persona == null)
                    {
                        result = "Debe introducir una persona";
                    }
                }
                if (columnName == "ListaMaterial")

                    if (listaMaterial.Count < 0 ) {
                        result = "Debe introducir materiales";
                    }
                if (columnName == "KM") {
                    if (km < 1) {
                        result = "La carrera no ha avanzado suficiente";
                    }
                } 
                return result;
            }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    
}
