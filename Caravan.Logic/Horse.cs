namespace Caravan.Logic
{
    public class Horse : PackAnimal
    {
        /// <summary>
        /// Pferd mit Maximalgeschwindigkeit 70 erzeugen
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mp"></param>
        public Horse(string name, int mp) 
            : base(name, mp)
        {
            MaxPace = MaxPace > 70 ? 70 : MaxPace;
        }

        /// <summary>
        /// Geschwindigkeit in Abhängigkeit der Ladung (Reduktion um 10 je Ballen)
        /// </summary>
        public override int Pace
        {
            get
            {
                return Math.Max(0, MaxPace - (10 * Load));
            }
        }

    }
}
