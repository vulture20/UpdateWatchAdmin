using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace UpdateWatch_Admin
{
    public partial class Form1 : Form
    {
        public List<UpdateClass> updateList = new List<UpdateClass>();
        private SQLiteConnection sqlConnection = new SQLiteConnection();
        private string dbFile;
        private bool enableSelect = false;

        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    loadDB(dbFile);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.treeListView1.CanExpandGetter = delegate(object x)
            {
                UpdateClass updateClass = (UpdateClass)x;
                return (updateClass.hasChildren);
            };
            this.treeListView1.ChildrenGetter = delegate(object x)
            {
                UpdateClass updateClass = (UpdateClass)x;
                return (updateClass.getChildren);
            };
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadDB(string dbFilename)
        {
            String showDefender = "";

            if (toolStripMenuItem1.Checked)
            {
                showDefender = " AND Title NOT REGEXP '(^Security Intelligence-Update für Windows Defender Antivirus|^Update für Windows Defender Antivirus-Antischadsoftwareplattform|^Definitionsupdate für Windows Defender Antivirus)'";
            }
            else
            {
                showDefender = "";
            }

            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            updateList.Clear();

            SQLiteCommand command = new SQLiteCommand(sqlConnection);

            try
            {
                RegExSQLiteFunction sqliteFunction = new RegExSQLiteFunction();
                sqlConnection.ConnectionString = "Data Source=" + dbFilename;
                sqlConnection.ParseViaFramework = true;
                sqlConnection.Open();
                sqlConnection.BindFunction(sqliteFunction.GetType().GetCustomAttributes(typeof(SQLiteFunctionAttribute), true).Cast<SQLiteFunctionAttribute>().ToArray()[0], sqliteFunction);
                command.CommandText = "SELECT *, cast(round(julianday('now') - julianday(lastChange)) as INTEGER) as lastChangeDays FROM Hosts";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int count = 0;

                    string _dnsName = (string)reader["dnsName"], _machineName = (string)reader["machineName"], _osVersion = (string)reader["osVersion"],
                        _IP = (string)reader["IP"];
                    long _tickCount = (long)reader["tickCount"];
                    Int64 _updateCount = (Int64)reader["updateCount"], _ID = (Int64)reader["ID"], _lastChangeDays = (Int64)reader["lastChangeDays"];
                    DateTime _lastChange = (DateTime)reader["lastChange"];

                    UpdateClass host = new UpdateClass(_ID, _IP, _dnsName, _machineName, _tickCount, _osVersion, _updateCount, _lastChange.ToString(), _lastChangeDays, new List<UpdateClass>());
                    
                    SQLiteCommand subcommand = new SQLiteCommand(sqlConnection);
                    subcommand.CommandText = "SELECT * FROM Updates JOIN HostUpdates ON Updates.ID=HostUpdates.UpdateID WHERE HostUpdates.HostID='" + _ID + "'" + showDefender;
                    SQLiteDataReader subreader = subcommand.ExecuteReader();
                    while (subreader.Read())
                    {
                        string _Title = (string)subreader["Title"], _Description = (string)subreader["Description"], _ReleaseNotes = (string)subreader["ReleaseNotes"],
                            _SupportURL = (string)subreader["SupportURL"], _UpdateID = (string)subreader["UpdateID"], _KBArticleIDs = (string)subreader["KBArticleIDs"],
                            _MsrcSeverity = (string)subreader["MsrcSeverity"];
                        Int64 _RevisionNumber = (Int64)subreader["RevisionNumber"], _Type = (Int64)subreader["Type"], _subID = (Int64)subreader["ID"];
                        bool _isMandatory = (bool)subreader["isMandatory"], _isUninstallable = (bool)subreader["isUninstallable"];

                        UpdateClass update = new UpdateClass(_subID, _Description, _ReleaseNotes, _SupportURL, _Title, _UpdateID, _RevisionNumber, _isMandatory, _isUninstallable,
                            _KBArticleIDs, _MsrcSeverity, _Type);
                        host.updates.Add(update);

                        count++;
                    }
                    if (toolStripMenuItem1.Checked)
                    {
                        host.updateCount = count;
                    }
                    subcommand.Dispose();

                    updateList.Add(host);
                }
                treeListView1.SetObjects(updateList);
                dBNeToolStripMenuItem.Enabled = true;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Fehler: Konnte Datenbank nicht öffnen bzw. lesen!\n(" + ex.Message + ")");
            }
        }

        private void vonWSUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbFile = "\\\\UpdateWatch.akafoe.de\\C$\\Program Files (x86)\\UpdateWatch-Server\\UpdateWatch.sqlite";
            loadDB(dbFile);
        }

        private void dateiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dbFile = openFileDialog1.FileName;
                loadDB(dbFile);
            }
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrightIdeasSoftware.TreeListView treeList = (BrightIdeasSoftware.TreeListView)sender;
            UpdateClass update = (UpdateClass)treeList.SelectedObject;

            try
            {
                if (update != null)
                {
                    if (!update.isUpdate)
                    {
                        enableSelect = true;
                        tabControl1.SelectTab(0);
                        enableSelect = false;
                        textBox1.Text = update.ID.ToString();
                        textBox2.Text = update.machineName;
                        textBox3.Text = update.dnsName;
                        textBox4.Text = update.updateCount.ToString();
                        textBox5.Text = update.osVersion;
                        textBox6.Text = update.lastChange;
                        textBox18.Text = update.lastChangeDays.ToString();
                        textBox7.Text = update.IP;
                    }
                    else
                    {
                        enableSelect = true;
                        tabControl1.SelectTab(1);
                        enableSelect = false;
                        textBox8.Text = update.ID.ToString();
                        textBox9.Text = update.Title;
                        textBox10.Text = update.Description;
                        textBox11.Text = update.SupportUrl;
                        textBox12.Text = update.RevisionNumber.ToString();
                        checkBox1.Checked = update.isMandatory;
                        checkBox2.Checked = update.isUninstallable;
                        switch (update.Type)
                        {
                            case 1: textBox13.Text = "Software"; break;
                            case 2: textBox13.Text = "Treiber"; break;
                            default: textBox13.Text = "Unbekannt"; break;
                        }
                        switch (update.MsrcSeverity)
                        {
                            case "Important": textBox14.Text = "Wichtig"; break;
                            case "Critical": textBox14.Text = "Kritisch"; break;
                            default: textBox14.Text = update.MsrcSeverity; break;
                        }
                        textBox15.Text = update.KBArticleIDs;
                        textBox16.Text = update.UpdateID;
                        textBox17.Text = update.ReleaseNotes;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dBNeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDB(dbFile);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!enableSelect) e.Cancel = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(textBox11.Text);
            }
            catch (Exception ex) { }
        }

        private void treeListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            UpdateClass update = (UpdateClass)e.Model;

            if (update.lastChangeDays >= 3)
                e.Item.ForeColor = Color.Red;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutBox1 frmAbout = new AboutBox1();
            frmAbout.Show();
        }

        private void datenbankBereinigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int affectedRows = 0;

            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            updateList.Clear();

            SQLiteCommand command = new SQLiteCommand(sqlConnection);

            try
            {
                sqlConnection.ConnectionString = "Data Source=" + dbFile;
                sqlConnection.ParseViaFramework = true;
                sqlConnection.Open();
                command.CommandText = "BEGIN;";
                command.ExecuteNonQuery();

                // Hosts samt Updates löschen, deren Einträge älter gleich 3 Tage sind
                command.CommandText = "DELETE FROM Updates WHERE Updates.ID IN (SELECT Updates.ID FROM Updates LEFT JOIN (SELECT * FROM HostUpdates	INNER JOIN (SELECT ID, lastchange, cast(round(julianday('now') - julianday(lastChange)) AS INTEGER) as lastChangeDays FROM Hosts WHERE lastChangeDays>=3) last ON (last.ID = HostUpdates.HostID)) upd2 ON (Updates.ID = upd2.UpdateID)	WHERE (upd2.UpdateID IS NOT NULL))";
                affectedRows += command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM HostUpdates WHERE HostUpdates.HostID IN (SELECT HostUpdates.HostID FROM HostUpdates INNER JOIN (SELECT ID, lastchange, cast(round(julianday('now') - julianday(lastChange)) AS INTEGER) as lastChangeDays FROM Hosts	WHERE lastChangeDays>=3) last ON (last.ID = HostUpdates.HostID))";
                affectedRows += command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Hosts WHERE ID IN (SELECT ID	FROM (SELECT ID, lastchange, cast(round(julianday('now') - julianday(lastChange)) AS INTEGER) as lastChangeDays	FROM Hosts WHERE lastChangeDays>=3))";
                affectedRows += command.ExecuteNonQuery();

                // UpdateID-Zuordnungen löschen, deren Host es nicht mehr gibt
                command.CommandText = "DELETE FROM HostUpdates WHERE HostUpdates.UpdateID IN (SELECT UpdateID FROM HostUpdates LEFT OUTER JOIN Hosts ON (HostUpdates.HostID = Hosts.ID) WHERE Hosts.ID IS NULL)";
                affectedRows += command.ExecuteNonQuery();

                // Updates löschen, die keinem Host mehr zugeordnet sind
                command.CommandText = "DELETE FROM Updates WHERE Updates.ID IN (SELECT ID FROM Updates LEFT OUTER JOIN HostUpdates ON (Updates.ID = HostUpdates.UpdateID) WHERE HostUpdates.UpdateID IS NULL)";
                affectedRows += command.ExecuteNonQuery();

                // Anzahl der Updates der Hosts aktualisieren
                command.CommandText = "UPDATE Hosts SET updateCount = (SELECT count(HostID) AS count FROM HostUpdates WHERE HostUpdates.HostID = Hosts.ID)";
                affectedRows += command.ExecuteNonQuery();

                command.CommandText = "END;";
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Fehler: Konnte Datenbank nicht öffnen bzw. bearbeiten!\n(" + ex.Message + ")");
            }

            loadDB(dbFile);
            MessageBox.Show("Bearbeitete Datensätze: " + affectedRows.ToString());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = !toolStripMenuItem1.Checked;
        }
    }
}
