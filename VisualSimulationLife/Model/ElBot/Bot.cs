using System;
using LifeSimulation_ConsoleVersion.NeuroBrainBor;

namespace LifeSimulation_ConsoleVersion.LifeSimulation {
    /// <summary>
    /// Класс с реализацияей бота
    /// </summary>
	class Bot {
        /// <summary>
        /// Очки здоровья бота
        /// </summary>
		int HP;
        /// <summary>
        /// Внутреняя энергия бота
        /// </summary>
		int Energy;
        /// <summary>
        /// Координаты бота на поле
        /// </summary>
		public int? IG, JG;
        /// <summary>
        /// Температурный диапазон для объекта
        /// </summary>
		public Temp TempRange;
        /// <summary>
        /// Ссылка на поле
        /// </summary>
		Field Link;
        /// <summary>
        /// Имя объекта исполизуемое как ключ для хеш таблицы
        /// </summary>
		public string HashName;
		/// <summary>
		/// Структура для статистики
		/// </summary>
		public struct Statistic {
			public int Move;
			public int Kill;
			public int Eat;
			public int Generation;
		}
		/// <summary>
		/// Поле для статистики
		/// </summary>
		public Statistic Info;
        /// <summary>
        /// Урон бота при атаке
        /// </summary>
		int Damage;
        /// <summary>
        /// Предельный возраст бота
        /// </summary>
		public int Old;
        /// <summary>
        /// Возраст бота
        /// </summary>
		public int OldChet;
        /// <summary>
        /// Нейронная сеть управляющая ботом
        /// </summary>
		NeuralNetwork Brain;
        /// <summary>
        /// Констуктор с стандартными параметрами по умолчанию
        /// </summary>
        /// <param name="link">ссылка на поле</param>
        /// <param name="i">координаты в поле</param>
        /// <param name="j">координаты в поле</param>
        /// <param name="HP">колличество очков здоровья</param>
        /// <param name="Energy">запас энергии</param>
        /// <param name="MaxTemp">мах комфортная температура</param>
        /// <param name="MinTemp">min комфортная температура</param>
        /// <param name="Damage">урон другим ботам при атаке</param>
        /// <param name="Brain">ссылка на нейросеть для наследования</param>
		public Bot(Field link, int i = 0, int j = 0, int HP = 100, int Energy = 100, sbyte MaxTemp = 50, sbyte MinTemp = -50, int Damage = 60, int Old = 100,NeuralNetwork Brain = null) {
			this.HP = HP;
			this.Energy = Energy;
			IG = i;
			JG = j;
			TempRange.MaxTemp = MaxTemp;
			TempRange.MinTemp = MinTemp;
			Link = link;
			Random ForName = new Random();
			HashName = ((DateTime.Today.ToString() + ForName.Next(0,100).ToString()).ToCharArray()).GetHashCode().ToString();
			Link.ListBot.Add(HashName,this);
			Link.SetBot(this,(int)IG,(int)JG);
			this.Damage = Damage;
			if(Brain == null)
				this.Brain = new NeuralNetwork(10);
			else
				this.Brain = new NeuralNetwork(Brain);
			this.Old = Old;
			OldChet = 0;
			Info.Eat = 0;
			Info.Generation = 0;
			Info.Kill = 0;
			Info.Kill = 0;
		} 
        /// <summary>
        /// Защищенный доступ к очкам здоровья
        /// </summary>
		public int HP_GET {
			get {
				return HP;
			}

			set {
				if (value > 100)
					HP = 100;
				else
					HP = value;
			}
		}
        /// <summary>
        /// Защищненный доступ к энергии
        /// </summary>
		public int ENERGY {
			get {
				return Energy;
			}
			set {
				if(value > 250)
					Energy = 250;
				else
					Energy = value;
			}
		}
        /// <summary>
        /// Расчет урона от HP
        /// </summary>
        /// <returns>урон</returns>
		public int DamageBot() {
			return (int)( Damage * HP / 100.0 );
		}
        /// <summary>
        /// Чистый урон
        /// </summary>
		public int DamageThis {
			get {
				return Damage;
			}
		}
        /// <summary>
        /// Возращает ссылку на объект нейросети
        /// </summary>
		public NeuralNetwork BRAIN {
			get {
				return Brain;
			}
		}
	}
}