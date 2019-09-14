using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Private Method
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
                return operador;
            else
                return "+";
        }
        #endregion

        #region Methods
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado= num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }

            return resultado;
        }
        #endregion
    }


}
