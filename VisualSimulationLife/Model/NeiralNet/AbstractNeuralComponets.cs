namespace LifeSimulation.Model.NeiralNet{
	///<sumarry>
	/// Абстрактный класс для компонетов нейронной сети
	///</sumarry>
	abstract class NeuralComponets {
		///<sumarry>
		/// Матрица весов компонента
		///</sumarry>
		protected double[,] Matrix;
		///<summary>
		/// Размеры матрицы
		///</summary>
		protected int n, m;
		///<summary>
		/// Чтение кол-ва строк
		///</summary>
		public int N {
			get => n;
		}
		///<summary>
		/// Чтение кол-ва столбов
		///</summary>
		public int M {
			get => m;
		}
		public double[,] MATRIX {
			get => Matrix;
			set => Matrix = value;
		}
	}
}