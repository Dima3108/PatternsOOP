﻿namespace WindowsFormsMVC
{
    partial class AddOutleetModelForm
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
			this.numericArea = new System.Windows.Forms.NumericUpDown();
			this.LArea = new System.Windows.Forms.Label();
			this.checkBoxPresenceOfAirConditioning = new System.Windows.Forms.CheckBox();
			this.numericAllocatedPowerKilowatts = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericNumberOfWindows = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericStorey = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numericRentalCostPerDay = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.numericInventoryNumber = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericArea)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericAllocatedPowerKilowatts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericNumberOfWindows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericStorey)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericRentalCostPerDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericInventoryNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// numericArea
			// 
			this.numericArea.Location = new System.Drawing.Point(183, 17);
			this.numericArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericArea.Name = "numericArea";
			this.numericArea.Size = new System.Drawing.Size(80, 20);
			this.numericArea.TabIndex = 0;
			// 
			// LArea
			// 
			this.LArea.AutoSize = true;
			this.LArea.Location = new System.Drawing.Point(48, 17);
			this.LArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LArea.Name = "LArea";
			this.LArea.Size = new System.Drawing.Size(119, 13);
			this.LArea.TabIndex = 1;
			this.LArea.Text = "Площадь помещения:";
			// 
			// checkBoxPresenceOfAirConditioning
			// 
			this.checkBoxPresenceOfAirConditioning.AutoSize = true;
			this.checkBoxPresenceOfAirConditioning.Location = new System.Drawing.Point(183, 44);
			this.checkBoxPresenceOfAirConditioning.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxPresenceOfAirConditioning.Name = "checkBoxPresenceOfAirConditioning";
			this.checkBoxPresenceOfAirConditioning.Size = new System.Drawing.Size(163, 17);
			this.checkBoxPresenceOfAirConditioning.TabIndex = 2;
			this.checkBoxPresenceOfAirConditioning.Text = "Кондиционер присутствует";
			this.checkBoxPresenceOfAirConditioning.UseVisualStyleBackColor = true;
			// 
			// numericAllocatedPowerKilowatts
			// 
			this.numericAllocatedPowerKilowatts.Location = new System.Drawing.Point(183, 70);
			this.numericAllocatedPowerKilowatts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericAllocatedPowerKilowatts.Name = "numericAllocatedPowerKilowatts";
			this.numericAllocatedPowerKilowatts.Size = new System.Drawing.Size(80, 20);
			this.numericAllocatedPowerKilowatts.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 70);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Число выделенных киловат:";
			// 
			// numericNumberOfWindows
			// 
			this.numericNumberOfWindows.Location = new System.Drawing.Point(183, 100);
			this.numericNumberOfWindows.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericNumberOfWindows.Name = "numericNumberOfWindows";
			this.numericNumberOfWindows.Size = new System.Drawing.Size(80, 20);
			this.numericNumberOfWindows.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(99, 100);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Число окон:";
			// 
			// numericStorey
			// 
			this.numericStorey.Location = new System.Drawing.Point(183, 134);
			this.numericStorey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericStorey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numericStorey.Name = "numericStorey";
			this.numericStorey.Size = new System.Drawing.Size(80, 20);
			this.numericStorey.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(130, 134);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Этаж:";
			// 
			// numericRentalCostPerDay
			// 
			this.numericRentalCostPerDay.Location = new System.Drawing.Point(183, 162);
			this.numericRentalCostPerDay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericRentalCostPerDay.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericRentalCostPerDay.Name = "numericRentalCostPerDay";
			this.numericRentalCostPerDay.Size = new System.Drawing.Size(80, 20);
			this.numericRentalCostPerDay.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 166);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(142, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Стоимость аренды в день:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(386, 229);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 36);
			this.button1.TabIndex = 11;
			this.button1.Text = "Создать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(30, 229);
			this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(101, 36);
			this.button2.TabIndex = 12;
			this.button2.Text = "Отмена";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// numericInventoryNumber
			// 
			this.numericInventoryNumber.Location = new System.Drawing.Point(183, 189);
			this.numericInventoryNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericInventoryNumber.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericInventoryNumber.Name = "numericInventoryNumber";
			this.numericInventoryNumber.Size = new System.Drawing.Size(80, 20);
			this.numericInventoryNumber.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 192);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(111, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Инвертарный номер";
			// 
			// AddOutleetModelForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(533, 292);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numericInventoryNumber);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericRentalCostPerDay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericStorey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericNumberOfWindows);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericAllocatedPowerKilowatts);
			this.Controls.Add(this.checkBoxPresenceOfAirConditioning);
			this.Controls.Add(this.LArea);
			this.Controls.Add(this.numericArea);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "AddOutleetModelForm";
			this.Text = "AddOutleetModelForm";
			((System.ComponentModel.ISupportInitialize)(this.numericArea)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericAllocatedPowerKilowatts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericNumberOfWindows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericStorey)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericRentalCostPerDay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericInventoryNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericArea;
        private System.Windows.Forms.Label LArea;
        private System.Windows.Forms.CheckBox checkBoxPresenceOfAirConditioning;
        private System.Windows.Forms.NumericUpDown numericAllocatedPowerKilowatts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericNumberOfWindows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericStorey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericRentalCostPerDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericInventoryNumber;
        private System.Windows.Forms.Label label5;
    }
}