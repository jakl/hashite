using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function
{
    class Parser
    {
        /// <summary>
        /// Parses the input to a number element
        /// </summary>
        /// <param name="listE"> stream of tokens </param>
        /// <returns> number element </returns>
        public static Number Parse(List<Element> listE)
        {
            if (listE != null)
            {
                if (listE.Count > 0)
                {
                    while(DeclareVariable(listE));
                    return ParseComplicatedInput(listE);
                }
            }
            return null;
        } // Parse

        /// <summary>
        /// Declares a variable if there is a declaration and deletes unnessesary stuff
        /// </summary>
        /// <param name="listE"> stream of tokens </param>
        /// <returns> true if we need to launch the function again </returns>
        public static bool DeclareVariable(List<Element> listE)
        {
            if (listE.Count > 2) // it can be a declaration only if the list has more than 2 elements
            {
                if (listE[0].Type == C.Number && listE[1].Type == C.Control) // if it is a number
                {
                    string name = listE[0].GetNumber().Name;
                    if (name != "" && listE[1].ToString() == "=") // if it is a variable
                    {
                        listE.RemoveRange(0, 2);
                        Number num = new Number(Parse(listE).Value.ToString());
                        num.Name = name;
                        Variable.Add(num);

                        return false;
                    }
                }
            }

            int index = listE.FindIndex(delegate(Element e)
                                        { if (e.ToString() == "=") return true; return false; });
            if (index != -1) { listE.RemoveRange(0, index + 1); return true; }


            return false;
        } // DeclareVariable
        
        /// <summary>
        /// Parses the input (containing brackets) to a number
        /// </summary>
        /// <param name="listE"> stream of tokens </param>
        /// <returns> number element </returns>
        private static Number ParseComplicatedInput(List<Element> listE)
        {
            // Checking the brackets
            int nb = 0; // number of opened brackets

            foreach (Element e in listE)
                if (e.ToString() == "(") nb++;
                else if (e.ToString() == ")") if (--nb < 0) return null; // if we close not opened bracket
            if (nb != 0) return null; // if there is not equal amount of openning and closing brackets


            // Performing Parsing

            List<int> listP = new List<int>(); // List of indexes of openning brackets in the list of elements

            // Building the list
            foreach (Element e in listE)
                if (e.Type == C.Control)
                    if (e.GetControl().ToString() == "(") listP.Add(listE.IndexOf(e));

            // Evaluating expressions in every bracket
            for (int i = listP.Count - 1; i > -1; i--)
            {
                int left = listP[i]; // index of the openning bracket
                int right = -1; // index of the closing bracket

                // getting the index of the closing bracket
                for (int j = listP[i] + 1; j < listE.Count; j++)
                    if (listE[j].Type == C.Control)
                        if (listE[j].GetControl().ToString() == ")") { right = j; break; }

                List<Element> BracketInput = new List<Element>(); // Expression in the brackets

                for (int k = left + 1; k < right; k++) BracketInput.Add(listE[k]); // Getting the expression

                Number result = ParseSimpleInput(BracketInput); // Simplified expression

                listE.RemoveRange(left, right - left + 1); // Removing calculated

                listE.Insert(left, result); // Inserting the result
            }

            return ParseSimpleInput(listE);
        } // ParseComplicatedInput

        /// <summary>
        /// Parses a simple input stream to a number element
        /// </summary>
        /// <param name="listE"> stream of tokens </param>
        /// <returns> number element </returns>
        private static Number ParseSimpleInput(List<Element> listE)
        {
            listE = FormatInput(listE); // Formatting the input

            if (listE.Count > 0) // if there is something to parse
            {
                // finding all the operations and all the functions in the input
                List<Operation> listO = new List<Operation>();
                List<FunctionElement> listF = new List<FunctionElement>();

                foreach (Element e in listE)
                {
                    if (e.Type == C.Operation) listO.Add(e.GetOperation());
                    if (e.Type == C.Function) listF.Add(e.GetFunction());
                }

                // performing function calculation
                for (int i = listF.Count - 1; i >= 0; i--)
                    listE = Simplify(listE, listE.IndexOf(listF[i]));

                // performing the highest level operation
                for (int i = 0; i < listO.Count; i++)
                    if (listO[i].Rank == 3) listE = Simplify(listE, listE.IndexOf(listO[i]));

                // performing middle level operation
                for (int i = 0; i < listO.Count; i++)
                    if (listO[i].Rank == 2) listE = Simplify(listE, listE.IndexOf(listO[i]));

                // performing the lowes operation
                for (int i = 0; i < listO.Count; i++)
                    if (listO[i].Rank == 1) listE = Simplify(listE, listE.IndexOf(listO[i]));

                if (listE.Count == 1) return listE[0].GetNumber(); // if everything went successful return the result
                else return null; // failed
            }

            return new Number("0"); 
        } // ParseSimpleInput

        /// <summary>
        /// Performing operation or function under indicated index
        /// </summary>
        /// <param name="listE"> list of token elements </param>
        /// <param name="index"> index of the element </param>
        /// <returns> simplified input </returns>
        private static List<Element> Simplify(List<Element> listE, int index)
        {
            if (listE[index].Type == C.Operation) // if it is an operation
            {
                if (index > 0 && index < listE.Count - 1) // if we can perform the operation
                {
                    if (listE[index - 1].GetNumber() != null &&
                        listE[index + 1].GetNumber() != null)
                    {
                        // Creating a new element
                        Number n = new OperationExpression(listE[index - 1].GetNumber(),
                                                           listE[index].GetOperation(),
                                                           listE[index + 1].GetNumber());
                        // Replacing the elements
                        listE.Insert(index - 1, n);
                        listE.RemoveRange(index, 3);
                    }
                }
            }
            else // if it is a function
            {
                if (index < listE.Count - 1) // if we can perorm the function
                {
                    if (listE[index + 1].GetNumber() != null)
                    {
                        // Creating a new element
                        Number n = new FunctionExpression(listE[index].GetFunction(), listE[index + 1].GetNumber());
                        // Replacing the elements
                        listE.Insert(index, n);
                        listE.RemoveRange(index + 1, 2);
                    }
                }
            }

            return listE;
        } // Simplify
        
        /// <summary>
        /// Formatting the input the way we can easily parse it
        /// </summary>
        /// <param name="listE"> stream of tokens </param>
        /// <returns> formatted stream of tokens </returns>
        private static List<Element> FormatInput(List<Element> listE)
        {
            if (listE != null) // if list exists
            {
                if (listE.Count > 0) // if list is not empty
                {
                    bool bCombine = false; // If we are supposed to combine the operations

                    // adding zeros and combining plus and minus signs
                    for (int i = 0; i < listE.Count; i++)
                        if (listE[i].Type == C.Operation)
                        {
                            Operation o = listE[i].GetOperation();
                            if (o.Rank == 1)
                            {
                                if (i == 0) listE.Insert(i++, new Number("0"));
                                if (bCombine)
                                {
                                    if (listE[i - 1].GetOperation().ToString() == "+") listE.RemoveAt(i-- - 1); // if the previous was plus
                                    else // if the previous operation was a minus
                                        if (o.ToString() == "+") listE.RemoveAt(i--); // Remove plus
                                        else
                                        {
                                            listE.RemoveRange(i-- - 1, 2);
                                            listE.Insert(i, new Operation("+"));
                                        }
                                }
                                bCombine = true; // Combine if the next element is a low priority operation
                            }
                        }
                        else bCombine = false; // Do not combine if the next element is a low priority operation

                    return listE; // return the result
                }
            }

            List<Element> zero = new List<Element>();
            zero.Add(new Number("0"));
            return zero;
        } // FormatInput
    } // PARSER
}
