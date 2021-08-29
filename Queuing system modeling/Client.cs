using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queuing_system_modeling
{
    public abstract class Client
    {
        protected double timeWait;
        protected Visits visits;

        public Client(int[] idQueuingSystem, int[] needVisiting)
        {
            timeWait = 0.0;
            visits = new Visits(idQueuingSystem, needVisiting);
        }

        public void IncreasedTimeWait(double time)
        {
            timeWait += time;
        }

        public double GetTimeWait()
        {
            return timeWait;
        }

        public bool CheckVisiting()
        {
            return visits.CheckVisiting();
        }

        public void AddVisiting(int idQueuingSystem)
        {
            visits.AddVisiting(idQueuingSystem);
        }

        public abstract int GetIdVisitQueuingSystem(List<int> sizeQueues);
    }

    public class Visits
    {
        private List<Visit> goals;

        public Visits(int []idQueuingSystem, int []needVisiting)
        {
            goals = new List<Visit>();

            for (int i = 0; i < idQueuingSystem.Length; i++)
            {
                goals.Add(new Visit(idQueuingSystem[0], needVisiting[0]));
            }
        }

        public void AddVisiting(int idQueuingSystem)
        {
            goals[idQueuingSystem].AddVisiting();
        }

        public bool CheckVisiting()
        {
            for (int i = 0; i < goals.Count; i++)
            {
                if(!goals[i].CheckVisiting())
                {
                    return false;
                }
            }

            return true;
        }

        public List<int> GetIdRemainingQueuingSystem()
        {
            List<int> idRemainingQueuingSystem = new List<int>();

            for (int i = 0; i < goals.Count; i++)
            {
                if (!goals[i].CheckVisiting())
                {
                    idRemainingQueuingSystem.Add(i);
                }
            }

            return idRemainingQueuingSystem;
        }
    }

    public class Visit
    {
        private int idQueuingSystem;
        private int needVisiting;
        private int currentVisiting;

        public Visit(int idQueuingSystem, int needVisiting)
        {
            this.idQueuingSystem = idQueuingSystem;
            this.needVisiting = needVisiting;
            this.currentVisiting = 0;
        }

        public bool CheckVisiting()
        {
            return needVisiting == currentVisiting;
        }

        public void AddVisiting()
        {
            currentVisiting++;
        }
    }

    public class CleverClient : Client
    {
        public CleverClient(int[] idQueuingSystem, int[] needVisiting) : base(idQueuingSystem, needVisiting)
        {

        }

        override public int GetIdVisitQueuingSystem(List<int> sizeQueues)
        {
            List<int> idRemainingQueuingSystem = visits.GetIdRemainingQueuingSystem();

            int minQueue = 100000;
            int idMinQueue = 0;

            for (int i = 0; i < idRemainingQueuingSystem.Count; i++)
            {
                if (sizeQueues[idRemainingQueuingSystem[i]] <= minQueue)
                {
                    minQueue = sizeQueues[idRemainingQueuingSystem[i]];
                    idMinQueue = idRemainingQueuingSystem[i];
                }
            }

            return idMinQueue;
        }
    }

    public class StupidClient : Client
    {
        public StupidClient(int[] idQueuingSystem, int[] needVisiting) : base(idQueuingSystem, needVisiting)
        {

        }

        override public int GetIdVisitQueuingSystem(List<int> sizeQueues)
        {
            List<int> idRemainingQueuingSystem = visits.GetIdRemainingQueuingSystem();

            return idRemainingQueuingSystem[0];
        }
    }
}
