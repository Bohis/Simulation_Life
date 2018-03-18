using System;
using LifeSimulation.Model.NeiralNet;
using LifeSimulation.Model.FieldName;

namespace LifeSimulation.Model.ElBot{
	/// <summary>
	///  Структура диапазона температур
	/// </summary>
	struct Temp {
		public sbyte MinTemp;
		public sbyte MaxTemp;
	}
	/// <summary>
	/// Структура для статистики
	/// </summary>
	struct Statistic {
		public int Move;
		public int Kill;
		public int Eat;
		public int Generation;
	}
	/// <summary>
	/// Класс с реализацияей бота
	/// </summary>
	class Bot : ICloneable{
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
		int? Ig, Jg;
        /// <summary>
        /// Температурный диапазон для объекта
        /// </summary>
		Temp TempRange;
        /// <summary>
        /// Ссылка на поле
        /// </summary>
		Field Link;
        /// <summary>
        /// Имя объекта исполизуемое как ключ для хеш таблицы
        /// </summary>
		string HashName;
		/// <summary>
		/// Поле для статистики
		/// </summary>
		public Statistic Info;
        /// <summary>
        /// Урон бота при атаке
        /// </summary>
		int Damage;
        /// <summary>
        /// Возраст бота
        /// </summary>
		int OldChet;
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
		public Bot(Field link, int i = 0, int j = 0, int HP = 100, int Energy = 100, sbyte MaxTemp = 50, sbyte MinTemp = -50, int Damage = 60,NeuralNetwork Brain = null,int TrainingCoof = 3,bool TriggerClone = false) {
			this.HP = HP;
			this.Energy = Energy;
			IG = i;
			JG = j;
			TempRange.MaxTemp = MaxTemp;
			TempRange.MinTemp = MinTemp;
			Link = link;
			Random ForName = new Random();
			HashName = ((DateTime.Today.Millisecond.ToString() + ForName.Next(-500,499).ToString()).ToCharArray()).GetHashCode().ToString() + ((char)ForName.Next(97,122)).ToString();
			if (TriggerClone == false) {
				Link.ListBot.Add(HashName, this);
				Link.SetBot(this, (int)IG, (int)JG);
			}
			this.Damage = Damage;
			if(Brain == null)
				this.Brain = new NeuralNetwork(TrainingCoof);
			else
				this.Brain = new NeuralNetwork(Brain);
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
		/// <summary>
		///  Метод для получения информации из "вне"
		/// </summary>
		string LookAround() {
			if (IG != null && JG != null) {
				string HashString = new string("".ToCharArray());
				bool Index = false;
				// Посмотреть движение сверху
				try {
					if (Link.CheckPlaceBot((int)IG - 1, (int)JG, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}
				// Посмотреть движение влево
				try {
					if (Link.CheckPlaceBot((int)IG, (int)JG - 1, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}
				// Посмотреть движение вниз
				try {
					if (Link.CheckPlaceBot((int)IG + 1, (int)JG, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}
				// Посмотреть движение вправо
				try {
					if (Link.CheckPlaceBot((int)IG, (int)JG + 1, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}
				// Проверить органику в местонахождении бота
				try {
					if (Link[ (int)IG, (int)JG ].PLACE_ORGANIC_MATTER)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проверить возможность для фотосинтеза
				try {
					if (Link[ (int)IG, (int)JG ].PLACE_LIGHT >= 50)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проверить возможность для размножения
				try {
					if (( Link[ (int)IG, (int)JG ].PLACE_BOT.ENERGY >= 150 ) && ( HashString.Split('|')[ 0 ] == "1" || HashString.Split('|')[ 1 ] == "1" || HashString.Split('|')[ 2 ] == "1" || HashString.Split('|')[ 3 ] == "1" ))
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проветь возможность для лечения
				try {
					if (Link[ (int)IG, (int)JG ].PLACE_BOT.HP_GET < 100 && Link[ (int)IG, (int)JG ].PLACE_BOT.ENERGY >= 10 && Link[ (int)IG, (int)JG ].PLACE_BOT.HP_GET != 100)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проверить возможность для убийства сверху
				try {
					if (Link.CheckPlaceBot((int)IG - 1, (int)JG, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проверить возможность для убийства влево
				try {
					if (Link.CheckPlaceBot((int)IG, (int)JG - 1, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проверить возможность для убийства внизу
				try {
					if (Link.CheckPlaceBot((int)IG + 1, (int)JG, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Проверить возможность для убийства вправо
				try {
					if (Link.CheckPlaceBot((int)IG, (int)JG + 1, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Уровень HP
				try {
					if (Link[ (int)IG, (int)JG ].PLACE_BOT.HP_GET >= 50)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				// Уровень Energy
				try {
					if (Link[ (int)IG, (int)JG ].PLACE_BOT.ENERGY >= 125)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}
				return HashString;
			}
			return null;
		}
		#region Движения 
		/// <summary>
		/// Движение вверх
		/// </summary>
		void MoveUp() {
			try {
				Link.SetBot(this, (int)IG - 1, (int)JG);
				Link.ClearBot((int)IG, (int)JG, false);
				IG--;
				Info.Move++;
				Console.WriteLine("{0,10}: Совершил движение вверх", HashName);

			}
			catch {
			}
		}
		/// <summary>
		/// Движение влево
		/// </summary>
		void MoveLeft() {
			try {
				Link.SetBot(this, (int)IG, (int)JG - 1);
				Link.ClearBot((int)IG, (int)JG, false);
				JG--;
				Info.Move++;
				Console.WriteLine("{0,10}: Совершил движение влево", HashName);
			}
			catch {
			}
		}
		/// <summary>
		/// Движение вниз
		/// </summary>
		void MoveDown() {
			try {
				Link.SetBot(this, (int)IG + 1, (int)JG);
				Link.ClearBot((int)IG, (int)JG, false);
				IG++;
				Info.Move++;
				Console.WriteLine("{0,10}: Совершил движение вниз", HashName);

			}
			catch {
			}
		}
		/// <summary>
		/// Движение вправо
		/// </summary>
		void MoveRight() {
			try {
				Link.SetBot(this, (int)IG, (int)JG + 1);
				Link.ClearBot((int)IG, (int)JG, false);
				JG++;
				Info.Move++;
				Console.WriteLine("{0,10}: Совершил движение вправо", HashName);
			}
			catch {
			}
		}
		/// <summary>
		/// Поедание органики, если она находится в одной с ботом клетке
		/// </summary>
		void EatOrganic() {
			try {
				Link[ (int)IG, (int)JG ].PLACE_ORGANIC_MATTER = false;
				ENERGY += 50;
				Info.Eat++;
				Link[ (int)IG, (int)JG ].CHANGES = true;
				Console.WriteLine("{0,10}: Совершил движение поедание органики", HashName);
			}
			catch {
			}
		}
		/// <summary>
		/// Фотосинтез при условии достаточной освещенности в клетке
		/// </summary>
		void EatPhotosynthesis() {
			try {
				ENERGY += (int)( Link[ (int)IG, (int)JG ].PLACE_LIGHT * 0.3 );
				Info.Eat++;
				Console.WriteLine("{0,10}: Совершил движение фотосинтез", HashName);
			}
			catch {
			}
		}
		/// <summary>
		/// Лечение за счет энергии бота
		/// </summary>
		void HealBot() {
			try {
				int MisingHp = ( 100 - HP_GET ) * 2;
				if (MisingHp >= ENERGY)
					MisingHp = ( MisingHp - ENERGY ) - 10;
				ENERGY -= MisingHp;
				HP_GET += ( MisingHp / 2 );
				Console.WriteLine("{0,10}: Совершил движение лечение", HashName);
			}
			catch {
			}
		}
		/// <summary>
		/// Партогенез
		/// </summary>
		void Generation(string StringMove) {
			try {
				Random ForTempHp = new Random();
				if (StringMove.Split('|')[ 0 ] == "1") {
					Link.SetBot(new Bot(Link, (int)IG - 1, (int)JG, HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( TempRange.MinTemp + ForTempHp.Next(-3, 3) ), DamageThis + ForTempHp.Next(-3, 3), BRAIN), (int)IG - 1, (int)JG);
					ENERGY -= 150;
					Info.Generation++;
				}
				else
					if (StringMove.Split('|')[ 1 ] == "1") {
					Link.SetBot(new Bot(Link, (int)IG, (int)JG - 1, HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( TempRange.MinTemp + ForTempHp.Next(-3, 3) ), DamageThis + ForTempHp.Next(-3, 3), BRAIN), (int)IG, (int)JG - 1);
					ENERGY -= 150;
					Info.Generation++;
				}
				else
					if (StringMove.Split('|')[ 2 ] == "1") {
					Link.SetBot(new Bot(Link, (int)IG + 1, (int)JG, HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( TempRange.MinTemp + ForTempHp.Next(-3, 3) ),  DamageThis + ForTempHp.Next(-3, 3), BRAIN), (int)IG + 1, (int)JG);
					ENERGY -= 150;
					Info.Generation++;
				}
				else
					if (StringMove.Split('|')[ 3 ] == "1") {
					Link.SetBot(new Bot(Link, (int)IG, (int)JG + 1, HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( TempRange.MinTemp + ForTempHp.Next(-3, 3) ), DamageThis + ForTempHp.Next(-3, 3), BRAIN), (int)IG, (int)JG + 1);
					ENERGY -= 150;
					Info.Generation++;
				}
				Console.WriteLine("{0,10}: Совершил движение размножение", HashName);
			}
			catch {
			}
		}
		/// <summary>
		/// Убийство бота в соседних клетках
		/// </summary>
		void KillOtherBot(string StringMove) {
			int Modi = 0, Modj = 0;
			if (StringMove.Split('|')[ 8 ] == "1") {
				Modi = -1;
				Modj = 0;
				goto Break;
			}
			else
				if (StringMove.Split('|')[ 10 ] == "1") {
				Modi = 0;
				Modj = -1;
				goto Break;
			}
			else
				if (StringMove.Split('|')[ 10 ] == "1") {
				Modi = +1;
				Modj = 0;
				goto Break;
			}
			else
				if (StringMove.Split('|')[ 11 ] == "1") {
				Modi = 0;
				Modj = +1;
				goto Break;
			}
			Break:
			Bot Enemy;
			try {
				Enemy = Link[ (int)IG + Modi, (int)JG + Modj ].PLACE_BOT;
				if (Enemy == null)
					throw new Exception();
			}
			catch {
				return;
			}
			if (DamageBot() >= Enemy.DamageBot()) {
				Link.ClearBot((int)Enemy.IG, (int)Enemy.JG);
				Link.ListBot.Remove(Enemy.HashName);
				HP_GET += Enemy.HP_GET / 2;
				ENERGY += Enemy.ENERGY / 2;
				Info.Kill++;
				Console.WriteLine("{0,10}: Совершил движение убийство", HashName);

				return;
			}
			else {
				Link.ClearBot((int)IG, (int)JG);
				Link.ListBot.Remove(HashName);
				Enemy.HP_GET += HP_GET / 2;
				Enemy.ENERGY += ENERGY / 2;
				Enemy.Info.Kill++;
				Console.WriteLine("{0,10}: Совершил движение был убит", HashName);
				return;
			}
		}
		#endregion
		/// <summary>
		/// Движение бота по ранне сработавшему методу LookArround
		/// </summary>
		public void Move() {
			string HashStr = LookAround();
			ENERGY -= 10;
			OldChet++;
			string TimeHashStr = new string("".ToCharArray());
			if (HashStr.Split('|')[ 0 ] == "1" || HashStr.Split('|')[ 1 ] == "1" || HashStr.Split('|')[ 2 ] == "1" || HashStr.Split('|')[ 3 ] == "1")
				TimeHashStr += "1|";
			else
				TimeHashStr += "0|";
			TimeHashStr += HashStr.Split('|')[ 4 ] + "|" + HashStr.Split('|')[ 5 ] + "|" + HashStr.Split('|')[ 6 ] + "|" + HashStr.Split('|')[ 7 ] + "|";
			if (HashStr.Split('|')[ 8 ] == "1" || HashStr.Split('|')[ 9 ] == "1" || HashStr.Split('|')[ 10 ] == "1" || HashStr.Split('|')[ 11 ] == "1")
				TimeHashStr += "1|";
			else
				TimeHashStr += "0|";
			int Binchoise = 0;
			TimeHashStr = BRAIN.WorkNet(TimeHashStr);
			Console.WriteLine("{0,10}: Обработаная информация из нейросети {1,9}", HashName, TimeHashStr);
			for (int i = 3; i >= 0; i--)
				Binchoise += int.Parse(TimeHashStr.Split('|')[ i ]) * (int)Math.Pow(2, 3 - i);
			switch (Binchoise) {
				case 0: {
						if (HashStr.Split('|')[ 0 ] == "1") {
							MoveUp();
							return;
						}
						break;
					}
				case 1: {

						if (HashStr.Split('|')[ 1 ] == "1") {
							MoveLeft();
							return;
						}
						break;
					}
				case 2: {
						if (HashStr.Split('|')[ 2 ] == "1") {
							MoveDown();
							return;
						}
						break;
					}
				case 3: {
						if (HashStr.Split('|')[ 3 ] == "1") {
							MoveRight();
							return;
						}
						break;
					}
				case 4: {
						if (HashStr.Split('|')[ 4 ] == "1") {
							EatOrganic();
							return;
						}
						break;
					}
				case 5: {

						if (HashStr.Split('|')[ 5 ] == "1") {
							EatPhotosynthesis();
							return;
						}
						break;
					}
				case 6: {
						if (HashStr.Split('|')[ 6 ] == "1") {
							Generation(HashStr);
							return;
						}
						break;
					}
				case 7: {
						if (HashStr.Split('|')[ 7 ] == "1") {
							HealBot();
							return;
						}
						break;
					}
				case 8: {
						if (HashStr.Split('|')[ 8 ] == "1" || HashStr.Split('|')[ 9 ] == "1" || HashStr.Split('|')[ 10 ] == "1" || HashStr.Split('|')[ 11 ] == "1") {
							KillOtherBot(HashStr);
							return;
						}
						break;
					}
				default: {
						Console.WriteLine("{0,10}: Бездействие", HashName);
						break;
					}
			}
		}
		///<summary>
		/// Защищенный доступ к координатам
		/// </summary>
		public int? IG {
			get {
				return (int)Ig;
			}
			set {
				Ig = value;
			}
		}
		///<summary>
		/// Защищенный доступ к координатам
		/// </summary>
		public int? JG {
			get {
				return (int)Jg;
			}
			set {
				Jg = value;
			}
		}
		/// <summary>
		/// Защищенный доступ к температурному диапазону 
		/// </summary>
		public Temp TEMP_RANGE {
			get {
				return TempRange;
			}
			set {
				TempRange = value;
			}
		}
		/// <summary>
		/// Доступ к хеш имени бота
		/// </summary>
		public string HASH_NAME {
			get {
				return HashName;
			}
		}
		///<summary>
		/// Доступ к возрасту бота
		/// </summary>
		public int OLD_CHET {
			get {
				return OldChet;
			}
		}
		///<summary>
		/// Создание копии данного объекта, не ссылки
		/// </summary>
		public Object Clone() {
			return new Bot(Link,(int)Ig,(int)Jg,HP,Energy,TempRange.MaxTemp,TempRange.MinTemp,Damage,Brain,BRAIN.TRAING_COOF,true);
		}
	}
}