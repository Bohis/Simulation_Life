namespace LifeSimulation.Model.NeiralNet {
	/// <summary>
	/// Класс перцетрона 
	/// </summary>
	class NeuralNetwork {
		#region Состав сети
		InputLayer First;

		HiddenLayer Second;

		HiddenLayer Third;

		HiddenLayer Forth;

		OutputLayer Fifth;

		SynapseLayer SFirst;

		SynapseLayer SSecond;

		SynapseLayer SThird;

		SynapseLayer SFourth;
		#endregion
		/// <summary>
		/// Коофициент обучения
		/// </summary>
		int TrainigCoof;
		///<summary>
		/// Конструктор для наследования
		/// </summary>
		public NeuralNetwork(int TrainigCoof,double [,] SFirst , double [,] SSecond,double[,] SThird,double[,] SFourth) {
			First = new InputLayer(6);

			Second = new HiddenLayer(5);

			Third = new HiddenLayer(4);

			Forth = new HiddenLayer(2);

			Fifth = new OutputLayer(4);

			this.SFirst = new SynapseLayer(SFirst, TrainigCoof);

			this.SSecond = new SynapseLayer(SSecond, TrainigCoof);

			this.SThird = new SynapseLayer(SThird, TrainigCoof);

			this.SFourth = new SynapseLayer(SFourth, TrainigCoof);

			this.TrainigCoof = TrainigCoof;
		}
		/// <summary>
		/// Конструктор с параметром обучения нейросети
		/// </summary>
		public NeuralNetwork(int TrainigCoof) {
			First = new InputLayer(6);

			Second = new HiddenLayer(5);

			Third = new HiddenLayer(4);

			Forth = new HiddenLayer(2);

			Fifth = new OutputLayer(4);

			SFirst = new SynapseLayer(6, 5);

			SSecond = new SynapseLayer(5, 4);

			SThird = new SynapseLayer(4, 2);

			SFourth = new SynapseLayer(2, 4);

			this.TrainigCoof = TrainigCoof;
		}
		///<sumarry>
		///Конструктор для наследования нейросети
		///</sumarry>
		public NeuralNetwork(NeuralNetwork BaseNet) {
			First = new InputLayer(6);

			Second = new HiddenLayer(5);

			Third = new HiddenLayer(4);

			Forth = new HiddenLayer(2);

			Fifth = new OutputLayer(4);

			TrainigCoof = BaseNet.TRAING_COOF;

			SFirst = new SynapseLayer(BaseNet.S_FIRST, BaseNet.TRAING_COOF);

			SSecond = new SynapseLayer(BaseNet.S_CECOND, BaseNet.TRAING_COOF);

			SThird = new SynapseLayer(BaseNet.S_THIRD, BaseNet.TRAING_COOF);

			SFourth = new SynapseLayer(BaseNet.S_FORTH, BaseNet.TRAING_COOF);
		}
		///<sumarry>
		///Метод работы нейросети, с результатом хеш-строки
		///</sumarry> 		
		public string WorkNet(string HashStr) {
			First.InputDate(HashStr);
			Second.MATRIX = Matrix.Multiplication(First.MATRIX, SFirst.MATRIX);
			Second.Formalize();
			Third.MATRIX = Matrix.Multiplication(Second.MATRIX, SSecond.MATRIX);
			Third.Formalize();
			Forth.MATRIX = Matrix.Multiplication(Third.MATRIX, SThird.MATRIX);
			Forth.Formalize();
			Fifth.MATRIX = Matrix.Multiplication(Forth.MATRIX, SFourth.MATRIX);
			Fifth.Formalize();
			return Fifth.OutputDate();
		}
		///<sumarry>
		///Коофициент обучения
		///</sumarry>
		public int TRAING_COOF {
			get =>TrainigCoof;
		}
		///<sumarry>
		///Свойства для наследования
		///</sumarry>
		public double[,] S_FIRST {
			get =>SFirst.MATRIX;
		}
		///<sumarry>
		///Свойства для наследования
		///</sumarry>
		public double[,] S_CECOND {
			get =>SSecond.MATRIX;
		}
		///<sumarry>
		///Свойства для наследования
		///</sumarry>
		public double[,] S_THIRD {
			get =>SThird.MATRIX;
		}
		///<sumarry>
		///Свойства для наследования
		///</sumarry>
		public double[,] S_FORTH {
			get => SFourth.MATRIX;
		}
	}
}