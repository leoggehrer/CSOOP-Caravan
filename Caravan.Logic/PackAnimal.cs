using System.Security;

namespace Caravan.Logic
{
    /// <summary>
    /// Abstrakte Basisklasse, die generelle Eigenschaften und Methoden von 
    /// Packtieren beschreibt.
    /// </summary>
    public abstract class PackAnimal
    {
        #region fields
        private int _load = 0;
        private Caravan? _myCaravan;
        #endregion fields

        /// <summary>
        /// Name des Tiers und Maximalgeschwindigkeit des Tiers
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="maxPace">MaxPace</param>
        protected PackAnimal(string name, int maxPace)
        {
            Name = name;
            MaxPace = maxPace < 0 ? 0 : maxPace;
        }

        public string Name { get; private set; }
        /// <summary>
        /// Maximale Geschwindigkeit des Tiers
        /// </summary>
        public int MaxPace { get; protected set; }

        /// <summary>
        /// Anzahl der Ballen, die das Tier trägt
        /// </summary>
        public int Load 
        {
            get { return _load; }
            set { _load = value >= 0 ? value : 0; }
        }
        
        /// <summary>
        /// Geschwindigkeit des Tiers
        /// </summary>
        public abstract int Pace { get; }  //! logisch eigentlich ein Property

        /// <summary>
        /// Karawane, in der das Tier mitläuft. Kann einfach durch Zuweisung 
        /// gewechselt werden. Umkettung in Karawanen erfolgt automatisch
        /// </summary>
        public Caravan? MyCaravan 
        {
            get { return _myCaravan; }
            set 
            {
                if (_myCaravan == null)
                {
                    _myCaravan = value;
                }
                else if (_myCaravan != value)
                {
                    _myCaravan.RemovePackAnimal(this);
                    _myCaravan = value;
                }
            }
        }
    }
}
