using System;

namespace ConsoleApp2
{
    class Program
    {
        class Punto
        {
            private double x;
            private double y;
            //------------------------ Métodos
            public  Punto( double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public double _x()
            {
                return this.x;
            }
            public double _y()
            {
                return this.y;
            }
            public Boolean mismo_punto(Punto punto)//--- Revisa si el punto que le envían por argumento es el mismo donde está él.
            {
                bool mismo = false;

                mismo = this.x == punto._x();
                mismo = mismo || this.y == punto._y();
                return mismo;
            }
          
        }
        class Circunferencia
        {
            private double x;
            private double y;
            private double radio;
            private Punto[] puntos = new Punto[360];
            //----------------------------- Métodos
            public Circunferencia( double x, double y, double radio)
            {
                this.x = x;
                this.y = y;
                this.radio = radio;
            }
            public Punto[]_puntos()
            {
                return this.puntos;
            }
            public bool calcula_puntos()
            {
                bool se_pudo = false;
                double theta = 0, x, y;
                

                for( int j = 0; j<360; j++)//-- Se usará a j como indicador del ángulo theta pero se debe recalcular de grados a radianes
                {
                    theta = j * Math.PI / 180;//-- Cada 180 grados hay un pi (3.141592654...) en radianes
                    x = this.x + Math.Cos(theta) * this.radio;
                    y = this.y + Math.Sin(theta) * this.radio;
                    Punto punto = new Punto(x, y);//-- creamos un objeto de la clase Punto para agregar a la colección
                    this.puntos[j]= punto;
                    se_pudo = se_pudo || j == 359;
                }
                return se_pudo;
            }
            public bool intersecta( Punto[] puntos )
            {
                bool si_intersecta = true;

                for( int i =0; i<360;i++ )//-- para cada punto dentro del objeto (usando this)
                {
                    for( int j = 0; j<360; j++)//-- revisar con cada punto del otro objeto, llegó como argumento.
                    {
                        si_intersecta = this.puntos[i].mismo_punto(puntos[j]);
                    }
                }
                return si_intersecta; 
            } 
        }
        static void Main(string[] args)
        {
            string entrada;
            double x, y, radio;
            
            //----------------------- PRIMERO LOS MENSAJES A PANTALLA PARA QUE EL USUARIO SEPA DE QUE TRATA EL PROGRAMA O APLICACIÓN
            Console.WriteLine("Este programa calcula si dos circunferencias se intersectan.");
            Console.WriteLine("Por favor introduzca las coordenadas del centro (x,y) y el radio:");
            //--- Ahora se piden los datos de las circunferencias.
            Console.WriteLine("Circunferencia A");
            Console.WriteLine("x = ");
            entrada = Console.ReadLine();
            x= Convert.ToDouble(entrada);
            Console.WriteLine("y = ");
            entrada = Console.ReadLine();
            y= Convert.ToDouble(entrada);
            Console.WriteLine("radio = ");
            entrada = Console.ReadLine();
            radio = Convert.ToDouble(entrada);
            Circunferencia C_A = new Circunferencia(x, y, radio);
            //--- Ahora la circunferencia B
            Console.WriteLine("Circunferencia B");
            Console.WriteLine("x = ");
            entrada = Console.ReadLine();
            x = Convert.ToDouble(entrada);
            Console.WriteLine("y = ");
            entrada = Console.ReadLine();
            y = Convert.ToDouble(entrada);
            Console.WriteLine("radio = ");
            entrada = Console.ReadLine();
            radio = Convert.ToDouble(entrada);
            Circunferencia C_B = new Circunferencia(x, y, radio);

            //----------------------------- UNA VEZ LEIDOS LOS DATOS Y ESTABLECIDO LOS OBJETOS INICIALMENTE, AHORA LOS PONEMOS A TRABAJAR
            C_A.calcula_puntos();
            C_B.calcula_puntos();
            //----------------------------- AHORA QUE YA CONOCEN SUS PROPIOS PUNTOS HACEMOS QUE UNA LE PREGUNTE A LA OTRA POR SUS PUNTOS 
            bool intersecta = C_A.intersecta(C_B._puntos());
            if (intersecta)
            {
                Console.WriteLine("La circunferencia A intersecta con la circunferencia B");
            } else 
                Console.WriteLine("La circunferencia A no intersecta con la circunferencia B");
        }
    }
}
