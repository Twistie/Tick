namespace Tick
{
    partial class Tick
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
            this.logBox = new System.Windows.Forms.TextBox();
            this.MapButton = new System.Windows.Forms.Button();
            this.TestButton1 = new System.Windows.Forms.Button();
            this.TestButton2 = new System.Windows.Forms.Button();
            this.TickButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(23, 34);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(554, 569);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "Hi";
            // 
            // MapButton
            // 
            this.MapButton.Location = new System.Drawing.Point(624, 57);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(157, 64);
            this.MapButton.TabIndex = 1;
            this.MapButton.Text = "Show Map";
            this.MapButton.UseVisualStyleBackColor = true;
            this.MapButton.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // TestButton1
            // 
            this.TestButton1.Location = new System.Drawing.Point(624, 365);
            this.TestButton1.Name = "TestButton1";
            this.TestButton1.Size = new System.Drawing.Size(94, 61);
            this.TestButton1.TabIndex = 2;
            this.TestButton1.Text = "Add Entity";
            this.TestButton1.UseVisualStyleBackColor = true;
            this.TestButton1.Click += new System.EventHandler(this.TestButton1_Click);
            // 
            // TestButton2
            // 
            this.TestButton2.Location = new System.Drawing.Point(734, 367);
            this.TestButton2.Name = "TestButton2";
            this.TestButton2.Size = new System.Drawing.Size(95, 58);
            this.TestButton2.TabIndex = 3;
            this.TestButton2.Text = "Add Movement objective";
            this.TestButton2.UseVisualStyleBackColor = true;
            this.TestButton2.Click += new System.EventHandler(this.TestButton2_Click);
            // 
            // TickButton
            // 
            this.TickButton.Location = new System.Drawing.Point(624, 289);
            this.TickButton.Name = "TickButton";
            this.TickButton.Size = new System.Drawing.Size(204, 63);
            this.TickButton.TabIndex = 4;
            this.TickButton.Text = "Do Tick";
            this.TickButton.UseVisualStyleBackColor = true;
            this.TickButton.Click += new System.EventHandler(this.TickButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(608, 516);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(109, 63);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(734, 516);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(93, 62);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_click);
            // 
            // Tick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 665);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.TickButton);
            this.Controls.Add(this.TestButton2);
            this.Controls.Add(this.TestButton1);
            this.Controls.Add(this.MapButton);
            this.Controls.Add(this.logBox);
            this.Name = "Tick";
            this.Text = "Tick";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button MapButton;
        private System.Windows.Forms.Button TestButton1;
        private System.Windows.Forms.Button TestButton2;
        private System.Windows.Forms.Button TickButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
    }
}

