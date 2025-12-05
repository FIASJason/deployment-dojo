namespace WindowsFormsApp1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEdition = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.EditionValue = new System.Windows.Forms.Label();
            this.CustomerValue = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(133, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Deployment Dojo";
            // 
            // lblEdition
            // 
            this.lblEdition.AutoSize = true;
            this.lblEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblEdition.Location = new System.Drawing.Point(67, 110);
            this.lblEdition.Name = "lblEdition";
            this.lblEdition.Size = new System.Drawing.Size(62, 20);
            this.lblEdition.TabIndex = 1;
            this.lblEdition.Text = "Edition:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblCustomer.Location = new System.Drawing.Point(47, 178);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(82, 20);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer:";
            // 
            // EditionValue
            // 
            this.EditionValue.AutoSize = true;
            this.EditionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.EditionValue.Location = new System.Drawing.Point(136, 110);
            this.EditionValue.Name = "EditionValue";
            this.EditionValue.Size = new System.Drawing.Size(99, 20);
            this.EditionValue.TabIndex = 3;
            this.EditionValue.Text = "Edition value";
            // 
            // CustomerValue
            // 
            this.CustomerValue.Location = new System.Drawing.Point(140, 178);
            this.CustomerValue.Name = "CustomerValue";
            this.CustomerValue.Size = new System.Drawing.Size(211, 20);
            this.CustomerValue.TabIndex = 4;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(357, 178);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CustomerValue);
            this.Controls.Add(this.EditionValue);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblEdition);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Deployment Dojo Winforms App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEdition;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label EditionValue;
        private System.Windows.Forms.TextBox CustomerValue;
        private System.Windows.Forms.Button SaveButton;
    }
}

