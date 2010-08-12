//This file is under the same license as Form_hashFunctions.cs
namespace cs276_bjt_11__2008_hashFunctions
{
    partial class Form_hashFunctions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_hashFunctions));
            this.label1 = new System.Windows.Forms.Label();
            this.InTxBxHashFunction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnEnterHashFunc = new System.Windows.Forms.Button();
            this.timer_Graphing = new System.Windows.Forms.Timer(this.components);
            this.tbEvalPerSec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbZoom = new System.Windows.Forms.CheckBox();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbEvalPerSec = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPoints = new System.Windows.Forms.CheckBox();
            this.cbLines = new System.Windows.Forms.CheckBox();
            this.lbOutMax = new System.Windows.Forms.Label();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbMinHash = new System.Windows.Forms.Label();
            this.lbMaxHash = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbMaxSubMin = new System.Windows.Forms.Label();
            this.lbMouseHash = new System.Windows.Forms.Label();
            this.lbMouseCollisions = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbModulus = new System.Windows.Forms.Label();
            this.BtnEnterInputFunc = new System.Windows.Forms.Button();
            this.InTxBxInputFunction = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btLineColor = new System.Windows.Forms.Button();
            this.btPointColor = new System.Windows.Forms.Button();
            this.sbDiameter = new System.Windows.Forms.HScrollBar();
            this.lbScroll = new System.Windows.Forms.Label();
            this.lbOutMin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // InTxBxHashFunction
            // 
            resources.ApplyResources(this.InTxBxHashFunction, "InTxBxHashFunction");
            this.InTxBxHashFunction.Name = "InTxBxHashFunction";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbMin
            // 
            resources.ApplyResources(this.tbMin, "tbMin");
            this.tbMin.Name = "tbMin";
            // 
            // tbMax
            // 
            resources.ApplyResources(this.tbMax, "tbMax");
            this.tbMax.Name = "tbMax";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // BtnEnterHashFunc
            // 
            resources.ApplyResources(this.BtnEnterHashFunc, "BtnEnterHashFunc");
            this.BtnEnterHashFunc.Name = "BtnEnterHashFunc";
            this.BtnEnterHashFunc.UseVisualStyleBackColor = true;
            this.BtnEnterHashFunc.Click += new System.EventHandler(this.BtnEnterHashFunc_Click);
            // 
            // timer_Graphing
            // 
            this.timer_Graphing.Enabled = true;
            this.timer_Graphing.Interval = 1000;
            this.timer_Graphing.Tick += new System.EventHandler(this.timer_Graphing_Tick);
            // 
            // tbEvalPerSec
            // 
            resources.ApplyResources(this.tbEvalPerSec, "tbEvalPerSec");
            this.tbEvalPerSec.Name = "tbEvalPerSec";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cbZoom
            // 
            resources.ApplyResources(this.cbZoom, "cbZoom");
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.UseVisualStyleBackColor = true;
            this.cbZoom.CheckedChanged += new System.EventHandler(this.cbZoom_CheckedChanged);
            // 
            // lbMin
            // 
            resources.ApplyResources(this.lbMin, "lbMin");
            this.lbMin.Name = "lbMin";
            // 
            // lbMax
            // 
            resources.ApplyResources(this.lbMax, "lbMax");
            this.lbMax.Name = "lbMax";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // lbEvalPerSec
            // 
            resources.ApplyResources(this.lbEvalPerSec, "lbEvalPerSec");
            this.lbEvalPerSec.Name = "lbEvalPerSec";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // pbGraph
            // 
            resources.ApplyResources(this.pbGraph, "pbGraph");
            this.pbGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbGraph.ErrorImage = null;
            this.pbGraph.InitialImage = null;
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Name = "label5";
            // 
            // cbPoints
            // 
            resources.ApplyResources(this.cbPoints, "cbPoints");
            this.cbPoints.Checked = true;
            this.cbPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPoints.Name = "cbPoints";
            this.cbPoints.UseVisualStyleBackColor = true;
            this.cbPoints.CheckedChanged += new System.EventHandler(this.cbPoints_CheckedChanged);
            // 
            // cbLines
            // 
            resources.ApplyResources(this.cbLines, "cbLines");
            this.cbLines.Checked = true;
            this.cbLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLines.Name = "cbLines";
            this.cbLines.UseVisualStyleBackColor = true;
            this.cbLines.CheckedChanged += new System.EventHandler(this.cbLines_CheckedChanged);
            // 
            // lbOutMax
            // 
            resources.ApplyResources(this.lbOutMax, "lbOutMax");
            this.lbOutMax.Name = "lbOutMax";
            // 
            // cbPause
            // 
            resources.ApplyResources(this.cbPause, "cbPause");
            this.cbPause.Name = "cbPause";
            this.cbPause.UseVisualStyleBackColor = true;
            this.cbPause.CheckedChanged += new System.EventHandler(this.cbPause_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            resources.ApplyResources(this.licenseToolStripMenuItem, "licenseToolStripMenuItem");
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lbMinHash
            // 
            resources.ApplyResources(this.lbMinHash, "lbMinHash");
            this.lbMinHash.Name = "lbMinHash";
            // 
            // lbMaxHash
            // 
            resources.ApplyResources(this.lbMaxHash, "lbMaxHash");
            this.lbMaxHash.Name = "lbMaxHash";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // lbMaxSubMin
            // 
            resources.ApplyResources(this.lbMaxSubMin, "lbMaxSubMin");
            this.lbMaxSubMin.Name = "lbMaxSubMin";
            // 
            // lbMouseHash
            // 
            resources.ApplyResources(this.lbMouseHash, "lbMouseHash");
            this.lbMouseHash.Name = "lbMouseHash";
            // 
            // lbMouseCollisions
            // 
            resources.ApplyResources(this.lbMouseCollisions, "lbMouseCollisions");
            this.lbMouseCollisions.Name = "lbMouseCollisions";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Name = "label15";
            // 
            // lbModulus
            // 
            resources.ApplyResources(this.lbModulus, "lbModulus");
            this.lbModulus.ForeColor = System.Drawing.Color.DimGray;
            this.lbModulus.Name = "lbModulus";
            // 
            // BtnEnterInputFunc
            // 
            resources.ApplyResources(this.BtnEnterInputFunc, "BtnEnterInputFunc");
            this.BtnEnterInputFunc.Name = "BtnEnterInputFunc";
            this.BtnEnterInputFunc.UseVisualStyleBackColor = true;
            this.BtnEnterInputFunc.Click += new System.EventHandler(this.BtnEnterInputFunc_Click);
            // 
            // InTxBxInputFunction
            // 
            resources.ApplyResources(this.InTxBxInputFunction, "InTxBxInputFunction");
            this.InTxBxInputFunction.Name = "InTxBxInputFunction";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // btLineColor
            // 
            resources.ApplyResources(this.btLineColor, "btLineColor");
            this.btLineColor.Name = "btLineColor";
            this.btLineColor.UseVisualStyleBackColor = true;
            this.btLineColor.Click += new System.EventHandler(this.btLineColor_Click);
            // 
            // btPointColor
            // 
            resources.ApplyResources(this.btPointColor, "btPointColor");
            this.btPointColor.Name = "btPointColor";
            this.btPointColor.UseVisualStyleBackColor = true;
            this.btPointColor.Click += new System.EventHandler(this.btPointColor_Click);
            // 
            // sbDiameter
            // 
            resources.ApplyResources(this.sbDiameter, "sbDiameter");
            this.sbDiameter.LargeChange = 1;
            this.sbDiameter.Maximum = 200;
            this.sbDiameter.Name = "sbDiameter";
            this.sbDiameter.Value = 5;
            this.sbDiameter.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // lbScroll
            // 
            resources.ApplyResources(this.lbScroll, "lbScroll");
            this.lbScroll.Name = "lbScroll";
            // 
            // lbOutMin
            // 
            resources.ApplyResources(this.lbOutMin, "lbOutMin");
            this.lbOutMin.Name = "lbOutMin";
            // 
            // Form_hashFunctions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbScroll);
            this.Controls.Add(this.sbDiameter);
            this.Controls.Add(this.btPointColor);
            this.Controls.Add(this.btLineColor);
            this.Controls.Add(this.BtnEnterInputFunc);
            this.Controls.Add(this.InTxBxInputFunction);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lbModulus);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbMouseCollisions);
            this.Controls.Add(this.lbMouseHash);
            this.Controls.Add(this.lbMaxSubMin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbMaxHash);
            this.Controls.Add(this.lbMinHash);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.lbOutMax);
            this.Controls.Add(this.lbOutMin);
            this.Controls.Add(this.cbLines);
            this.Controls.Add(this.cbPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbEvalPerSec);
            this.Controls.Add(this.pbGraph);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbMax);
            this.Controls.Add(this.lbMin);
            this.Controls.Add(this.cbZoom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbEvalPerSec);
            this.Controls.Add(this.BtnEnterHashFunc);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InTxBxHashFunction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_hashFunctions";
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InTxBxHashFunction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnEnterHashFunc;
        private System.Windows.Forms.Timer timer_Graphing;
        private System.Windows.Forms.TextBox tbEvalPerSec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbZoom;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbEvalPerSec;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbPoints;
        private System.Windows.Forms.CheckBox cbLines;
        private System.Windows.Forms.Label lbOutMax;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbMinHash;
        private System.Windows.Forms.Label lbMaxHash;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbMaxSubMin;
        private System.Windows.Forms.Label lbMouseHash;
        private System.Windows.Forms.Label lbMouseCollisions;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbModulus;
        private System.Windows.Forms.Button BtnEnterInputFunc;
        private System.Windows.Forms.TextBox InTxBxInputFunction;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btLineColor;
        private System.Windows.Forms.Button btPointColor;
        private System.Windows.Forms.HScrollBar sbDiameter;
        private System.Windows.Forms.Label lbScroll;
        private System.Windows.Forms.Label lbOutMin;
    }
}

