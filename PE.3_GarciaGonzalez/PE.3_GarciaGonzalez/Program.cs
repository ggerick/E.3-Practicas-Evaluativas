using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PE._GarciaGonzalez
{
   public class Tarea
    {
        public int id = 0;
        public string nombre = "";
        public string descripcion = "";
        public string fechaInicio = "";
        public string fechaFin = "";
        public string status = "";

    }

    public class Operaciones
    {
       
        List<Tarea> tareasGlobal = new List<Tarea>();//Declaracion de listas de objetos
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasProceso = new List<Tarea>();
        List<Tarea> tareasTerminadas = new List<Tarea>();
        public void AgregarTareas()
        {
            Console.WriteLine("\t\tAgrega tareas\n\n");
            Tarea tarea;
            char opc = ' ';
            int contador = 0;
           
            do//Entrada de datos pura y dura
            {

                tarea = new Tarea();//Instanciamos un nuevo ojbeto 'tarea'
                tarea.id = contador + 1;
                Console.Write("\nNombre de la tarea: ");
                tarea.nombre = Console.ReadLine();
                Console.Write("Agregar una descripcion para la tarea: ");
                tarea.descripcion = Console.ReadLine();
                Console.Write("Fecha de inicio(dd/MM/yy): ");
                tarea.fechaInicio = Console.ReadLine();
                Console.Write("Fecha esperada para terminar(dd/MM/yy): ");
                tarea.fechaFin = Console.ReadLine();
                tarea.status = "pendiente";
                tareasGlobal.Add(tarea);
                tareasPendientes.Add(tarea);//y con sus propeidades llenadas, lo mandamos a la lista correspondiente
                Console.Write("\n\nDesea agregar otra tarea? No<S> \tSi<Cualquier otra tecla>");
                opc = Console.ReadKey().KeyChar;
                contador++; 

            } while (opc != 's');//Para decidir cuantas tareas se van a añadir

            Menu();//Llama al menu para realizar otra accion

        }

        public void VerTareas()
        {
            Console.Clear();
            Console.WriteLine("\t\tLista tareas: ");
            int opc = 0;
            char salida = ' ';
            do
            {
                Console.Clear();
                Console.WriteLine("Que tareas deseas ver");//Un menú donde puede ver el contenido de las 3 listas
                Console.WriteLine("1.- Tienes  " + tareasPendientes.Count + " tareas pendientes");
                Console.WriteLine("2.- Tienes  " + tareasProceso.Count + " tareas en proceso");
                Console.WriteLine("3.- Tienes  " + tareasTerminadas.Count + " tareas terminadas");
                opc = int.Parse(Console.ReadLine());
                switch(opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\t\tTareas pendientes");
                        foreach (var item in tareasPendientes)//Un simple despliegue de los elementos de la lista seleccionada
                        {
                            Console.WriteLine(item.id);
                            Console.WriteLine(item.nombre);
                            Console.WriteLine(item.descripcion);
                            Console.WriteLine(item.fechaInicio);
                            Console.WriteLine(item.fechaFin);
                            Console.WriteLine(item.status);
                        }

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("\t\tTareas en proceso");//Un simple despliegue de los elementos de la lista seleccionada
                        foreach (var item in tareasProceso)
                        {
                            Console.WriteLine(item.id);
                            Console.WriteLine(item.nombre);
                            Console.WriteLine(item.descripcion);
                            Console.WriteLine(item.fechaInicio);
                            Console.WriteLine(item.fechaFin);
                            Console.WriteLine(item.status);
                        }

                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("\t\tTareas terminadas");//Un simple despliegue de los elementos de la lista seleccionada
                        foreach (var item in tareasTerminadas)
                        {
                            Console.WriteLine(item.id);
                            Console.WriteLine(item.nombre);
                            Console.WriteLine(item.descripcion);
                            Console.WriteLine(item.fechaInicio);
                            Console.WriteLine(item.fechaFin);
                            Console.WriteLine(item.status);
                        }

                        break;

                  

                }

                Console.Write("\nPara salir, presiona otra tecla que no sea s");
                salida = Console.ReadKey().KeyChar;

                
            } while (salida == 's');//Sale del menu de VerTareas

            Menu();
        }

        public void MoverTareas()//Aqui es donde comienza la magia - Un metodo para mover las tareas de una lista a otra
        {
            Console.WriteLine("\n\t\tAqui podras cambiar el estado de tus tareas (proceso/terminadas)");

            int opc = 0;
            string move = " ";
            char opcion = ' ';
            do
            {

                Console.Write("Elige una opcion: ");// Se elige de qué lista a qué otra lista se va a mover la tarea
                Console.WriteLine("\n" +
                                  "1.- Tareas Pendientes => Tareas en proceso");
                Console.WriteLine("2.- Tareas en proceso => Tareas terminadas");
                Console.WriteLine("3.- Tareas terminadas => Tareas en proceso");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Write("Escriba el nombre de la tarea que quiera mover de la lista pendientes: ");
                        move = Console.ReadLine();//Preguntamos y almacenamos el nombre de la tarea en la variable 'move'
                        var movible = tareasPendientes.Where(x => x.nombre == move);//Creamos una variable tipo var, que va a guardar el objeto cuando encuentre un valor igual a move en la lista.nombre
                        tareasProceso.AddRange(movible);//Agregamos el objeto a la lista tareaProceso
                        int index = tareasPendientes.FindIndex(a => a.nombre == move);//Aqui hacemos una busca del mismo nombre pero en vez de alcamenar el objeto, almacenará la posición de éste
                        tareasPendientes.RemoveAt(index);//Y una vez encontrado, lo va a eliminar de la lista de donde se movió

                        tareasProceso[index].status = "En proceso";//Le cambiamos el status a la tarea porque se cambio de lista
                        break;

                    case 2:
                        Console.Write("Escriba el nombre de la tarea que quiera mover de la lista proceso: ");
                        move = Console.ReadLine();
                        var movible2 = tareasProceso.Where(x => x.nombre == move);
                        tareasTerminadas.AddRange(movible2);
                        int index2 = tareasProceso.FindIndex(a => a.nombre == move);
                        tareasProceso.RemoveAt(index2);
                        tareasTerminadas[index2].status = "Terminada"; 
                        break;

                    case 3:
                        Console.Write("Escriba el nombre de la tarea que quiera mover de la lista terminada a proceso: ");
                        move = Console.ReadLine();
                        var movible3 = tareasTerminadas.Where(x => x.nombre == move);
                        tareasProceso.AddRange(movible3);
                        int index3 = tareasTerminadas.FindIndex(a => a.nombre == move);
                        tareasTerminadas.RemoveAt(index3);
                        tareasTerminadas[index3].status = "En proceso";
                        break;




                }
                Console.Write("Si deseas seguir moviendo tareas, pulsa n. De lo contrario pulsa otra tecla ");
               opcion = Console.ReadKey().KeyChar;
            } while (opcion == 'n');
            Menu();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t\tMenu de tareas");
            Console.WriteLine("1.- Agregar tareas");
            Console.WriteLine("2.- Visualizar las tareas");
            Console.WriteLine("3.- Marcar tareas como terminaras/en proceso de");
            Console.WriteLine("4.- Salir del programa");
            int opc = int.Parse(Console.ReadLine());


            switch(opc)
            {
                case 1:
                    AgregarTareas();
                    break;

                case 2:
                    VerTareas();
                    break;

                case 3:
                    MoverTareas();
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Opcion invalida, vuelve a intentarlo");
                    break;



            }
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Operaciones ops = new Operaciones();
            ops.Menu();
            Console.ReadKey();

           
           
           
        }
    }
}
