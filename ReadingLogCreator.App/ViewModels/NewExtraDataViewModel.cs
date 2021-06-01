using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    class NewExtraDataViewModel : CreationDialogViewModelBase<KeyValuePair<string, string>>
    {
        private string _Key;
        private string _Value;

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
        public override void Create()
        {
            this.RetrunObject(new KeyValuePair<string, string>(this.Key, this.Value));
        }
        private bool CheckCanCreate()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                return false;
            if (string.IsNullOrWhiteSpace(this.Value))
                return false;
            return true;
        }
    }
}
