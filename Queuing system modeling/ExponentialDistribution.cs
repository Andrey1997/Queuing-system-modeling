using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queuing_system_modeling
{
    public interface IExponentialDistribution
    {
        double CreateValue();
    }


    public class ExponentialDistribution : IExponentialDistribution
    {
        private double a;
        private Random random;

        ExponentialDistribution(double a)
        {
            this.a = a;
            random = new Random();
        }

        ExponentialDistribution(double a, Random random)
        {
            this.a = a;
            this.random = random;
        }

        public double CreateValue()
        {
            return Math.Round(-Math.Log(random.NextDouble()) / a, 3);
        }
    }
}
