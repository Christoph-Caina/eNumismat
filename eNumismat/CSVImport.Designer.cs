namespace eNumismat
{
    partial class CSVImport
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
            this.resultData = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cb_HasHeader = new System.Windows.Forms.CheckBox();
            this.cb_separator = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_name1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_name2 = new System.Windows.Forms.ComboBox();
            this.cb_familyname = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_gender = new System.Windows.Forms.ComboBox();
            this.cb_birthdate = new System.Windows.Forms.ComboBox();
            this.cb_addrline1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_addrline2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_postalcode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_city = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_state = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_country = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_phone = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_mobile = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cb_email = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_notes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultData
            // 
            this.resultData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultData.Location = new System.Drawing.Point(12, 205);
            this.resultData.Name = "resultData";
            this.resultData.Size = new System.Drawing.Size(629, 416);
            this.resultData.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(566, 627);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Import";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(474, 627);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // cb_HasHeader
            // 
            this.cb_HasHeader.AutoSize = true;
            this.cb_HasHeader.Location = new System.Drawing.Point(12, 12);
            this.cb_HasHeader.Name = "cb_HasHeader";
            this.cb_HasHeader.Size = new System.Drawing.Size(92, 17);
            this.cb_HasHeader.TabIndex = 3;
            this.cb_HasHeader.Text = "File has heder";
            this.cb_HasHeader.UseVisualStyleBackColor = true;
            // 
            // cb_separator
            // 
            this.cb_separator.FormattingEnabled = true;
            this.cb_separator.Items.AddRange(new object[] {
            ", (comma)",
            "; (semicolon)",
            "\\t (tabulator)"});
            this.cb_separator.Location = new System.Drawing.Point(183, 10);
            this.cb_separator.Name = "cb_separator";
            this.cb_separator.Size = new System.Drawing.Size(121, 21);
            this.cb_separator.TabIndex = 4;
            this.cb_separator.SelectedValueChanged += new System.EventHandler(this.cb_separator_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Separator:";
            // 
            // cb_name1
            // 
            this.cb_name1.FormattingEnabled = true;
            this.cb_name1.Location = new System.Drawing.Point(79, 19);
            this.cb_name1.Name = "cb_name1";
            this.cb_name1.Size = new System.Drawing.Size(121, 21);
            this.cb_name1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cb_notes);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cb_email);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cb_mobile);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cb_phone);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cb_country);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cb_state);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cb_city);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cb_postalcode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cb_addrline2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cb_addrline1);
            this.groupBox1.Controls.Add(this.cb_birthdate);
            this.groupBox1.Controls.Add(this.cb_gender);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cb_familyname);
            this.groupBox1.Controls.Add(this.cb_name2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_name1);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 162);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header Assignment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "FamilyName:";
            // 
            // cb_name2
            // 
            this.cb_name2.FormattingEnabled = true;
            this.cb_name2.Location = new System.Drawing.Point(79, 46);
            this.cb_name2.Name = "cb_name2";
            this.cb_name2.Size = new System.Drawing.Size(121, 21);
            this.cb_name2.TabIndex = 10;
            // 
            // cb_familyname
            // 
            this.cb_familyname.FormattingEnabled = true;
            this.cb_familyname.Location = new System.Drawing.Point(79, 73);
            this.cb_familyname.Name = "cb_familyname";
            this.cb_familyname.Size = new System.Drawing.Size(121, 21);
            this.cb_familyname.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Gender:";
            // 
            // cb_gender
            // 
            this.cb_gender.FormattingEnabled = true;
            this.cb_gender.Location = new System.Drawing.Point(79, 100);
            this.cb_gender.Name = "cb_gender";
            this.cb_gender.Size = new System.Drawing.Size(121, 21);
            this.cb_gender.TabIndex = 13;
            // 
            // cb_birthdate
            // 
            this.cb_birthdate.FormattingEnabled = true;
            this.cb_birthdate.Location = new System.Drawing.Point(79, 127);
            this.cb_birthdate.Name = "cb_birthdate";
            this.cb_birthdate.Size = new System.Drawing.Size(121, 21);
            this.cb_birthdate.TabIndex = 14;
            // 
            // cb_addrline1
            // 
            this.cb_addrline1.FormattingEnabled = true;
            this.cb_addrline1.Location = new System.Drawing.Point(286, 19);
            this.cb_addrline1.Name = "cb_addrline1";
            this.cb_addrline1.Size = new System.Drawing.Size(121, 21);
            this.cb_addrline1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Birthdate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "AddressLine1:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "AddressLine2:";
            // 
            // cb_addrline2
            // 
            this.cb_addrline2.FormattingEnabled = true;
            this.cb_addrline2.Location = new System.Drawing.Point(286, 46);
            this.cb_addrline2.Name = "cb_addrline2";
            this.cb_addrline2.Size = new System.Drawing.Size(121, 21);
            this.cb_addrline2.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "PostalCode:";
            // 
            // cb_postalcode
            // 
            this.cb_postalcode.FormattingEnabled = true;
            this.cb_postalcode.Location = new System.Drawing.Point(286, 73);
            this.cb_postalcode.Name = "cb_postalcode";
            this.cb_postalcode.Size = new System.Drawing.Size(121, 21);
            this.cb_postalcode.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "City:";
            // 
            // cb_city
            // 
            this.cb_city.FormattingEnabled = true;
            this.cb_city.Location = new System.Drawing.Point(286, 100);
            this.cb_city.Name = "cb_city";
            this.cb_city.Size = new System.Drawing.Size(121, 21);
            this.cb_city.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(206, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "State:";
            // 
            // cb_state
            // 
            this.cb_state.FormattingEnabled = true;
            this.cb_state.Location = new System.Drawing.Point(286, 127);
            this.cb_state.Name = "cb_state";
            this.cb_state.Size = new System.Drawing.Size(121, 21);
            this.cb_state.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(413, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Country:";
            // 
            // cb_country
            // 
            this.cb_country.FormattingEnabled = true;
            this.cb_country.Location = new System.Drawing.Point(493, 19);
            this.cb_country.Name = "cb_country";
            this.cb_country.Size = new System.Drawing.Size(121, 21);
            this.cb_country.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(414, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Phone:";
            // 
            // cb_phone
            // 
            this.cb_phone.FormattingEnabled = true;
            this.cb_phone.Location = new System.Drawing.Point(494, 46);
            this.cb_phone.Name = "cb_phone";
            this.cb_phone.Size = new System.Drawing.Size(121, 21);
            this.cb_phone.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(414, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Mobile Phone:";
            // 
            // cb_mobile
            // 
            this.cb_mobile.FormattingEnabled = true;
            this.cb_mobile.Location = new System.Drawing.Point(494, 73);
            this.cb_mobile.Name = "cb_mobile";
            this.cb_mobile.Size = new System.Drawing.Size(121, 21);
            this.cb_mobile.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(414, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "E Mail:";
            // 
            // cb_email
            // 
            this.cb_email.FormattingEnabled = true;
            this.cb_email.Location = new System.Drawing.Point(494, 100);
            this.cb_email.Name = "cb_email";
            this.cb_email.Size = new System.Drawing.Size(121, 21);
            this.cb_email.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(414, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Notes:";
            // 
            // cb_notes
            // 
            this.cb_notes.FormattingEnabled = true;
            this.cb_notes.Location = new System.Drawing.Point(494, 127);
            this.cb_notes.Name = "cb_notes";
            this.cb_notes.Size = new System.Drawing.Size(121, 21);
            this.cb_notes.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CSVImport
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(654, 662);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_separator);
            this.Controls.Add(this.cb_HasHeader);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.resultData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CSVImport";
            this.Text = "CSVImport";
            this.Load += new System.EventHandler(this.CSVImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultData;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox cb_HasHeader;
        private System.Windows.Forms.ComboBox cb_separator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_name1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_addrline1;
        private System.Windows.Forms.ComboBox cb_birthdate;
        private System.Windows.Forms.ComboBox cb_gender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_familyname;
        private System.Windows.Forms.ComboBox cb_name2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cb_notes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cb_email;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_mobile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_phone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_country;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_state;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_city;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_postalcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_addrline2;
        private System.Windows.Forms.Button button1;
    }
}