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
            this.components = new System.ComponentModel.Container();
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
            this.spracheÄndernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.französischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdressbuchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TauschmonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachUpdatesSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überENumismatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeZuENumismatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.swapMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.datenbankSichernToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compressDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.ExtrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // dateiToolStripMenuItem
            // 
            resources.ApplyResources(this.dateiToolStripMenuItem, "dateiToolStripMenuItem");
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueDatenbankToolStripMenuItem,
            this.datenbankÖffnenToolStripMenuItem,
            this.toolStripSeparator2,
            this.datenbankSichernToolStripMenuItem,
            this.datenbankKomprimierenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            // 
            // neueDatenbankToolStripMenuItem
            // 
            resources.ApplyResources(this.neueDatenbankToolStripMenuItem, "neueDatenbankToolStripMenuItem");
            this.neueDatenbankToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_add;
            this.neueDatenbankToolStripMenuItem.Name = "neueDatenbankToolStripMenuItem";
            this.neueDatenbankToolStripMenuItem.Click += new System.EventHandler(this.NeueDatenbankToolStripMenuItem_Click);
            // 
            // datenbankÖffnenToolStripMenuItem
            // 
            resources.ApplyResources(this.datenbankÖffnenToolStripMenuItem, "datenbankÖffnenToolStripMenuItem");
            this.datenbankÖffnenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_connect;
            this.datenbankÖffnenToolStripMenuItem.Name = "datenbankÖffnenToolStripMenuItem";
            this.datenbankÖffnenToolStripMenuItem.Click += new System.EventHandler(this.DatenbankOeffnenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // datenbankSichernToolStripMenuItem
            // 
            resources.ApplyResources(this.datenbankSichernToolStripMenuItem, "datenbankSichernToolStripMenuItem");
            this.datenbankSichernToolStripMenuItem.Image = global::eNumismat.Properties.Resources.database_save;
            this.datenbankSichernToolStripMenuItem.Name = "datenbankSichernToolStripMenuItem";
            this.datenbankSichernToolStripMenuItem.Click += new System.EventHandler(this.DatenbankSichernToolStripMenuItem_Click);
            // 
            // datenbankKomprimierenToolStripMenuItem
            // 
            resources.ApplyResources(this.datenbankKomprimierenToolStripMenuItem, "datenbankKomprimierenToolStripMenuItem");
            this.datenbankKomprimierenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.compress;
            this.datenbankKomprimierenToolStripMenuItem.Name = "datenbankKomprimierenToolStripMenuItem";
            this.datenbankKomprimierenToolStripMenuItem.Click += new System.EventHandler(this.DatenbankKomprimierenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // beendenToolStripMenuItem
            // 
            resources.ApplyResources(this.beendenToolStripMenuItem, "beendenToolStripMenuItem");
            this.beendenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.door_in;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.BeendenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            resources.ApplyResources(this.einstellungenToolStripMenuItem, "einstellungenToolStripMenuItem");
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenBearbeitenToolStripMenuItem,
            this.spracheÄndernToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            // 
            // einstellungenBearbeitenToolStripMenuItem
            // 
            resources.ApplyResources(this.einstellungenBearbeitenToolStripMenuItem, "einstellungenBearbeitenToolStripMenuItem");
            this.einstellungenBearbeitenToolStripMenuItem.Image = global::eNumismat.Properties.Resources.cog;
            this.einstellungenBearbeitenToolStripMenuItem.Name = "einstellungenBearbeitenToolStripMenuItem";
            this.einstellungenBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.EinstellungenBearbeitenToolStripMenuItem_Click);
            // 
            // spracheÄndernToolStripMenuItem
            // 
            resources.ApplyResources(this.spracheÄndernToolStripMenuItem, "spracheÄndernToolStripMenuItem");
            this.spracheÄndernToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschToolStripMenuItem,
            this.englischToolStripMenuItem,
            this.französischToolStripMenuItem,
            this.españolToolStripMenuItem});
            this.spracheÄndernToolStripMenuItem.Name = "spracheÄndernToolStripMenuItem";
            // 
            // deutschToolStripMenuItem
            // 
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.Image = global::eNumismat.Properties.Resources.DE_Germany_Flag_icon;
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.DeutschToolStripMenuItem_Click);
            // 
            // englischToolStripMenuItem
            // 
            resources.ApplyResources(this.englischToolStripMenuItem, "englischToolStripMenuItem");
            this.englischToolStripMenuItem.Image = global::eNumismat.Properties.Resources.US_United_States_Flag_icon;
            this.englischToolStripMenuItem.Name = "englischToolStripMenuItem";
            this.englischToolStripMenuItem.Click += new System.EventHandler(this.EnglischToolStripMenuItem_Click);
            // 
            // französischToolStripMenuItem
            // 
            resources.ApplyResources(this.französischToolStripMenuItem, "französischToolStripMenuItem");
            this.französischToolStripMenuItem.Image = global::eNumismat.Properties.Resources.FR_France_Flag_icon;
            this.französischToolStripMenuItem.Name = "französischToolStripMenuItem";
            this.französischToolStripMenuItem.Click += new System.EventHandler(this.FranzösischToolStripMenuItem_Click);
            // 
            // españolToolStripMenuItem
            // 
            resources.ApplyResources(this.españolToolStripMenuItem, "españolToolStripMenuItem");
            this.españolToolStripMenuItem.Image = global::eNumismat.Properties.Resources.ES_Spain_Flag_icon;
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.EspañolToolStripMenuItem_Click);
            // 
            // ExtrasToolStripMenuItem
            // 
            resources.ApplyResources(this.ExtrasToolStripMenuItem, "ExtrasToolStripMenuItem");
            this.ExtrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdressbuchToolStripMenuItem,
            this.TauschmonitorToolStripMenuItem});
            this.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem";
            // 
            // AdressbuchToolStripMenuItem
            // 
            resources.ApplyResources(this.AdressbuchToolStripMenuItem, "AdressbuchToolStripMenuItem");
            this.AdressbuchToolStripMenuItem.Image = global::eNumismat.Properties.Resources.book_addresses;
            this.AdressbuchToolStripMenuItem.Name = "AdressbuchToolStripMenuItem";
            this.AdressbuchToolStripMenuItem.Click += new System.EventHandler(this.AdressbuchToolStripMenuItem_Click);
            // 
            // TauschmonitorToolStripMenuItem
            // 
            resources.ApplyResources(this.TauschmonitorToolStripMenuItem, "TauschmonitorToolStripMenuItem");
            this.TauschmonitorToolStripMenuItem.Image = global::eNumismat.Properties.Resources.table_refresh;
            this.TauschmonitorToolStripMenuItem.Name = "TauschmonitorToolStripMenuItem";
            this.TauschmonitorToolStripMenuItem.Click += new System.EventHandler(this.TauschmonitorToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            resources.ApplyResources(this.hilfeToolStripMenuItem, "hilfeToolStripMenuItem");
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nachUpdatesSuchenToolStripMenuItem,
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem,
            this.überENumismatToolStripMenuItem,
            this.hilfeZuENumismatToolStripMenuItem});
            this.hilfeToolStripMenuItem.Image = global::eNumismat.Properties.Resources.help;
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            // 
            // nachUpdatesSuchenToolStripMenuItem
            // 
            resources.ApplyResources(this.nachUpdatesSuchenToolStripMenuItem, "nachUpdatesSuchenToolStripMenuItem");
            this.nachUpdatesSuchenToolStripMenuItem.Name = "nachUpdatesSuchenToolStripMenuItem";
            // 
            // unicodeTabelleFürWährungssymboleToolStripMenuItem
            // 
            resources.ApplyResources(this.unicodeTabelleFürWährungssymboleToolStripMenuItem, "unicodeTabelleFürWährungssymboleToolStripMenuItem");
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem.Name = "unicodeTabelleFürWährungssymboleToolStripMenuItem";
            this.unicodeTabelleFürWährungssymboleToolStripMenuItem.Click += new System.EventHandler(this.UnicodeTabelleFuerWaehrungssymboleToolStripMenuItem_Click);
            // 
            // überENumismatToolStripMenuItem
            // 
            resources.ApplyResources(this.überENumismatToolStripMenuItem, "überENumismatToolStripMenuItem");
            this.überENumismatToolStripMenuItem.Name = "überENumismatToolStripMenuItem";
            this.überENumismatToolStripMenuItem.Click += new System.EventHandler(this.ÜberENumismatToolStripMenuItem_Click);
            // 
            // hilfeZuENumismatToolStripMenuItem
            // 
            resources.ApplyResources(this.hilfeZuENumismatToolStripMenuItem, "hilfeZuENumismatToolStripMenuItem");
            this.hilfeZuENumismatToolStripMenuItem.Image = global::eNumismat.Properties.Resources.help;
            this.hilfeZuENumismatToolStripMenuItem.Name = "hilfeZuENumismatToolStripMenuItem";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // TrayIcon
            // 
            resources.ApplyResources(this.TrayIcon, "TrayIcon");
            this.TrayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TryIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.swapMonitorToolStripMenuItem,
            this.addressbookToolStripMenuItem,
            this.toolStripSeparator3,
            this.datenbankSichernToolStripMenuItem1,
            this.compressDatabaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.beendenToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // swapMonitorToolStripMenuItem
            // 
            resources.ApplyResources(this.swapMonitorToolStripMenuItem, "swapMonitorToolStripMenuItem");
            this.swapMonitorToolStripMenuItem.Image = global::eNumismat.Properties.Resources.table_refresh;
            this.swapMonitorToolStripMenuItem.Name = "swapMonitorToolStripMenuItem";
            this.swapMonitorToolStripMenuItem.Click += new System.EventHandler(this.SwapMonitorToolStripMenuItem_Click);
            // 
            // addressbookToolStripMenuItem
            // 
            resources.ApplyResources(this.addressbookToolStripMenuItem, "addressbookToolStripMenuItem");
            this.addressbookToolStripMenuItem.Image = global::eNumismat.Properties.Resources.book_addresses;
            this.addressbookToolStripMenuItem.Name = "addressbookToolStripMenuItem";
            this.addressbookToolStripMenuItem.Click += new System.EventHandler(this.AddressbookToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // datenbankSichernToolStripMenuItem1
            // 
            resources.ApplyResources(this.datenbankSichernToolStripMenuItem1, "datenbankSichernToolStripMenuItem1");
            this.datenbankSichernToolStripMenuItem1.Image = global::eNumismat.Properties.Resources.database_save;
            this.datenbankSichernToolStripMenuItem1.Name = "datenbankSichernToolStripMenuItem1";
            this.datenbankSichernToolStripMenuItem1.Click += new System.EventHandler(this.DatenbankSichernToolStripMenuItem1_Click);
            // 
            // compressDatabaseToolStripMenuItem
            // 
            resources.ApplyResources(this.compressDatabaseToolStripMenuItem, "compressDatabaseToolStripMenuItem");
            this.compressDatabaseToolStripMenuItem.Image = global::eNumismat.Properties.Resources.compress;
            this.compressDatabaseToolStripMenuItem.Name = "compressDatabaseToolStripMenuItem";
            this.compressDatabaseToolStripMenuItem.Click += new System.EventHandler(this.CompressDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // beendenToolStripMenuItem1
            // 
            resources.ApplyResources(this.beendenToolStripMenuItem1, "beendenToolStripMenuItem1");
            this.beendenToolStripMenuItem1.Image = global::eNumismat.Properties.Resources.door_in;
            this.beendenToolStripMenuItem1.Name = "beendenToolStripMenuItem1";
            this.beendenToolStripMenuItem1.Click += new System.EventHandler(this.BeendenToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Show);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem französischToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datenbankSichernToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem swapMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressbookToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem compressDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
    }
}

