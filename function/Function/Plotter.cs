using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Function
{
    class Plotter
    {
        PictureBox DrawingArea;

        int[] Collisions;

        int LowLimit;
        int HighLimit;

        int X;
        int Y;

        int MinValue;
        int MaxValue;

        bool bShift = false;

        List<int> Values;

        public int Maximum { get { return MaxValue; } } // Getting the maximum value of collisions
        public int Minimum { get { return MinValue; } } // Getting the minimum value of collisions

        /// <summary>
        /// Creating a plotter
        /// </summary>
        /// <param name="f"></param>
        /// <param name="pb"></param>
        public Plotter(Function f, PictureBox pb)
        {
            Update(f, pb);
        } // Plotter

        /// <summary>
        /// Resets the collisions to zeros
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < Collisions.Length; i++) Collisions[i] = 0;
            Values = new List<int>();
            Values.Add(0);
            MinValue = 0;
            MaxValue = 0;
        } // Reset

        /// <summary>
        /// Updating the function and the output area
        /// </summary>
        /// <param name="f"> function </param>
        /// <param name="pb"> output area </param>
        public void Update(Function f, PictureBox pb)
        {
            Update(pb);
            Update(f);
        } // Update

        /// <summary>
        /// Updating the output area only
        /// </summary>
        /// <param name="pb"> output area </param>
        public void Update(PictureBox pb)
        {
            DrawingArea = pb;
        } // Update

        /// <summary>
        /// Updating the function only
        /// </summary>
        /// <param name="f"> function </param>
        public void Update(Function f)
        {
            LowLimit = f.Min;
            HighLimit = f.Max;
            Collisions = new int[HighLimit - LowLimit+1];
            Reset();
        } // Update

        /// <summary>
        /// Plotting the graph
        /// </summary>
        public void Plot()
        {
            Redraw();
        } // Plot

        /// <summary>
        /// Add a set of collisions and plot the graph
        /// </summary>
        /// <param name="hashCollisions"> a set of collisions </param>
        public void Plot(int[] hashCollisions)
        {
            if (hashCollisions.Length == Collisions.Length)
                for (int i = 0; i < Collisions.Length; i++) Collisions[i] += hashCollisions[i];
            Redraw();
        } // Plot

        /// <summary>
        /// Add a collision and plot the graph
        /// </summary>
        /// <param name="hash"> hash of the collision </param>
        public void Plot(int hash)
        {
            AddHash(hash);
            Redraw();
        } // Plot

        /// <summary>
        /// Redraw the graph
        /// </summary>
        private void Redraw()
        {
            // Deciding what shift we are going to make
            int Shift = 0;
            if (bShift) Shift = MinValue;

            // Getting the context of the graphic area
            Graphics g = DrawingArea.CreateGraphics();

            // Clearing the area
            g.Clear(Color.White);

            // Getting the sizes of the area
            int yMax = DrawingArea.Height-1;
            int xMax = DrawingArea.Width-2;

            // Drawing the axes
            g.DrawLine(Pens.Blue, 0, 0, 0, yMax);
            g.DrawLine(Pens.Blue, 0, yMax, xMax, yMax);

            // Finding the maximum value
            int Max = MaxValue - Shift;
            if (Max == 0) Max = 1;

            // Finding the units
            float xUnit;
            if(xMax > Collisions.Length) xUnit = (float)xMax / (Collisions.Length - 1);
            else xUnit = 1;
            float yUnit = (float)yMax * 9 / 10 / Max;

            // Choosing the values to display
            int[] xToDisplay;
            if (xMax >Collisions.Length) xToDisplay = new int[Collisions.Length];
            else xToDisplay = new int[xMax];

            for (int i = 0; i < xToDisplay.Length; i++)
                xToDisplay[i] = GetMax(Collisions, 
                                       (int)Math.Round(i*((float)Collisions.Length/xToDisplay.Length), 0),
                                       (int)Math.Round((i+1)*((float)Collisions.Length/xToDisplay.Length), 0)) - Shift;

            // Plotting the function
            for (int x = 0; x < xToDisplay.Length; x++)
            {
                try
                {
                    g.DrawEllipse(Pens.Red, x * xUnit, yMax - 2 - xToDisplay[x] * yUnit, 2, 2);
                    if (x < xToDisplay.Length - 1)
                        g.DrawLine(Pens.Green, x * xUnit + 1, yMax - 1 - xToDisplay[x] * yUnit,
                                               (x + 1) * xUnit + 1, yMax - 1 - xToDisplay[x + 1] * yUnit);
                }
                catch
                {
                }
            }
        } // Redraw

        /// <summary>
        /// Adding a hash collision and checking if it is the first one
        /// </summary>
        /// <param name="h"> hash of the function </param>
        /// <returns> false if it is the first collision </returns>
        public bool AddHash(int h)
        {
            int collisionValue = ++Collisions[h - LowLimit];

            // recording how many hashes with this amount of collisions we have
            if (collisionValue > Values.Count - 1)
            {
                Values.Add(0);
                MaxValue = Values.Count - 1;
            }

            if (++Values[collisionValue-1] == Collisions.Length) MinValue++;

            if (collisionValue == MinValue || collisionValue == MinValue + 1) return false;
            else return true;
        } // AddHash

        /// <summary>
        /// Gets the maximum value in a part of an array of integers
        /// </summary>
        /// <param name="a"> array of integers </param>
        /// <param name="start"> starting index </param>
        /// <param name="end"> ending index(not included in the search) </param>
        /// <returns> Maximum value </returns>
        private int GetMax(int[] a, int start, int end)
        {
            int Max = 0;
            for (int i = start; i < end; i++) if (Max < a[i]) Max = a[i];
            return Max;
        } // GetMax

        /// <summary>
        /// Gets the minimum value in a part of an array of integers
        /// </summary>
        /// <param name="a"> array of integers </param>
        /// <param name="start"> starting index </param>
        /// <param name="end"> ending index(not included in the search) </param>
        /// <returns> Minimum value </returns>
        private int GetMin(int[] a, int start, int end)
        {
            int Min = a[start];
            for (int i = start + 1; i < end; i++) if (Min > a[i]) Min = a[i];
            return Min;
        } // GetMin

        /// <summary>
        /// Returns the effectiveness of the plotted graph
        /// </summary>
        /// <returns> how close it is to a horizontal line </returns>
        public int GetEffectiveness()
        {

            float Mid = (float)(MaxValue - MinValue) / 2 + MinValue;

            float displacement = 0;

            for (int i = 0; i < Collisions.Length; i++)
            {
                displacement += Collisions[i] - Mid;
            }

            if (Mid == 0 && displacement == 0) return 100;
            else return (int)Math.Round(100 * Mid / (Mid + Math.Abs(displacement) / Collisions.Length), 0);
        } // GetEffectiveness

        /// <summary>
        /// Draws hash and number of collisions
        /// </summary>
        private void DrawValue()
        {
            // Getting the context of the graphic area
            Graphics g = DrawingArea.CreateGraphics();

            // Outputting the values
            g.DrawString("hash\ncollisions", new Font("Arial", 16), Brushes.Blue, new Point(20, 20));

            X = -1;
            Y = -1;
        } // DrawValue

        /// <summary>
        /// Shows hash and number of collisions
        /// </summary>
        /// <param name="x"> x coordinate </param>
        /// <param name="y"> y coordinate </param>
        public void ShowValue(int x, int y)
        {
            X = x;
            Y = y;
        } // ShowValue

        /// <summary>
        /// Gives the amount of collisions for a coordinate on the graph
        /// </summary>
        /// <param name="x"> coordinate </param>
        /// <returns> amount of collisions </returns>
        public int GetCollision(int x)
        {
            int y = GetHash(x) - 1;
            if (y == -2) return -1;
            else return Collisions[y];
        } // GetCollision

        /// <summary>
        /// Gives the hash for a coordinate on the graph
        /// </summary>
        /// <param name="x"> coordinate </param>
        /// <returns> hash </returns>
        public int GetHash(int x)
        {
            x -= DrawingArea.Location.X+1;

            int result = -2;

            if (x >= 0 && x < DrawingArea.Width-2)
            {
                int xMax = DrawingArea.Width - 2;
                if (xMax >= Collisions.Length)
                {
                    float dx = (float)xMax / (Collisions.Length - 1);
                    float b = x / dx;
                    result = (int)Math.Round(x / dx, 0);
                    if (result > Collisions.Length) 
                       result = Collisions.Length - 1;
                }
                else
                {
                    float dx = (float)Collisions.Length / xMax; // amount of values for this point

                    int iMax = (int)Math.Round(x * dx, 0); // index of the maximum element
                    for (int i = iMax + 1; i < (int)Math.Round((x + 1) * dx, 0); i++)
                        if (Collisions[i] > Collisions[iMax]) iMax = i;

                    result = iMax;
                }
            }

            return result + 1;
        } // GetHash

        /// <summary>
        /// Changes the shift of the graph
        /// </summary>
        /// <param name="s"> true if we are going to shift the graph </param>
        public void ShiftGraph(bool shift)
        {
            bShift = shift;
        } // ShiftGraph

    } // PLOTTER
}
