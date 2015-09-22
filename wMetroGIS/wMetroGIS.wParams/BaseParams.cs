using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace wMetroGIS.wParams
{
	public class BaseParams
	{
		protected bool m_LoadSccessed = false;

		protected string m_ParamFilePath;

		public bool LoadSccessed
		{
			get
			{
				return this.m_LoadSccessed;
			}
		}

		public string ParamFilePath
		{
			get
			{
				return this.m_ParamFilePath;
			}
			set
			{
				this.m_ParamFilePath = value;
			}
		}

		public BaseParams()
		{
			this.m_ParamFilePath = "";
		}

		public BaseParams(string ParamFilePath)
		{
			this.m_ParamFilePath = ParamFilePath;
		}

		public int DashStyleToInt(System.Drawing.Drawing2D.DashStyle thisDashStyle)
		{
			int result;
			if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.Dash)
			{
				result = 0;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.DashDot)
			{
				result = 1;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.DashDotDot)
			{
				result = 2;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.Dot)
			{
				result = 3;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.Solid)
			{
				result = 4;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public System.Drawing.Drawing2D.DashStyle IntToDashStyle(int thisDashStyle)
		{
			System.Drawing.Drawing2D.DashStyle result;
			if (thisDashStyle == 0)
			{
				result = System.Drawing.Drawing2D.DashStyle.Dash;
			}
			else if (thisDashStyle == 1)
			{
				result = System.Drawing.Drawing2D.DashStyle.DashDot;
			}
			else if (thisDashStyle == 2)
			{
				result = System.Drawing.Drawing2D.DashStyle.DashDotDot;
			}
			else if (thisDashStyle == 3)
			{
				result = System.Drawing.Drawing2D.DashStyle.Dot;
			}
			else if (thisDashStyle == 4)
			{
				result = System.Drawing.Drawing2D.DashStyle.Solid;
			}
			else
			{
				result = System.Drawing.Drawing2D.DashStyle.Custom;
			}
			return result;
		}

		public float[] String2Data(string Line)
		{
			System.Collections.Generic.List<float> Data = new System.Collections.Generic.List<float>();
			string[] TempCells = Line.Split(new char[]
			{
				',',
				' ',
				'\t'
			});
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(System.Convert.ToSingle(TempCells[i]));
				}
			}
			return Data.ToArray();
		}

		public float[] String2Data(string Line, int SplitLen)
		{
			System.Collections.Generic.List<float> Data = new System.Collections.Generic.List<float>();
			for (int i = 0; i < Line.Length; i += SplitLen)
			{
				Data.Add(System.Convert.ToSingle(Line.Substring(i, SplitLen)));
			}
			return Data.ToArray();
		}

		public string[] String2StrData(string Line)
		{
			System.Collections.Generic.List<string> Data = new System.Collections.Generic.List<string>();
			string[] TempCells = Line.Split(new char[]
			{
				',',
				' ',
				'\t'
			});
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(TempCells[i]);
				}
			}
			return Data.ToArray();
		}

		public virtual bool LoadParams()
		{
			return true;
		}

		public virtual bool SaveParams()
		{
			return true;
		}

		public virtual bool LoadDefaultParams()
		{
			string DefaultParamFilePath = this.m_ParamFilePath + "d";
			string OldParamFilePath = this.m_ParamFilePath;
			this.m_ParamFilePath = DefaultParamFilePath;
			bool res = this.LoadParams();
			this.m_ParamFilePath = OldParamFilePath;
			return res;
		}

		public virtual bool SaveDefaultParams()
		{
			string DefaultParamFilePath = this.m_ParamFilePath + "d";
			string OldParamFilePath = this.m_ParamFilePath;
			this.m_ParamFilePath = DefaultParamFilePath;
			bool res = this.SaveParams();
			this.m_ParamFilePath = OldParamFilePath;
			return res;
		}
	}
}
