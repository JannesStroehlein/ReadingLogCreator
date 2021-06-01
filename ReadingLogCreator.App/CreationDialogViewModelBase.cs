using System;
using System.Windows.Input;

namespace ReadingLogCreator.App
{
    public abstract class CreationDialogViewModelBase<T> : ViewModelBase
    {
        private RelayCommand _CancelCommand;
        private RelayCommand _CreateCommand;

        private bool _CanCreate;

        public event EventHandler<T> onCreated;
        public event EventHandler<EventArgs> requestsClose;

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
        public abstract void Create();

        public void RetrunObject(T value)
        {
            EventHandler<T> handler = this.onCreated;
            if (handler != null)
                handler(this, value);
            this.Close();
        }
        private void Close()
        {
            EventHandler<EventArgs> handler = this.requestsClose;
            if (handler != null)
                handler(this, new EventArgs());
        }
    }
}
