namespace PsMinder
{
    partial class Reminder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpbxReminderPsMinder = new System.Windows.Forms.GroupBox();
            this.lklblReminderPrescriptionInfo = new System.Windows.Forms.LinkLabel();
            this.btnReminderExit = new System.Windows.Forms.Button();
            this.lklblReminderEmail = new System.Windows.Forms.LinkLabel();
            this.grpbxReminderInfo = new System.Windows.Forms.GroupBox();
            this.lblReminderTip = new System.Windows.Forms.Label();
            this.dataGridReminderPrescriptionInfo = new System.Windows.Forms.DataGridView();
            this.lklblReminderLinkedIn = new System.Windows.Forms.LinkLabel();
            this.lklbReminderSignout = new System.Windows.Forms.LinkLabel();
            this.lklblReminderLog = new System.Windows.Forms.LinkLabel();
            this.lklblReminderMedicineInfo = new System.Windows.Forms.LinkLabel();
            this.lklblReminderPetInfo = new System.Windows.Forms.LinkLabel();
            this.lklblReminderReminder = new System.Windows.Forms.LinkLabel();
            this.DateTimePickerReminder = new System.Windows.Forms.DateTimePicker();
            this.grpbxReminderPsMinder.SuspendLayout();
            this.grpbxReminderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReminderPrescriptionInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbxReminderPsMinder
            // 
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderPrescriptionInfo);
            this.grpbxReminderPsMinder.Controls.Add(this.btnReminderExit);
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderEmail);
            this.grpbxReminderPsMinder.Controls.Add(this.grpbxReminderInfo);
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderLinkedIn);
            this.grpbxReminderPsMinder.Controls.Add(this.lklbReminderSignout);
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderLog);
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderMedicineInfo);
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderPetInfo);
            this.grpbxReminderPsMinder.Controls.Add(this.lklblReminderReminder);
            this.grpbxReminderPsMinder.Controls.Add(this.DateTimePickerReminder);
            this.grpbxReminderPsMinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpbxReminderPsMinder.Location = new System.Drawing.Point(12, 12);
            this.grpbxReminderPsMinder.Name = "grpbxReminderPsMinder";
            this.grpbxReminderPsMinder.Size = new System.Drawing.Size(1002, 723);
            this.grpbxReminderPsMinder.TabIndex = 1;
            this.grpbxReminderPsMinder.TabStop = false;
            this.grpbxReminderPsMinder.Text = "Ps Minder";
            // 
            // lklblReminderPrescriptionInfo
            // 
            this.lklblReminderPrescriptionInfo.AutoSize = true;
            this.lklblReminderPrescriptionInfo.Location = new System.Drawing.Point(368, 35);
            this.lklblReminderPrescriptionInfo.Name = "lklblReminderPrescriptionInfo";
            this.lklblReminderPrescriptionInfo.Size = new System.Drawing.Size(83, 13);
            this.lklblReminderPrescriptionInfo.TabIndex = 12;
            this.lklblReminderPrescriptionInfo.TabStop = true;
            this.lklblReminderPrescriptionInfo.Text = "Prescription Info";
            this.lklblReminderPrescriptionInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblReminderPrescriptionInfo_LinkClicked);
            // 
            // btnReminderExit
            // 
            this.btnReminderExit.Location = new System.Drawing.Point(889, 666);
            this.btnReminderExit.Name = "btnReminderExit";
            this.btnReminderExit.Size = new System.Drawing.Size(75, 23);
            this.btnReminderExit.TabIndex = 11;
            this.btnReminderExit.Text = "Exit Program";
            this.btnReminderExit.UseVisualStyleBackColor = true;
            this.btnReminderExit.Click += new System.EventHandler(this.btnReminderExit_Click);
            // 
            // lklblReminderEmail
            // 
            this.lklblReminderEmail.AutoSize = true;
            this.lklblReminderEmail.Location = new System.Drawing.Point(129, 671);
            this.lklblReminderEmail.Name = "lklblReminderEmail";
            this.lklblReminderEmail.Size = new System.Drawing.Size(50, 13);
            this.lklblReminderEmail.TabIndex = 10;
            this.lklblReminderEmail.TabStop = true;
            this.lklblReminderEmail.Text = "Email Me";
            this.lklblReminderEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblReminderEmail_LinkClicked);
            // 
            // grpbxReminderInfo
            // 
            this.grpbxReminderInfo.Controls.Add(this.lblReminderTip);
            this.grpbxReminderInfo.Controls.Add(this.dataGridReminderPrescriptionInfo);
            this.grpbxReminderInfo.Location = new System.Drawing.Point(12, 78);
            this.grpbxReminderInfo.Name = "grpbxReminderInfo";
            this.grpbxReminderInfo.Size = new System.Drawing.Size(974, 582);
            this.grpbxReminderInfo.TabIndex = 5;
            this.grpbxReminderInfo.TabStop = false;
            this.grpbxReminderInfo.Text = "Reminder Information";
            // 
            // lblReminderTip
            // 
            this.lblReminderTip.AutoSize = true;
            this.lblReminderTip.Location = new System.Drawing.Point(7, 545);
            this.lblReminderTip.Name = "lblReminderTip";
            this.lblReminderTip.Size = new System.Drawing.Size(389, 13);
            this.lblReminderTip.TabIndex = 1;
            this.lblReminderTip.Text = "*Reminders will be sent out 10, 5, 3, and 1 day before the projected restock date" +
    ".";
            // 
            // dataGridReminderPrescriptionInfo
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReminderPrescriptionInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridReminderPrescriptionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridReminderPrescriptionInfo.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridReminderPrescriptionInfo.Location = new System.Drawing.Point(7, 19);
            this.dataGridReminderPrescriptionInfo.Name = "dataGridReminderPrescriptionInfo";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReminderPrescriptionInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridReminderPrescriptionInfo.Size = new System.Drawing.Size(945, 508);
            this.dataGridReminderPrescriptionInfo.TabIndex = 0;
            // 
            // lklblReminderLinkedIn
            // 
            this.lklblReminderLinkedIn.AutoSize = true;
            this.lklblReminderLinkedIn.Location = new System.Drawing.Point(17, 671);
            this.lklblReminderLinkedIn.Name = "lklblReminderLinkedIn";
            this.lklblReminderLinkedIn.Size = new System.Drawing.Size(87, 13);
            this.lklblReminderLinkedIn.TabIndex = 9;
            this.lklblReminderLinkedIn.TabStop = true;
            this.lklblReminderLinkedIn.Text = "Visit My LinkedIn";
            this.lklblReminderLinkedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblReminderLinkedIn_LinkClicked);
            // 
            // lklbReminderSignout
            // 
            this.lklbReminderSignout.AutoSize = true;
            this.lklbReminderSignout.Location = new System.Drawing.Point(772, 36);
            this.lklbReminderSignout.Name = "lklbReminderSignout";
            this.lklbReminderSignout.Size = new System.Drawing.Size(48, 13);
            this.lklbReminderSignout.TabIndex = 4;
            this.lklbReminderSignout.TabStop = true;
            this.lklbReminderSignout.Text = "Sign Out";
            this.lklbReminderSignout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklbReminderSignout_LinkClicked);
            // 
            // lklblReminderLog
            // 
            this.lklblReminderLog.AutoSize = true;
            this.lklblReminderLog.Location = new System.Drawing.Point(725, 36);
            this.lklblReminderLog.Name = "lklblReminderLog";
            this.lklblReminderLog.Size = new System.Drawing.Size(30, 13);
            this.lklblReminderLog.TabIndex = 3;
            this.lklblReminderLog.TabStop = true;
            this.lklblReminderLog.Text = "Logs";
            // 
            // lklblReminderMedicineInfo
            // 
            this.lklblReminderMedicineInfo.AutoSize = true;
            this.lklblReminderMedicineInfo.Location = new System.Drawing.Point(457, 35);
            this.lklblReminderMedicineInfo.Name = "lklblReminderMedicineInfo";
            this.lklblReminderMedicineInfo.Size = new System.Drawing.Size(135, 13);
            this.lklblReminderMedicineInfo.TabIndex = 2;
            this.lklblReminderMedicineInfo.TabStop = true;
            this.lklblReminderMedicineInfo.Text = "Medicine Info and Restock";
            this.lklblReminderMedicineInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblReminderMedicineInfo_LinkClicked);
            // 
            // lklblReminderPetInfo
            // 
            this.lklblReminderPetInfo.AutoSize = true;
            this.lklblReminderPetInfo.Location = new System.Drawing.Point(627, 36);
            this.lklblReminderPetInfo.Name = "lklblReminderPetInfo";
            this.lklblReminderPetInfo.Size = new System.Drawing.Size(44, 13);
            this.lklblReminderPetInfo.TabIndex = 1;
            this.lklblReminderPetInfo.TabStop = true;
            this.lklblReminderPetInfo.Text = "Pet Info";
            this.lklblReminderPetInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblReminderPetInfo_LinkClicked);
            // 
            // lklblReminderReminder
            // 
            this.lklblReminderReminder.AutoSize = true;
            this.lklblReminderReminder.Location = new System.Drawing.Point(297, 36);
            this.lklblReminderReminder.Name = "lklblReminderReminder";
            this.lklblReminderReminder.Size = new System.Drawing.Size(52, 13);
            this.lklblReminderReminder.TabIndex = 1;
            this.lklblReminderReminder.TabStop = true;
            this.lklblReminderReminder.Text = "Reminder";
            // 
            // DateTimePickerReminder
            // 
            this.DateTimePickerReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateTimePickerReminder.Location = new System.Drawing.Point(12, 29);
            this.DateTimePickerReminder.Name = "DateTimePickerReminder";
            this.DateTimePickerReminder.Size = new System.Drawing.Size(202, 20);
            this.DateTimePickerReminder.TabIndex = 0;
            // 
            // Reminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 747);
            this.Controls.Add(this.grpbxReminderPsMinder);
            this.Name = "Reminder";
            this.Text = "Reminder";
            this.Load += new System.EventHandler(this.Reminder_Load);
            this.grpbxReminderPsMinder.ResumeLayout(false);
            this.grpbxReminderPsMinder.PerformLayout();
            this.grpbxReminderInfo.ResumeLayout(false);
            this.grpbxReminderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReminderPrescriptionInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxReminderPsMinder;
        private System.Windows.Forms.Button btnReminderExit;
        private System.Windows.Forms.LinkLabel lklblReminderEmail;
        private System.Windows.Forms.GroupBox grpbxReminderInfo;
        private System.Windows.Forms.DataGridView dataGridReminderPrescriptionInfo;
        private System.Windows.Forms.LinkLabel lklblReminderLinkedIn;
        private System.Windows.Forms.LinkLabel lklbReminderSignout;
        private System.Windows.Forms.LinkLabel lklblReminderLog;
        private System.Windows.Forms.LinkLabel lklblReminderMedicineInfo;
        private System.Windows.Forms.LinkLabel lklblReminderPetInfo;
        private System.Windows.Forms.LinkLabel lklblReminderReminder;
        private System.Windows.Forms.DateTimePicker DateTimePickerReminder;
        private System.Windows.Forms.Label lblReminderTip;
        private System.Windows.Forms.LinkLabel lklblReminderPrescriptionInfo;
    }
}