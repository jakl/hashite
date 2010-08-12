//This file is under the same license as Form_hashFunctions.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs276_bjt_11__2008_hashFunctions
{
    class Function_class
    {
        List<string> VarName = new List<string>(); // the names of the parameters of the function

        int lowLimit = 0; // the minimum of the function
        int highLimit = 0; // the maximum of the fuction

        List<Element> expression; // the expression of the function

        bool UseFunction = false; // if we can use the function

        string comment; // comment about the last operation


        public int Min { get { return lowLimit; } }
        public int Max { get { return highLimit; } }
        public string Comment { get { return comment; } } // tells weather the function was created successful or not

        /// <summary>
        /// Creating a function based on the users input and the names of the variables
        /// </summary>
        /// <param name="s"> users input string </param>
        /// <param name="var"> list of the names of variables </param>
        public Function_class(string s, List<string> var)
        {
            Reset(s, var);
        } // Function Constructor

        /// <summary>
        /// Creating a function with only one variable
        /// </summary>
        /// <param name="s"> users input string </param>
        /// <param name="var"> the name of the variable </param>
        public Function_class(string s, string var)
        {
            Reset(s, var);
        } // Function Constructor

        /// <summary>
        /// Resetting the function
        /// </summary>
        /// <param name="s"> user input string </param>
        /// <param name="var"> the name of the variable </param>
        public void Reset(string s, string var)
        {
            List<string> varNames = new List<string>();
            varNames.Add(var);
            Reset(s, varNames);
        }

        /// <summary>
        /// Resetting the function
        /// </summary>
        /// <param name="s"> user input string </param>
        /// <param name="var"> list of the names of the variables </param>
        public void Reset(string s, List<string> var)
        {
            if (var != null && s != null) // if the arguments exist
            {
                expression = Lexer.Lex(s); // Getting the expression made of tokens

                VarName.RemoveRange(0, VarName.Count); // Emptying the list
                foreach (string str in var) VarName.Add(str); // setting the names of the variables

                if (Parser.Parse(expression) != null)
                {
                    UseFunction = true; // The function can be used
                    comment = "Successful"; // The function was created successful
                }
                else
                {
                    UseFunction = false; // the function cannot be used
                    comment = "Error in the expression"; // ERROR!
                }
            }
            else
            {
                UseFunction = false; // The function cannot be used
                comment = "Null arguments!"; // ERROR!
            }
        } // Reset

        /// <summary>
        /// Evaluating the function
        /// </summary>
        /// <param name="x"> the value of the variable </param>
        /// <returns> real result </returns>
        public double GetValue(double x)
        {
            List<double> var = new List<double>();
            var.Add(x);
            return Evaluate(var);
        } // GetValue

        /// <summary>
        /// Evaluating the function
        /// </summary>
        /// <param name="x"> the values of the variables </param>
        /// <returns> real result </returns>
        public double GetValue(List<double> x)
        {
            return Evaluate(x);
        } // GetValue

        /// <summary>
        /// Evaluating the function
        /// </summary>
        /// <param name="x"> the value of the variable </param>
        /// <returns> int result </returns>
        public int GetIntValue(double x)
        {
            List<double> var = new List<double>();
            var.Add(x);
            return DoubleToInt(Evaluate(var));
        } // GetValue

        /// <summary>
        /// Evaluating the function
        /// </summary>
        /// <param name="x"> the values of the variables </param>
        /// <returns> int result </returns>
        public int GetIntValue(List<double> x)
        {
            return DoubleToInt(Evaluate(x));
        } // GetValue

        private int DoubleToInt(double d)
        {
            d = Math.Truncate(d);
            return (int)(d % int.MaxValue);
        } // DoubleToInt

        /// <summary>
        /// Evaluates the value of the function
        /// </summary>
        /// <param name="x"> list of values of the variables </param>
        /// <returns> the value of the function </returns>
        private double Evaluate(List<double> x)
        {
            if (UseFunction)
            {
                if (x != null) // if the list of values exists
                {
                    if (x.Count == VarName.Count)
                    {
                        // resetting the values of the variables
                        for (int i = 0; i < x.Count; i++)
                        {
                            Number e = new Number(x[i].ToString());
                            e.Name = VarName[0];
                            Variable.Add(e);
                        }
                        comment = "Successful";
                        return Parser.Parse(expression).Value;
                    }
                    else comment = "The amount of values doesn't match the function";
                }
                else comment = "The list of values is null!";
            }
            else comment = "The function was not created successful";
            return 0; // ERROR! Returning zero
        } // Evaluate

        /// <summary>
        /// Evaluating the hash code of the function
        /// </summary>
        /// <param name="d"> the value of the variable </param>
        /// <returns> the hash code value of the function </returns>
        public int GetHashCode(double d)
        {
            int result = (GetIntValue(d) - lowLimit) % (highLimit - lowLimit + 1);
            if (result < 0) result += highLimit - lowLimit + 1;
            result += lowLimit;
            return result;
        } // GetHashCode

        /// <summary>
        /// Evaluating the hash code of the function
        /// </summary>
        /// <param name="x"> the values of the variables </param>
        /// <returns> the hash code of the function </returns>
        public int GetHashCode(List<double> x)
        {
            int result = (GetIntValue(x) - lowLimit) % (highLimit - lowLimit + 1);
            if (result < 0) result += highLimit - lowLimit;
            result += lowLimit;
            return result;
        } // GetHashCode

        public void SetLimits(int min, int max)
        {
            lowLimit = min;
            highLimit = max;
        }

    } // FUNCTION
}
