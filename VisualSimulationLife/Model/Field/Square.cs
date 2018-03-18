using LifeSimulation.Model.ElBot;
namespace LifeSimulation.Model{
	/// <summary>
	/// Класс представляющий клетку поля, методы для работы с ней
	/// </summary>
	class Square {
		/// <summary>
		/// Поле бота
		/// </summary>
		Bot PlaceBot;
		/// <summary>
		/// Поле органической материи
		/// </summary>
		bool PlaceOrganicMatter;
		/// <summary>
		/// Поле освещенности
		/// </summary>
		byte PlaceLight;
		/// <summary>
		/// Поле температуры
		/// </summary>
		sbyte PlaceTemp;
		/// <summary>
		/// Была ли клетка изменена
		/// </summary>
		bool changes;
		/// <summary>
		/// Конструктор с параметрами по умолчанию
		/// </summary>
		/// <param name="PlaceBot">Для наследования</param>
		/// <param name="PlaceOrganicMatter">Для наследования</param>
		/// <param name="PlaceLight">Для наследования</param>
		/// <param name="PlaceTemp">Для наследования</param>
		public Square(Bot PlaceBot = null, bool PlaceOrganicMatter = false, byte PlaceLight = 50, sbyte PlaceTemp = 30) {
			PLACE_BOT = PlaceBot;
			PLACE_ORGANIC_MATTER = PlaceOrganicMatter;
			PLACE_LIGHT = PLACE_LIGHT;
			PLACE_TEMP = PlaceTemp;
			changes = true;
		}
		/// <summary>
		/// Свойсто для доступа к полю бота
		/// </summary>
		public Bot PLACE_BOT {
			get {
				return PlaceBot;
			}
			set {
				PlaceBot = value;
			}
		}
		/// <summary>
		/// Свойсто для доступа к полю органики
		/// </summary>
		public bool PLACE_ORGANIC_MATTER {
			get {
				return PlaceOrganicMatter;
			}
			set {
				PlaceOrganicMatter = (bool)value;
			}
		}
		/// <summary>
		/// Свойсто для доступа к полю освещенности
		/// </summary>
		public byte PLACE_LIGHT {
			get {
				return PlaceLight;
			}
			set {
				if (value > 100)
					PlaceLight = 100;
				else
					if (value < 0)
					PlaceLight = 0;
				else
					PlaceLight = (byte)value;
			}
		}
		/// <summary>
		/// Свойсто для доступа к полю температуры
		/// </summary>
		public sbyte PLACE_TEMP {
			get {
				return PlaceTemp;
			}
			set {
				try {
					PlaceTemp = checked((sbyte)value);
				}
				catch {
					PlaceTemp = 10;
				}
			}
		}
		/// <summary>
		/// Проверка занятости клетки
		/// </summary>
		public bool CheckBotPlace {
			get {
				if (PlaceBot != null)
					return true;
				else
					return false;
			}
		}
		/// <summary>
		/// Доступ к полю изменений для отрисовки
		/// </summary>
		public bool CHANGES{
			get {
				return changes;
			}
			set {
				changes = value;
			}
		}
	}
}