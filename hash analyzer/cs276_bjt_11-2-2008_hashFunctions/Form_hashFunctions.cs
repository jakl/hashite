/*
 Copyright (c) 2008, Hashites (masterarcher, jediknight304, gentlejoy16, and sloosh)
 All rights reserved.

 Redistribution and use in source and binary forms, with or without
 modification, are permitted provided that the following conditions are met:
     * Redistributions of source code must retain the above copyright
       notice, this list of conditions and the following disclaimer.
     * Redistributions in binary form must reproduce the above copyright
       notice, this list of conditions and the following disclaimer in the
       documentation and/or other materials provided with the distribution.
     * Neither the name(s) of the program's author(s) nor the
       names of its contributors may be used to endorse or promote products
       derived from this software without specific prior written permission.

 THIS SOFTWARE IS PROVIDED BY the Hashites ''AS IS'' AND ANY
 EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 DISCLAIMED. IN NO EVENT SHALL the Hashites BE LIABLE FOR ANY
 DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cs276_bjt_11__2008_hashFunctions
{
    public partial class Form_hashFunctions : Form
    {
        /// <summary>
        /// instance of InOutHandler to call for performing operations
        /// </summary>
        private InOutHandler m_ioh;

        /// <summary>
        /// optional user supplied variable to store
        /// the minimun value of the hashes output
        /// default value 1
        /// </summary>
        private int m_iInHashMin = 0;

        /// <summary>
        /// optional user supplied variable to store
        /// the maximum value of the hashes output
        /// default value 21
        /// </summary>
        private int m_iInHashMax = 30;

        /// <summary>
        /// bool to store whether to user desires graphing
        /// of the function to continue for new input values
        /// </summary>
        private bool m_bIsGraphing = false;

        //Program Version Number
        string m_sVersion;

        //Program License text
        List<string> m_lsLicense;//Holds the BSD license in a list of strings for convenience
        string m_sLicense;//Used as the vessel after converting m_lsLicense to a single string

        public Form_hashFunctions()
        {
            m_sVersion = "1.4";
            InitializeComponent();
            this.Resize += new EventHandler(FormPart_Resize);
            pbGraph.MouseMove += new MouseEventHandler(FormPart_MouseMove);
            pbGraph.MouseLeave += new EventHandler(FormPart_MouseLeavepbGraph);

            //InOutHandler has to get a few things so we can start
            m_ioh = new InOutHandler(pbGraph.CreateGraphics(), m_iInHashMin, m_iInHashMax);

            lbScroll.Text = sbDiameter.Value.ToString();

            //BSD license agreement
            m_lsLicense = new List<string>();
            m_sLicense = "";
            WriteLicense();//Writes the license to m_lsLicense and from that into m_sLicense
        }

        /// <summary>
        /// Function called on form resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormPart_Resize(object sender, EventArgs e)
        {
            //Make sure we resize our graph!
            if (!m_ioh.ResizeGraphics(pbGraph.CreateGraphics()))
            {
                MessageBox.Show("Something Failed", "Title",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                this.Close();
            }//if
            // MessageBox.Show("Something!!", "Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }//FormPart_Resize

        private void BtnEnterInputFunc_Click(object sender, EventArgs e)
        {
            //should you wish to disallow dynamic update to input function
            //if (m_bIsGraphing == true)
            //{
            //    InTxBxInputFunction.AppendText(" Dynamic update to input function not allowed!");
            //    return;
            //}
            //create our function for controlling input!
            try
            {
                m_ioh.UpdateInputFunc(InTxBxInputFunction.Text);
            }//try
            catch (Exception eA)
            {
                //the next call is code mostly reused from Tom Fuller's tutorial programs
                string strMsg = String.Format("Creating input function failed.\n\nUse of ''{0}failed: '{1}'",
                    InTxBxInputFunction.Text, eA.ToString());

                MessageBox.Show(strMsg, "cs276_bjt_11-2-2008_hashFunctions - Form_hashFunctions - InOutHandler.UpdateInputFunc;",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                InTxBxInputFunction.Text = "Function creation failed, please try again. x^3";
                return;
            }//catch
        }

        private void BtnEnterHashFunc_Click(object sender, EventArgs e)
        {
            //Do not try to graph until we know if we have what we need.
            m_bIsGraphing = false;

            //reset error messages
            lbOutMin.Text = "";
            lbOutMax.Text = "";

            //Error Handling for Min/Max
            //we want numbers!
            try
            {
                m_iInHashMin = int.Parse(tbMin.Text);
            }//try
            catch
            {
                m_iInHashMin = 0;
                lbOutMin.Text = "You can't trick me! Min has been set to default zero";
            }//catch

            //we want numbers!
            try
            {
                m_iInHashMax = int.Parse(tbMax.Text);
            }//try
            catch
            {
                m_iInHashMax = m_iInHashMin + 20;
                lbOutMax.Text = "You can't trick me! Max has been set to default min+20";
            }//catch

            //check to see that the user didn't misunderstand the purpose of min and max...
            if (m_iInHashMax <= m_iInHashMin)
            {
                m_iInHashMax = m_iInHashMin + 20;
                lbOutMax.Text = "You can't trick me! Max has been set to default min+20";
            }//if

            //make sure the user is being reasonable, this is just a demonstration of concept after all

            if (Math.Abs(m_iInHashMax - m_iInHashMin) >= 5000)
            {
                m_iInHashMax = m_iInHashMin + 20;
                lbOutMax.Text = "Output settings require too much work! Max has been set to default min+20";
            }//if

            //get our hash function to graph, if we can
            try
            {
                m_ioh.UpdateHash(InTxBxHashFunction.Text, m_iInHashMin, m_iInHashMax);
            }//try
            catch (Exception eA)
            {
                ////the next call is code mostly reused from Tom Fuller's tutorial programs
                //string strMsg = String.Format("Creating hash function failed.\n\nUse of ''{0}failed: '{1}'",
                //    InTxBxHashFunction.Text, eA.ToString());

                //MessageBox.Show(strMsg, "cs276_bjt_11-2-2008_hashFunctions - Form_hashFunctions - InOutHandler.UpdateHash;",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation);

                //reset to something that will work, except for functions that get a special message.
                tbMin.Text = "0";
                tbMax.Text = "30";
                InTxBxHashFunction.Text = "Function creation failed, please try again. x*Sin(x)";
                if (eA.Message == "No input function has been created!")
                    InTxBxInputFunction.Text = "No input function has been entered! x*Sin(x)";
                m_bIsGraphing = false;
                cbPause.Checked = false;
                return;
            }//catch

            //we got this far, we can allow graphing again
            m_bIsGraphing = !cbPause.Checked;

            //a bit of information for our less informed users, let them know the function output is processed by modulus (based on the output settings)
            lbModulus.Text = (m_iInHashMax - m_iInHashMin +1).ToString();

            m_ioh.PointDiameter = sbDiameter.Value;
        }

        private void timer_Graphing_Tick(object sender, EventArgs e)
        {
            int iEvalPerSec = GetEvalPerSec();  //admittedly, not necessarily evenly spaced in the second...
            Plot(iEvalPerSec);
        }

        private void Plot(int iEvalPerSec)
        {
            //we don't actually want to do anything if the user has asked us not to be graphing...
            if (m_bIsGraphing)
            {
                //do the calculations and draw the graph
                m_ioh.IncrementMultipleHashes(iEvalPerSec);
                m_ioh.Plot();

                //report some informative details to the user
                lbMax.Text = m_ioh.Maximum.ToString();
                lbMin.Text = m_ioh.Minimum.ToString();
                lbMaxHash.Text = m_ioh.MaximumIndex.ToString();
                lbMinHash.Text = m_ioh.MinimumIndex.ToString();
                lbMaxSubMin.Text = (m_ioh.Maximum - m_ioh.Minimum).ToString();
            }//if
        }

        private int GetEvalPerSec()
        {
            int iEvalPerSec;
            lbEvalPerSec.Text = "";

            //Move to Facade at first opportunity
            //does the user know we want counting numbers...?
            try
            {
                iEvalPerSec = int.Parse(tbEvalPerSec.Text);
            }//try
            catch
            {
                iEvalPerSec = 5;
                lbEvalPerSec.Text = "We've caught your mischief, and set it to 5!";
            }

            //make sure the user is being reasonable, this is just a demonstration of concept after all
            if (iEvalPerSec < 1 || iEvalPerSec > 20000)
            {
                iEvalPerSec = 5;
                lbEvalPerSec.Text = "We've caught your mischief, and set it to 5!";
            }//if

            return iEvalPerSec;
        }

        public void FormPart_MouseMove(object sender, MouseEventArgs e)
        {
            //if the user isn't already overwhelmed with informative data, here's some more
            lbMouseHash.Text = (m_ioh.GetHash(e.X)-1).ToString();
            lbMouseCollisions.Text = m_ioh.GetCollision(e.X).ToString();
        }

        public void FormPart_MouseLeavepbGraph(object sender, EventArgs e)
        {
            //unless we are talking about imaginary collisions the user problem doesn't want to know
            lbMouseHash.Text = "";
            lbMouseCollisions.Text = "";
        }

        private void cbZoom_CheckedChanged(object sender, EventArgs e)
        {
            //make sure you don't add something else that calls this, it could turn out poorly for you...
            m_ioh.SwitchZoom();
        }

        private void cbPoints_CheckedChanged(object sender, EventArgs e)
        {
            //make sure you don't add something else that calls this, it could turn out poorly for you...
            m_ioh.SwitchPoints();
        }

        private void cbLines_CheckedChanged(object sender, EventArgs e)
        {
            m_ioh.SwitchLines();
        }

        private void cbPause_CheckedChanged(object sender, EventArgs e)
        {
            //make sure you don't add something else that calls this, it could turn out poorly for you...
            m_bIsGraphing = !m_bIsGraphing;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            m_ioh.PointDiameter = sbDiameter.Value;
            lbScroll.Text = sbDiameter.Value.ToString();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //let the user know what it is they got themselves into
            string sAboutText = "Hash Function Analyzer\nCreated by:\nmasterarcher\njediknight304\ngentlejoy16\nand the illustrious...\nsloosh!\n\nEnjoy Version ";
            MessageBox.Show(sAboutText + m_sVersion, "About Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //don't blame us, we're doing this for free, well, sort of
            MessageBox.Show(m_sLicense, "BSD License", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btLineColor_Click(object sender, EventArgs e)
        {
            //Code used from MSDN (http://msdn.microsoft.com/en-us/library/system.windows.forms.colordialog.aspx)
            //Creates popup window to allow user to select color of choice for the lines on the graph
            ColorDialog MyDialog = new ColorDialog();
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;

            Pen pLineColor;
            // Update the line color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pLineColor = new Pen(MyDialog.Color);
                m_ioh.ChangeLineColor(pLineColor);
            }
        }

        private void btPointColor_Click(object sender, EventArgs e)
        {
            //Code used from MSDN (http://msdn.microsoft.com/en-us/library/system.windows.forms.colordialog.aspx)
            //Creates popup window to allow user to select color of choice for the points on the graph
            ColorDialog MyDialog = new ColorDialog();
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;

            Pen pPointColor;
            // Update the point color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pPointColor = new Pen(MyDialog.Color);
                m_ioh.ChangePointColor(pPointColor);
            }
        }

        /// <summary>
        /// Writes the Free BSD License into a list of strings
        /// This is done to ease readability and usability throughout the program
        /// Then m_sLicense is populated with each line in m_lsLicense seperated by '\n'
        /// </summary>
        private void WriteLicense()
        {
            m_lsLicense.Add("Copyright (c) 2008, Hashites (masterarcher, jediknight304, gentlejoy16, and sloosh)\n");
            m_lsLicense.Add("All rights reserved.\n");
            m_lsLicense.Add("Redistribution and use in source and binary forms, with or without ");
            m_lsLicense.Add("modification, are permitted provided that the following conditions are met:\n\n");
            m_lsLicense.Add("   * Redistributions of source code must retain the above copyright ");
            m_lsLicense.Add("notice, this list of conditions and the following disclaimer.\n");
            m_lsLicense.Add("   * Redistributions in binary form must reproduce the above copyright ");
            m_lsLicense.Add("notice, this list of conditions and the following disclaimer in the ");
            m_lsLicense.Add("documentation and/or other materials provided with the distribution.\n");
            m_lsLicense.Add("   * Neither the name(s) of the program's author(s) nor the ");
            m_lsLicense.Add("names of its contributors may be used to endorse or promote products ");
            m_lsLicense.Add("derived from this software without specific prior written permission.\n\n");
            m_lsLicense.Add("THIS SOFTWARE IS PROVIDED BY the Hashites ''AS IS'' AND ANY ");
            m_lsLicense.Add("EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED ");
            m_lsLicense.Add("WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE ");
            m_lsLicense.Add("DISCLAIMED. IN NO EVENT SHALL the Hashites BE LIABLE FOR ANY ");
            m_lsLicense.Add("DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES ");
            m_lsLicense.Add("(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; ");
            m_lsLicense.Add("LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ");
            m_lsLicense.Add("ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT ");
            m_lsLicense.Add("(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS ");
            m_lsLicense.Add("SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.");
            for (int i = 0; i < m_lsLicense.Count; i++)
                m_sLicense += m_lsLicense[i];
        }//WriteLicense
    }//FORM_HASHFUNCTIONS
}
