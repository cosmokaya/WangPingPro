using System;
using System.Collections.Generic;

namespace wMetroGIS.wMathmatics
{
	public static class Mathmatics
	{
		public enum NOISE_TYPE
		{
			RED_NOISE,
			WHITE_NOISE
		}

		public const double AirMolecularWeight = 28.966;

		public const double GasConstant = 8.314472;

		public const double AbsoluteZero = 273.15;

		public const double Kaid = 0.2859;

		public const double Eps = 622.0;

		public const double Cpd = 1004.0;

		public static double[] T_alpha005 = new double[]
		{
			12.706,
			4.303,
			3.182,
			2.776,
			2.571,
			2.447,
			2.365,
			2.306,
			2.262,
			2.228,
			2.201,
			2.179,
			2.16,
			2.145,
			2.131,
			2.12,
			2.11,
			2.101,
			2.093,
			2.086,
			2.08,
			2.074,
			2.069,
			2.064,
			2.06,
			2.056,
			2.052,
			2.048,
			2.045,
			2.042,
			2.021,
			2.0,
			1.198,
			1.906
		};

		public static double[] T_alpha001 = new double[]
		{
			63.657,
			9.925,
			5.841,
			4.604,
			4.032,
			3.707,
			3.499,
			3.355,
			3.25,
			3.169,
			3.106,
			3.055,
			3.102,
			2.977,
			2.947,
			2.921,
			2.898,
			2.878,
			2.861,
			2.845,
			2.831,
			2.819,
			2.807,
			2.797,
			2.787,
			2.779,
			2.771,
			2.763,
			2.756,
			2.75,
			2.704,
			2.66,
			2.617,
			2.576
		};

		public static double[] Kai005 = new double[]
		{
			3.84,
			5.99,
			7.82,
			9.49,
			11.07,
			12.59,
			14.07,
			15.51,
			16.92,
			18.31,
			19.68,
			21.03,
			22.36,
			23.69,
			25.0,
			26.3,
			27.59,
			28.87,
			30.14,
			31.41,
			32.67,
			33.92,
			35.17,
			36.42,
			37.65,
			38.89,
			40.11,
			41.34,
			42.56,
			43.77
		};

		public static double GetAngle(double x1, double y1, double x2, double y2)
		{
			double angle = System.Math.Atan((y2 - y1) / (x2 - x1)) * 180.0 / 3.1415926535897931;
			if (x2 >= x1)
			{
				if (y2 < y1)
				{
					angle += 360.0;
				}
			}
			else
			{
				angle += 180.0;
			}
			return angle;
		}

		public static double GetModel(double x, double y)
		{
			return System.Math.Sqrt(x * x + y * y);
		}

		public static void FxFsToUV(double Fs, double Fx, out double U, out double V)
		{
			U = (double)System.Convert.ToSingle(Fs * System.Math.Sin(Fx * 3.1415926535897931 / 180.0));
			V = (double)System.Convert.ToSingle(Fs * System.Math.Cos(Fx * 3.1415926535897931 / 180.0));
		}

		public static void UVToFxFs(double U, double V, out double Fs, out double Fx)
		{
			Fs = System.Convert.ToDouble(System.Math.Sqrt(U * U + V * V));
			U *= -1.0;
			V *= -1.0;
			if (U == 0.0 && V == 0.0)
			{
				Fx = 0.0;
			}
			else
			{
				double a;
				if (U >= 0.0)
				{
					a = 90.0 - 180.0 * System.Math.Atan(V / U) / 3.1415926535897931;
				}
				else
				{
					a = 270.0 - 180.0 * System.Math.Atan(V / U) / 3.1415926535897931;
				}
				Fx = a;
			}
		}

		public static void UVToMA(double U, double V, out double M, out double A)
		{
			M = (double)System.Convert.ToInt32(System.Math.Sqrt(U * U + V * V));
			if (U == 0.0 && V == 0.0)
			{
				A = 0.0;
			}
			else
			{
				double a;
				if (U >= 0.0)
				{
					a = 90.0 - 180.0 * System.Math.Atan(V / U) / 3.1415926535897931;
				}
				else
				{
					a = 270.0 - 180.0 * System.Math.Atan(V / U) / 3.1415926535897931;
				}
				A = a;
			}
		}

		public static void MAToUV(float M, float A, out float U, out float V)
		{
			double a = (double)A * 3.1415926535897931 / 180.0;
			U = System.Convert.ToSingle((double)M * System.Math.Cos(a));
			V = System.Convert.ToSingle((double)M * System.Math.Sin(a));
		}

		public static float SLGQ(float[] XValue, float[] YValue, float[] DataValue, float V, float U)
		{
			int i = XValue.Length;
			int j = YValue.Length;
			float result;
			if (j * i != DataValue.Length)
			{
				result = -999f;
			}
			else
			{
				float[] b = new float[10];
				int ip;
				int ipp;
				if (U <= XValue[0])
				{
					ip = 1;
					ipp = 4;
				}
				else if (U >= XValue[i - 1])
				{
					ip = i - 3;
					ipp = i;
				}
				else
				{
					int k = 1;
					int l = i;
					while (k - l != 1 && k - l != -1)
					{
						int m = (k + l) / 2;
						if (U < XValue[m - 1])
						{
							l = m;
						}
						else
						{
							k = m;
						}
					}
					ip = k - 2;
					ipp = k + 2;
				}
				if (ip < 1)
				{
					ip = 1;
				}
				if (ipp > i)
				{
					ipp = i;
				}
				int iq;
				int iqq;
				if (V <= YValue[0])
				{
					iq = 1;
					iqq = 4;
				}
				else if (V >= YValue[j - 1])
				{
					iq = j - 3;
					iqq = j;
				}
				else
				{
					int k = 1;
					int l = j;
					while (k - l != 1 && k - l != -1)
					{
						int m = (k + l) / 2;
						if (V < YValue[m - 1])
						{
							l = m;
						}
						else
						{
							k = m;
						}
					}
					iq = k - 2;
					iqq = k + 2;
				}
				if (iq < 1)
				{
					iq = 1;
				}
				if (iqq > j)
				{
					iqq = j;
				}
				for (int k = ip - 1; k <= ipp - 1; k++)
				{
					b[k - ip + 1] = 0f;
					for (int l = iq - 1; l <= iqq - 1; l++)
					{
						float h = DataValue[j * k + l];
						for (int n = iq - 1; n <= iqq - 1; n++)
						{
							if (n != l)
							{
								h = h * (V - YValue[n]) / (YValue[l] - YValue[n]);
							}
						}
						b[k - ip + 1] = b[k - ip + 1] + h;
					}
				}
				float w = 0f;
				for (int k = ip - 1; k <= ipp - 1; k++)
				{
					float h = b[k - ip + 1];
					for (int l = ip - 1; l <= ipp - 1; l++)
					{
						if (l != k)
						{
							h = h * (U - XValue[l]) / (XValue[k] - XValue[l]);
						}
					}
					w += h;
				}
				result = w;
			}
			return result;
		}

		public static double SLGQ(double[] XValue, double[] YValue, double[] DataValue, double V, double U)
		{
			int i = XValue.Length;
			int j = YValue.Length;
			double result;
			if (j * i != DataValue.Length)
			{
				result = -999.0;
			}
			else
			{
				double[] b = new double[10];
				int ip;
				int ipp;
				if (U <= XValue[0])
				{
					ip = 1;
					ipp = 4;
				}
				else if (U >= XValue[i - 1])
				{
					ip = i - 3;
					ipp = i;
				}
				else
				{
					int k = 1;
					int l = i;
					while (k - l != 1 && k - l != -1)
					{
						int m = (k + l) / 2;
						if (U < XValue[m - 1])
						{
							l = m;
						}
						else
						{
							k = m;
						}
					}
					ip = k - 2;
					ipp = k + 2;
				}
				if (ip < 1)
				{
					ip = 1;
				}
				if (ipp > i)
				{
					ipp = i;
				}
				int iq;
				int iqq;
				if (V <= YValue[0])
				{
					iq = 1;
					iqq = 4;
				}
				else if (V >= YValue[j - 1])
				{
					iq = j - 3;
					iqq = j;
				}
				else
				{
					int k = 1;
					int l = j;
					while (k - l != 1 && k - l != -1)
					{
						int m = (k + l) / 2;
						if (V < YValue[m - 1])
						{
							l = m;
						}
						else
						{
							k = m;
						}
					}
					iq = k - 2;
					iqq = k + 2;
				}
				if (iq < 1)
				{
					iq = 1;
				}
				if (iqq > j)
				{
					iqq = j;
				}
				for (int k = ip - 1; k <= ipp - 1; k++)
				{
					b[k - ip + 1] = 0.0;
					for (int l = iq - 1; l <= iqq - 1; l++)
					{
						double h = DataValue[j * k + l];
						for (int n = iq - 1; n <= iqq - 1; n++)
						{
							if (n != l)
							{
								h = h * (V - YValue[n]) / (YValue[l] - YValue[n]);
							}
						}
						b[k - ip + 1] = b[k - ip + 1] + h;
					}
				}
				double w = 0.0;
				for (int k = ip - 1; k <= ipp - 1; k++)
				{
					double h = b[k - ip + 1];
					for (int l = ip - 1; l <= ipp - 1; l++)
					{
						if (l != k)
						{
							h = h * (U - XValue[l]) / (XValue[k] - XValue[l]);
						}
					}
					w += h;
				}
				result = w;
			}
			return result;
		}

		public static double[] Normalize(double[] X, int n)
		{
			double Xm = 0.0;
			for (int i = 0; i < n; i++)
			{
				Xm += X[i];
			}
			Xm /= (double)n;
			double s = 0.0;
			for (int i = 0; i < n; i++)
			{
				s += (X[i] - Xm) * (X[i] - Xm);
			}
			s = System.Math.Sqrt(s / (double)n);
			double[] X_normal = new double[n];
			for (int i = 0; i < n; i++)
			{
				X_normal[i] = (X[i] - Xm) / s;
			}
			return X_normal;
		}

		public static double Correlation(int n, double[] X, double[] Y)
		{
			double[] xx = Mathmatics.Normalize(X, n);
			double[] yy = Mathmatics.Normalize(Y, n);
			double r = 0.0;
			for (int i = 0; i < n; i++)
			{
				r += xx[i] * yy[i];
			}
			return r / (double)n;
		}

		public static double[] TrendAnalyze(int[] t, double[] X)
		{
			int i = X.Length;
			double[] y = new double[i + 2];
			double xm = 0.0;
			double tm = 0.0;
			double fz = 0.0;
			double fm = 0.0;
			for (int j = 0; j < i; j++)
			{
				xm += X[j];
				tm += (double)t[j];
			}
			for (int j = 0; j < i; j++)
			{
				fz += X[j] * (double)t[j];
			}
			fz -= xm * tm / (double)i;
			for (int j = 0; j < i; j++)
			{
				fm += (double)(t[j] * t[j]);
			}
			fm -= tm * tm / (double)System.Convert.ToSingle(i);
			tm /= (double)System.Convert.ToSingle(i);
			xm /= (double)i;
			double b = fz / fm;
			double a = xm - b * tm;
			for (int j = 0; j < i; j++)
			{
				y[j] = a + b * (double)t[j];
			}
			y[i] = a;
			y[i + 1] = b;
			return y;
		}

		public static double[] MovingAnverage(int n, int sl, double[] X)
		{
			double[] y = new double[n];
			for (int i = sl / 2; i < n - sl / 2; i++)
			{
				double yt = 0.0;
				for (int j = i - sl / 2; j <= i + sl / 2; j++)
				{
					yt += X[j];
				}
				y[i] = yt / (double)sl;
			}
			return y;
		}

		public static double[] AccumulatedDeparture(int n, double[] X)
		{
			double[] xt = new double[n];
			double xm = 0.0;
			for (int i = 0; i < n; i++)
			{
				xm += X[i];
			}
			xm /= (double)n;
			for (int t = 0; t < n; t++)
			{
				xt[t] = 0.0;
				for (int i = 0; i <= t; i++)
				{
					xt[t] += X[i] - xm;
				}
			}
			return xt;
		}

		public static double[] QuadraticSmooth579pt(int n, double[] xt, int id)
		{
			double[] array = new double[n];
			double[] result;
			if (n > 8)
			{
				switch (id)
				{
				case 5:
					for (int i = 2; i < n - 2; i++)
					{
						array[i] = (-3.0 * xt[i - 2] + 12.0 * xt[i - 1] + 17.0 * xt[i] + 12.0 * xt[i + 1] - 3.0 * xt[i + 2]) / 35.0;
					}
					array[1] = (array[2] + array[3]) / 2.0;
					array[0] = (array[1] + array[2]) / 2.0;
					array[n - 2] = (array[n - 4] + array[n - 3]) / 2.0;
					array[n - 1] = (array[n - 3] + array[n - 2]) / 2.0;
					break;
				case 7:
					for (int i = 3; i < n - 3; i++)
					{
						array[i] = (-2.0 * xt[i - 3] + 3.0 * xt[i - 2] + 6.0 * xt[i - 1] + 7.0 * xt[i] + 6.0 * xt[i + 1] + 3.0 * xt[i + 2] - 2.0 * xt[i + 3]) / 21.0;
					}
					array[2] = (array[3] + array[4] + array[5]) / 3.0;
					array[1] = (array[2] + array[3] + array[4]) / 3.0;
					array[0] = (array[1] + array[2] + array[3]) / 3.0;
					array[n - 3] = (array[n - 6] + array[n - 5] + array[n - 4]) / 3.0;
					array[n - 2] = (array[n - 5] + array[n - 4] + array[n - 3]) / 3.0;
					array[n - 1] = (array[n - 4] + array[n - 3] + array[n - 2]) / 3.0;
					break;
				case 9:
					for (int i = 4; i < n - 4; i++)
					{
						array[i] = (-21.0 * xt[i - 4] + 14.0 * xt[i - 3] + 39.0 * xt[i - 2] + 54.0 * xt[i - 1] + 59.0 * xt[i] + 54.0 * xt[i + 1] + 39.0 * xt[i + 2] + 14.0 * xt[i + 3] - 21.0 * xt[i + 4]) / 231.0;
					}
					array[3] = (array[4] + array[5] + array[6] + array[7]) / 4.0;
					array[2] = (array[3] + array[4] + array[5] + array[6]) / 4.0;
					array[1] = (array[2] + array[3] + array[4] + array[5]) / 4.0;
					array[0] = (array[1] + array[2] + array[3] + array[4]) / 4.0;
					array[n - 4] = (array[n - 8] + array[n - 7] + array[n - 6] + array[n - 5]) / 4.0;
					array[n - 3] = (array[n - 7] + array[n - 6] + array[n - 5] + array[n - 4]) / 4.0;
					array[n - 2] = (array[n - 6] + array[n - 5] + array[n - 4] + array[n - 3]) / 4.0;
					array[n - 1] = (array[n - 5] + array[n - 4] + array[n - 3] + array[n - 2]) / 4.0;
					break;
				}
				result = array;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static double[] CubicSmooth5pt(int n, double[] xt)
		{
			double[] array = new double[n];
			double[] result;
			if (n >= 5)
			{
				for (int i = 2; i < n - 2; i++)
				{
					array[i] = (-3.0 * xt[i - 2] + 12.0 * xt[i - 1] + 17.0 * xt[i] + 12.0 * xt[i + 1] - 3.0 * xt[i + 2]) / 35.0;
				}
				array[0] = (69.0 * array[0] + 4.0 * array[1] - 6.0 * array[2] + 4.0 * array[3] - array[4]) / 70.0;
				array[1] = (2.0 * array[0] + 27.0 * array[1] + 12.0 * array[2] - 8.0 * array[3] + 2.0 * array[4]) / 35.0;
				array[n - 2] = (2.0 * array[n - 5] - 8.0 * array[n - 4] + 12.0 * array[n - 3] + 27.0 * array[n - 2] + 2.0 * array[n - 1]) / 35.0;
				array[n - 1] = (-1.0 * array[n - 5] + 4.0 * array[n - 4] - 6.0 * array[n - 3] + 4.0 * array[n - 2] + 69.0 * array[n - 1]) / 70.0;
				result = array;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static double[] Spectrum(double[] X, int n, int m)
		{
			double[] Xnor = Mathmatics.Normalize(X, n);
			double[] r = Mathmatics.AutoCorrelation(Xnor, n, m);
			double[] sle = Mathmatics.SpectrumEstimation(r);
			return Mathmatics.SpectrumSmooth(sle);
		}

		public static double[] SpectrumOfNoise(double[] X, int n, int m, out Mathmatics.NOISE_TYPE noiseType)
		{
			double[] X_normal = Mathmatics.Normalize(X, n);
			double[] r = Mathmatics.AutoCorrelation(X_normal, n, m);
			double[] sle = Mathmatics.SpectrumEstimation(r);
			double[] s = Mathmatics.SpectrumSmooth(sle);
			double ta = Mathmatics.GetT005((double)(n - 2));
			double rc = Mathmatics.slove_rc(n, ta);
			double[] s0k;
			if (System.Math.Abs(r[1]) > rc)
			{
				s0k = Mathmatics.StandardSpectrumOfRedNoise(s, r[1]);
				noiseType = Mathmatics.NOISE_TYPE.RED_NOISE;
			}
			else
			{
				s0k = Mathmatics.StandardSpectrumOfWhiteNoise(s);
				noiseType = Mathmatics.NOISE_TYPE.WHITE_NOISE;
			}
			double v = (2.0 * (double)n - (double)m / 2.0) / (double)m;
			double kai = Mathmatics.GetKai005(v);
			for (int i = 0; i < s0k.Length; i++)
			{
				s0k[i] = s0k[i] * kai / v;
			}
			return s0k;
		}

		public static double[] AutoCorrelation(double[] X, int n, int m)
		{
			double[] r = new double[m + 1];
			for (int i = 0; i <= m; i++)
			{
				r[i] = 0.0;
				for (int t = 0; t < n - i; t++)
				{
					r[i] += X[t] * X[t + i];
				}
				r[i] /= (double)(n - i);
			}
			return r;
		}

		public static double[] SpectrumEstimation(double[] r)
		{
			int i = r.Length - 1;
			double[] sle = new double[i + 1];
			sle[0] = 0.0;
			for (int j = 1; j <= i - 1; j++)
			{
				sle[0] += r[j];
			}
			sle[0] = (r[0] + r[i]) / (double)(2 * i) + sle[0] / (double)i;
			sle[i] = 0.0;
			for (int j = 1; j <= i - 1; j++)
			{
				sle[i] += System.Math.Pow(-1.0, (double)j) * r[j];
			}
			sle[i] = (r[0] + System.Math.Pow(-1.0, (double)i) * r[i]) / (double)(2 * i) + sle[i] / (double)i;
			for (int k = 1; k < i; k++)
			{
				double temp = 0.0;
				for (int j = 1; j <= i - 1; j++)
				{
					temp += r[j] * System.Math.Cos((double)(k * j) * 3.1415926535897931 / (double)i);
				}
				sle[k] = (r[0] + 2.0 * temp + r[i] * System.Math.Cos((double)k * 3.1415926535897931)) / (double)i;
			}
			return sle;
		}

		public static double[] SpectrumSmooth(double[] sle)
		{
			int i = sle.Length - 1;
			double[] sl = new double[i + 1];
			sl[0] = 0.5 * (sle[0] + sle[1]);
			sl[i] = 0.5 * (sle[i - 1] + sle[i]);
			for (int j = 1; j < i; j++)
			{
				sl[j] = 0.25 * (sle[j - 1] + sle[j + 1]) + 0.5 * sle[j];
			}
			return sl;
		}

		public static double[] StandardSpectrumOfRedNoise(double[] s, double r1)
		{
			double sm = 0.0;
			int i = s.Length - 1;
			for (int j = 1; j <= i - 1; j++)
			{
				sm += s[j];
			}
			sm = (s[0] + s[i]) / (double)(2 * i) + sm / (double)i;
			double[] s2 = new double[i + 1];
			for (int j = 0; j <= i; j++)
			{
				s2[j] = sm * (1.0 - r1 * r1) / (1.0 + r1 * r1 - 2.0 * r1 * System.Math.Cos(3.1415926535897931 * (double)j / (double)i));
			}
			return s2;
		}

		public static double[] StandardSpectrumOfWhiteNoise(double[] s)
		{
			double sm = 0.0;
			int i = s.Length - 1;
			for (int j = 1; j <= i - 1; j++)
			{
				sm += s[j];
			}
			sm = (s[0] + s[i]) / (double)(2 * i) + sm / (double)i;
			double[] s2 = new double[i + 1];
			for (int j = 0; j <= i; j++)
			{
				s2[j] = sm;
			}
			return s2;
		}

		public static double getValueSpline(int n, double[] x, double[] y, double[] dy, double[] ddy, int m, double[] t, double[] z)
		{
			double[] s = new double[n];
			dy[0] = 0.0;
			s[0] = dy[0];
			double h0 = x[1] - x[0];
			double h;
			for (int i = 1; i <= n - 2; i++)
			{
				h = x[i + 1] - x[i];
				double alpha = h0 / (h0 + h);
				double beta = (1.0 - alpha) * (y[i] - y[i - 1]) / h0;
				beta = 3.0 * (beta + alpha * (y[i + 1] - y[i]) / h);
				dy[i] = -alpha / (2.0 + (1.0 - alpha) * dy[i - 1]);
				s[i] = beta - (1.0 - alpha) * s[i - 1];
				s[i] /= 2.0 + (1.0 - alpha) * dy[i - 1];
				h0 = h;
			}
			for (int i = n - 2; i >= 0; i--)
			{
				dy[i] = dy[i] * dy[i + 1] + s[i];
			}
			for (int i = 0; i <= n - 2; i++)
			{
				s[i] = x[i + 1] - x[i];
			}
			for (int i = 0; i <= n - 2; i++)
			{
				h = s[i] * s[i];
				ddy[i] = 6.0 * (y[i + 1] - y[i]) / h - 2.0 * (2.0 * dy[i] + dy[i + 1]) / s[i];
			}
			h = s[n - 2] * s[n - 2];
			ddy[n - 1] = 6.0 * (y[n - 2] - y[n - 1]) / h + 2.0 * (2.0 * dy[n - 1] + dy[n - 2]) / s[n - 2];
			double g = 0.0;
			for (int j = 0; j <= n - 2; j++)
			{
				h = 0.5 * s[j] * (y[j] + y[j + 1]);
				h -= 0.5 * s[j] * s[j] * s[j] * (ddy[j] + ddy[j + 1]) / 24.0;
				g += h;
			}
			for (int i = 0; i <= m - 1; i++)
			{
				int j;
				if (t[i] >= x[n - 1])
				{
					j = n - 2;
				}
				else
				{
					j = 0;
					while (t[i] > x[j + 1])
					{
						j++;
					}
				}
				h = (x[j + 1] - t[i]) / s[j];
				h0 = h * h;
				z[i] = (3.0 * h0 - 2.0 * h0 * h) * y[j];
				z[i] += s[j] * (h0 - h0 * h) * dy[j];
				h = (t[i] - x[j]) / s[j];
				h0 = h * h;
				z[i] += (3.0 * h0 - 2.0 * h0 * h) * y[j + 1];
				z[i] -= s[j] * (h0 - h0 * h) * dy[j + 1];
			}
			return 1.0;
		}

		public static double slove_rc(int v, double talf)
		{
			double rc = talf * talf / ((double)((float)v - 2f) + talf * talf);
			return System.Math.Sqrt(rc);
		}

		public static double GetKai005(double v)
		{
			int iv = (int)v;
			double result;
			if (iv < 1 || iv > 30)
			{
				result = 0.0;
			}
			else
			{
				result = Mathmatics.Kai005[iv - 1] + (v - (double)iv) * (Mathmatics.Kai005[iv] - Mathmatics.Kai005[iv - 1]);
			}
			return result;
		}

		public static double GetT005(double v)
		{
			double result;
			if (v < 30.0)
			{
				int iv = (int)v;
				result = Mathmatics.T_alpha005[iv - 1] + (v - (double)iv) * (Mathmatics.T_alpha005[iv] - Mathmatics.T_alpha005[iv - 1]);
			}
			else if (v >= 30.0 && v < 40.0)
			{
				result = Mathmatics.T_alpha005[29] + (Mathmatics.T_alpha005[30] - Mathmatics.T_alpha005[29]) * (v - 30.0) / 10.0;
			}
			else if (v >= 40.0 && v < 60.0)
			{
				result = Mathmatics.T_alpha005[30] + (Mathmatics.T_alpha005[31] - Mathmatics.T_alpha005[30]) * (v - 40.0) / 20.0;
			}
			else if (v >= 60.0 && v < 120.0)
			{
				result = Mathmatics.T_alpha005[31] + (Mathmatics.T_alpha005[32] - Mathmatics.T_alpha005[31]) * (v - 60.0) / 60.0;
			}
			else
			{
				result = Mathmatics.T_alpha005[32];
			}
			return result;
		}

		public static int TTest95(double r, int n)
		{
			double rc;
			if (n - 2 <= 30)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha005[n - 2 - 1]);
			}
			else if (n - 2 > 30 && n - 2 < 40)
			{
				rc = Mathmatics.T_alpha005[29] + (Mathmatics.T_alpha005[30] - Mathmatics.T_alpha005[29]) * (double)(n - 2 - 30) / 10.0;
				rc = Mathmatics.slove_rc(n, rc);
			}
			else if (n - 2 == 40)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha005[30]);
			}
			else if (n - 2 > 40 && n - 2 < 60)
			{
				rc = Mathmatics.T_alpha005[30] + (Mathmatics.T_alpha005[31] - Mathmatics.T_alpha005[30]) * (double)(n - 2 - 40) / 20.0;
				rc = Mathmatics.slove_rc(n, rc);
			}
			else if (n - 2 == 60)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha005[31]);
			}
			else if (n - 2 > 60 && n - 2 < 120)
			{
				rc = Mathmatics.T_alpha005[31] + (Mathmatics.T_alpha005[32] - Mathmatics.T_alpha005[31]) * (double)(n - 2 - 60) / 60.0;
				rc = Mathmatics.slove_rc(n, rc);
			}
			else if (n - 2 == 120)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha005[32]);
			}
			else
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha005[33]);
			}
			int result;
			if (System.Math.Abs(r) >= System.Math.Abs(rc))
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int TTest99(double r, int n)
		{
			double rc;
			if (n - 2 <= 30)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha001[n - 2 - 1]);
			}
			else if (n - 2 > 30 && n - 2 < 40)
			{
				rc = Mathmatics.T_alpha001[29] + (Mathmatics.T_alpha001[30] - Mathmatics.T_alpha001[29]) * (double)(n - 2 - 30) / 10.0;
				rc = Mathmatics.slove_rc(n, rc);
			}
			else if (n - 2 == 40)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha001[30]);
			}
			else if (n - 2 > 40 && n - 2 < 60)
			{
				rc = Mathmatics.T_alpha001[30] + (Mathmatics.T_alpha001[31] - Mathmatics.T_alpha001[30]) * (double)(n - 2 - 40) / 20.0;
				rc = Mathmatics.slove_rc(n, rc);
			}
			else if (n - 2 == 60)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha001[31]);
			}
			else if (n - 2 > 60 && n - 2 < 120)
			{
				rc = Mathmatics.T_alpha001[31] + (Mathmatics.T_alpha001[32] - Mathmatics.T_alpha001[31]) * (double)(n - 2 - 60) / 60.0;
				rc = Mathmatics.slove_rc(n, rc);
			}
			else if (n - 2 == 120)
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha001[32]);
			}
			else
			{
				rc = Mathmatics.slove_rc(n, Mathmatics.T_alpha001[33]);
			}
			int result;
			if (r >= rc)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static double GeopotentialHeightToActualHeight(double GeoHeight, double Latitude)
		{
			double g0 = 9.80616 * (1.0 - 0.002637 * System.Math.Cos(2.0 * Latitude * 3.1415926535897931 / 180.0) + 5.9E-06 * System.Math.Pow(System.Math.Cos(2.0 * Latitude * 3.1415926535897931 / 180.0), 2.0));
			double r0 = 2.0 * g0 / (1.8512808000000002E-05 + 2.0429999999999998E-08 * System.Math.Cos(2.0 * Latitude * 3.1415926535897931 / 180.0));
			double gnp = 9.80665;
			return r0 * GeoHeight / (r0 * g0 / gnp - GeoHeight);
		}

		public static double CalStandardAirPressure(double GeoHeight, double Latitude)
		{
			double Z = Mathmatics.GeopotentialHeightToActualHeight(GeoHeight, Latitude);
			double P0;
			if (Z <= 11000.0)
			{
				P0 = 1013.25 * System.Math.Pow(1.0 - 2.26E-05 * GeoHeight, 5.26);
			}
			else if (Z > 11000.0 && Z < 20000.0)
			{
				P0 = 226.99 * System.Math.Exp(-0.00015800000000000002 * (Z - 11000.0));
			}
			else
			{
				P0 = 55.29 * System.Math.Pow(1.0 + 4.6159999999999995E-06 * (Z - 20000.0), -34.0);
			}
			return P0;
		}

		public static void LowLevelWindProfile(float T1, float T2, float U1, float U2, float H1, float H2, out float[] U, out float[] H)
		{
			double dt = (double)((T2 - T1) / (H2 - H1));
			double du = (double)((U2 - U1) / (H2 - H1));
			double T3 = (double)(T1 + T2) / 2.0;
			double Ri = 9.8 * (dt + 0.0098) / (T3 * du * du);
			System.Collections.Generic.List<float> tmpH = new System.Collections.Generic.List<float>();
			for (int i = 10; i <= (int)H2; i += 10)
			{
				tmpH.Add(1f * (float)i);
			}
			H = tmpH.ToArray();
			double a;
			if (Ri < 0.0)
			{
				a = Ri;
			}
			else
			{
				a = Ri / (1.0 - 5.0 * Ri);
			}
			double b;
			if (a > 0.0)
			{
				b = -5.0 * a;
			}
			else
			{
				double x = System.Math.Pow(1.0 - 16.0 * a, 0.25);
				b = System.Math.Log(1.0 + x * x / 2.0) + System.Math.Log((1.0 + x) / 2.0 * ((1.0 + x) / 2.0)) - System.Math.Atan(x + 1.5707963267948966);
			}
			double lnz0 = ((System.Math.Log(70.0) - b) * (double)U1 - (System.Math.Log(10.0) - b) * (double)U2) / (double)(U1 - U2);
			double z0 = System.Math.Exp(lnz0);
			double u0 = 0.4 * (double)U1 / (System.Math.Log(10.0) - lnz0 - b);
			U = new float[H.Length];
			for (int i = 0; i < H.Length; i++)
			{
				U[i] = System.Convert.ToSingle(u0 / 0.4 * (System.Math.Log((double)H[i] / z0) - b));
			}
		}

		public static double VaporPressure(double Td)
		{
			double a = 19.802;
			double b = 17.885;
			double c = 0.0002311;
			return 6.11136 * System.Math.Exp(a * (Td - 273.15) / (Td - b - c * Td * Td));
		}

		public static double SurfAirDensity(double P, double T, double Td)
		{
			double e = Mathmatics.VaporPressure(Td);
			double Tv = T * (1.0 + 0.37802 * e / P);
			return 100.0 * P / (287.0528 * Tv);
		}

		public static double IsobaricSurfaceAirDensity(double P, double T, double Td)
		{
			double e = Mathmatics.VaporPressure(Td);
			return 1.293 * (P - 0.504 * e) / ((1.0 + 0.00367 * T) * 1013.0);
		}

		public static double get_P_from_qAnde(double q, double e)
		{
			return 622.0 * e / q;
		}

		public static double get_e_from_qAndP(double q, double P)
		{
			return q * P / 622.0;
		}

		public static double get_Sita_from_TAndP(double T, double P)
		{
			return (T + 273.15) * System.Math.Pow(1000.0 / P, 0.2859) - 273.15;
		}

		public static double get_T_from_SitaAndP(double Sita, double P)
		{
			Sita += 273.15;
			return Sita / System.Math.Pow(1000.0 / P, 0.2859) - 273.15;
		}

		public static double get_P_from_SitaAndT(double Sita, double T)
		{
			Sita += 273.15;
			return 1000.0 / System.Math.Exp(System.Math.Log(Sita / (273.15 + T)) / 0.2859);
		}

		public static double get_T_from_es(double es)
		{
			double T;
			if (es > 6.0)
			{
				double temp = System.Math.Log(es / 6.1078) / 17.2693882;
				T = (temp * 35.86 - 273.15) / (temp - 1.0);
			}
			else
			{
				double temp = System.Math.Log(es / 6.1078) / 21.8745584;
				T = (temp * 7.66 - 273.15) / (temp - 1.0);
			}
			return T;
		}

		public static double get_es_from_T(double T)
		{
			double es;
			if (T >= 273.15)
			{
				es = 6.1078 * System.Math.Exp(17.2693882 * (T - 273.15) / (T - 35.86));
			}
			else
			{
				es = 6.1078 * System.Math.Exp(21.8745584 * (T - 273.15) / (T - 7.66));
			}
			return es;
		}

		public static double iterative_T(double P, double SitaSe)
		{
			double y = System.Math.Log(1000.0 / P);
			double P2 = 1000.0;
			SitaSe += 273.15;
			double Ts = 313.15;
			double lv = (2500.0 - 2.323 * (Ts - 273.15)) * 1000.0;
			double es = Mathmatics.get_es_from_T(Ts);
			double rs = 0.622 * es * System.Math.Exp(y) / (P2 - es * System.Math.Exp(y));
			double temp = System.Math.Log(P2 * System.Math.Exp(y) / (P2 - es * System.Math.Exp(y)));
			double sita_temp = Ts * System.Math.Exp(0.2859 * temp + rs * lv / (1004.0 * Ts));
			while (true)
			{
				lv = (2500.0 - 2.323 * (Ts - 273.15)) * 1000.0;
				es = Mathmatics.get_es_from_T(Ts);
				rs = 0.622 * es * System.Math.Exp(y) / (P2 - es * System.Math.Exp(y));
				temp = System.Math.Log(P2 * System.Math.Exp(y) / (P2 - es * System.Math.Exp(y)));
				double sita_real = Ts * System.Math.Exp(0.2859 * temp + rs * lv / (1004.0 * Ts));
				if (SitaSe == sita_real)
				{
					break;
				}
				if (SitaSe > sita_real)
				{
					Ts += 0.01;
				}
				if (SitaSe < sita_real)
				{
					Ts -= 0.01;
				}
				if ((SitaSe - sita_temp) * (SitaSe - sita_real) < 0.0)
				{
					goto Block_4;
				}
				sita_temp = sita_real;
			}
			double result = Ts - 273.15;
			return result;
			Block_4:
			result = Ts - 273.15;
			return result;
		}

		public static double joint_Sita_qs(double SitaSe, double qs)
		{
			double P0 = 1000.0;
			SitaSe += 273.15;
			double Ts = 233.14999999999998;
			double es = Mathmatics.get_es_from_T(Ts);
			double p = es * 622.0 / qs;
			double lv = (2500.0 - 2.323 * (Ts - 273.15)) * 1000.0;
			double temp = System.Math.Log(P0 / (p - es));
			double rs = qs / 1000.0;
			double sita_temp = Ts * System.Math.Exp(0.2859 * temp + rs * lv / (1004.0 * Ts));
			while (true)
			{
				es = Mathmatics.get_es_from_T(Ts);
				p = es * 622.0 / qs;
				lv = (2500.0 - 2.323 * (Ts - 273.15)) * 1000.0;
				temp = System.Math.Log(P0 / (p - es));
				rs = qs / 1000.0;
				double sita_real = Ts * System.Math.Exp(0.2859 * temp + rs * lv / (1004.0 * Ts));
				if (SitaSe == sita_real)
				{
					break;
				}
				if (SitaSe > sita_real)
				{
					Ts -= 0.01;
				}
				if (SitaSe < sita_real)
				{
					Ts += 0.01;
				}
				if ((SitaSe - sita_temp) * (SitaSe - sita_real) < 0.0)
				{
					goto Block_4;
				}
				sita_temp = sita_real;
			}
			double result = Ts - 273.15;
			return result;
			Block_4:
			result = Ts - 273.15;
			return result;
		}

		public static double solve_Lcl(double P, double T, double Td)
		{
			double K_Td = Td + 273.15;
			double sita = Mathmatics.get_Sita_from_TAndP(T, P);
			double pl = P;
			double es = Mathmatics.get_es_from_T(K_Td);
			double q_s = 622.0 * es / (P - 0.378 * es);
			double K_T = Mathmatics.get_T_from_SitaAndP(sita, pl) + 273.15;
			es = Mathmatics.get_es_from_T(K_T);
			double qtemp = 622.0 * es / (pl - 0.378 * es);
			while (true)
			{
				K_T = Mathmatics.get_T_from_SitaAndP(sita, pl) + 273.15;
				es = Mathmatics.get_es_from_T(K_T);
				double q_c = 622.0 * es / (pl - 0.378 * es);
				if (q_s == q_c)
				{
					break;
				}
				if (q_s > q_c)
				{
					pl += 1.0;
				}
				if (q_s < q_c)
				{
					pl -= 1.0;
				}
				if ((q_s - q_c) * (q_s - qtemp) < 0.0)
				{
					goto Block_4;
				}
				qtemp = q_c;
			}
			double result = pl;
			return result;
			Block_4:
			result = pl;
			return result;
		}

		public static double get_ISOP_sita_se(double P, double T, double Td)
		{
			double sita = Mathmatics.get_Sita_from_TAndP(T, P) + 273.15;
			double Pc = Mathmatics.solve_Lcl(P, T, Td);
			double y = System.Math.Log(1000.0 / Pc);
			double Tc = sita / System.Math.Exp(0.2859 * y);
			double K_Td = Td + 273.15;
			double es = Mathmatics.get_es_from_T(K_Td);
			double rs = 0.622 * es / (P - es);
			double lv = (2500.0 - 2.323 * (Tc - 273.15)) * 1000.0;
			double sita_d = (T + 273.15) * System.Math.Exp(0.2859 * System.Math.Log(1000.0 / (P - es)));
			sita = sita_d * System.Math.Exp(rs * lv / (1004.0 * Tc));
			return sita - 273.15;
		}
	}
}
