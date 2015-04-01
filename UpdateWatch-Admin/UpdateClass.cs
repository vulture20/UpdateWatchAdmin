using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace UpdateWatch_Admin
{
    public class UpdateClass : INotifyPropertyChanged
    {
        public UpdateClass() { }

        public UpdateClass(string _dnsName, string _machineName, Int64 _tickCount, string _osVersion, Int64 _updateCount, List<UpdateClass>_updates)
        {
            this.dnsName = _dnsName;
            this.machineName = _machineName;
            this.tickCount = _tickCount;
            this.osVersion = _osVersion;
            this.updateCount = _updateCount;
            this.updates = _updates;
            this.isUpdate = false;
        }
        public UpdateClass(Int64 _ID, string _IP, string _dnsName, string _machineName, Int64 _tickCount, string _osVersion, Int64 _updateCount, string _lastChange, List<UpdateClass> _updates)
        {
            this.ID = _ID;
            this.IP = _IP;
            this.dnsName = _dnsName;
            this.machineName = _machineName;
            this.tickCount = _tickCount;
            this.osVersion = _osVersion;
            this.updateCount = _updateCount;
            this.lastChange = _lastChange;
            this.updates = _updates;
            this.isUpdate = false;
        }
        public UpdateClass(string _Description, string _ReleaseNotes, string _SupportUrl, string _Title, string _UpdateID, Int64 _RevisionNumber,
            bool _isMandatory, bool _isUninstallable, string _KBArticleIDs, string _MsrcSeverity, Int64 _Type)
        {
            this.Description = _Description;
            this.ReleaseNotes = _ReleaseNotes;
            this.SupportUrl = _SupportUrl;
            this.Title = _Title;
            this.UpdateID = _UpdateID;
            this.RevisionNumber = _RevisionNumber;
            this.isMandatory = _isMandatory;
            this.isUninstallable = _isUninstallable;
            this.KBArticleIDs = _KBArticleIDs;
            this.MsrcSeverity = _MsrcSeverity;
            this.Type = _Type;
            this.isUpdate = true;
        }
        public UpdateClass(Int64 _ID, string _Description, string _ReleaseNotes, string _SupportUrl, string _Title, string _UpdateID, Int64 _RevisionNumber,
            bool _isMandatory, bool _isUninstallable, string _KBArticleIDs, string _MsrcSeverity, Int64 _Type)
        {
            this.ID = _ID;
            this.Description = _Description;
            this.ReleaseNotes = _ReleaseNotes;
            this.SupportUrl = _SupportUrl;
            this.Title = _Title;
            this.UpdateID = _UpdateID;
            this.RevisionNumber = _RevisionNumber;
            this.isMandatory = _isMandatory;
            this.isUninstallable = _isUninstallable;
            this.KBArticleIDs = _KBArticleIDs;
            this.MsrcSeverity = _MsrcSeverity;
            this.Type = _Type;
            this.isUpdate = true;
        }

        public bool isUpdate { get; set; }
        public string UpdateCol
        {
            get
            {
                if (isUpdate)
                {
                    return Description;
                }
                else
                {
                    if (updateCount >= 1) return "..."; else return "";
                }
            }
        }
        public bool hasChildren
        {
            get { return (updateCount >= 1); }
        }
        public List<UpdateClass> getChildren
        {
            get { return updates; }
        }

        // isUpdate = false => Host
        public Int64 ID { get; set; }
        public string IP { get; set; }
        public string dnsName { get; set; }
        private string _machineName;
        public string machineName
        {
            get
            {
                if (isUpdate)
                {
                    return Title;
                }
                else
                {
                    return _machineName;
                }
            }
            set
            {
                _machineName = value;
            }
        }
        public Int64 tickCount { get; set; }
        public string osVersion { get; set; }
        public Int64 updateCount { get; set; }
        public string lastChange { get; set; }
        public List<UpdateClass> updates { get; set; }

        // isUpdate = true => Update
        public string Description { get; set; }
        public string ReleaseNotes { get; set; }
        public string SupportUrl { get; set; }
        public string Title { get; set; }
        public string UpdateID { get; set; }
        public Int64 RevisionNumber { get; set; }
        public bool isMandatory { get; set; }
        public bool isUninstallable { get; set; }
        public string KBArticleIDs { get; set; }
        public string MsrcSeverity { get; set; }
        public Int64 Type { get; set; } // 1 = Software, 2 = Driver

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
