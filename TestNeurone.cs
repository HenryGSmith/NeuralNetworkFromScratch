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
		private double[] inputs;
		private double[] weights;
		private double bias;

		public TestNeurone(double[] inputs, double[] weights, double bias)
		{
			this.inputs = inputs;
			this.weights = weights;
			this.bias = bias;
		}

		public double Output()
		{
			double weightedSum = 0;
			for(int i = 0; i < inputs.Length; i++)
			{
				weightedSum += inputs[i] * weights[i];
			}
			return weightedSum + bias;
		}
	}
}
