namespace NSites_V.ApplicationObjects.UserInterfaces.HRISs.Transactions
{
    partial class ChangeShiftScheduleUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeShiftScheduleUI));
            this.pnlBody = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNextDay = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBreakOut = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.dtpBreakIn = new System.Windows.Forms.DateTimePicker();
            this.chkBreak = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.dtpTimeIn = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeOut = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Controls.Add(this.txtEmployeeName);
            this.pnlBody.Controls.Add(this.dtpEndDate);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.lblDay);
            this.pnlBody.Controls.Add(this.dtpStartDate);
            this.pnlBody.Controls.Add(this.label4);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Location = new System.Drawing.Point(12, 11);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(556, 328);
            this.pnlBody.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNextDay);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpBreakOut);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label56);
            this.groupBox1.Controls.Add(this.dtpBreakIn);
            this.groupBox1.Controls.Add(this.chkBreak);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.label57);
            this.groupBox1.Controls.Add(this.dtpTimeIn);
            this.groupBox1.Controls.Add(this.dtpTimeOut);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 105);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shift Schedule";
            // 
            // chkNextDay
            // 
            this.chkNextDay.AutoSize = true;
            this.chkNextDay.ForeColor = System.Drawing.Color.Black;
            this.chkNextDay.Location = new System.Drawing.Point(385, 60);
            this.chkNextDay.Name = "chkNextDay";
            this.chkNextDay.Size = new System.Drawing.Size(18, 17);
            this.chkNextDay.TabIndex = 216;
            this.chkNextDay.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(358, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 23);
            this.label7.TabIndex = 215;
            this.label7.Text = "Next Day";
            // 
            // dtpBreakOut
            // 
            this.dtpBreakOut.CustomFormat = "hh:mm tt";
            this.dtpBreakOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBreakOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBreakOut.Location = new System.Drawing.Point(98, 55);
            this.dtpBreakOut.Name = "dtpBreakOut";
            this.dtpBreakOut.ShowUpDown = true;
            this.dtpBreakOut.Size = new System.Drawing.Size(81, 29);
            this.dtpBreakOut.TabIndex = 206;
            this.dtpBreakOut.Value = new System.DateTime(2012, 9, 18, 12, 0, 0, 0);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Blue;
            this.label35.Location = new System.Drawing.Point(25, 31);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(66, 23);
            this.label35.TabIndex = 203;
            this.label35.Text = "Time In";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Blue;
            this.label56.Location = new System.Drawing.Point(201, 31);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(71, 23);
            this.label56.TabIndex = 207;
            this.label56.Text = "Break In";
            // 
            // dtpBreakIn
            // 
            this.dtpBreakIn.CustomFormat = "hh:mm tt";
            this.dtpBreakIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBreakIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBreakIn.Location = new System.Drawing.Point(185, 55);
            this.dtpBreakIn.Name = "dtpBreakIn";
            this.dtpBreakIn.ShowUpDown = true;
            this.dtpBreakIn.Size = new System.Drawing.Size(81, 29);
            this.dtpBreakIn.TabIndex = 208;
            this.dtpBreakIn.Value = new System.DateTime(2012, 9, 18, 13, 0, 0, 0);
            // 
            // chkBreak
            // 
            this.chkBreak.AutoSize = true;
            this.chkBreak.Checked = true;
            this.chkBreak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBreak.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBreak.ForeColor = System.Drawing.Color.Black;
            this.chkBreak.Location = new System.Drawing.Point(453, 60);
            this.chkBreak.Name = "chkBreak";
            this.chkBreak.Size = new System.Drawing.Size(18, 17);
            this.chkBreak.TabIndex = 212;
            this.chkBreak.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(427, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 211;
            this.label3.Text = "With Break";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Blue;
            this.label50.Location = new System.Drawing.Point(106, 31);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(84, 23);
            this.label50.TabIndex = 205;
            this.label50.Text = "Break Out";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Blue;
            this.label57.Location = new System.Drawing.Point(283, 31);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(79, 23);
            this.label57.TabIndex = 209;
            this.label57.Text = "Time Out";
            // 
            // dtpTimeIn
            // 
            this.dtpTimeIn.CustomFormat = "hh:mm tt";
            this.dtpTimeIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeIn.Location = new System.Drawing.Point(11, 55);
            this.dtpTimeIn.Name = "dtpTimeIn";
            this.dtpTimeIn.ShowUpDown = true;
            this.dtpTimeIn.Size = new System.Drawing.Size(81, 29);
            this.dtpTimeIn.TabIndex = 204;
            this.dtpTimeIn.Value = new System.DateTime(2012, 9, 18, 8, 0, 0, 0);
            // 
            // dtpTimeOut
            // 
            this.dtpTimeOut.CustomFormat = "hh:mm tt";
            this.dtpTimeOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeOut.Location = new System.Drawing.Point(272, 55);
            this.dtpTimeOut.Name = "dtpTimeOut";
            this.dtpTimeOut.ShowUpDown = true;
            this.dtpTimeOut.Size = new System.Drawing.Size(81, 29);
            this.dtpTimeOut.TabIndex = 210;
            this.dtpTimeOut.Value = new System.DateTime(2012, 9, 18, 17, 0, 0, 0);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(129, 33);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(323, 29);
            this.txtEmployeeName.TabIndex = 154;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "MM-dd-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(129, 95);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(111, 22);
            this.dtpEndDate.TabIndex = 153;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 152;
            this.label2.Text = "End Date";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.Color.Red;
            this.lblDay.Location = new System.Drawing.Point(248, 68);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(0, 23);
            this.lblDay.TabIndex = 151;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MM-dd-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(129, 64);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(111, 22);
            this.dtpStartDate.TabIndex = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 149;
            this.label4.Text = "Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 146;
            this.label1.Text = "Employee Name";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(232, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = " &Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ChangeShiftScheduleUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(580, 351);
            this.Controls.Add(this.pnlBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeShiftScheduleUI";
            this.Text = "Change Shift Schedule";
            this.Load += new System.EventHandler(this.ChangeShiftScheduleUI_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNextDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBreakOut;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.DateTimePicker dtpBreakIn;
        private System.Windows.Forms.CheckBox chkBreak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.DateTimePicker dtpTimeIn;
        private System.Windows.Forms.DateTimePicker dtpTimeOut;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
    }
}