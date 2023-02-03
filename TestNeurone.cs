using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NeuralNetworkFromScratch
{
	internal class TestNeurone
	{
		double[] inputs = { 1.2, 5.1, 2.1 };
		double[] weights = { 3.1, 2.1, 8.7 };
		double bias = 3;

		public double Output()
		{
			return inputs[0] * weights[0] + inputs[1] * weights[1] + inputs[2] * weights[2] + bias;
		}
	}
}
