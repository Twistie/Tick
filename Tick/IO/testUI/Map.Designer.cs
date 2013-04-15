using System.Windows.Forms;

namespace Tick.IO.testUI
{
    partial class Map
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
            this.mapTable = new LinkLabel[20,20];

            for (int i = 0; i < 20; i++ )
            {
                for (int j = 0; j < 20; j++)
                {
                    this.mapTable[i,j] = new System.Windows.Forms.LinkLabel();
                }
            }
            this.SuspendLayout();
            // 
            // l00
            // 
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    this.mapTable[i, j].AutoSize = true;
                    this.mapTable[i, j].Location = new System.Drawing.Point(25 + 25 * i, 25 + 25 * j);
                    this.mapTable[i, j].Name = string.Format("l{0}{1}",i,j);
                    this.mapTable[i, j].Size = new System.Drawing.Size(55, 13);
                    this.mapTable[i, j].TabIndex = 0;
                    this.mapTable[i, j].TabStop = true;
                    this.mapTable[i, j].Text = string.Format("l{0}{1}", i, j);
                }
            }
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 548);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    this.Controls.Add(this.mapTable[i, j]);
                }
            }
            this.Name = "Map";
            this.Text = "Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel[,] mapTable;
    }
}