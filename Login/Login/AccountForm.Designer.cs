namespace Login
{
    partial class AccountForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email:";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(74, 64);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(148, 20);
            this.passwordBox.TabIndex = 6;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(74, 34);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(148, 20);
            this.emailBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nickname:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(74, 6);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(148, 20);
            this.nameBox.TabIndex = 9;
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.doneButton.Location = new System.Drawing.Point(15, 95);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(207, 37);
            this.doneButton.TabIndex = 11;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 136);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.emailBox);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox nameBox;
    }
}