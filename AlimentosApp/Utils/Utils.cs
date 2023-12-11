using AlimentosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimentosApp.Utils
{
     class Utils
    {
        public static List<Alimento> ListaAlimentos = new List<Alimento>()
        {
            new Alimento()
            {
                IdAlimento = 1,
                Nombre = "Alimento 1",
                Cantidad = 2,
                Descripcion = "alimento1"
            },

            new Alimento()
            {

                IdAlimento = 2,
                Nombre = "Alimento 2",
                Cantidad = 500,
                Descripcion = "alimento2"

            },

            new Alimento()
            {

                IdAlimento = 3,
                Nombre = "Alimento 3",
                Cantidad = 3000,
                Descripcion = "alimento3"

            }
        };
    }
}
