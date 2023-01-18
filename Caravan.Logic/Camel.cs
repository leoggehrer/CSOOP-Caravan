namespace Caravan.Logic
{
    public class Camel : PackAnimal
    {
        /// <summary>
        /// Kamel mit Maximalgeschwindigkeit 20 erzeugen
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mp"></param>
        public Camel(string name, int mp)
            : base(name, mp)
        {
            MaxPace = MaxPace > 20 ? 20 : MaxPace;
        }

        /// <summary>
        /// Geschwindigkeit in Abhängigkeit der Ladung (Reduktion um 1 je Ballen)
        /// </summary>
        public override int Pace
        {
            get
            {
                return Math.Max(0, MaxPace - Load);
            }
        }

    }
}
