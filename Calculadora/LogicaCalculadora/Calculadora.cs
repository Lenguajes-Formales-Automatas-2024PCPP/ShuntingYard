using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaCalculadora.DTO;
namespace LogicaCalculadora
{
    public class Calculadora
    {
        private Queue<string> Operadores = new Queue<string>();
        private Stack<string> Operandos = new Stack<string>();
        private Stack<decimal> Operaciones = new Stack<decimal>();
         Dictionary<string, int> Jerarquia = new Dictionary<string, int>() { { "-", 1 }, { "+", 2 }, { "*", 3 }, { "/", 4 } };
        public decimal Operar(string Operacion){
            foreach (char Caracter in Operacion)
            {
                int n;
                if (int.TryParse(Caracter.ToString(), out n))
                {
                    Operandos.Push(Caracter.ToString());
                }
                else
                {
                    if (Operadores.Count == 0 || Jerarquia[Operadores.Peek()] < Jerarquia[Caracter.ToString()])
                    {
                        Operadores.Enqueue(Caracter.ToString());
                    }
                    else
                    {
                        Operadores = new Queue<string>(Operadores.Reverse());
                        while (Operadores.Count > 0 && Jerarquia[Operadores.Peek()] >= Jerarquia[Caracter.ToString()])
                        {
                            Operandos.Push(Operadores.Dequeue());
                        }
                        Operadores = new Queue<string>(Operadores.Reverse());
                        Operadores.Enqueue(Caracter.ToString());

                    }
                }
            }
            while (Operadores.Count > 0)
            {
                Operandos.Push(Operadores.Dequeue());
            }
            string RPN = string.Join(";", Operandos.Reverse().ToArray());
            decimal n1 = 0;
            decimal n2 = 0;
            decimal result = 0;
            foreach (var item in RPN.Split(';'))
            {
                decimal n;
                if (decimal.TryParse(item.ToString(), out n))
                {
                    Operaciones.Push(n);
                }
                else {
                    n1 = Convert.ToDecimal(Operaciones.Pop());
                    n2 = Convert.ToDecimal(Operaciones.Pop());
                    if (item.ToString() == "+")
                    {
                        result = n2 + n1;
                    }
                    else if (item.ToString() == "-")
                    {
                        result = n2 - n1;
                    }
                    else if (item.ToString() == "*")
                    {
                        result = n2 * n1;
                    }
                    else if (item.ToString() == "/") {
                        if (n1 != 0)
                        {
                            result = n2 / n1;
                        }
                        else { throw new DivideByZeroException(); }
                    }
                    Operaciones.Push(result);
                }
            }
            return Operaciones.Pop();
        }
    }
}
