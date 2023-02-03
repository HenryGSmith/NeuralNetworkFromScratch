using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFromScratch.Utils
{
	internal class Vec
	{
		private double[] vector {  get; }

		public Vec(double[] vector)
		{
			this.vector = vector;
		}

		public Vec(int length)
		{
			this.vector = new double[length];
		}

		public void Show()
		{
			foreach(double d in this.vector)
			{
				Console.WriteLine(d);
			}
		}
	}
}
