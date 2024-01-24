using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaCalculadora;
namespace Calculadora_Aritmetica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ingrese una operacion a realizar: ");
            string operacion = Console.ReadLine();
            Calculadora cls = new Calculadora();
            Console.WriteLine("Resultado: " + cls.Operar(operacion).ToString());
            Console.ReadKey();
            //string operacion = "9+3-5/9*3";
            //Calculadora cls = new Calculadora();
            //Console.WriteLine("Resultado: " + cls.Operar(operacion).ToString());
            //Console.ReadKey();
        }
    }
}
