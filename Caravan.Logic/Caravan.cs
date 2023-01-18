using System.Xml.Linq;

namespace Caravan.Logic
{
    public class Caravan
    {
        private class Node
        {
            public Node(PackAnimal packAnimal, Node? next)
            {
                PackAnimal = packAnimal;
                Next = next;
            }
            public PackAnimal PackAnimal { get; set; }
            public Node? Next { get; set; }
        }

        #region fields
        private Node? _first = null;
        #endregion fields

        public Caravan()
        {
        }

        /// <summary>
        /// Gibt die Anzahl der Tragtiere in der Karavane zurück
        /// </summary>
        public int Count
        {
            get
            {
                int result = 0;
                Node? run = _first;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Anzahl der Ballen der gesamten Karawane
        /// </summary>
        public int Load
        {
            get
            {
                int result = 0;
                Node? run = _first;

                while (run != null)
                {
                    result += run.PackAnimal.Load;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier nach Namen sucht und zurückgibt.
        /// Existiert das Packtier nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="name">Name des Packtiers</param>
        /// <returns>Packtier</returns>
        public PackAnimal? this[string name]
        {
            get
            {
                PackAnimal? result = null;
                Node? run = _first;

                while (run != null && result == null)
                {
                    if (run.PackAnimal.Name == name)
                    {
                        result = run.PackAnimal;
                    }
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier entsprechend der Position in der Karawane sucht 
        /// und zurückgibt (0 --> Erstes Tier in der Karawane)
        /// Existiert die Position nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PackAnimal? this[int index]
        {
            get
            {
                int pos = 0;
                PackAnimal? result = null;
                Node? run = _first;

                while (run != null && result == null)
                {
                    if (pos == index)
                    {
                        result = run.PackAnimal;
                    }
                    pos++;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Liefert die Reisegeschwindigkeit dieser Karawane, die
        /// vom langsamsten Tier bestimmt wird. Dabei wird die Ladung 
        /// der Tiere berücksichtigt
        /// </summary>
        public int Pace  
        {
            get
            {
                int result = 0;
                Node? run = _first;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Fügt ein Tragtier in die Karawane ein.
        /// Dem Tragtier wird mitgeteilt, in welcher Karawane es sich nun befindet.
        /// </summary>
        /// <param name="packAnimal">einzufügendes Tragtier</param>
        public void AddPackAnimal(PackAnimal packAnimal)
        {
            if (_first == null && packAnimal != null)
            {
                _first = new Node(packAnimal, _first);
                packAnimal.MyCaravan = this;
            }
            else if (_first != null && packAnimal != null && Exists(packAnimal) == false)
            {
                Node run = _first;

                while (run.Next != null)
                {
                    run = run.Next;
                }
                run.Next = new Node(packAnimal, run.Next);
                packAnimal.MyCaravan = this;
            }
        }

        /// <summary>
        /// Nimmt das Tragtier o aus dieser Karawane heraus
        /// </summary>
        /// <param name="packAnimal">Tragtier, das die Karawane verläßt</param>
        public void RemovePackAnimal(PackAnimal packAnimal)
        {
        }

        /// <summary>
        /// Entlädt alle Tragtiere dieser Karawane
        /// </summary>
        public void Unload()
        {
            Node? run = _first;

            while (run != null)
            {
                run.PackAnimal.Load = 0;
                run = run.Next;
            }
        }

        /// <summary>
        /// Verteilt zusätzliche Ballen Ladung so auf die Tragtiere 
        /// der Karawane, dass die Reisegeschwindigkeit möglichst hoch bleibt
        /// Tipp: Gib immer einen Ballen auf das belastbarste (schnellste) Tier bis alle Ballen vergeben sind
        /// </summary>
        /// <param name="load">Anzahl der Ballen Ladung</param>
        public void AddLoad(int load)
        {
        }

        private bool Exists(PackAnimal packAnimal)
        {
            bool result = false;
            Node? run = _first;

            while (run != null && result == false)
            {
                if (run.PackAnimal == packAnimal)
                {
                    result = true;
                }
                run = run.Next;
            }
            return result;
        }
    }
}
