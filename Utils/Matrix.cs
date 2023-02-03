using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NeuralNetworkFromScratch.Utils
{
	internal class Matrix
	{
		private int rows { get; }
		private int columns { get; }
		private double[,] mat { get; }

		public Matrix(double[,] mat)
		{
			this.rows = mat.GetLength(0);
			this.columns = mat.GetLength(1);
			Console.WriteLine($"{rows}, {columns}");
			this.mat = mat;
		}

		public Matrix(int rows, int cols)
		{
			this.rows = rows;
			this.columns = cols;
			double[,] mat = new double[rows,cols];
		}

		public Matrix Mul(Matrix matrix)
		{
			if (matrix == null) throw new ArgumentNullException("matrix is null");
			if (matrix.columns != this.rows) throw new ArgumentException("invalid matix dimensions");

			double[,] output = new double[this.rows, matrix.columns];


			for(int i = 0; i < this.rows; i++)
			{
				for(int j = 0; j < matrix.columns; j++)
				{
					output[i,j] = 0;
					for(int k = 0; k < matrix.rows; k++)
					{
						output[i,j] += this.mat[i,k] * matrix.mat[k,j];
					}
				}
			}

			return new Matrix(output);
		}

		public void Show()
		{
			Console.WriteLine();
			for(int i = 0; i < rows; i++) 
			{
				for(int j = 0; j < columns; j++)
				{
					Console.Write(mat[i,j]);
					Console.Write(' ');
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
