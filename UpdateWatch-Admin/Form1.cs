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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<UpdateClass> updates = new List<UpdateClass>();
            //updates.Add(new UpdateClass("Description1", "ReleaseNotes1", "SupportUrl1", "Title1", "UpdateID1", 200, true, false, "KBArticleIDs1", "MsrcSeverity1", 1));
            //UpdateClass host = new UpdateClass("dnsName1", "machineName1", 12345, "osVersion1", 1, updates);
            //updateList.Add(host);
            //host = new UpdateClass("dnsName2", "machineName2", 23456, "osVersion2", 0, null);
            //updateList.Add(host);
            //host = new UpdateClass("dnsName3", "machineName3", 34567, "osVersion3", 1, updates);
            //updateList.Add(host);

            //this.treeListView1.SetObjects(updateList);
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
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            treeListView1.ClearObjects();

            SQLiteCommand command = new SQLiteCommand(sqlConnection);

            try
            {
                sqlConnection.ConnectionString = "Data Source=" + dbFilename;
                sqlConnection.ParseViaFramework = true;
                sqlConnection.Open();
                command.CommandText = "SELECT * FROM Hosts";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string _dnsName = (string)reader["dnsName"], _machineName = (string)reader["machineName"], _osVersion = (string)reader["osVersion"];
                    long _tickCount = (long)reader["tickCount"];
                    Int64 _updateCount = (Int64)reader["updateCount"], _ID = (Int64)reader["ID"];

                    UpdateClass host = new UpdateClass(_ID, _dnsName, _machineName, _tickCount, _osVersion, _updateCount, new List<UpdateClass>());
                    
                    SQLiteCommand subcommand = new SQLiteCommand(sqlConnection);
                    subcommand.CommandText = "SELECT * FROM Updates JOIN HostUpdates ON Updates.ID=HostUpdates.UpdateID WHERE HostUpdates.HostID='" + _ID + "'";
                    SQLiteDataReader subreader = subcommand.ExecuteReader();
                    while (subreader.Read())
                    {
                        string _Title = (string)subreader["Title"], _Description = (string)subreader["Description"], _ReleaseNotes = (string)subreader["ReleaseNotes"],
                            _SupportURL = (string)subreader["SupportURL"], _UpdateID = (string)subreader["UpdateID"], _KBArticleIDs = (string)subreader["KBArticleIDs"],
                            _MsrcSeverity = (string)subreader["MsrcSeverity"];
                        Int64 _RevisionNumber = (Int64)subreader["RevisionNumber"], _Type = (Int64)subreader["Type"], _subID = (Int64)subreader["ID"];
                        bool _isMandatory = (bool)subreader["isMandatory"], _isUninstallable = (bool)subreader["isUninstallable"];

                        UpdateClass update = new UpdateClass(_ID, _Description, _ReleaseNotes, _SupportURL, _Title, _UpdateID, _RevisionNumber, _isMandatory, _isUninstallable,
                            _KBArticleIDs, _MsrcSeverity, _Type);
                        host.updates.Add(update);
                    }
                    subcommand.Dispose();

                    updateList.Add(host);
                }
                treeListView1.SetObjects(updateList);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Fehler: Konnte Datenbank nicht öffnen bzw. lesen!\n(" + ex.Message + ")");
            }
        }

        private void vonWSUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            loadDB("\\\\WSUS\\C$\\Program Files (x86)\\UpdateWatch-Server\\UpdateWatch.sqlite");
            loadDB("\\\\WSUS\\C$\\Program Files (x86)\\UpdateWatch-Server\\UpdateWatch.sqlite");
        }

        private void dateiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                loadDB(openFileDialog1.FileName);
            }
        }
    }
}
