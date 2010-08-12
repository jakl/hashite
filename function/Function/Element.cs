using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function
{
    class Element
    {
        protected string sValue = "";
        protected int iType = 0;

        public int Type { get { return iType; } } // To be able to check the type

        public Element() { }

        /// <summary>
        /// Creating an element based on a string
        /// </summary>
        /// <param name="s"> token string </param>
        public Element(string s)
        {
            sValue = s;
            iType = C.Unknown; // Unknown element if it is null or an empty string

            if (s != null)
            {
                if (s.Length == 1)
                {
                    for (int i = 0; i < C.Operations.Length; i++) // Checking operations
                        if (s[0] == C.Operations[i]) { iType = C.Operation; break; }

                    for (int i = 0; i < C.Controls.Length; i++) // Checking controls
                        if (s[0] == C.Controls[i]) { iType = C.Control; break; }
                }

                // if the type hasn't been identified yet it is a number
                if (iType == C.Unknown && s != "") iType = C.Number;

                for (int i = 0; i < C.StandardFunctions.Length; i++) // Checking standard functions
                    if (s == C.StandardFunctions[i]) { iType = C.Function; break; }
            }
        } // Element constructor

        public override string ToString()
        {
            return sValue;
        }

        public string ToTokenString()
        {
            string s = "";

            switch (iType)
            {
                case C.Number: s += "NUMBER "; break;
                case C.Operation: s += "OPERATION "; break;
                case C.Function: s += "FUNCTION "; break;
                case C.Control: s += "CONTROL "; break;
                default: s += "UNKNOWN "; break;
            }

            return s + sValue;
        } // ToTokenString

        public virtual Operation GetOperation() { return null; }
        public virtual FunctionElement GetFunction() { return null; }
        public virtual Number GetNumber() { return null; }
        public virtual Control GetControl() { return null; }
    } // ELEMENT

    class Operation : Element
    {
        int iRank = -1; // effects the order of execution

        public int Rank { get { return iRank; } } // The priority of the operation

        /// <summary>
        /// Creating an operation element based on a string
        /// </summary>
        /// <param name="s"> token string </param>
        public Operation(string s)
        {
            iType = C.Operation;

            switch (s)
            {
                case "+": iRank = 1; break;
                case "-": iRank = 1; break;
                case "*": iRank = 2; break;
                case "/": iRank = 2; break;
                case "%": iRank = 2; break;
                case "^": iRank = 3; break;
            }

            sValue = s;
        } // Operation constructor

        /// <summary>
        /// Creating an operation based on an existing element
        /// </summary>
        /// <param name="e"> existing element </param>
        public Operation(Element e)
        {
            iType = C.Operation;

            sValue = e.ToString();

            switch (sValue)
            {
                case "+": iRank = 1; break;
                case "-": iRank = 1; break;
                case "*": iRank = 2; break;
                case "/": iRank = 2; break;
                case "%": iRank = 2; break;
                case "^": iRank = 3; break;
            }
        } // Operation constructor

        /// <summary>
        /// Performing operation on two numbers
        /// </summary>
        /// <param name="A"> Left Operand </param>
        /// <param name="B"> Right Operand </param>
        /// <returns> Result of the operation </returns>
        public double Calculate(Number A, Number B)
        {
            switch (sValue)
            {
                case "+": return A.Value + B.Value; // summation
                case "-": return A.Value - B.Value; // subtraction
                case "*": return A.Value * B.Value; // multiplication
                case "/": return A.Value / B.Value; // division
                case "^": return Math.Pow(A.Value, B.Value); // raising to power
                default: return 0; // otherwise
            }
        } // Calculate

        public override Operation GetOperation() { return this; }

    } // OPERATION

    class Control : Element
    {
        /// <summary>
        /// Creating a control element based on a string
        /// </summary>
        /// <param name="s"> token string </param>
        public Control(string s)
        {
            iType = C.Control;
            sValue = s;
        } // Control constructor

        /// <summary>
        /// Creating a control element based on an existing element
        /// </summary>
        /// <param name="e"> existing element </param>
        public Control(Element e)
        {
            iType = C.Control;
            sValue = e.ToString();
        } // Control constructor

        public override Control GetControl() { return this; }
    } // CONTROL

    class Number : Element
    {
        protected double dValue = 0; // The value of the number
        protected string sName = ""; // The name of the variable

        public double Value { get { Evaluate(); return dValue; } } // The double value of the number
        public string Name { get { return sName; } set { sName = value; } } // The name of the number

        public Number() { }

        /// <summary>
        /// creating a number based on a string
        /// </summary>
        /// <param name="s"> token string </param>
        public Number(string s)
        {
            iType = C.Number;
            sValue = s;

            try // Checking if it is supposed to be a variable
            {
                dValue = double.Parse(sValue);
            }
            catch
            {
                sName = sValue;

                // creating a new variable if it doesn't exist yet
                Number n = Variable.CheckName(sName);
                if (n == null)
                {
                    Number num = new Number("0");
                    num.Name = sName;
                    Variable.Add(num);
                }
            }            
        } // Number constructor

        /// <summary>
        /// creating a number based on an existing element
        /// </summary>
        /// <param name="e"> existing element </param>
        public Number(Element e)
        {
            iType = C.Number;
            sValue = e.ToString();

            try // Checking if it is supposed to be a variable
            {
                dValue = double.Parse(sValue);
            }
            catch
            {
                sName = sValue;

                // creating a new variable if it doesn't exist yet
                Number n = Variable.CheckName(sName);
                if (n == null)
                {
                    Number num = new Number("0");
                    num.Name = sName;
                    Variable.Add(num);
                }
            }         
        } // Number constructor

        /// <summary>
        /// Updating the value of the number
        /// </summary>
        protected virtual void Evaluate()
        {
            if (sName != "") // Check if it is a variable
            {
                Number n = Variable.CheckName(sName);
                if (n != null)
                {
                    sValue = n.ToString();
                    dValue = double.Parse(sValue); // Parsing to avoid stack overflow
                }
            }
        } // Evaluate

        public override Number GetNumber() { return this; }

    } // NUMBER

    class FunctionElement : Element
    {
        /// <summary>
        /// Creating a function element based on a string
        /// </summary>
        /// <param name="s"> token string </param>
        public FunctionElement(string s)
        {
            iType = C.Function;
            sValue = s;
        } // FunctionElement constructor

        /// <summary>
        /// Creating a function element based on an existing element
        /// </summary>
        /// <param name="e"> existing element </param>
        public FunctionElement(Element e)
        {
            iType = C.Function;
            sValue = e.ToString();
        } // FunctionElement constructor

        public double Calculate(Number n)
        {
            switch (sValue)
            {
                case "f": return n.Value + 1;
                case "Cos": return Math.Cos(n.Value);
                case "Sin": return Math.Sin(n.Value);
                case "Ln": return Math.Log(n.Value);
                case "Tan": return Math.Tan(n.Value);
                case "SQRT": return Math.Sqrt(n.Value);
                default: return 0;
            }
        } // Calculate

        public override FunctionElement GetFunction() { return this; }
    } // FUNCTION

    class OperationExpression : Number
    {
        Number A; // Left Operand
        Number B; // Right Operand
        Operation O; // Operation

        public OperationExpression(Number a, Operation o, Number b)
        {
            A = a; O = o; B = b;
        } // OperationExpression constructor

        protected override void Evaluate()
        {
            if (A != null && B != null && O != null)
            {
                dValue = O.Calculate(A, B);
                sValue = dValue.ToString();
            }
        }
    } // OPERATION_EXPRESSION

    class FunctionExpression : Number
    {
        FunctionElement F; // Function
        Number N; // Argument

        public FunctionExpression(FunctionElement f, Number n)
        {
            F = f; N = n;
        } // FunctionExpression constructor

        protected override void Evaluate()
        {
            if (F != null && N != null) dValue = F.Calculate(N);
        }
    } // FUNCTION_EXPRESSION
}
