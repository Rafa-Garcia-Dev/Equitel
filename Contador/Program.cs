using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;

namespace Contador
{
    class Program
    {
       
//-------------------------------------------METODO PRINCIPAL--------------------------------------------------------//
        static void Main(string[] args)
        {
             
            System.Threading.Thread tarea1 = new System.Threading.Thread(new ThreadStart(hilo1));
            System.Threading.Thread tarea2 = new System.Threading.Thread(new ThreadStart(hilo2));
            System.Threading.Thread tarea3 = new System.Threading.Thread(new ThreadStart(hilo3));
            System.Threading.Thread tarea4 = new System.Threading.Thread(new ThreadStart(hilo4));


            tarea1.Start();
            tarea2.Start();
            tarea3.Start();
            tarea4.Start();

            Console.ReadKey();

        }

//-------------------------------------------METODOS ADICIONALES--------------------------------------------------------//

    
        // metodo para escribir resultados en .txt

        public static void EscribirEnTxt(String resultado)
        {
            
            try
            {
                //using (StreamWriter Escribir = new StreamWriter("./Resultados.txt"))
                using (StreamWriter Escribir = File.CreateText("Resul.txt"))
                {
                    
                    //Escribir.WriteLine(resultado);
                    Escribir.WriteLineAsync("Resultados");
                    Escribir.Close();
                    if (File.Exists("./Resultados.txt"))
                    {
                        StreamWriter Escribir2 = File.AppendText("./Resultados.txt");
                        Escribir2.WriteLine(resultado);
                        Escribir2.Close();

                    }

                    
                    
                }
            }
            catch
            {
                Console.WriteLine("ERROR");
            }
        }





 //--------------------------------------------------- TAREA 1----------------------------------------------------------//
            /* Leer un archivo de texto, que se encuentre localizado en el equipo y contar las palabras de
              dicho archivo que terminen con la letra n. Escribir el número de palabras encontradas en OTRO
                           archivo de texto, e imprimir dicho número en pantalla*/
       public static void hilo1()
       {
           using (StreamReader leer = new StreamReader("./Texto.txt"))
           {
               String x = leer.ReadToEnd();
      
                x = new string((from c in x where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)   select c).ToArray());
                String[] valores  = x.Split(" ");
                string final;
                int contador = 0;
                bool Devuelve;
                

                foreach( string valor in valores)

                {

                    if (valor.EndsWith("n"))
                        { contador ++; }

                }
               Console.WriteLine("El numero de palabras terminadas en n son : " + contador);
                EscribirEnTxt("El numero de palabras terminadas en n son : " + contador);
            }

       }



 //---------------------------------------------- TAREA 2----------------------------------------------------------//
            /*Leer EL MISMO archivo de texto de la acción 1 (ojo, el mismo archivo físico, no una copia
          exacta del archivo) y esta vez, contar el número de oraciones que contengan más de 15 palabras.
          Entiéndase por oración aquel conjunto de palabras que terminan en un punto SEGUIDO. Escribir el
              número de oraciones de más de 15 palabras encontradas en el MISMO archivo de texto donde se
                escribió (o escribirá) el resultado de la tarea 1, e imprimir dicho número en pantalla*/
     public static void hilo2()
     {
         using (StreamReader leer = new StreamReader("./Texto.txt"))
         {
             string x = leer.ReadToEnd();
               

                var contadorMayorQuince = 0;
             int  numeroEspacios;
             string [] oraciones = x.Split(". ");
                int contadorOracionesMayorAQuince;
                foreach( string oracion in oraciones)
                {
                    numeroEspacios = Regex.Matches(oracion, " ").Count;
                        if (numeroEspacios > 15)
                    {
                        contadorMayorQuince++;
                    }
                }
                Console.WriteLine(" las oraciones con mas de 15 palabras son : " + contadorMayorQuince);
                EscribirEnTxt(" las oraciones con mas de 15 palabras son : " + contadorMayorQuince);

            }

        }

//---------------------------------------------- TAREA 3----------------------------------------------------------//
            /* Leer EL MISMO archivo de texto de la acción 1 (ojo, el mismo archivo físico, no una copia
             exacta del archivo) y esta vez, contar el número de párrafos que contenga el archivo.Entiéndase
             or párrafo aquel conjunto de palabras que terminan en un punto APARTE.Escribir el número de
            párrafos encontrados en el MISMO archivo de texto donde se escribió(o escribirá) el resultado de
                               la tarea 1, e imprimir dicho número en pantalla.*/

     public static void hilo3()
     {
         using (StreamReader leer = new StreamReader("./Texto.txt"))
         {
             String x = leer.ReadToEnd();
                var paragraphs = x.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Count();
                Console.WriteLine("El numero de parrafos es " + paragraphs);
                EscribirEnTxt("El numero de parrafos es " + paragraphs);

            }
     }

//---------------------------------------------- TAREA 4----------------------------------------------------------//
           /*Leer EL MISMO archivo de texto de la acción 1 (ojo, el mismo archivo físico, no una copia
         exacta del archivo) y esta vez, contar el número de caracteres alfanuméricos distintos a n o N que
            contenga el archivo. Entiéndase por caracteres alfanuméricos toda letra que pertenezca a los
         rangos [A Z], [a z] y [0 9]. Es decir ni el punto ni la coma, ni el espacio, etc son considerados
          caracteres alfanuméricos. Escribir el número de alfanuméricos distintos a n o N encontrados en el
         MISMO archivo de texto donde se escribió (o escribirá) el resultado de la tarea 1, e imprimir dicho
                                          número en pantalla*/

     public static void hilo4()
     {
            using (StreamReader leer = new StreamReader("./Texto.txt"))
            {
                String x = leer.ReadToEnd();
             
                x = new string((from c in x where  char.IsLetterOrDigit(c) select c).ToArray());

               
                int tamaño1 = x.Length;
                int totalEnes = Regex.Matches(x, "n").Count + Regex.Matches(x, "N").Count;
                int tamañofinal = tamaño1-totalEnes;

                
                Console.WriteLine("El numero total de caracteres alfanuméricos distintos a n o N es : " + tamañofinal);
                EscribirEnTxt("El numero total de caracteres alfanuméricos distintos a n o N es : " + tamañofinal);
            }
        }
 }
}

