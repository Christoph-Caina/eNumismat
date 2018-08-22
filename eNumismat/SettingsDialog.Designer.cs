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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_AutoFillCities = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_AutoFillFedStates = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_ValidateNames = new System.Windows.Forms.CheckBox();
            this.cb_ValidateEmail = new System.Windows.Forms.CheckBox();
            this.cb_ValidateAddress = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cb_languageSelection);
            this.tabPage1.Controls.Add(this.cb_MinimizeToTray);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cb_languageSelection
            // 
            this.cb_languageSelection.FormattingEnabled = true;
            resources.ApplyResources(this.cb_languageSelection, "cb_languageSelection");
            this.cb_languageSelection.Name = "cb_languageSelection";
            // 
            // cb_MinimizeToTray
            // 
            resources.ApplyResources(this.cb_MinimizeToTray, "cb_MinimizeToTray");
            this.cb_MinimizeToTray.Name = "cb_MinimizeToTray";
            this.cb_MinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cb_DbBackUpOnAppExit);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cb_DbCompressionBeforeBackup);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
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
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Image = global::eNumismat.Properties.Resources.cancel;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.Name = "btn_Cancel";
            this.toolTip1.SetToolTip(this.btn_Cancel, resources.GetString("btn_Cancel.ToolTip"));
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::eNumismat.Properties.Resources.accept;
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.Name = "btn_Save";
            this.toolTip1.SetToolTip(this.btn_Save, resources.GetString("btn_Save.ToolTip"));
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_AutoFillCities);
            this.groupBox1.Controls.Add(this.cb_AutoFillFedStates);
            resources.ApplyResources(this.groupBox1, "groupBox1");
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
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cb_AutoFillFedStates
            // 
            resources.ApplyResources(this.cb_AutoFillFedStates, "cb_AutoFillFedStates");
            this.cb_AutoFillFedStates.Name = "cb_AutoFillFedStates";
            this.cb_AutoFillFedStates.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_ValidateAddress);
            this.groupBox2.Controls.Add(this.cb_ValidateEmail);
            this.groupBox2.Controls.Add(this.cb_ValidateNames);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cb_ValidateNames
            // 
            resources.ApplyResources(this.cb_ValidateNames, "cb_ValidateNames");
            this.cb_ValidateNames.Name = "cb_ValidateNames";
            this.cb_ValidateNames.UseVisualStyleBackColor = true;
            // 
            // cb_ValidateEmail
            // 
            resources.ApplyResources(this.cb_ValidateEmail, "cb_ValidateEmail");
            this.cb_ValidateEmail.Name = "cb_ValidateEmail";
            this.cb_ValidateEmail.UseVisualStyleBackColor = true;
            // 
            // cb_ValidateAddress
            // 
            resources.ApplyResources(this.cb_ValidateAddress, "cb_ValidateAddress");
            this.cb_ValidateAddress.Name = "cb_ValidateAddress";
            this.cb_ValidateAddress.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_Save);
            this.flowLayoutPanel1.Controls.Add(this.btn_Cancel);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.btn_Save;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsDialog";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_languageSelection;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_ValidateAddress;
        private System.Windows.Forms.CheckBox cb_ValidateEmail;
        private System.Windows.Forms.CheckBox cb_ValidateNames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_AutoFillCities;
        private System.Windows.Forms.CheckBox cb_AutoFillFedStates;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
    }
}