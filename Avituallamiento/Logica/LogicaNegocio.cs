using Avituallamiento.dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avituallamiento.Logica
{
    public class LogicaNegocio
    {
        public ObservableCollection<Material> listaMaterial { get; set; }
        public ObservableCollection<Persona> listaPersonas { get; set; }
        public ObservableCollection<Carrera> listaCarrera { get; set;}

        public LogicaNegocio() {
            listaMaterial = new ObservableCollection<Material>();
            listaMaterial.Add(new Material("Coca-Cola", "Bebida", 5));
            listaMaterial.Add(new Material("Kas", "Bebida", 5));


            listaCarrera = new ObservableCollection<Carrera>();
            listaCarrera.Add(new Carrera("Subida al Naranco"));
            listaCarrera.Add(new Carrera("Kilometrin"));

            listaPersonas = new ObservableCollection<Persona>();
            listaPersonas.Add(new Persona("Paco", "123456789"));
            listaPersonas.Add(new Persona("Luis", "123456789"));
        }

        public void aniadirMaterial(Material materia) {
            listaMaterial.Add(materia);
        }

        public void aniadirPersona(Persona persona)
        {
            listaPersonas.Add(persona);
        }

        public void modificarPersona(Persona persona, int posicion) { 
            //Recibo la persona y la posicion de este en la lista
            listaPersonas[posicion] = persona;
        }

        public void modificarMaterial(Material material, int posicion)
        {
            listaMaterial[posicion] = material;
        }


        public void aniadirAvituallamiento(Puesto p, int posicionCarrera) {
                    listaCarrera[posicionCarrera].ListaAvituallamiento.Add(p);
        }

        public void modificarCarrera(Carrera carrera, int posicion) {
            listaCarrera[posicion] = carrera;
        }

        public void eliminarCarrera(int posicion) {
            listaCarrera.RemoveAt(posicion);
        }

        public void eliminarAvituallamiento(int posicionCarrera, int posicionAvituallamiento) {
            listaCarrera[posicionCarrera].ListaAvituallamiento.RemoveAt(posicionAvituallamiento);
        }

        public void modificarAvituallamiento(int posicionCarrera, int posicionAvituallamiento, Puesto puesto) {
            listaCarrera[posicionCarrera].ListaAvituallamiento[posicionAvituallamiento] = puesto;
        }

        public Boolean eliminarMaterial(int  posicion) {
            Material material = listaMaterial[posicion];
            Boolean presenteEnCarreras = false;
            foreach(Carrera c in listaCarrera){
                foreach (Puesto p in c.ListaAvituallamiento) {
                    foreach (Material m in p.ListaMaterial) {
                        if (m.Equals(material)) {
                            presenteEnCarreras = true;
                        }
                    }
                }
            }

            if (!presenteEnCarreras)
            {
                listaMaterial.RemoveAt(posicion);
                return true;
            }
            else {
                return false;
            }
        }

        public Boolean eliminarPersona(int posicion) {
            Persona persona = listaPersonas[posicion];
            Boolean presenteEnCarreras = false;
            foreach (Carrera c in listaCarrera)
            {
                foreach (Puesto p in c.ListaAvituallamiento)
                {
                    if (p.Persona.Equals(persona))
                    {
                        presenteEnCarreras = true;
                    }
                }
            }

            if (!presenteEnCarreras)
            {
                listaPersonas.RemoveAt(posicion);
                return true;
            }
            else {
                return false;
            }
        }
    }
}
