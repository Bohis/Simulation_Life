using System;
using System.Collections;
using LifeSimulation.Model.ElBot;

namespace LifeSimulation.Model.FieldName{
	///<summary>
	///Класс организующий работу с полем из Square
	///</summary>
	class Field {
		///<summary>
		///Матрица клеток с ботом
        ///</summary>
		Square[,] MatrixBot;
        /// <summary>
        /// Хеш таблица для хранения ботов
        /// </summary>
		public Hashtable ListBot;
        /// <summary>
        /// Размер квадратного поля
        /// </summary>
		public int N;
		/// <summary>
		/// Коструктор класса Field
		/// </summary>
		/// <param name="n">размер поля</param>
		public Field(int n = 10, bool DinamicChoiseBool = false) {
			N = n;
			MatrixBot = new Square[ N, N ];
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					MatrixBot[ i, j ] = new Square();
			ListBot = new Hashtable();
			Random ForOrganicPlace = new Random();
			DinamicOrganic();
			double Cels = N / 100.0;
			for (int i = N - 1; i >= 0 ; i--) {
				for (int j = 0; j < N; j++)
					MatrixBot[ i, j ].PLACE_LIGHT = (byte)(Cels);
				Cels += N / 100.0;
			}
			DinamicFieldTemp();
		}
		/// <summary>
		/// Заполнение поле температуры распространением волны
		/// </summary>
		public void DinamicFieldTemp(){
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					MatrixBot[ i, j ].PLACE_TEMP = -120;
			int[,] Myr = { { -1, 0, 1, 0 }, { 0, 1, 0, -1 } };
			Random ForTemp = new Random();
			int Start_i = ForTemp.Next(0, N);
			int Start_j = ForTemp.Next(0, N);
			MatrixBot[ Start_i, Start_j ].PLACE_TEMP = -100;
			int y, x, k;
			sbyte d = -100;
			bool stop = true;
			do {
				stop = true;
				for (y = 0; y < N; ++y)
					for (x = 0; x < N; ++x)
						if (MatrixBot[ y, x ].PLACE_TEMP == d) {
							for (k = 0; k < 4; ++k) {
								int iy = y + Myr[ 0, k ], ix = x + Myr[ 1, k ];
								if (iy >= 0 && iy < N && ix >= 0 && ix < N && MatrixBot[ iy, ix ].PLACE_TEMP == -120) {
									stop = false;
									MatrixBot[ iy, ix ].PLACE_TEMP = (sbyte)( d + 3);
								}
							}
						}
				d += 3;
			} while (!stop || d <= 100);
		}
		/// <summary>
		/// Разброс органики по полю
		/// </summary>
		public void DinamicOrganic() {
			Random ForOrganicPlace = new Random();
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					if (ForOrganicPlace.Next(0, 20) == 1) {
						MatrixBot[ i, j ].PLACE_ORGANIC_MATTER = true;
					}
					else {
						MatrixBot[ i, j ].PLACE_ORGANIC_MATTER = false;
					}
		}
        /// <summary>
        /// Перегрузка для работы с конкретными полями матрицы
        /// </summary>
        /// <param name="i">индекс строк</param>
        /// <param name="j">индекс столбцов</param>
        /// <returns>Ячейка матрицы</returns>
		public Square this[ int i, int j ] {
			get {
				return MatrixBot[ i, j ];
			}
		}
        /// <summary>
        /// Получить ссылку на бота в ячейке
        /// </summary>
        /// <param name="i">индекс строк</param>
        /// <param name="j">индекс столбцов</param>
        /// <returns></returns>
		public Bot GetBot(int i, int j) {
			return MatrixBot[ i, j ].PLACE_BOT;
		}
        /// <summary>
        /// Установить бота в конкретной ячейке
        /// </summary>
        /// <param name="bot">ссылка на экземпляр бота</param>
        /// <param name="i">индекс строк</param>
        /// <param name="j">индекс столбцов</param>
		public void SetBot(Bot bot, int i , int j) {
			if (MatrixBot[ i, j ].PLACE_BOT == null) {
				MatrixBot[ i, j ].PLACE_BOT = bot;
				MatrixBot[ i, j ].CHANGES = true;
			}
		}
        /// <summary>
        /// Очистить ячейку с ботом от бота
        /// </summary>
        /// <param name="i">индекс строк</param>
        /// <param name="j">индекс столбцов</param>
		public void ClearBot(int i, int j,bool Organic = true) {
			MatrixBot[ i, j ].PLACE_BOT = null;
			MatrixBot[ i, j ].CHANGES = true;
			if (Organic)
				MatrixBot[ i, j ].PLACE_ORGANIC_MATTER = true;
		}
        /// <summary>
        ///  Провеить явлеется ли эта ячейка "населена" ботом
        /// </summary>
        /// <param name="i">индекс строк</param>
        /// <param name="j">индекс столбцов</param>
        /// <param name="Index">true - если не выходит за границу, false - выход за границу</param>
        /// <returns>true - если ячейка занята, false - если не занята</returns>
		public bool CheckPlaceBot(int i,int j, out bool Index) {
			try {
				if (MatrixBot[ i, j ].CheckBotPlace) {
					Index = false;
					return true;
				}
				else {
					Index = false;
					return false;
				}
			}
			catch (IndexOutOfRangeException) {
			}
			Index = true;
			return false;
		}
	}
}