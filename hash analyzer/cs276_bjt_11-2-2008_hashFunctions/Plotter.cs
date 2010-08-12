//This file is under the same license as Form_hashFunctions.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace cs276_bjt_11__2008_hashFunctions
{
    /// <summary>
    /// version: 1.4
    /// author: masterarcher & jediknight304
    /// date: 2008/11/12
    /// purpose: Plot hashes and their collisions on an external Graphics object
    ///             To get a good grade in CompSci 276
    /// input: Graphics to draw on, range of hash values to plot
    /// output: Program displays hashes and their collisions as a graph
    /// </summary>
    class Plotter
    {
        /// <summary>
        /// Variable Pool
        /// </summary>
        int m_iMin, m_iMax;//Min / Max Collisions throughout all hashes
        int m_iMinHash, m_iMaxHash;//Hases carrying the min and max collisions
        int m_iLowLimit, m_iHighLimit;//Range of hashes
        Graphics m_gArea;//Output canvas for Plot
        int[] m_aiHashes;//The index represents potential hashes, index values being their collisions
        List<int> m_liCollisions;//How many hashes(value) have hit a certain amount of collisions(index)
        bool m_bZoom = false;//Tells Plot to scale from the bottom of m_gArea to the top; the hash with min collisions will always touch the bottom of the graphing area
        bool m_bPoints = true, m_bLines = true;//For point and line graphs
        int m_iPointDiameter;
        float fH, fW;//Canvas height and width
        Pen m_pLineColor, m_pPointColor; // Color For Points and Lines on Graph

        /// <summary>
        /// Minimum collisions throughout all hashes
        /// </summary>
        public int Minimum
        {
            get { return m_iMin; }
        }

        /// <summary>
        /// Maximum collisions throughout all hashes
        /// </summary>
        public int Maximum
        {
            get { return m_iMax; }
        }

        /// <summary>
        /// Hash with the fewest collisions
        /// </summary>
        public int MinimumHash
        {
            get { return m_iMinHash; }
        }

        /// <summary>
        /// Hash with the most collisions
        /// </summary>
        public int MaximumHash
        {
            get { return m_iMaxHash; }
        }

        /// <summary>
        /// Diameter of plotted points
        /// </summary>
        public int PointDiameter
        {
            set { m_iPointDiameter = value; }
        }

        /// <summary>
        /// Method Description: Plotter(Graphics)
        /// Postcondition: Graphics g will be used throughout the plotting process to display the graph
        /// Range of hashes is defaulted to 0 through 30
        /// </summary>
        /// <param name="g"></param>
        public Plotter(Graphics g)
        {
            UpdateArea(g);
            Reset(0, 30);
            m_iPointDiameter = 5;
        }//Plotter Constructor(Graphics)

        /// <summary>
        /// Method Description: Plotter(Graphics, int, int, bool, bool)
        /// Postcondition: Graphics g will be used throughout the plotting process to display the graph
        /// Range of hashes is set to (iHighLimit-iLowLimit+1)
        /// bPoints and bLines will denote whether or not to draw points and lines
        /// </summary>
        /// <param name="g"></param>
        /// <param name="iLowLimit"></param>
        /// <param name="iHighLimit"></param>
        /// <param name="bPoints"></param>
        /// <param name="bLines"></param>
        public Plotter(Graphics g, int iLowLimit, int iHighLimit, bool bPoints, bool bLines)
        {
            UpdateArea(g);
            Reset(iLowLimit, iHighLimit);
            m_iPointDiameter = 5;
            m_bLines = bLines;//True to draw lines connecting points
            m_bPoints = bPoints;//True to draw a point at each collision

        }//Plotter Constructor(Graphics, int, int, bool, bool)

        /// <summary>
        /// Method Description: Reset()
        /// Sets: m_iMin, m_iMax, and m_aiHashes values = zero; m_liCollisions = new list
        /// </summary>
        public void Reset()
        {
            m_iMax = 0;
            m_iMin = 0;

            //m_iPointDiameter = 5;

            for (int i = 0; i < m_aiHashes.Length; i++)
                m_aiHashes[i] = 0;
            m_liCollisions = new List<int>();
        }//Reset

        /// <summary>
        /// Method Description: Reset()
        /// Sets: m_iMin, m_iMax = zero; m_aiHashes = new int[iHighLimit - iLowLimit + 1];  m_liCollisions = new list
        /// </summary>
        public void Reset(int iLowLimit, int iHighLimit)
        {
            m_iHighLimit = iHighLimit;
            m_iLowLimit = iLowLimit;

            m_iPointDiameter = 5;

            m_iMax = 0;
            m_iMin = 0;
            m_aiHashes = new int[m_iHighLimit - m_iLowLimit + 1];
            for (int i = 0; i < m_aiHashes.Length; i++)
                m_aiHashes[i] = 0;
            m_liCollisions = new List<int>();
            m_pLineColor = new Pen(Color.Blue);
            m_pPointColor = new Pen(Color.Blue);
        }//Reset

        /// <summary>
        /// Method Description: UpdateArea(Graphics)
        /// Postcondition: Graphics g has replaced the previous Graphics for graphing
        /// </summary>
        /// <param name="g"></param>
        public void UpdateArea(Graphics g)
        {
            m_gArea = g;
            fH = m_gArea.VisibleClipBounds.Height;
            fW = m_gArea.VisibleClipBounds.Width;
        }//UpdateArea(Graphics)

        /// <summary>
        /// Method Description: Plot
        /// Precondition: m_aiHashes has been populated
        /// Postcondition: A background gradient has been drawn from solid red at the top of m_gArea to solid green at the bottom
        /// Red represents more collisions, which means a poor quality hash function. Green represents fewer collisions, implying a high quality hash function
        /// A graph has been drawn to m_gArea: index is domain and m_aiHashes[index] is range
        /// in other words: The hashes are along the X axis, their collisions are along the Y axis
        /// </summary>
        public void Plot()
        {
            DrawBackGround();
            if(m_bPoints)
                PlotPoints();
            if(m_bLines)
                PlotLines();
        }//Plot

        private void DrawBackGround()
        {
            int r = 0, g = 0, b = 0;//Red, Green, Blue for Pen Color
            Pen pPen;
            Color cColor;

            //Draw Background Gradient
            for (int i = 0; i < fH; i++)
            {
                r = (int)(255 * ((fH - i) / fH));
                g = 255 - r;//Inverse of red's strength
                cColor = Color.FromArgb(r, g, b);
                pPen = new Pen(cColor);
                m_gArea.DrawLine(pPen, 0, i, fW, i);
            }
        }//DrawBackGround

        private void PlotLines()
        {
            int iZoom = 0;//How far to stretch the bottom of the points down
            if (m_bZoom)
                iZoom = m_iMin;

            float fWPad = fW * .05f, fHPad = fH * .05f;

            //Coefficients to scale hashes and their collisions to the width and height of the m_gArea
            //Allows resizing
            float fPxlPerHash = (fW - fWPad) / (float)(m_aiHashes.Length - 1);
            float fPxlPerMaxCollisions = (fH - fHPad) / ((float)(m_iMax - iZoom));

            //Loop to draw lines
            for (int i = 1; i < m_aiHashes.Length; i++)
                m_gArea.DrawLine(m_pLineColor, (i - 1) * fPxlPerHash + fWPad/2, fH - (m_aiHashes[i - 1] - iZoom) * fPxlPerMaxCollisions - fHPad/2, (i) * fPxlPerHash + fWPad/2, (fH - fHPad) - (m_aiHashes[i] - iZoom) * fPxlPerMaxCollisions + fHPad/2);
        }//PlotLines

        private void PlotPoints()
        {
            int iZoom = 0;//How far to stretch the bottom of the points down
            if (m_bZoom)
                iZoom = m_iMin;

            float fWPad = fW * .05f, fHPad = fH * .05f;

            //Coefficients to scale hashes and their collisions to the width and height of the m_gArea
            //Allows resizing
            float fPxlPerHash = (fW - fWPad) / (float)(m_aiHashes.Length - 1);
            float fPxlPerMaxCollisions = (fH - fHPad) / ((float)(m_iMax - iZoom));
            
            //Loop to draw points
            for (int i = 0; i < m_aiHashes.Length; i++)
                m_gArea.FillEllipse(m_pPointColor.Brush, i * fPxlPerHash - m_iPointDiameter / 2 + fWPad / 2, fH - ((m_aiHashes[i] - iZoom) * fPxlPerMaxCollisions) - m_iPointDiameter / 2 - fHPad / 2, m_iPointDiameter, m_iPointDiameter);
        }



        /// <summary>
        /// Method Description: IncrementHash(int)
        /// Increments the collisions at a specific hash
        /// </summary>
        /// <param name="iHash"></param>
        public void IncrementHash(int iHash)
        {
            //Upkeep m_liCollisions simultaneously with incrementing the hash's collisions
            if (++m_aiHashes[iHash - m_iLowLimit] > m_liCollisions.Count)
                m_liCollisions.Add(1);
            else
                //Keep track of how many of a certain value of collisions we have throughout all hashes
                //If all hashes have increment to or beyond some number of collisions, then that is the new m_iMin
                if (++m_liCollisions[m_aiHashes[iHash - m_iLowLimit] - 1] == m_aiHashes.Length)
                {
                    m_iMinHash = iHash - m_iLowLimit;
                    m_iMin++;
                }

            if (m_aiHashes[iHash - m_iLowLimit] > m_iMax)
            {
                m_iMaxHash = iHash - m_iLowLimit;
                m_iMax++;
            }
        }//IncrementHash


        /// <summary>
        /// Method Description: GetCollision
        /// Gives the max collisions for a vertical coordinate on the graph
        /// </summary>
        /// <param name="iPxl"></param>
        /// <returns></returns>
        public int GetCollision(int iPxl)
        {
            int iHash = GetHash(iPxl) - 1;
            if (iHash == -2) 
                return -1;
            else 
                return m_aiHashes[iHash];
        }//GetCollision(int)

        /// <summary>
        /// Method Description: GetHash
        /// Gives the hash for a vertical coordinate on the graph
        /// </summary>
        /// <param name="iPxl"></param>
        /// <returns></returns>
        public int GetHash(int iPxl)
        {
            int iHash = -1;
            float iW = m_gArea.VisibleClipBounds.Width;

            if (iW > m_aiHashes.Length)
            {
                float fPxlPerPoint = iW / (m_aiHashes.Length - 1);
                float fPoint = iPxl / fPxlPerPoint;
                iHash = (int)Math.Round(fPoint);
                if (iHash > m_aiHashes.Length)
                    iHash = m_aiHashes.Length - 1;
            }
            else
            {
                float fPointsPerPxl = (float)m_aiHashes.Length / iW;
                int iPoint = (int)Math.Round(iPxl * fPointsPerPxl);
                for (int i = iPoint + 1; i < (int)Math.Round((iPxl + 1) * fPointsPerPxl); i++)
                    if (m_aiHashes[i] > m_aiHashes[iPoint])
                        iPoint = i;
                iHash = iPoint;
            }
            return iHash + 1;
        }//GetHash(int)

        /// <summary>
        /// This m_bZoom, if true, crops out the whitespace underneathe the graph
        /// Appears like the graph has zoomed in, or more realistically, stretched to fill to the bottom of the m_gArea
        /// </summary>
        public void SwitchZoom()
        {
            m_bZoom = !m_bZoom;
        }

        /// <summary>
        /// Toggles Drawing points
        /// </summary>
        public void SwitchPoints()
        {
            m_bPoints = !m_bPoints;
        }

        /// <summary>
        /// Toggles Drawing lines
        /// </summary>
        public void SwitchLines()
        {
            m_bLines = !m_bLines;
        }

        /// <summary>
        /// Changes the line color on the graph
        /// Pre: pNewLineColor has been assigned
        /// Post: m_pLineColor has been updated to new color
        /// </summary>
        /// <param name="pNewLineColor"></param>
        public void ChangeLineColor(Pen pNewLineColor)
        {
            m_pLineColor = pNewLineColor;
        }

        /// <summary>
        /// Changes the point color on the graph
        /// Pre: pPointColor has been assigned
        /// Post: m_pPointColor has been updated to new color
        /// </summary>
        /// <param name="pNewLineColor"></param>
        public void ChangePointColor(Pen pNewPointColor)
        {
            m_pPointColor = pNewPointColor;
        }

                
    }//PLOTTER
}
