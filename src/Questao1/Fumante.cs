using System;
using System.Threading;

namespace Questao1
{
    public class Fumante
    {
        private readonly string _name;
        private readonly Semaphore _semaforo;
        private readonly Vendedor _vendedor;

        public bool Tabaco { get; set; } = false;
        public bool Papel { get; set; } = false;
        public bool Fosforo { get; set; } = false;

        public Fumante(Semaphore semaphore, Vendedor vendedor, string name)
        {
            _semaforo = semaphore;
            _vendedor = vendedor;
            _name = name;
        }

        public void Start()
        {
            var verificador = true;

            var random = new Random();

            while (verificador)
            {
                if (_vendedor.Fosforo == false && Fosforo == true ||
                    _vendedor.Papel == false && Papel == true ||
                    _vendedor.Tabaco == false && Tabaco == true)
                {
                    _semaforo.WaitOne();

                    Console.WriteLine($"{_name} está fumando");

                    Thread.Sleep(3000);

                    Console.WriteLine($"{_name} acabou de fumar");

                    _semaforo.Release();

                    verificador = false;
                }
                else
                {
                    Thread.Sleep(3000);
                    _vendedor.LiberaProdutos();
                }
            }
        }
    }
}