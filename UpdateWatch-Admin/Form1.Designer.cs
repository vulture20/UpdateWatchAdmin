namespace UpdateWatch_Admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vonWSUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBÖffnenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // dBÖffnenToolStripMenuItem
            // 
            this.dBÖffnenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem1,
            this.vonWSUSToolStripMenuItem});
            this.dBÖffnenToolStripMenuItem.Name = "dBÖffnenToolStripMenuItem";
            this.dBÖffnenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.dBÖffnenToolStripMenuItem.Text = "DB ö&ffnen";
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.dateiToolStripMenuItem1.Text = "Datei...";
            this.dateiToolStripMenuItem1.Click += new System.EventHandler(this.dateiToolStripMenuItem1_Click);
            // 
            // vonWSUSToolStripMenuItem
            // 
            this.vonWSUSToolStripMenuItem.Name = "vonWSUSToolStripMenuItem";
            this.vonWSUSToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.vonWSUSToolStripMenuItem.Text = "von WSUS";
            this.vonWSUSToolStripMenuItem.Click += new System.EventHandler(this.vonWSUSToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.beendenToolStripMenuItem.Text = "&Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.toolStripMenuItem2.Text = "Ü&ber";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "sqlite";
            this.openFileDialog1.FileName = "UpdateWatch.sqlite";
            this.openFileDialog1.Filter = "SQLite-Datenbanken|*.sqlite|Alle Dateien|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Datenbank öffnen";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1034, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumn6);
            this.treeListView1.AllColumns.Add(this.olvColumn4);
            this.treeListView1.AllColumns.Add(this.olvColumn5);
            this.treeListView1.AllColumns.Add(this.olvColumn1);
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn6,
            this.olvColumn4});
            this.treeListView1.EmptyListMsg = "Keine Daten vorhanden";
            this.treeListView1.Location = new System.Drawing.Point(12, 27);
            this.treeListView1.MultiSelect = false;
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.SelectAllOnControlA = false;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(425, 614);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.treeListView1.TabIndex = 3;
            this.treeListView1.UseAlternatingBackColors = true;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "machineName";
            this.olvColumn6.FillsFreeSpace = true;
            this.olvColumn6.Hideable = false;
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.MinimumWidth = 35;
            this.olvColumn6.Text = "Host";
            this.olvColumn6.Width = 180;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "updateCount";
            this.olvColumn4.AspectToStringFormat = "{0:#}";
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.IsHeaderVertical = true;
            this.olvColumn4.Text = "Anzahl";
            this.olvColumn4.Width = 20;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "UpdateCol";
            this.olvColumn5.DisplayIndex = 2;
            this.olvColumn5.FillsFreeSpace = true;
            this.olvColumn5.Groupable = false;
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.IsVisible = false;
            this.olvColumn5.Text = "Updates";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "ID";
            this.olvColumn1.Groupable = false;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.IsVisible = false;
            this.olvColumn1.Searchable = false;
            this.olvColumn1.Text = "ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 676);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UpdateWatch-Admin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vonWSUSToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
    }
}

