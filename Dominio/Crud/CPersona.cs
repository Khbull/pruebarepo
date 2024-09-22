using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAcces.Entidades;
using Common.Atributos;



namespace Dominio.Crud
{
    public class CPersona
    {
        Persona persona = new Persona();

        public DataTable Mostrar()

        { 
            DataTable td = new DataTable();
            td = persona.Mostrar();
            return td;
        
        }

        public DataTable Buscar(string buscar)

        {
            DataTable td = new DataTable();
            td = persona.Buscar(buscar);
            return td;

        }



        public void Insertar(AtributosPersona obj)
        {
            persona.Insertar(obj);
        
        }

        public void Modificar(AtributosPersona obj)
        {
            persona.Modificar(obj);

        }
        public void Eliminar(AtributosPersona obj)
        {
            persona.Eliminar(obj);

        }
    }
}
