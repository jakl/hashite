using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Function
{
    public partial class MainForm : Form
    {
        Processor processor;
        System.Timers.Timer tPaint = new System.Timers.Timer();
        System.Timers.Timer tValues = new System.Timers.Timer();
        Point pBase;


        public MainForm()
        {
            InitializeComponent();

            pBase = this.PointToClient(new Point(0, 0));
            
            this.DoubleBuffered = true;            

            processor = new Processor(pbOutput, tbHashFunction, tbHashParameter, tbRange,
                                      tbInputFunction, tbInputParameter, tbSpeed);

            tPaint.Interval = 1000;
            tPaint.Elapsed += this.PaintAlarm;
            tPaint.Start();

            tValues.Interval = 10;
            tValues.Elapsed += this.ValueAlarm;
            tValues.Start();
        }

        Label label; // label used for outputing information in a thread-safe mode

        delegate void SetTextCallback(string text); // anables setting a text property in a thread-safe mode

        /// <summary>
        /// Sets a text property of a label
        /// </summary>
        /// <param name="text"> text </param>
        /// <param name="l"> label </param>
        public void SetText(string text, Label l)
        {
            label = l;
            SetText(text);
        } // SetText

        /// <summary>
        /// Thread safely sets a text property of a label
        /// </summary>
        /// <param name="text"> text </param>
        private void SetText(string text)
        {
            if (label.InvokeRequired)
            {
                try
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                catch
                {
                }
            }
            else
            {
                label.Text = text;
            }
        } // SetText

        public void ValueAlarm(object sender, EventArgs e)
        {
            SetText(processor.Effectiveness.ToString() + "%", lResult);
            SetText(processor.Tried.ToString(), lTried);
            SetText(processor.Collisions.ToString(), lCollisions);
            SetText(processor.LastInput.ToString(), lLastInput);
            SetText(processor.LastHash.ToString(), lLastHash);
            SetText(processor.GetCollision(Cursor.Position.X + pBase.X).ToString(), lCollision);
            SetText(processor.GetHash(Cursor.Position.X + pBase.X).ToString(), lHash);
            SetText(processor.Max.ToString(), lMaximum);
            SetText(processor.Min.ToString(), lMinimum);
            if (cbShiftGraph.Checked)
            {
                SetText("1 / " + processor.Min.ToString(), lO);
            }
            else SetText("1 / 0", lO);
        } // Outputting the graph

        public void PaintAlarm(object sender, EventArgs e)
        {
            processor.Plot();
        } // Outputting the graph

        protected override void OnClosing(CancelEventArgs e)
        {
            processor.Kill();
        } // Killing the thread on closing
 
        private void button1_Click(object sender, EventArgs e)
        {
            processor.UpdateHash();
        } // Updating the hash function

        private void button2_Click(object sender, EventArgs e)
        {
            processor.UpdateInput();
        } // Updating the input function

        private void button3_Click(object sender, EventArgs e)
        {
            processor.Stop();
        } // Stop/Pause the processing

        private void button4_Click(object sender, EventArgs e)
        {
            processor.Start();
        } // Start/Continue the processing

        private void bSpeed_Click(object sender, EventArgs e)
        {
            processor.ChangeSpeed();
        } // Changing the speed

        private void bRestart_Click(object sender, EventArgs e)
        {
            processor.Reset();
        } // Reset

        private void bStepForfard_Click(object sender, EventArgs e)
        {
            processor.Step();
        } // StepForward

        private void pbOutput_MouseHover(object sender, System.EventArgs e)
        {
      //      processor.ShowValue(0, 0);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            pBase = this.PointToClient(new Point(0, 0));
        }

        private void cbShiftGraph_CheckedChanged(object sender, EventArgs e)
        {
            processor.ShiftGraph(cbShiftGraph.Checked);
        }

    } // Form1
}
