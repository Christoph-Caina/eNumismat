namespace eNumismat
{
    partial class SettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_AutoFillCities = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_AutoFillFedStates = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_languageSelection = new System.Windows.Forms.ComboBox();
            this.cb_MinimizeToTray = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_DbBackUpOnAppExit = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_DbCompressionBeforeBackup = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cb_languageSelection);
            this.tabPage1.Controls.Add(this.cb_MinimizeToTray);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.cb_AutoFillCities);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cb_AutoFillFedStates);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cb_AutoFillCities
            // 
            resources.ApplyResources(this.cb_AutoFillCities, "cb_AutoFillCities");
            this.cb_AutoFillCities.Name = "cb_AutoFillCities";
            this.cb_AutoFillCities.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // cb_AutoFillFedStates
            // 
            resources.ApplyResources(this.cb_AutoFillFedStates, "cb_AutoFillFedStates");
            this.cb_AutoFillFedStates.Name = "cb_AutoFillFedStates";
            this.cb_AutoFillFedStates.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cb_languageSelection
            // 
            resources.ApplyResources(this.cb_languageSelection, "cb_languageSelection");
            this.cb_languageSelection.FormattingEnabled = true;
            this.cb_languageSelection.Name = "cb_languageSelection";
            // 
            // cb_MinimizeToTray
            // 
            resources.ApplyResources(this.cb_MinimizeToTray, "cb_MinimizeToTray");
            this.cb_MinimizeToTray.Name = "cb_MinimizeToTray";
            this.cb_MinimizeToTray.UseVisualStyleBackColor = true;
            this.cb_MinimizeToTray.CheckedChanged += new System.EventHandler(this.cb_MinimizeToTray_CheckedChanged);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cb_DbBackUpOnAppExit);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cb_DbCompressionBeforeBackup);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cb_DbBackUpOnAppExit
            // 
            resources.ApplyResources(this.cb_DbBackUpOnAppExit, "cb_DbBackUpOnAppExit");
            this.cb_DbBackUpOnAppExit.Name = "cb_DbBackUpOnAppExit";
            this.cb_DbBackUpOnAppExit.UseVisualStyleBackColor = true;
            this.cb_DbBackUpOnAppExit.CheckedChanged += new System.EventHandler(this.cb_DbBackUpOnAppExit_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cb_DbCompressionBeforeBackup
            // 
            resources.ApplyResources(this.cb_DbCompressionBeforeBackup, "cb_DbCompressionBeforeBackup");
            this.cb_DbCompressionBeforeBackup.Name = "cb_DbCompressionBeforeBackup";
            this.cb_DbCompressionBeforeBackup.UseVisualStyleBackColor = true;
            this.cb_DbCompressionBeforeBackup.CheckedChanged += new System.EventHandler(this.cb_DbCompressionBeforeBackup_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Name = "panel1";
            // 
            // btn_Cancel
            // 
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.btn_Save;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsDialog";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cb_MinimizeToTray;
        private System.Windows.Forms.CheckBox cb_DbBackUpOnAppExit;
        private System.Windows.Forms.CheckBox cb_DbCompressionBeforeBackup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_languageSelection;
        private System.Windows.Forms.CheckBox cb_AutoFillFedStates;
        private System.Windows.Forms.CheckBox cb_AutoFillCities;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}