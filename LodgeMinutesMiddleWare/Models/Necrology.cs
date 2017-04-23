namespace LodgeMinutesMiddleWare.Models
{
    public class Necrology: ModelBase
    {
        #region Fields

        private string _name;

        #endregion

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Necrology"/> class.
        /// </summary>
        public Necrology() { }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

    }
}