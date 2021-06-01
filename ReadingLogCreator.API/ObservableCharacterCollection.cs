using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLogCreator.API
{
    public class ObservableCharacterCollection : ObservableCollection<Character>
    {
        public bool Contains(Guid identifier) => this.FirstOrDefault(c => c.Guid == identifier) != null;
    }
}
