namespace LifeSimulation.Model.NeiralNet{
	///<sumarry>
	/// Абстрактный класс для компонетов нейронной сети
	///</sumarry>
	abstract class NeuralComponets {
		///<sumarry>
		/// Матрица весов компонента
		///</sumarry>
		public double[,] Matrix;
		///<summary>
		/// Размеры матрицы
		///</summary>
		protected int n, m;
		///<summary>
		/// Чтение кол-ва строк
		///</summary>
		public int N {
			get {
				return n;
			}
		}
		///<summary>
		/// Чтение кол-ва столбов
		///</summary>
		public int M {
			get {
				return m;
			}
		}
	}
}