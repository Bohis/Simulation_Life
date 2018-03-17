using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation_ConsoleVersion.NeuroBrainBor {
	/// <summary>
	/// Класс выходного слоя нейросети
	/// </summary>
	class OutputLayer : NeuralComponets {
		///<summary>
		/// Конструктор с заданием кол-ва столбов
		///</summary>
		public OutputLayer(int M) {
			m = M;
			n = 1;
			Matrix = new double[ n, m ];
		}
		///<summary>
		/// Фомирование хеш-строки из полученных значений 
		///</summary>
		public string OutputDate() {
			string HashOutstr = new string("".ToCharArray());
			for (int j = 0; j < m; j++) {
				//Console.WriteLine(Matrix[ 0, j ]);
				if (Matrix[ 0, j ] >= 0.55)
					HashOutstr += "1|";
				else
					HashOutstr += "0|";
			}
			Console.WriteLine(HashOutstr);
			return HashOutstr;
		}
		///<summary>
		/// Прогон всех значений через активационную функцию
		///</summary>
		public void Formalize() {
			for (int j = 0; j < m; j++)
				Matrix[ 0, j ] = Function.Sigmoid(Matrix[ 0, j ]);
		}
	}
}
