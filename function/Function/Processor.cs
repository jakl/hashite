using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Function
{
    class Processor
    {
        public Thread processing; // a hidden task that calculates the values
        Function fHash; // hash function
        Function fInput; // function for input

        Plotter plotter; // plots the graph

        TextBox tbHashFunction; // getting hash function
        TextBox tbHashRange; // getting range
        TextBox tbHashVar; // getting the name of variable for the hash function
        TextBox tbInputFunction; // getting input function
        TextBox tbInputVar; // getting the name of variable for the input function
        TextBox tbSpeed; // getting speed

        bool paused; // if the process is paused

        int n = 0;
        int tried = 0; // tried numbers
        int collistions = 0; // collisions

        double lastInput = -1; // last input
        int lastHash = -1; // last hash calculated

        int speed = 10; // speed of evaluating

        public int Effectiveness 
        { 
            get 
            {
                if (tried != 0) return 100 - (int)Math.Round(100 * (float)collistions / tried);
                else return 100;
            } 
        }
            //return plotter.GetEffectiveness(); } } // Effectiveness of the function
        public int Tried { get { return tried; } } // Amount of tried input
        public int Collisions { get { return collistions; } } // Amount collisions
        public double LastInput { get { return lastInput; } } // Last input
        public int LastHash { get { return lastHash; } } // Last hash
        public int Min { get { return plotter.Minimum; } } // Getting the minimum value of collisions
        public int Max { get { return plotter.Maximum; } } // Getting the maximum value of collisions

        /// <summary>
        /// Creating the interface for working with the user and operating the processes
        /// </summary>
        public Processor(PictureBox pb, TextBox hF, TextBox hV, TextBox hR, 
                         TextBox iF, TextBox iV, TextBox S)
        {
            // setting default functions
            fHash = new Function("x*Cos(x)", "x");
            fHash.SetLimits(1, 20);
            fInput = new Function("n", "n");
            speed = 5;

            // setting input/output objects
            plotter = new Plotter(fHash, pb);

            tbHashFunction = hF;
            tbHashRange = hR;
            tbHashVar = hV;
            tbInputFunction = iF;
            tbInputVar = iV;
            tbSpeed = S;

            // Creating a hidden process
            processing = new Thread(this.Process);
            processing.Start();
            Stop();
        } // Processor constructor

        /// <summary>
        /// Updating hash function
        /// </summary>
        public void UpdateHash()
        {
            Stop();

            bool CannotUseTheNameOfVariable = true;

            string var = tbHashVar.Text;
            try
            {
                double.Parse(var);
            }
            catch
            {
                CannotUseTheNameOfVariable = false;

                string[] sBuf = var.Split(C.Delims);
                if (sBuf.Length != 1) CannotUseTheNameOfVariable = true;

                for (int i = 0; i < C.StandardFunctions.Length; i++)
                    if (var == C.StandardFunctions[i]) CannotUseTheNameOfVariable = true;

                if (var == "") CannotUseTheNameOfVariable = true;

                if (!CannotUseTheNameOfVariable)
                {
                    Function trial = new Function(tbHashFunction.Text, var);
                    if (trial.Comment == "Successful")
                    {
                        bool CannotUseTheRange = false;

                        int range = 0;
                        try
                        {
                            range = int.Parse(tbHashRange.Text);
                        }
                        catch
                        {
                            CannotUseTheRange = true;

                            MessageBox.Show("Range is supposed to be an integer!" + "\n Try again",
                                            "Updating hash function",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (!CannotUseTheRange)
                            if (range > 1 && range < 2000001)
                            {
                                fHash.Reset(tbHashFunction.Text, var);
                                fHash.SetLimits(1, int.Parse(tbHashRange.Text));
                                plotter.Update(fHash);
                                Reset();
                            }
                            else
                            {
                                MessageBox.Show("Range cannot be less then 2 or more than 2 million!" + "\n Try again",
                                                "Updating hash function",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    else
                    {
                        MessageBox.Show(trial.Comment + "\n Try again", "Updating hash function",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if(CannotUseTheNameOfVariable)
                MessageBox.Show("The name of the parameter cannot be a number!" +
                                "\nIt cannot be empty" +
                                "\nIt cannot contain:" +
                                "\n'+', '-', '*', '/', '%', '^', '(', ')', '=', ' '" +
                                "\nAnd it cannot be the same as one of the standard functions" +
                                "\n Try again", 
                                "Updating hash function", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // UpdateHash

        /// <summary>
        /// Updating input function
        /// </summary>
        public void UpdateInput()
        {
            Stop();

            bool CannotUseTheNameOfVariable = true;

            string var = tbInputVar.Text;
            try
            {
                double.Parse(var);
            }
            catch
            {
                CannotUseTheNameOfVariable = false;

                string[] sBuf = var.Split(C.Delims);
                if (sBuf.Length != 1) CannotUseTheNameOfVariable = true;

                for (int i = 0; i < C.StandardFunctions.Length; i++)
                    if (var == C.StandardFunctions[i]) CannotUseTheNameOfVariable = true;

                if (var == "") CannotUseTheNameOfVariable = true;

                if (!CannotUseTheNameOfVariable)
                {
                    Function trial = new Function(tbInputFunction.Text, var);
                    if (trial.Comment == "Successful")
                    {

                        fInput.Reset(tbInputFunction.Text, tbInputVar.Text);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show(trial.Comment + "\n Try again", "Updating input function",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (CannotUseTheNameOfVariable)
                MessageBox.Show("The name of the parameter cannot be a number" +
                                "\nIt cannot be empty" +
                                "\nIt cannot contain:" +
                                "\n'+', '-', '*', '/', '%', '^', '(', ')', '=', ' '" +
                                "\nAnd it cannot be the same as one of the standard functions" +
                                "\nTry again",
                                "Updating input function",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // UpdateInput

        /// <summary>
        /// Resets the counters
        /// </summary>
        public void Reset()
        {
            Stop();
            n = 0;
            collistions = 0;
            tried = 0;
            plotter.Reset();
            lastHash = -1;
            lastInput = -1;
        } // Reset

        /// <summary>
        /// Evaluating the function
        /// </summary>
        public void Process()
        {
            if (fHash != null && fInput != null)
            {
                while (true)
                {
                    lastInput = fInput.GetValue(n++);
                    lastHash = fHash.GetHashCode(lastInput);

                    if (plotter.AddHash(lastHash)) collistions++;
                    tried++;

                    Thread.Sleep(1000 / speed);
                }
            }
        } // Process

        /// <summary>
        /// Processing evaluating of the function
        /// </summary>
        public void Step()
        {
            lastInput = fInput.GetValue(n++);
            lastHash = fHash.GetHashCode(lastInput);

            if (plotter.AddHash(lastHash)) collistions++;
            tried++;
        } // Step

        /// <summary>
        /// Changing the speed
        /// </summary>
        public void ChangeSpeed()
        {
            bool TheSpeedIsChanged = true;

            int s = 0;

            try
            {
                s = int.Parse(tbSpeed.Text);
            }
            catch
            {
                TheSpeedIsChanged = false;
                MessageBox.Show("The speed is supposed to be an integer!" + "\n Try again",
                                "Changing the speed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (TheSpeedIsChanged)
            {
                if (s > 0)
                {
                    Stop();
                    speed = s;
                }
                else
                {
                    TheSpeedIsChanged = false;
                    MessageBox.Show("The speed cannot be less then one!" + "\n Try again",
                                    "Changing the speed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } // ChangeSpeed

        /// <summary>
        /// Plotting the graph
        /// </summary>
        public void Plot()
        {
            if (true)//!paused)
            {
                plotter.Plot(); // outputting the graph
            }
        } // Plot

        /// <summary>
        /// Shifts the graph to the minimum
        /// </summary>
        /// <param name="Shift"></param>
        public void ShiftGraph(bool shift)
        {
            plotter.ShiftGraph(shift);
        } // ShiftGraph

        /// <summary>
        /// Starting or resuming the thread
        /// </summary>
        public void Start()
        {
            if (paused)
            {
                paused = false;
                if (processing != null) processing.Resume();
            }
        } // Start

        /// <summary>
        /// Stopping or pausing the thread
        /// </summary>
        public void Stop()
        {
            if (!paused)
            {
                paused = true;
                if (processing != null) processing.Suspend();
            }
        } // Stop

        /// <summary>
        /// Shows the value of the hash and the amount of collisions for a coordinat on graph
        /// </summary>
        /// <param name="x"> x coordinate </param>
        /// <param name="y"> y coordinate </param>
        public void ShowValue(int x, int y)
        {
            plotter.ShowValue(x, y);
        } // ShowValue

        /// <summary>
        /// Gives the hash for a coordinate on the graph
        /// </summary>
        /// <param name="x"> coordinate </param>
        /// <returns> hash </returns>
        public int GetHash(int x)
        {
            return plotter.GetHash(x);
        } // GetHash

        /// <summary>
        /// Gives the amount of collisions for a coordinate on the graph
        /// </summary>
        /// <param name="x"> coordinate </param>
        /// <returns> amount of collisions </returns>
        public int GetCollision(int x)
        {
            return plotter.GetCollision(x);
        } // GetCollision

        /// <summary>
        /// Killing the thread
        /// </summary>
        public void Kill()
        {
            Start();
            processing.Abort();
        } // Kill

    } // PROCESSOR
}
