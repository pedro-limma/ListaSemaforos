using System;
using System.Threading;

namespace Questao1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tabacaria");

            Semaphore semaphore = new Semaphore(1, 1);

            Vendedor vendedor = new Vendedor();
            vendedor.LiberaProdutos();

            Fumante Junior = new Fumante(semaphore, vendedor, "Junior");
            Junior.Tabaco = true;

            Fumante Bernardo = new Fumante(semaphore, vendedor, "Bernardo");
            Bernardo.Fosforo = true;
            
            Fumante Caio = new Fumante(semaphore, vendedor, "Caio");
            Caio.Fosforo = true;


            Thread t1 = new Thread(() => Junior.Start());
            Thread t2 = new Thread(() => Bernardo.Start());
            Thread t3 = new Thread(() => Caio.Start());


            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

        }
    }
}
