//This file is under the same license as Form_hashFunctions.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace cs276_bjt_11__2008_hashFunctions
{
    /// <summary>
    /// Facade - coordinates between view and the critical
    /// classes for plotting and evaluating the hash function
    /// </summary>
    class InOutHandler
    {
        /// <summary>
        /// We need a plotter to plot our graph
        /// </summary>
        private Plotter m_plotGraphBuilder;

        /// <summary>
        /// We need a FunctionInterpreter to make
        /// something useful out of the funciton string
        /// </summary>
        private Function_class m_funcHashFunction = null;

        /// <summary>
        /// we need a FunctionInterpreter to make
        /// something useful out of the function string
        /// </summary>
        private Function_class m_funcInputFunction = null;

        /// <summary>
        /// Keep track of the current value for input
        /// </summary>
        private int m_iDomainCount = 0;

        /// <summary>
        /// Allow client access to useful information
        /// Minimum number of collisions, for any hash
        /// </summary>
        public int Minimum
        {
            get { return m_plotGraphBuilder.Minimum; }
        }

        /// <summary>
        /// Allow client access to useful information
        /// Maximum number of collisions, for any hash
        /// </summary>
        public int Maximum
        {
            get { return m_plotGraphBuilder.Maximum; }
        }

        /// <summary>
        /// Allow client access to useful information
        /// Hash output value with the least collisions
        /// </summary>
        public int MinimumIndex
        {
            get { return m_plotGraphBuilder.MinimumHash; }
        }

        /// <summary>
        /// Allow client access to useful information
        /// Hash output value with the most collisions
        /// </summary>
        public int MaximumIndex
        {
            get { return m_plotGraphBuilder.MaximumHash; }
        }

        public int PointDiameter
        {
            set { m_plotGraphBuilder.PointDiameter = value; }
        }


        /// <summary>
        /// Constructor, we want parameters, don't let anyone use this one
        /// </summary>
        private InOutHandler()
        {
        }//InOutHandler

        /// <summary>
        /// Initialize instances of the objects we need to work with
        /// </summary>
        /// <param name="pbInGraphicsArea">we need to access the picture box to plot to</param>
        public InOutHandler(Graphics gGraph, int iInRangeMin, int iInRangeMax)
        {
            //m_fiHashFunction = new FunctionInterpreter();

            m_plotGraphBuilder = new Plotter(gGraph);//send a graphic object for our picture box
        }//InOutHandler(PictureBox)

        /// <summary>
        /// We get information on a new function, m_plotGraphBuilder and m_fiHashFunction
        /// need the information so that they can do their jobs
        /// Pre: the min and max values are valid
        /// </summary>
        /// <param name="strInFunc">new hash function as a string</param>
        /// <param name="iInRangeMin">minimum value that is output by the function</param>
        /// <param name="iInRangeMax">maximum value that is output by the function</param>
        public void UpdateHash(string strInFunc, int iInRangeMin, int iInRangeMax)
        {
            //call FunctionInterpreter to give it information on our new hash fuction
            try
            {
                m_funcHashFunction = new Function_class(strInFunc, "x");
            }//try
            catch (Exception eA)
            {
                //something went wrong, tell the user
                //the next call is code mostly reused from Tom Fuller's tutorial programs
                string strMsg = String.Format("UpdateFunction failed.\n\nUse of ''{0}failed: '{1}'",
                    strInFunc, eA.ToString());

                MessageBox.Show(strMsg, "cs276_bjt_11-2-2008_hashFunctions - InOutHandler - FunctionInterpreter.UpdateFunction();",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                m_funcHashFunction = null;
                throw new InvalidOperationException("Could not create the function.");
            }//catch

            //check to see if the function was successfully created
            if (m_funcHashFunction.Comment != "Successful")
            {
                m_funcHashFunction = null;
                throw new ArgumentOutOfRangeException("Could not parse the function.");
            }//if

            //check to be sure we have an input funciton to work with
            if (m_funcInputFunction == null)
            {
                throw new ArgumentOutOfRangeException("No input function has been created!");
            }

            //set min and max for function
            m_funcHashFunction.SetLimits(iInRangeMin, iInRangeMax);
            
            //so that we can keep track of how many times we send a new X input
            m_iDomainCount = 0;

            //give m_plotGraphBuilder the range so it can set up for plotting
            //this should not fail, if it does there is an error in some other class
            m_plotGraphBuilder.Reset(iInRangeMin, iInRangeMax);
        }//UpdateHash(string, int, int)

        public void UpdateInputFunc(string strInFunc)
        {
            //call FunctionInterpreter to give it information on our new hash fuction
            try
            {
                m_funcInputFunction = new Function_class(strInFunc, "x");
            }//try
            catch (Exception eA)
            {
                //something went wrong, tell the user
                //the next call is code mostly reused from Tom Fuller's tutorial programs
                string strMsg = String.Format("Update Input Function failed.\n\nUse of ''{0}failed: '{1}'",
                    strInFunc, eA.ToString());

                MessageBox.Show(strMsg, "cs276_bjt_11-2-2008_hashFunctions - InOutHandler - FunctionInterpreter();",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                m_funcInputFunction = null;
                throw new InvalidOperationException("Could not create new input function"); //throw new might be useful here...
            }//catch

            //check to see if the function was successfully created
            if (m_funcInputFunction.Comment != "Successful")
            {
                m_funcInputFunction = null;
                throw new ArgumentOutOfRangeException("Could not parse the function.");
            }//if

            //set min and max for function
            m_funcInputFunction.SetLimits(0, 2000000);

            //set things graph wise? set things domain wise? set domain counter?...
        }

        /// <summary>
        /// Get our current graph displayed to the PictureBox Graphics
        /// </summary>
        public void Plot()
        {
            m_plotGraphBuilder.Plot();//Re-draw graph
        }

        /// <summary>
        /// Method Description: IncrementMultipleHashes(int)
        /// Evaluates hashes for a defined number of values
        /// </summary>
        /// <param name="iNum"></param>
        public void IncrementMultipleHashes(int iNum)
        {
            int iTempResult;

            //we are not dealing with extremenly large numbers, sorry.
            if (m_iDomainCount == int.MaxValue)
            {
                m_iDomainCount = 0;
            }//if

            for (int i = 0; i < iNum; i++)
            {
                //get the next output from our hash funtction
                iTempResult = m_funcHashFunction.GetHashCode(m_funcInputFunction.GetValue(m_iDomainCount++));
                //send this collision to our plotter
                m_plotGraphBuilder.IncrementHash(iTempResult);
            }//for
        }

        /// <summary>
        /// Gives the amount of collisions for a coordinate on the graph
        /// </summary>
        /// <param name="iPxl">pixel where for which we want the coordinate</param>
        /// <returns>value as requested</returns>
        public int GetCollision(int iPxl)
        {
            return m_plotGraphBuilder.GetCollision(iPxl);
        }

        /// <summary>
        /// Gives the hash for a coordinate on the graph
        /// </summary>
        /// <param name="iPxl">pixel where for which we want the coordinate</param>
        /// <returns>value as requested</returns>
        public int GetHash(int iPxl)
        {
            return m_plotGraphBuilder.GetHash(iPxl);
        }

        /// <summary>
        /// We want our graph to be a different size!
        /// </summary>
        /// <param name="g">the new Draw Area</param>
        /// <returns>if it went well, return true</returns>
        public bool ResizeGraphics(Graphics g)
        {
            m_plotGraphBuilder.UpdateArea(g);
            return true;//everything worked
        }

        /// <summary>
        /// Get a closup view of the graph or Get a complete view of the graph
        /// </summary>
        public void SwitchZoom()
        {
            m_plotGraphBuilder.SwitchZoom();
        }

        /// <summary>
        /// Change between showing and not showing points on the graph and visa versa
        /// </summary>
        public void SwitchPoints()
        {
            m_plotGraphBuilder.SwitchPoints();
        }

        /// <summary>
        /// Change between showing and not showing lines on the graph and visa versa
        /// </summary>
        public void SwitchLines()
        {
            m_plotGraphBuilder.SwitchLines();
        }

        /// <summary>
        /// Changes the line color on the graph
        /// Pre: pLineColor has been assigned
        /// </summary>
        /// <param name="pLineColor"></param>
        public void ChangeLineColor(Pen pLineColor)
        {
            m_plotGraphBuilder.ChangeLineColor(pLineColor);
        }

        /// <summary>
        /// Changes the point color on the graph
        /// Pre: pPointColor has been assigned
        /// </summary>
        /// <param name="pLineColor"></param>
        public void ChangePointColor(Pen pPointColor)
        {
            m_plotGraphBuilder.ChangePointColor(pPointColor);
        }

    }//InOutHandler
}
