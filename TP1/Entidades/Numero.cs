using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Props
        private double numero;
        #endregion

        #region Constructors
        public Numero ()
        {
            this.numero = 0;
        }

        public Numero(double dblNum)
        {
            this.numero = dblNum;
        }

        public Numero(string strNum)
        {
            SetNumero(strNum);
        }
        #endregion

        #region Private Methods
        private double ValidarNumero(string strNumero)
        {
            if(double.TryParse(strNumero,out double dblNumero))
                return dblNumero;
            else
                return 0;
        }
        #endregion

        #region Conversion Methods
        public static string DecimalBinario(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return DecimalBinario(numero);
            }
            else
            {
                return "Valor Invalido";
            }
        }
        public static string DecimalBinario(double numero)
        {
            string cadena = "";
            numero = Math.Truncate(Math.Abs(numero));
            if (numero >= 0)
            {

                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                }
                return cadena;
            }
            return "Valor Invalido";
        }
       
        public static string BinarioDecimal(string strNumero)
        {
            double acumulador = 0;
            string bin;
            int i;

            if (strNumero != "")
            {
                bin = strNumero.Replace(" ", "");
                for (i = 0; i < bin.Length; i++)
                {
                    if (bin[i] != '1' && bin[i] != '0')
                    {
                        break;
                    }
                }

                if (i == bin.Length)
                {
                    for (int j = bin.Length - 1, exp = 0; j >= 0; j--, exp++)
                    {
                        if (bin[j] == '1')
                        {
                            acumulador += Math.Pow(2, exp);
                        }
                    }

                    return acumulador.ToString();
                }
            }
            return "Valor Invalido";
        }
        #endregion

        #region Set
        public void SetNumero(string stringNumero)
        {
            this.numero = ValidarNumero(stringNumero);
        }
        #endregion

        #region Operator Overloads
        public static double operator - (Numero n1,Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        #endregion
    }
}
