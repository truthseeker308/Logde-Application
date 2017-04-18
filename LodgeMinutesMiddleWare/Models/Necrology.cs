namespace LodgeMinutesMiddleWare.Models
{
    public class Necrology: ModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if( _name != value )
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Necrology() { }

    }
}