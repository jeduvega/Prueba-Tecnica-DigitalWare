using System;
using System.Linq;

namespace Prueba_DigitalWare
{
    internal class Program
    {
        static void Main(string[] args)
        {
Inicio:
            Console.WriteLine("1. Punto 1 \n2. Punto 2\n3. Punto 3" );
            Console.Write("Inserta una opcion y presiona enter: ");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    var myArray = new[] { 54, 28, 54, 40, 15 };
                    var maxValue = 0;

                    for (int i = 0; i < myArray.Length; i++)
                    {
                        if (myArray[i] > maxValue)
                            maxValue = myArray[i];

                    }

                    Console.WriteLine(maxValue);
                    
                    goto  Inicio;
                    


                case "2":

                    myArray = new[] { 1, 2, 1, 3, 3, 1, 2, 1, 5, 1 };
                   
                   for(int i = 1; i <= 5; i++)
                    {
                        Console.Write(i + ": ");
                        var result = myArray.Where(x => x.Equals(i)).Count();
                        for (int j = 0; j < result ; j++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    
                    }
                    goto Inicio;

                case "3":


                    myArray = new[] { 1, 3, 4, 2, 7, 0};

                    int Na, Nb;

                    for(int i=0; i<myArray.Length;i++)
                    {
                        for(int j= 1; j<myArray.Length;j++)
                        {
                            Na=myArray[i];
                            Nb = myArray[j];
                            int suma = Na+Nb;
                            if (suma == 10)
                            {
                                Console.WriteLine(Na+" "+Nb);
                                return;

                            }

                        }


                    }

                    goto Inicio;

                default:
                    goto Inicio;
            }

        }
    }
}
