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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neueDatenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.datenbankSichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankKomprimierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdressbuchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TauschmonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachUpdatesSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überENumismatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeZuENumismatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.spracheÄndernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.ExtrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueDatenbankToolStripMenuItem,
            this.datenbankÖffnenToolStripMenuItem,
            this.toolStripSeparator2,
            this.datenbankSichernToolStripMenuItem,
            this.datenbankKomprimierenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            resources.ApplyResources(this.dateiToolStripMenuItem, "dateiToolStripMenuItem");
            // 
            // neueDatenbankToolStripMenuItem
            // 
            this.neueDatenbankToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_add;
            this.neueDatenbankToolStripMenuItem.Name = "neueDatenbankToolStripMenuItem";
            resources.ApplyResources(this.neueDatenbankToolStripMenuItem, "neueDatenbankToolStripMenuItem");
            this.neueDatenbankToolStripMenuItem.Click += new System.EventHandler(this.NeueDatenbankToolStripMenuItem_Click);
            // 
            // datenbankÖffnenToolStripMenuItem
            // 
            this.datenbankÖffnenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_connect;
            this.datenbankÖffnenToolStripMenuItem.Name = "datenbankÖffnenToolStripMenuItem";
            resources.ApplyResources(this.datenbankÖffnenToolStripMenuItem, "datenbankÖffnenToolStripMenuItem");
            this.datenbankÖffnenToolStripMenuItem.Click += new System.EventHandler(this.DatenbankOeffnenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // datenbankSichernToolStripMenuItem
            // 
            this.datenbankSichernToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_save;
            this.datenbankSichernToolStripMenuItem.Name = "datenbankSichernToolStripMenuItem";
            resources.ApplyResources(this.datenbankSichernToolStripMenuItem, "datenbankSichernToolStripMenuItem");
            this.datenbankSichernToolStripMenuItem.Click += new System.EventHandler(this.DatenbankSichernToolStripMenuItem_Click);
            // 
            // datenbankKomprimierenToolStripMenuItem
            // 
            this.datenbankKomprimierenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.compress;
            this.datenbankKomprimierenToolStripMenuItem.Name = "datenbankKomprimierenToolStripMenuItem";
            resources.ApplyResources(this.datenbankKomprimierenToolStripMenuItem, "datenbankKomprimierenToolStripMenuItem");
            this.datenbankKomprimierenToolStripMenuItem.Click += new System.EventHandler(this.datenbankKomprimierenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.door_in;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            resources.ApplyResources(this.beendenToolStripMenuItem, "beendenToolStripMenuItem");
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.BeendenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenBearbeitenToolStripMenuItem,
            this.spracheÄndernToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            resources.ApplyResources(this.einstellungenToolStripMenuItem, "einstellungenToolStripMenuItem");
            // 
            // einstellungenBearbeitenToolStripMenuItem
            // 
            this.einstellungenBearbeitenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.cog;
            this.einstellungenBearbeitenToolStripMenuItem.Name = "einstellungenBearbeitenToolStripMenuItem";
            resources.ApplyResources(this.einstellungenBearbeitenToolStripMenuItem, "einstellungenBearbeitenToolStripMenuItem");
            this.einstellungenBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.EinstellungenBearbeitenToolStripMenuItem_Click);
            // 
            // ExtrasToolStripMenuItem
            // 
            this.ExtrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdressbuchToolStripMenuItem,
            this.TauschmonitorToolStripMenuItem});
            this.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem";
            resources.ApplyResources(this.ExtrasToolStripMenuItem, "ExtrasToolStripMenuItem");
            // 
            // AdressbuchToolStripMenuItem
            // 
            this.AdressbuchToolStripMenuItem.Image = global::eNumismat.Properties.Resources.book_addresses;
            this.AdressbuchToolStripMenuItem.Name = "AdressbuchToolStripMenuItem";
            resources.ApplyResources(this.AdressbuchToolStripMenuItem, "AdressbuchToolStripMenuItem");
            this.AdressbuchToolStripMenuItem.Click += new System.EventHandler(this.AdressbuchToolStripMenuItem_Click);
            // 
            // TauschmonitorToolStripMenuItem
            // 
            this.TauschmonitorToolStripMenuItem.Image = global::eNumismat.Properties.Resources.table_refresh;
            this.TauschmonitorToolStripMenuItem.Name = "TauschmonitorToolStripMenuItem";
            resources.ApplyResources(this.TauschmonitorToolStripMenuItem, "TauschmonitorToolStripMenuItem");
            this.TauschmonitorToolStripMenuItem.Click += new System.EventHandler(this.TauschmonitorToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nachUpdatesSuchenToolStripMenuItem,
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem,
            this.überENumismatToolStripMenuItem,
            this.hilfeZuENumismatToolStripMenuItem});
            this.hilfeToolStripMenuItem.Image = global::eNumismat.Properties.Resources.help;
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            resources.ApplyResources(this.hilfeToolStripMenuItem, "hilfeToolStripMenuItem");
            // 
            // nachUpdatesSuchenToolStripMenuItem
            // 
            resources.ApplyResources(this.nachUpdatesSuchenToolStripMenuItem, "nachUpdatesSuchenToolStripMenuItem");
            this.nachUpdatesSuchenToolStripMenuItem.Name = "nachUpdatesSuchenToolStripMenuItem";
            // 
            // unicodeTabelleFürWährungssymboleToolStripMenuItem
            // 
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem.Name = "unicodeTabelleFürWährungssymboleToolStripMenuItem";
            resources.ApplyResources(this.unicodeTabelleFürWährungssymboleToolStripMenuItem, "unicodeTabelleFürWährungssymboleToolStripMenuItem");
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem.Click += new System.EventHandler(this.UnicodeTabelleFuerWaehrungssymboleToolStripMenuItem_Click);
            // 
            // überENumismatToolStripMenuItem
            // 
            this.überENumismatToolStripMenuItem.Name = "überENumismatToolStripMenuItem";
            resources.ApplyResources(this.überENumismatToolStripMenuItem, "überENumismatToolStripMenuItem");
            this.überENumismatToolStripMenuItem.Click += new System.EventHandler(this.überENumismatToolStripMenuItem_Click);
            // 
            // hilfeZuENumismatToolStripMenuItem
            // 
            this.hilfeZuENumismatToolStripMenuItem.Image = global::eNumismat.Properties.Resources.help;
            this.hilfeZuENumismatToolStripMenuItem.Name = "hilfeZuENumismatToolStripMenuItem";
            resources.ApplyResources(this.hilfeZuENumismatToolStripMenuItem, "hilfeZuENumismatToolStripMenuItem");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // spracheÄndernToolStripMenuItem
            // 
            this.spracheÄndernToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschToolStripMenuItem,
            this.englischToolStripMenuItem});
            this.spracheÄndernToolStripMenuItem.Name = "spracheÄndernToolStripMenuItem";
            resources.ApplyResources(this.spracheÄndernToolStripMenuItem, "spracheÄndernToolStripMenuItem");
            // 
            // deutschToolStripMenuItem
            // 
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            // 
            // englischToolStripMenuItem
            // 
            this.englischToolStripMenuItem.Name = "englischToolStripMenuItem";
            resources.ApplyResources(this.englischToolStripMenuItem, "englischToolStripMenuItem");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Show);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem ExtrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdressbuchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TauschmonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nachUpdatesSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unicodeTabelleFürWährungssymboleToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem datenbankSichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ToolStripMenuItem datenbankKomprimierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überENumismatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeZuENumismatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spracheÄndernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englischToolStripMenuItem;
    }
}

