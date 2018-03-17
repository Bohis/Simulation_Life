using System;

namespace LifeSimulation_ConsoleVersion.LifeSimulation {
	/// <summary>
	///  Структура диапазона температур
	/// </summary>
	struct Temp {
		public sbyte MinTemp;
		public sbyte MaxTemp;
	}
	/// <summary>
	/// Класс движения бота
	/// </summary>
	class MoveTo {
		/// <summary>
		///  Метод для получения информации из "вне"
		/// </summary>
		/// <param name="j">координаты бота</param>
		/// <param name="i">координаты бота</param>
		/// <param name="link">ссылка на экземпляр поля</param>
		/// <returns>строку состоящаю из доступных действий</returns>
		public string LookAround(int? j, int? i, Field link) {
			if (i != null && j != null) {
				string HashString = new string("".ToCharArray());
				bool Index = false;

				try {
					if (link.CheckPlaceBot((int)i - 1, (int)j, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i, (int)j - 1, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i + 1, (int)j, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i, (int)j + 1, out Index) == false && !Index)
						HashString += "1|";
					else
						throw new Exception();
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link[ (int)i, (int)j ].PLACE_ORGANIC_MATTER)
						HashString += "1|";
					else
						HashString += "0|";

				}
				catch {
					HashString += "0|";
				}

				try {
					if (link[ (int)i, (int)j ].PLACE_LIGHT >= 50)
						HashString += "1|";
					else
						HashString += "0|";

				}
				catch {
					HashString += "0|";
				}

				try {
					if (( link[ (int)i, (int)j ].PLACE_BOT.ENERGY >= 150 ) && ( HashString.Split('|')[ 0 ] == "1" || HashString.Split('|')[ 1 ] == "1" || HashString.Split('|')[ 2 ] == "1" || HashString.Split('|')[ 3 ] == "1" ))
						HashString += "1|";
					else
						HashString += "0|";

				}
				catch {
					HashString += "0|";
				}

				try {
					if (link[ (int)i, (int)j ].PLACE_BOT.HP_GET < 100 && link[ (int)i, (int)j ].PLACE_BOT.ENERGY >= 10 && link[ (int)i, (int)j ].PLACE_BOT.HP_GET != 100)
						HashString += "1|";
					else
						HashString += "0|";

				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i - 1, (int)j, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i, (int)j - 1, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i + 1, (int)j, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link.CheckPlaceBot((int)i, (int)j + 1, out Index) && !Index)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link[ (int)i, (int)j ].PLACE_BOT.HP_GET >= 50)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}

				try {
					if (link[ (int)i, (int)j ].PLACE_BOT.ENERGY >= 125)
						HashString += "1|";
					else
						HashString += "0|";
				}
				catch {
					HashString += "0|";
				}

				//Console.WriteLine(HashString);
				return HashString;
			}
			return null;
		}
		/// <summary>
		/// Движение вверх
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		void MoveUp(Field link, Bot bot) {
			try {
				link.SetBot(bot, (int)bot.IG - 1, (int)bot.JG);
				link.ClearBot((int)bot.IG, (int)bot.JG,false);
				bot.IG--;
				bot.Info.Move++;
				
			}
			catch {
			}
		}
		/// <summary>
		/// Движение влево
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		void MoveLeft(Field link, Bot bot) {
			try {
				link.SetBot(bot, (int)bot.IG, (int)bot.JG - 1);
				link.ClearBot((int)bot.IG, (int)bot.JG, false);
				bot.JG--;
				bot.Info.Move++;

			}
			catch {
			}
		}
		/// <summary>
		/// Движение вниз
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		void MoveDown(Field link, Bot bot) {
			try {
				link.SetBot(bot, (int)bot.IG + 1, (int)bot.JG);
				link.ClearBot((int)bot.IG, (int)bot.JG, false);
				bot.IG++;
				bot.Info.Move++;

			}
			catch {
			}
		}
		/// <summary>
		/// Движение вправо
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		void MoveRight(Field link, Bot bot) {
			try {
				link.SetBot(bot, (int)bot.IG, (int)bot.JG + 1);
				link.ClearBot((int)bot.IG, (int)bot.JG, false);
				bot.JG++;
				bot.Info.Move++;

			}
			catch {
			}
		}
		/// <summary>
		/// Поедание органики, если она находится в одной с ботом клетке
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		void EatOrganic(Field link, Bot bot) {
			try {
				link[ (int)bot.IG, (int)bot.JG ].PLACE_ORGANIC_MATTER = false;
				bot.ENERGY += 50;
				bot.Info.Eat++;
				link[ (int)bot.IG, (int)bot.JG ].CHANGES = true;

				return;
			}
			catch {
			}
		}
		/// <summary>
		/// Фотосинтез при условии достаточной освещенности в клетке
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		void EatPhotosynthesis(Field link, Bot bot) {
			try {
				bot.ENERGY += (int)( link[ (int)bot.IG, (int)bot.JG ].PLACE_LIGHT * 0.3 );
				bot.Info.Eat++;
				return;
			}
			catch {
			}
		}
		/// <summary>
		/// Лечение за счет энергии бота
		/// </summary>
		/// <param name="bot">ссылка на объект бота</param>
		void HealBot(Bot bot) {
			try {
				int MisingHp = ( 100 - bot.HP_GET ) * 2;
				if (MisingHp >= bot.ENERGY) {
					MisingHp = ( MisingHp - bot.ENERGY ) - 10;
				}
				bot.ENERGY -= MisingHp;
				bot.HP_GET += ( MisingHp / 2 );
				return;
			}
			catch {
			}
		}
		/// <summary>
		/// Партогенез
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бота</param>
		/// <param name="StringMove">строка содержащая 0 или 1 (занятость соседней клетки)</param>
		void Generation(Field link, Bot bot, string StringMove) {
			try {
				Random ForTempHp = new Random();
				if (StringMove.Split('|')[ 0 ] == "1") {
					link.SetBot(new Bot(link, (int)bot.IG - 1, (int)bot.JG, bot.HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( bot.TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( bot.TempRange.MinTemp + ForTempHp.Next(-3, 3) ),(int)(bot.Old + ForTempHp.Next(-2,2)) ,bot.DamageThis + ForTempHp.Next(-3, 3), bot.BRAIN), (int)bot.IG - 1, (int)bot.JG);
					bot.ENERGY -= 150;
					bot.Info.Generation++;
				}
				else
					if (StringMove.Split('|')[ 1 ] == "1") {
					link.SetBot(new Bot(link, (int)bot.IG, (int)bot.JG - 1, bot.HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( bot.TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( bot.TempRange.MinTemp + ForTempHp.Next(-3, 3) ), (int)( bot.Old + ForTempHp.Next(-2, 2) ) ,bot.DamageThis + ForTempHp.Next(-3, 3), bot.BRAIN), (int)bot.IG, (int)bot.JG - 1);
					bot.ENERGY -= 150;
					bot.Info.Generation++;

				}
				else
					if (StringMove.Split('|')[ 2 ] == "1") {
					link.SetBot(new Bot(link, (int)bot.IG + 1, (int)bot.JG, bot.HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( bot.TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( bot.TempRange.MinTemp + ForTempHp.Next(-3, 3) ), (int)( bot.Old + ForTempHp.Next(-2, 2) ) ,bot.DamageThis + ForTempHp.Next(-3, 3), bot.BRAIN), (int)bot.IG + 1, (int)bot.JG);
					bot.ENERGY -= 150;
					bot.Info.Generation++;

				}
				else
					if (StringMove.Split('|')[ 3 ] == "1") {
					link.SetBot(new Bot(link, (int)bot.IG, (int)bot.JG + 1, bot.HP_GET + ForTempHp.Next(-3, 3), 100, (sbyte)( bot.TempRange.MaxTemp + ForTempHp.Next(-3, 3) ), (sbyte)( bot.TempRange.MinTemp + ForTempHp.Next(-3, 3) ), (int)( bot.Old + ForTempHp.Next(-2, 2) ) ,bot.DamageThis + ForTempHp.Next(-3, 3), bot.BRAIN), (int)bot.IG, (int)bot.JG + 1);
					bot.ENERGY -= 150;
					bot.Info.Generation++;

				}
				return;
			}
			catch {
			}
		}
		/// <summary>
		/// Убийство бота в соседних клетках
		/// </summary>
		/// <param name="link">ссылка на объект поля</param>
		/// <param name="bot">ссылка на объект бот</param>
		/// <param name="StringMove">строка содержащая 1 или 0 (занятость соседней клетки)</param>
		void KillOtherBot(Field link, Bot bot, string StringMove) {
			int Modi = 0, Modj = 0;
			if (StringMove.Split('|')[ 8 ] == "1") {
				Modi = -1;
				Modj = 0;
				goto Break;
			}
			else
				if (StringMove.Split('|')[ 9 ] == "1") {
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
				Enemy = link[ (int)bot.IG + Modi, (int)bot.JG + Modj ].PLACE_BOT;
				if (Enemy == null)
					throw new Exception();
			}
			catch {
				return;
			}
			if (bot.DamageBot() >= Enemy.DamageBot()) {
				link.ClearBot((int)Enemy.IG, (int)Enemy.JG);
				link.ListBot.Remove(Enemy.HashName);
				bot.HP_GET += Enemy.HP_GET / 2;
				bot.ENERGY += Enemy.ENERGY / 2;
				bot.Info.Kill++;
				Enemy = null;
				return;
			}
			else {
				link.ClearBot((int)bot.IG, (int)bot.JG);
				link.ListBot.Remove(bot.HashName);
				Enemy.HP_GET += bot.HP_GET / 2;
				Enemy.ENERGY += bot.ENERGY / 2;
				Enemy.Info.Kill++;
				bot = null;
				return;
			}
		}
		/// <summary>
		/// Двмжение бота по ранне сработавшему методу LookArround
		/// </summary>
		/// <param name="HashStr">Строка действий</param>
		/// <param name="bot">ссылка на объект бота</param>
		/// <param name="link">ссылка на объект поля</param>
		public void Move(string HashStr, Bot bot, Field link) {
			bot.ENERGY -= 10;
			bot.OldChet++;
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
			TimeHashStr = bot.BRAIN.WorkNet(TimeHashStr);
			for (int i = 3; i >= 0; i--) {
				Binchoise += int.Parse(TimeHashStr.Split('|')[ i ]) * (int)Math.Pow(2, 3 - i);
			}
			switch (Binchoise) {
				case 0: {
						if (HashStr.Split('|')[ 0 ] == "1") {
							MoveUp(link, bot);
							return;
						}
						break;
					}
				case 1: {

						if (HashStr.Split('|')[ 1 ] == "1") {
							MoveLeft(link, bot);
							return;
						}
						break;
					}
				case 2: {
						if (HashStr.Split('|')[ 2 ] == "1") {
							MoveDown(link, bot);
							return;
						}
						break;
					}
				case 3: {
						if (HashStr.Split('|')[ 3 ] == "1") {
							MoveRight(link, bot);
							return;
						}
						break;
					}
				case 4: {
						if (HashStr.Split('|')[ 4 ] == "1") {
							EatOrganic(link, bot);
							return;
						}
						break;
					}
				case 5: {

						if (HashStr.Split('|')[ 5 ] == "1") {
							EatPhotosynthesis(link, bot);
							return;
						}
						break;
					}
				case 6: {
						if (HashStr.Split('|')[ 6 ] == "1") {
							Generation(link, bot, HashStr);
							return;
						}
						break;
					}
				case 7: {
						if (HashStr.Split('|')[ 7 ] == "1") {
							HealBot(bot);
							return;
						}
						break;
					}
				case 8: {
						if (HashStr.Split('|')[ 8 ] == "1" || HashStr.Split('|')[ 9 ] == "1" || HashStr.Split('|')[ 10 ] == "1" || HashStr.Split('|')[ 11 ] == "1") {
							KillOtherBot(link, bot, HashStr);
							return;
						}
						break;
					}
				default: {
						break;
					}
			}
		}
	}
}