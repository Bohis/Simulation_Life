using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation_ConsoleVersion.NeuroBrainBor {
	/// <summary>
	/// Класс синапса нейросети
	/// </summary>
	class SynapseLayer : NeuralComponets {
		///<summary>
		/// Конструктор с заданием кол-во строк и кол-ва столбов
		///</summary>
		public SynapseLayer(int N, int M) {
			Random ForSpace = new Random();
			m = M;
			n = N;
			Matrix = new double[ n, m ];
			for (int i = 0; i < N; i++)
				for (int j = 0; j < M; j++)
					Matrix[ i, j ] = ForSpace.Next(-2, 2);
		}
		///<summary>
		/// Метод для формирования синапсов через наследования ботов
		///</summary>
		public SynapseLayer(double[,] BaseMatrix, int TrainigCoof) {
			Random ForSpace = new Random();
			m = BaseMatrix.GetLength(1);
			n = BaseMatrix.GetLength(0);
			Matrix = BaseMatrix;
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++) {
					int choise = ForSpace.Next(-TrainigCoof, TrainigCoof);
					if (choise == 1)
						Matrix[ i, j ] += ForSpace.NextDouble();
					if (choise == -1)
						Matrix[ i, j ] -= ForSpace.NextDouble();
				}
		}
	}
}