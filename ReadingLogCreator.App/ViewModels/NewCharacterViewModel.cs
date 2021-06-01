using ReadingLogCreator.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLogCreator.App.ViewModels
{
    public class NewCharacterViewModel : CreationDialogViewModelBase<Character>
    {
        private string _Name;
        private bool _IsMainCharacter;

        public string Name
        {
            get { return this._Name; }
            set
            {
                if (value == this._Name)
                    return;
                this._Name = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public bool IsMainCharacter
        {
            get { return this._IsMainCharacter; }
            set
            {
                if (value == this._IsMainCharacter)
                    return;
                this._IsMainCharacter = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }

        private bool CheckCanCreate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                return false;
            return true;
        }

        public override void Create()
        {
            this.RetrunObject(new Character() { Name = this.Name, IsMainCharacter = this.IsMainCharacter });
        }
    }
}
