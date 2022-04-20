using System;

namespace Questao1
{
    public class Vendedor
    {
        public bool Tabaco { get; set; } = false;
        public bool Papel { get; set; } = false;
        public bool Fosforo { get; set; } = false;

        public void LiberaProdutos()
        {
            var random = new Random();

            var valor = random.Next(3);

            Tabaco = false;
            Papel = false;
            Fosforo = false;

            switch (valor)
            {
                case 0:
                    Tabaco = true;
                    Papel = true;
                    break;
                case 1:
                    Papel = true;
                    Fosforo = true;
                    break;
                case 2:
                    Tabaco = true;
                    Fosforo = true;
                    break;
            }
        }
    }
}