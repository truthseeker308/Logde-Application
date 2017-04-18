using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public class Necrologies: ModelBase
    {
        private bool _setAside = false;

        private ObservableCollection<Necrology> _negrologies;

        public bool SetAside
        {
            get { return _setAside; }
            set
            {
                if( _setAside != value )
                {
                    _setAside = value;
                    NotifyPropertyChanged();
                }
            }
        }
            
        public ObservableCollection<Necrology> BrotherNecrologies
        {
            get { return _negrologies; }
        }

        public Necrologies()
        {
            _negrologies = new ObservableCollection<Models.Necrology>();
        }

    }
}
