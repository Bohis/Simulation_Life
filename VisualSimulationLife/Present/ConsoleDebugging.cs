using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LifeSimulation.Present {
	/// <summary>
	/// Работа с консолью
	/// </summary>
	public sealed class ConsoleDebugging {
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		/// <summary>
		/// Триггер указывающий на открытое окно консоли
		/// </summary>
		bool Show;
		IntPtr handle;
		public ConsoleDebugging() {
			handle = GetConsoleWindow();
			Show = true;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Green;
		}
		/// <summary>
		/// Скрыть консоль
		/// </summary>
		public void ClouseWindow() {
			ShowWindow(handle, SW_HIDE);
			Show = false;
		}
		/// <summary>
		/// Открыть консоль
		/// </summary>
		public void ShowWindow() {
			ShowWindow(handle, SW_SHOW);
			Show = true;
		}
		/// <summary>
		/// Получить значение открытого окна
		/// </summary>
		public bool SHOW {
			get => Show;
		}
	}
}
