using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFromScratch.Utils
{
	internal static class Utils
	{
		public static double[][] ConvertToJaggedArray(double[,] multiArray)
		{
			int firstElement = multiArray.GetLength(0);
			int secondElement = multiArray.GetLength(1);

			double[][] jaggedArray = new double[firstElement][];

			for (int c = 0; c < firstElement; c++)
			{
				jaggedArray[c] = new double[secondElement];
				for (int r = 0; r < secondElement; r++)
				{
					jaggedArray[c][r] = multiArray[c, r];
				}
			}
			return jaggedArray;
		}
	}
}
