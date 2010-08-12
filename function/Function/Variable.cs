using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function
{
    class Variable
    {
        static List<Number> Var = new List<Number>(); // list of variables

        /// <summary>
        /// Checking if the variable is assigned
        /// </summary>
        /// <param name="name"> Variable ID </param>
        /// <returns> Number </returns>
        public static Number CheckName(string name)
        {
            return Var.Find(delegate(Number n) { if (n.Name == name) return true; return false; });
        } // CheckName

        /// <summary>
        /// Adding or replacing a variable number in the list
        /// </summary>
        /// <param name="e"> name of the variable </param>
        public static void Add(Number n)
        {
            Number buf = Var.Find(delegate(Number num) { if (num.Name == n.Name) return true; return false; });
            if (buf != null) Var.Remove(buf);
            Var.Add(n);
        } // Add
    } // VARIABLE

    class C
    {
        public const int Unknown = 0;
        public const int Number = 1;
        public const int Operation = 2;
        public const int Function = 3;
        public const int Control = 4;

        public static char[] Operations = new char[] { '+', '-', '*', '/', '%', '^' };
        public static char[] Controls = new char[] { '(', ')', '=' };
        public static string[] StandardFunctions = new string[] { "f", "Cos", "Sin", "Ln", "Tan", "SQRT" };

        public static char[] Delims = new char[] { '+', '-', '*', '/', '%', '^', '(', ')', ' ', '=' };

    } // CONSTANTS
}
