using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    class NewExtraDataViewModel : WorkspaceViewModel
    {
        private RelayCommand _CancelCommand;
        private RelayCommand _CreateCommand;

        private string _Key;
        private string _Value;
        private bool _CanCreate;

        public event EventHandler<KeyValuePair<string, string>> onCreated;

        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new RelayCommand(param => this.Close());
                }
                return _CancelCommand;
            }
        }
        public ICommand CreateCommand
        {
            get
            {
                if (_CreateCommand == null)
                {
                    _CreateCommand = new RelayCommand(param => this.Create());
                }
                return _CreateCommand;
            }
        }

        public string Key
        {
            get { return this._Key; }
            set
            {
                if (value == this._Key)
                    return;
                this._Key = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public string Value
        {
            get { return this._Value; }
            set
            {
                if (value == this._Value)
                    return;
                this._Value = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public bool CanCreate
        {
            get { return this._CanCreate; }
            set
            {
                if (value == this._CanCreate)
                    return;
                this._CanCreate = value;
                base.OnPropertyChanged();
            }
        }

        public NewExtraDataViewModel() : base("New Chapter", false, true)
        {
        }

        private bool CheckCanCreate()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                return false;
            if (string.IsNullOrWhiteSpace(this.Value))
                return false;
            return true;
        }
        private void Create()
        {
            EventHandler<KeyValuePair<string, string>> handler = this.onCreated;
            if (handler != null)
                handler(this, new KeyValuePair<string, string>(this.Key, this.Value));
            this.Close();
        }
    }
}
