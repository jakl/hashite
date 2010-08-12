namespace Function
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHashFunction = new System.Windows.Forms.TextBox();
            this.bGetHashFunction = new System.Windows.Forms.Button();
            this.tbRange = new System.Windows.Forms.TextBox();
            this.tbInputFunction = new System.Windows.Forms.TextBox();
            this.bGetInputFunction = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lResult = new System.Windows.Forms.Label();
            this.bSpeed = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.bReset = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHashParameter = new System.Windows.Forms.TextBox();
            this.tbInputParameter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bStepForfard = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lLastInput = new System.Windows.Forms.Label();
            this.lLastHash = new System.Windows.Forms.Label();
            this.lTried = new System.Windows.Forms.Label();
            this.lCollisions = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lCollision = new System.Windows.Forms.Label();
            this.lHash = new System.Windows.Forms.Label();
            this.lO = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lMaximum = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lMinimum = new System.Windows.Forms.Label();
            this.cbShiftGraph = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // tbHashFunction
            // 
            this.tbHashFunction.Location = new System.Drawing.Point(231, 40);
            this.tbHashFunction.Name = "tbHashFunction";
            this.tbHashFunction.Size = new System.Drawing.Size(260, 20);
            this.tbHashFunction.TabIndex = 0;
            this.tbHashFunction.Text = "x*Cos(x)";
            // 
            // bGetHashFunction
            // 
            this.bGetHashFunction.Location = new System.Drawing.Point(10, 38);
            this.bGetHashFunction.Name = "bGetHashFunction";
            this.bGetHashFunction.Size = new System.Drawing.Size(117, 23);
            this.bGetHashFunction.TabIndex = 1;
            this.bGetHashFunction.Text = "Get Hash Function";
            this.bGetHashFunction.UseVisualStyleBackColor = true;
            this.bGetHashFunction.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbRange
            // 
            this.tbRange.Location = new System.Drawing.Point(530, 40);
            this.tbRange.Name = "tbRange";
            this.tbRange.Size = new System.Drawing.Size(100, 20);
            this.tbRange.TabIndex = 3;
            this.tbRange.Text = "20";
            // 
            // tbInputFunction
            // 
            this.tbInputFunction.Location = new System.Drawing.Point(231, 82);
            this.tbInputFunction.Name = "tbInputFunction";
            this.tbInputFunction.Size = new System.Drawing.Size(260, 20);
            this.tbInputFunction.TabIndex = 4;
            this.tbInputFunction.Text = "n";
            // 
            // bGetInputFunction
            // 
            this.bGetInputFunction.Location = new System.Drawing.Point(10, 80);
            this.bGetInputFunction.Name = "bGetInputFunction";
            this.bGetInputFunction.Size = new System.Drawing.Size(117, 23);
            this.bGetInputFunction.TabIndex = 6;
            this.bGetInputFunction.Text = "Get Input Function";
            this.bGetInputFunction.UseVisualStyleBackColor = true;
            this.bGetInputFunction.Click += new System.EventHandler(this.button2_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(10, 320);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(117, 23);
            this.bStop.TabIndex = 7;
            this.bStop.Text = "Stop/Pause";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.button3_Click);
            // 
            // pbOutput
            // 
            this.pbOutput.BackColor = System.Drawing.Color.White;
            this.pbOutput.Location = new System.Drawing.Point(155, 230);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(731, 316);
            this.pbOutput.TabIndex = 8;
            this.pbOutput.TabStop = false;
            this.pbOutput.MouseHover += new System.EventHandler(this.pbOutput_MouseHover);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(10, 275);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(117, 23);
            this.bStart.TabIndex = 9;
            this.bStart.Text = "Start/Continue";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(664, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Effectiveness:";
            // 
            // lResult
            // 
            this.lResult.AutoSize = true;
            this.lResult.Location = new System.Drawing.Point(783, 43);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(33, 13);
            this.lResult.TabIndex = 14;
            this.lResult.Text = "100%";
            // 
            // bSpeed
            // 
            this.bSpeed.Location = new System.Drawing.Point(10, 125);
            this.bSpeed.Name = "bSpeed";
            this.bSpeed.Size = new System.Drawing.Size(117, 23);
            this.bSpeed.TabIndex = 15;
            this.bSpeed.Text = "Change speed";
            this.bSpeed.UseVisualStyleBackColor = true;
            this.bSpeed.Click += new System.EventHandler(this.bSpeed_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Speed:";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(180, 127);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(68, 20);
            this.tbSpeed.TabIndex = 17;
            this.tbSpeed.Text = "5";
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(10, 230);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(117, 23);
            this.bReset.TabIndex = 19;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bRestart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(716, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Monitoring";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "h(";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "f(";
            // 
            // tbHashParameter
            // 
            this.tbHashParameter.Location = new System.Drawing.Point(155, 40);
            this.tbHashParameter.Name = "tbHashParameter";
            this.tbHashParameter.Size = new System.Drawing.Size(45, 20);
            this.tbHashParameter.TabIndex = 23;
            this.tbHashParameter.Text = "x";
            this.tbHashParameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInputParameter
            // 
            this.tbInputParameter.Location = new System.Drawing.Point(155, 82);
            this.tbInputParameter.Name = "tbInputParameter";
            this.tbInputParameter.Size = new System.Drawing.Size(45, 20);
            this.tbInputParameter.TabIndex = 24;
            this.tbInputParameter.Text = "n";
            this.tbInputParameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = ") =";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = ") =";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Parameter";
            // 
            // bStepForfard
            // 
            this.bStepForfard.Location = new System.Drawing.Point(12, 364);
            this.bStepForfard.Name = "bStepForfard";
            this.bStepForfard.Size = new System.Drawing.Size(115, 23);
            this.bStepForfard.TabIndex = 28;
            this.bStepForfard.Text = "Step Forward";
            this.bStepForfard.UseVisualStyleBackColor = true;
            this.bStepForfard.Click += new System.EventHandler(this.bStepForfard_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(664, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Number of tried input:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(664, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Number of collisions:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(664, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Last tried input:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(664, 147);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Last generated hash:";
            // 
            // lLastInput
            // 
            this.lLastInput.AutoSize = true;
            this.lLastInput.Location = new System.Drawing.Point(783, 125);
            this.lLastInput.Name = "lLastInput";
            this.lLastInput.Size = new System.Drawing.Size(16, 13);
            this.lLastInput.TabIndex = 33;
            this.lLastInput.Text = "-1";
            // 
            // lLastHash
            // 
            this.lLastHash.AutoSize = true;
            this.lLastHash.Location = new System.Drawing.Point(783, 147);
            this.lLastHash.Name = "lLastHash";
            this.lLastHash.Size = new System.Drawing.Size(16, 13);
            this.lLastHash.TabIndex = 34;
            this.lLastHash.Text = "-1";
            // 
            // lTried
            // 
            this.lTried.AutoSize = true;
            this.lTried.Location = new System.Drawing.Point(783, 73);
            this.lTried.Name = "lTried";
            this.lTried.Size = new System.Drawing.Size(13, 13);
            this.lTried.TabIndex = 35;
            this.lTried.Text = "0";
            // 
            // lCollisions
            // 
            this.lCollisions.AutoSize = true;
            this.lCollisions.Location = new System.Drawing.Point(783, 96);
            this.lCollisions.Name = "lCollisions";
            this.lCollisions.Size = new System.Drawing.Size(13, 13);
            this.lCollisions.TabIndex = 36;
            this.lCollisions.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(854, 549);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Hash";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(152, 214);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Collisions";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 524);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Hash:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 549);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Collisions:";
            // 
            // lCollision
            // 
            this.lCollision.AutoSize = true;
            this.lCollision.Location = new System.Drawing.Point(66, 549);
            this.lCollision.Name = "lCollision";
            this.lCollision.Size = new System.Drawing.Size(13, 13);
            this.lCollision.TabIndex = 41;
            this.lCollision.Text = "0";
            // 
            // lHash
            // 
            this.lHash.AutoSize = true;
            this.lHash.Location = new System.Drawing.Point(66, 524);
            this.lHash.Name = "lHash";
            this.lHash.Size = new System.Drawing.Size(13, 13);
            this.lHash.TabIndex = 42;
            this.lHash.Text = "0";
            // 
            // lO
            // 
            this.lO.AutoSize = true;
            this.lO.Location = new System.Drawing.Point(152, 549);
            this.lO.Name = "lO";
            this.lO.Size = new System.Drawing.Size(30, 13);
            this.lO.TabIndex = 43;
            this.lO.Text = "1 / 0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(664, 177);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 44;
            this.label21.Text = "Maximum:";
            // 
            // lMaximum
            // 
            this.lMaximum.AutoSize = true;
            this.lMaximum.Location = new System.Drawing.Point(783, 177);
            this.lMaximum.Name = "lMaximum";
            this.lMaximum.Size = new System.Drawing.Size(13, 13);
            this.lMaximum.TabIndex = 45;
            this.lMaximum.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(664, 199);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 13);
            this.label22.TabIndex = 46;
            this.label22.Text = "Minimum:";
            // 
            // lMinimum
            // 
            this.lMinimum.AutoSize = true;
            this.lMinimum.Location = new System.Drawing.Point(783, 199);
            this.lMinimum.Name = "lMinimum";
            this.lMinimum.Size = new System.Drawing.Size(13, 13);
            this.lMinimum.TabIndex = 47;
            this.lMinimum.Text = "0";
            // 
            // cbShiftGraph
            // 
            this.cbShiftGraph.AutoSize = true;
            this.cbShiftGraph.Location = new System.Drawing.Point(12, 440);
            this.cbShiftGraph.Name = "cbShiftGraph";
            this.cbShiftGraph.Size = new System.Drawing.Size(95, 17);
            this.cbShiftGraph.TabIndex = 48;
            this.cbShiftGraph.Text = "Shift the graph";
            this.cbShiftGraph.UseVisualStyleBackColor = true;
            this.cbShiftGraph.CheckedChanged += new System.EventHandler(this.cbShiftGraph_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 572);
            this.Controls.Add(this.cbShiftGraph);
            this.Controls.Add(this.lMinimum);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lMaximum);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lO);
            this.Controls.Add(this.lHash);
            this.Controls.Add(this.lCollision);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lCollisions);
            this.Controls.Add(this.lTried);
            this.Controls.Add(this.lLastHash);
            this.Controls.Add(this.lLastInput);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bStepForfard);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbInputParameter);
            this.Controls.Add(this.tbHashParameter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bSpeed);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bGetInputFunction);
            this.Controls.Add(this.tbInputFunction);
            this.Controls.Add(this.tbRange);
            this.Controls.Add(this.bGetHashFunction);
            this.Controls.Add(this.tbHashFunction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vladimir\'s hash function analizer";
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHashFunction;
        private System.Windows.Forms.Button bGetHashFunction;
        private System.Windows.Forms.TextBox tbRange;
        private System.Windows.Forms.TextBox tbInputFunction;
        private System.Windows.Forms.Button bGetInputFunction;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lResult;
        private System.Windows.Forms.Button bSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbHashParameter;
        private System.Windows.Forms.TextBox tbInputParameter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bStepForfard;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lLastInput;
        private System.Windows.Forms.Label lLastHash;
        private System.Windows.Forms.Label lTried;
        private System.Windows.Forms.Label lCollisions;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lCollision;
        private System.Windows.Forms.Label lHash;
        private System.Windows.Forms.Label lO;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lMaximum;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lMinimum;
        private System.Windows.Forms.CheckBox cbShiftGraph;
    }
}

