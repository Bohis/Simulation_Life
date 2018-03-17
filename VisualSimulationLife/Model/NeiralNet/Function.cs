﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation_ConsoleVersion.NeuroBrainBor {
	/// <summary>
	/// Класс содержащий активационную функцию и распределение гаусса
	/// </summary>
	static class Function {
		static public double Gauss(double x) {
			return ( 1.0 / ( Math.Sqrt(5) * Math.Sqrt(2 * Math.PI) ) ) * Math.Exp(-( x * x ) / ( 2 * 5 ));
		}
		static public double Sigmoid(double x) {
			return 1.0 / ( 1 + Math.Exp(-1 * x) );
		}
	}
}
