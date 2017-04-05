namespace Login
{
    partial class GW2Login
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
            this.addButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.accountListBox = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCharacter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownGame = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTPA = new System.Windows.Forms.Label();
            this.labelTT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGame)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(10, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(66, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // accountListBox
            // 
            this.accountListBox.FormattingEnabled = true;
            this.accountListBox.Location = new System.Drawing.Point(10, 46);
            this.accountListBox.Name = "accountListBox";
            this.accountListBox.Size = new System.Drawing.Size(239, 186);
            this.accountListBox.TabIndex = 6;
            this.accountListBox.SelectedIndexChanged += new System.EventHandler(this.accountListBox_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(10, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 58);
            this.button2.TabIndex = 7;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.runButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(98, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(66, 23);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Time to Character Screen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "seconds";
            // 
            // numericUpDownCharacter
            // 
            this.numericUpDownCharacter.Location = new System.Drawing.Point(144, 238);
            this.numericUpDownCharacter.Name = "numericUpDownCharacter";
            this.numericUpDownCharacter.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownCharacter.TabIndex = 12;
            this.numericUpDownCharacter.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCharacter.ValueChanged += new System.EventHandler(this.numericUpDownCharacter_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Time to in game:";
            // 
            // numericUpDownGame
            // 
            this.numericUpDownGame.Location = new System.Drawing.Point(143, 272);
            this.numericUpDownGame.Name = "numericUpDownGame";
            this.numericUpDownGame.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownGame.TabIndex = 14;
            this.numericUpDownGame.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownGame.ValueChanged += new System.EventHandler(this.numericUpDownGame_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Minion Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Time Per Account:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Minion Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 29);
            this.label6.TabIndex = 17;
            this.label6.Text = "Total Time:";
            // 
            // labelTPA
            // 
            this.labelTPA.AutoSize = true;
            this.labelTPA.Font = new System.Drawing.Font("Minion Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTPA.Location = new System.Drawing.Point(187, 306);
            this.labelTPA.Name = "labelTPA";
            this.labelTPA.Size = new System.Drawing.Size(62, 29);
            this.labelTPA.TabIndex = 18;
            this.labelTPA.Text = "00:00";
            // 
            // labelTT
            // 
            this.labelTT.AutoSize = true;
            this.labelTT.Font = new System.Drawing.Font("Minion Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTT.Location = new System.Drawing.Point(160, 335);
            this.labelTT.Name = "labelTT";
            this.labelTT.Size = new System.Drawing.Size(89, 29);
            this.labelTT.TabIndex = 19;
            this.labelTT.Text = "00:00:00";
            // 
            // GW2Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(258, 452);
            this.Controls.Add(this.labelTT);
            this.Controls.Add(this.labelTPA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownGame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownCharacter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.accountListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addButton);
            this.Name = "GW2Login";
            this.Text = "Login Portal";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox accountListBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCharacter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownGame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTPA;
        private System.Windows.Forms.Label labelTT;
    }
}

