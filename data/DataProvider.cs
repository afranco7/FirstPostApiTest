using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAPIRequest.data
{
    public class DataProvider
    {
        public static MyData Persona1()
        {
            MyData persona1 = new MyData();
            persona1.Id = 1;
            persona1.Nombre = "carlos";
            persona1.Apellido = "valderrama";
            persona1.Age = 50;

            return persona1;
        }

        public static MyData Persona2()
        {
            MyData persona2 = new MyData
            {
                Id = 2,
                Nombre = "cristiano",
                Apellido = "ronaldo",
                Direccion = "turin italia",
                Age = 33
            };

            return persona2;
        }
    }
}
