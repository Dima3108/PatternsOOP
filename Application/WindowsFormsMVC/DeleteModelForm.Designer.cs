namespace WindowsFormsMVC
{
    partial class DeleteModelForm
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
            this.buttonDelOk = new System.Windows.Forms.Button();
            this.buttonDelCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelInventoryNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStorey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDelOk
            // 
            this.buttonDelOk.Location = new System.Drawing.Point(898, 240);
            this.buttonDelOk.Name = "buttonDelOk";
            this.buttonDelOk.Size = new System.Drawing.Size(148, 44);
            this.buttonDelOk.TabIndex = 0;
            this.buttonDelOk.Text = "Да";
            this.buttonDelOk.UseVisualStyleBackColor = true;
            this.buttonDelOk.Click += new System.EventHandler(this.buttonDelOk_Click);
            // 
            // buttonDelCancel
            // 
            this.buttonDelCancel.Location = new System.Drawing.Point(40, 240);
            this.buttonDelCancel.Name = "buttonDelCancel";
            this.buttonDelCancel.Size = new System.Drawing.Size(143, 44);
            this.buttonDelCancel.TabIndex = 1;
            this.buttonDelCancel.Text = "Отмена";
            this.buttonDelCancel.UseVisualStyleBackColor = true;
            this.buttonDelCancel.Click += new System.EventHandler(this.buttonDelCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Удалить торговое помещение со следующими параметрами?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(171, 79);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 20);
            this.labelID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Инвертарный номер:";
            // 
            // labelInventoryNumber
            // 
            this.labelInventoryNumber.AutoSize = true;
            this.labelInventoryNumber.Location = new System.Drawing.Point(348, 113);
            this.labelInventoryNumber.Name = "labelInventoryNumber";
            this.labelInventoryNumber.Size = new System.Drawing.Size(0, 20);
            this.labelInventoryNumber.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Этаж:";
            // 
            // labelStorey
            // 
            this.labelStorey.AutoSize = true;
            this.labelStorey.Location = new System.Drawing.Point(230, 163);
            this.labelStorey.Name = "labelStorey";
            this.labelStorey.Size = new System.Drawing.Size(0, 20);
            this.labelStorey.TabIndex = 8;
            // 
            // DeleteModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 296);
            this.Controls.Add(this.labelStorey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelInventoryNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelCancel);
            this.Controls.Add(this.buttonDelOk);
            this.Name = "DeleteModelForm";
            this.Text = "DeleteModelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelOk;
        private System.Windows.Forms.Button buttonDelCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelInventoryNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelStorey;
    }
}