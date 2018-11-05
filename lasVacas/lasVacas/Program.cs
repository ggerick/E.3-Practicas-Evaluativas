using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lasVacas
{
    public class Cows//Creamos la clase vaca, y cada vaca tendra nombre y tiempo(en cruzar el puente)
    {
        public string name;//Agregamos la  propiedad nombre
        public int time;//Agregamos la proviedad de tiempo

        public Cows(string name, int time)//Un constructor que recibe valores en los parametros
        {
            this.name = name;//Usamos "this" para usar el mismo nombre que los parametros
            this.time = time;
        }

    }

    public class Quizz
    {
        public List<Cows> mainBridge = new List<Cows>();//Creamos una lista de objetos vaca, que es el puente Inicial
        public List<Cows> finalBridge = new List<Cows>();//Creamos una lista de objetos vaca, y es el final, donde pasaremos las vacas
        int totalTime = 0;// el tiempo que ha pasado moviendo vacas

        public void Values()
        {
            mainBridge.Add(new Cows("Mazie", 2));//Agregamos a Mazie
            mainBridge.Add(new Cows("Daisy", 4));//Agregamos a Daisy
            mainBridge.Add(new Cows("Crazy", 10));//Agregamos a Crazy
            mainBridge.Add(new Cows("Lazy", 20));//Agregamos a Lazy
        }

        public void MovingCows()
        {
            Console.WriteLine("1.- Supongamos que Bob tiene cuatro vacas que quiere cruzar por un puente, pero solo un yugo," +
                              " que puede sostener hasta dos vacas, lado a lado, atadas al yugo. El yugo es demasiado pesado para que lo lleve a través del puente," +
                              " pero puede atar (y desatar) vacas a él en muy poco tiempo. De sus cuatro vacas, Mazie puede cruzar el puente en 2 minutos," +
                              " Daisy puede cruzarlo en 4 minutos, Crazy puede cruzarlo en 10 minutos y Lazy puede cruzar en 20 minutos. Por supuesto," +
                              " cuando dos vacas están atadas al yugo, deben ir a la velocidad de la vaca más lenta. Describe cómo Bob puede conseguir que todas" +
                              "sus vacas crucen el puente en 34 minutos.");
            Console.WriteLine("\n\n\t\tResolviendo\n\n");
            totalTime = totalTime + mainBridge[1].time;
            Console.WriteLine("Primero cruzan Mazie y Daisy al final\t{0} minutos", totalTime);
            Console.ReadKey();
            finalBridge.Add(mainBridge[0]);//Agregamos a Mazie al puente final
            finalBridge.Add(mainBridge[1]);//Agregamos a Daisy al puente final
            mainBridge.RemoveRange(0, 2);//Removemos a Mazie y Daisy
            totalTime = totalTime + finalBridge[0].time;//Sumanos los tiempos Mazie y Daisy
            Console.WriteLine("\bDespues Mazie vuelve al principio\t{0} minutos", totalTime); //Imprimimos el tiempo
            Console.ReadKey();
            mainBridge.Insert(0, finalBridge[0]);//Agregamos a Mazie al puente principal a la primera posicion de la lista
            finalBridge.RemoveAt(0);//Removemos Mazie del puente final porque se devolvio
            finalBridge.Add(mainBridge[1]);//Agregamos a Crazy al puente final
            finalBridge.Add(mainBridge[2]);//Agregamos a Lazy al puente final
            mainBridge.RemoveRange(1, 2);//Removemos a Crazy y Lazy del puente principal
            totalTime = totalTime + finalBridge[2].time;//Sumamos los tiempos
            Console.WriteLine("\bAhora cruza Crazy y Lazy al final\t{0} minutos", totalTime);
            Console.ReadKey();
            mainBridge.Add(finalBridge[0]);//Agregamos a Daisy al inicio
            finalBridge.RemoveAt(0);//Removemos a Daisy del puente final porque se devuelve al principio
            totalTime = totalTime + mainBridge[1].time;//Sumamos el tiempo de Daisy
            Console.WriteLine("\bDaisy vuelve al principio\t\t{0} minutos", totalTime);//Imprimimos tiempos
            Console.ReadKey();
            finalBridge.Add(mainBridge[0]);
            finalBridge.Add(mainBridge[1]);
            mainBridge.Clear();
            totalTime = totalTime + finalBridge[3].time;
            Console.WriteLine("\bFinalmente cruzan Mazie y Daisy\t\t{0} minutos", totalTime);
        }
    }

    public
    class MainClass
    {
        public static void Main(string[] args)
        {
            Quizz pop = new Quizz();
            pop.Values();
            pop.MovingCows();
            Console.ReadKey();
        }
    }
}
