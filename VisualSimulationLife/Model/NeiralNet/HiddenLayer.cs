
namespace LifeSimulation.Model.NeiralNet{
	/// <summary>
	/// Класс скрытого слоя нейросети
	/// </summary>
	class HiddenLayer : NeuralComponets {
		///<summary>
		/// Конструктор с заданием кол-ва столбов
		///</summary>
		public HiddenLayer(int M) {
			m = M;
			n = 1;
			Matrix = new double[ n, m ];
		}
		///<summary>
		/// Прогнать все значения через активационную функкцию
		///</summary>
		public void Formalize() {
			for (int j = 0; j < m; j++)
				Matrix[ 0, j ] = Function.Sigmoid(Matrix[ 0, j ]);
		}
	}
}