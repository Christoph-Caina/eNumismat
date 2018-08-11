namespace eNumismat
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neueDatenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adressbuchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adressbuchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tauschmonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.adressbuchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueDatenbankToolStripMenuItem,
            this.datenbankÖffnenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neueDatenbankToolStripMenuItem
            // 
            this.neueDatenbankToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_add;
            this.neueDatenbankToolStripMenuItem.Name = "neueDatenbankToolStripMenuItem";
            this.neueDatenbankToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neueDatenbankToolStripMenuItem.Text = "Neue Datenbank";
            this.neueDatenbankToolStripMenuItem.Click += new System.EventHandler(this.NeueDatenbankToolStripMenuItem_Click);
            // 
            // datenbankÖffnenToolStripMenuItem
            // 
            this.datenbankÖffnenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_connect;
            this.datenbankÖffnenToolStripMenuItem.Name = "datenbankÖffnenToolStripMenuItem";
            this.datenbankÖffnenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.datenbankÖffnenToolStripMenuItem.Text = "Datenbank öffnen";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.door_in;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenBearbeitenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // einstellungenBearbeitenToolStripMenuItem
            // 
            this.einstellungenBearbeitenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.cog;
            this.einstellungenBearbeitenToolStripMenuItem.Name = "einstellungenBearbeitenToolStripMenuItem";
            this.einstellungenBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.einstellungenBearbeitenToolStripMenuItem.Text = "Einstellungen Bearbeiten";
            this.einstellungenBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.EinstellungenBearbeitenToolStripMenuItem_Click);
            // 
            // adressbuchToolStripMenuItem
            // 
            this.adressbuchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adressbuchToolStripMenuItem1,
            this.tauschmonitorToolStripMenuItem});
            this.adressbuchToolStripMenuItem.Name = "adressbuchToolStripMenuItem";
            this.adressbuchToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.adressbuchToolStripMenuItem.Text = "Extras";
            // 
            // adressbuchToolStripMenuItem1
            // 
            this.adressbuchToolStripMenuItem1.Image = global::eNumismat.Properties.Resources.book_addresses;
            this.adressbuchToolStripMenuItem1.Name = "adressbuchToolStripMenuItem1";
            this.adressbuchToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.adressbuchToolStripMenuItem1.Text = "Adressbuch";
            this.adressbuchToolStripMenuItem1.Click += new System.EventHandler(this.adressbuchToolStripMenuItem1_Click);
            // 
            // tauschmonitorToolStripMenuItem
            // 
            this.tauschmonitorToolStripMenuItem.Image = global::eNumismat.Properties.Resources.table_refresh;
            this.tauschmonitorToolStripMenuItem.Name = "tauschmonitorToolStripMenuItem";
            this.tauschmonitorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tauschmonitorToolStripMenuItem.Text = "Tauschmonitor";
            this.tauschmonitorToolStripMenuItem.Click += new System.EventHandler(this.tauschmonitorToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 592);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(860, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 614);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "eNumismat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Show);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neueDatenbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenbankÖffnenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenBearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adressbuchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adressbuchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tauschmonitorToolStripMenuItem;
    }
}

