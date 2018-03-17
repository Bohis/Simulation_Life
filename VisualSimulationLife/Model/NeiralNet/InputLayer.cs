using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation_ConsoleVersion.NeuroBrainBor {
	/// <summary>
	/// Класс входного слоя нейросети
	/// </summary>
	class InputLayer : NeuralComponets {
		///<summary>
		/// Конструктор с заданием кол-ва столбов
		///</summary>
		public InputLayer(int M) {
			m = M;
			n = 1;
			Matrix = new double[ n, m ];
		}
		///<summary>
		/// Чтение из хеш-строки действий
		///</summary>
		public void InputDate(string HashString) {
			for (int j = 0; j < m; j++)
				Matrix[ 0, j ] = double.Parse(HashString.Split('|')[ j ]);
		}
	}
}
