namespace AutoClick
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label2 = new System.Windows.Forms.Label();
            this.clickIntervalTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dragIntervalTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.autoDragHoldCtrl = new System.Windows.Forms.CheckBox();
            this.autoClickToggleKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autoDragToggleKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mouseBtnCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interval (ms)";
            // 
            // clickIntervalTextBox
            // 
            this.clickIntervalTextBox.BackColor = System.Drawing.Color.White;
            this.clickIntervalTextBox.Location = new System.Drawing.Point(78, 34);
            this.clickIntervalTextBox.Name = "clickIntervalTextBox";
            this.clickIntervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.clickIntervalTextBox.TabIndex = 2;
            this.clickIntervalTextBox.TextChanged += new System.EventHandler(this.clickIntervalTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Interval (ms)";
            // 
            // dragIntervalTextBox
            // 
            this.dragIntervalTextBox.BackColor = System.Drawing.Color.White;
            this.dragIntervalTextBox.Location = new System.Drawing.Point(78, 155);
            this.dragIntervalTextBox.Name = "dragIntervalTextBox";
            this.dragIntervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.dragIntervalTextBox.TabIndex = 7;
            this.dragIntervalTextBox.TextChanged += new System.EventHandler(this.dragIntervalTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Point 1";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(78, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Point 2";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(78, 207);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 12;
            // 
            // autoDragHoldCtrl
            // 
            this.autoDragHoldCtrl.AutoSize = true;
            this.autoDragHoldCtrl.Location = new System.Drawing.Point(11, 259);
            this.autoDragHoldCtrl.Name = "autoDragHoldCtrl";
            this.autoDragHoldCtrl.Size = new System.Drawing.Size(211, 17);
            this.autoDragHoldCtrl.TabIndex = 16;
            this.autoDragHoldCtrl.Text = "Hold CTRL on drag // not implemented";
            this.autoDragHoldCtrl.UseVisualStyleBackColor = true;
            this.autoDragHoldCtrl.CheckedChanged += new System.EventHandler(this.autoDragHoldCtrl_CheckedChanged);
            // 
            // autoClickToggleKey
            // 
            this.autoClickToggleKey.BackColor = System.Drawing.Color.White;
            this.autoClickToggleKey.Location = new System.Drawing.Point(78, 58);
            this.autoClickToggleKey.Name = "autoClickToggleKey";
            this.autoClickToggleKey.Size = new System.Drawing.Size(100, 20);
            this.autoClickToggleKey.TabIndex = 17;
            this.autoClickToggleKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.autoClickToggleKey_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "On/Off";
            // 
            // autoDragToggleKey
            // 
            this.autoDragToggleKey.BackColor = System.Drawing.Color.White;
            this.autoDragToggleKey.Location = new System.Drawing.Point(78, 233);
            this.autoDragToggleKey.Name = "autoDragToggleKey";
            this.autoDragToggleKey.Size = new System.Drawing.Size(100, 20);
            this.autoDragToggleKey.TabIndex = 19;
            this.autoDragToggleKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.autoDragToggleKey_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "On/Off";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Auto Click";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Auto Drag";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mouseBtnCheckbox
            // 
            this.mouseBtnCheckbox.AutoSize = true;
            this.mouseBtnCheckbox.Location = new System.Drawing.Point(78, 84);
            this.mouseBtnCheckbox.Name = "mouseBtnCheckbox";
            this.mouseBtnCheckbox.Size = new System.Drawing.Size(76, 17);
            this.mouseBtnCheckbox.TabIndex = 23;
            this.mouseBtnCheckbox.Text = "Right click";
            this.mouseBtnCheckbox.UseVisualStyleBackColor = true;
            this.mouseBtnCheckbox.CheckedChanged += new System.EventHandler(this.mouseBtnCheckbox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(226, 292);
            this.Controls.Add(this.mouseBtnCheckbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoDragToggleKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.autoClickToggleKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autoDragHoldCtrl);
            this.Controls.Add(this.clickIntervalTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dragIntervalTextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClick";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoClick_FormClosing);
            this.Load += new System.EventHandler(this.AutoClick_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clickIntervalTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dragIntervalTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox autoDragHoldCtrl;
        private System.Windows.Forms.TextBox autoClickToggleKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox autoDragToggleKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox mouseBtnCheckbox;
    }
}

