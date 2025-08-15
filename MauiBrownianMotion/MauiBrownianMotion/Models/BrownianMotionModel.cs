using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBrownianMotion.Models
{
    public class BrownianMotionModel
    {
        public static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
        {
            Random random = new();
            double[] prices = new double[numDays];
            prices[0] = initialPrice;

            for (int i = 1; i < numDays; i++)
            {
                double uniformRandom = 1.0 - random.NextDouble();
                double uniformRandom2 = 1.0 - random.NextDouble();
                double z = Math.Sqrt(-2.0 * Math.Log(uniformRandom)) * Math.Sin(2.0 * Math.PI * uniformRandom2);

                double returnValue = mean + sigma * z;
                prices[i] = prices[i - 1] * Math.Exp(returnValue);
            }

            return prices;
        }
    }
}
