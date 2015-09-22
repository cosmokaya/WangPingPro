using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using wMetroGIS.wColorManager;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wCurve
{
    public class Curve
    {
        private const int k = 3;

        private bool m_WantSPL;

        private System.Drawing.Region m_FillRegion;

        private ColorManager m_ColorManagerCurve;

        private ColorManager m_ColorManagerFill;

        private int m_CurveColorIndex;

        private int m_FillColorIndex;

        private int m_LineWidth;

        private System.Drawing.Drawing2D.DashStyle m_LineStyle;

        private System.Drawing.PointF[] m_BasePointArray;

        private System.Drawing.PointF[] m_PathPointArray;

        private bool m_IsClosed;

        public TreeNodeCurve CurveRelationTreeNode = null;

        private bool m_IsSelected;

        private int m_SelectedIndex;

        private float[] t;

        public System.Drawing.Region FillRegion
        {
            get
            {
                return this.m_FillRegion;
            }
            set
            {
                this.FillRegion = value;
            }
        }

        public ColorManager ColorManagerCurve
        {
            get
            {
                return this.m_ColorManagerCurve;
            }
            set
            {
                this.m_ColorManagerCurve = value;
            }
        }

        public ColorManager ColorManagerFill
        {
            get
            {
                return this.m_ColorManagerFill;
            }
            set
            {
                this.m_ColorManagerFill = value;
            }
        }

        public int CurveColorIndex
        {
            get
            {
                return this.m_CurveColorIndex;
            }
            set
            {
                this.m_CurveColorIndex = value;
            }
        }

        public int FillColorIndex
        {
            get
            {
                return this.m_FillColorIndex;
            }
            set
            {
                this.m_FillColorIndex = value;
            }
        }

        public System.Drawing.Color CurveColor
        {
            get
            {
                return this.m_ColorManagerCurve.GetColorItemByIndex(this.m_CurveColorIndex).myColor;
            }
        }

        public float CurveValue
        {
            get
            {
                return this.m_ColorManagerCurve.GetColorItemByIndex(this.m_CurveColorIndex).myValue;
            }
        }

        public string CurveValueText
        {
            get
            {
                return this.m_ColorManagerCurve.GetColorItemByIndex(this.m_CurveColorIndex).myValueText;
            }
        }

        public System.Drawing.Color FillColor
        {
            get
            {
                return this.m_ColorManagerFill.GetColorItemByIndex(this.m_FillColorIndex).myColor;
            }
        }

        public int LineWidth
        {
            get
            {
                return this.m_LineWidth;
            }
            set
            {
                if (value < 1)
                {
                    this.m_LineWidth = 1;
                }
                this.m_LineWidth = value;
            }
        }

        public System.Drawing.Drawing2D.DashStyle LineStyle
        {
            get
            {
                return this.m_LineStyle;
            }
            set
            {
                this.m_LineStyle = value;
            }
        }

        public System.Drawing.PointF[] BasePointArray
        {
            get
            {
                return this.m_BasePointArray;
            }
            set
            {
                this.m_BasePointArray = value;
            }
        }

        public System.Drawing.PointF[] PathPointArray
        {
            get
            {
                return this.m_PathPointArray;
            }
            set
            {
                this.m_PathPointArray = value;
            }
        }

        public bool IsClosed
        {
            get
            {
                return this.m_IsClosed;
            }
            set
            {
                this.m_IsClosed = value;
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.m_IsSelected;
            }
            set
            {
                this.m_IsSelected = value;
                if (!this.m_IsSelected)
                {
                    this.m_SelectedIndex = -1;
                }
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.m_SelectedIndex;
            }
            set
            {
                this.m_SelectedIndex = -1;
            }
        }

        public System.Drawing.PointF SelectedPoint
        {
            get
            {
                System.Drawing.PointF result;
                if (this.m_SelectedIndex != -1)
                {
                    result = this.m_BasePointArray[this.m_SelectedIndex];
                }
                else
                {
                    result = System.Drawing.PointF.Empty;
                }
                return result;
            }
        }

        public int PointNum
        {
            get
            {
                return this.m_BasePointArray.Length;
            }
        }

        public Curve()
        {
            this.m_IsSelected = false;
            this.m_SelectedIndex = -1;
            this.m_IsClosed = false;
            this.m_LineWidth = 1;
            this.m_LineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.m_BasePointArray = null;
            this.m_PathPointArray = null;
            this.m_WantSPL = false;
        }

        public void SetPointArray(System.Drawing.PointF[] Points, bool IsClosed, bool WantSPL)
        {
            if (Points != null && Points.Length >= 3)
            {
                this.m_IsClosed = IsClosed;
                if (IsClosed)
                {
                    this.m_BasePointArray = new System.Drawing.PointF[Points.Length + 1];
                    this.m_BasePointArray[0].X = 0.5f * (Points[0].X + Points[1].X);
                    this.m_BasePointArray[0].Y = 0.5f * (Points[0].Y + Points[1].Y);
                    for (int i = 1; i < Points.Length; i++)
                    {
                        this.m_BasePointArray[i] = Points[i];
                    }
                    this.m_BasePointArray[Points.Length] = this.m_BasePointArray[0];
                }
                else
                {
                    this.m_BasePointArray = Points;
                }
                this.m_WantSPL = WantSPL;
                if (WantSPL)
                {
                    this.SPL();
                }
                else
                {
                    this.m_PathPointArray = this.m_BasePointArray;
                }
            }
        }

        public bool SelectCurve(System.Drawing.PointF testPoint)
        {
            this.m_IsSelected = false;
            this.m_SelectedIndex = -1;
            bool result;
            for (int i = 0; i < this.m_PathPointArray.Length - 1; i++)
            {
                double Xa = (double)(testPoint.X - this.m_PathPointArray[i].X);
                double Ya = (double)(testPoint.Y - this.m_PathPointArray[i].Y);
                double Xb = (double)(this.m_PathPointArray[i + 1].X - this.m_PathPointArray[i].X);
                double Yb = (double)(this.m_PathPointArray[i + 1].Y - this.m_PathPointArray[i].Y);
                double DP = (Xa * Xb + Ya * Yb) / (Xb * Xb + Yb * Yb);
                double Xc = Xb * DP;
                double Yc = Yb * DP;
                double Xe = Xa - Xc;
                double Ye = Ya - Yc;
                double Dis = System.Math.Sqrt(Xe * Xe + Ye * Ye);
                if (Dis <= 0.1 && Xa * Xa + Ya * Ya <= Xb * Xb + Yb * Yb)
                {
                    this.m_IsSelected = true;
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public bool SelectCurvePoint(System.Drawing.PointF testPoint)
        {
            bool result;
            if (!this.m_IsSelected)
            {
                result = false;
            }
            else
            {
                this.m_SelectedIndex = -1;
                for (int i = 0; i < this.m_BasePointArray.Length; i++)
                {
                    double Radii = 0.3;
                    double Dist = System.Math.Sqrt((double)((testPoint.X - this.m_BasePointArray[i].X) * (testPoint.X - this.m_BasePointArray[i].X) + (testPoint.Y - this.m_BasePointArray[i].Y) * (testPoint.Y - this.m_BasePointArray[i].Y)));
                    if (Dist < Radii)
                    {
                        this.m_SelectedIndex = i;
                        result = true;
                        return result;
                    }
                }
                result = false;
            }
            return result;
        }

        public bool SetSelectedPointNewCoor(System.Drawing.PointF newPoint)
        {
            bool result;
            if (!this.m_IsSelected || this.m_SelectedIndex == -1)
            {
                result = false;
            }
            else
            {
                this.m_BasePointArray[this.m_SelectedIndex].X = newPoint.X;
                this.m_BasePointArray[this.m_SelectedIndex].Y = newPoint.Y;
                if (this.m_WantSPL)
                {
                    this.SPL();
                }
                else
                {
                    this.m_PathPointArray = this.m_BasePointArray;
                }
                result = true;
            }
            return result;
        }

        public bool DeletePoint(System.Drawing.PointF testPoint)
        {
            bool result;
            if (!this.m_IsSelected)
            {
                result = false;
            }
            else
            {
                this.m_SelectedIndex = -1;
                for (int i = 0; i < this.m_BasePointArray.Length; i++)
                {
                    double Radii = 0.3;
                    double Dist = System.Math.Sqrt((double)((testPoint.X - this.m_BasePointArray[i].X) * (testPoint.X - this.m_BasePointArray[i].X) + (testPoint.Y - this.m_BasePointArray[i].Y) * (testPoint.Y - this.m_BasePointArray[i].Y)));
                    if (Dist < Radii)
                    {
                        if (System.Windows.Forms.MessageBox.Show("确定要删除该点吗？", "询问", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Drawing.PointF[] newBasicPointArray = new System.Drawing.PointF[this.m_BasePointArray.Length - 1];
                            for (int j = 0; j <= i - 1; j++)
                            {
                                newBasicPointArray[j] = this.m_BasePointArray[j];
                            }
                            for (int j = i + 1; j < this.m_BasePointArray.Length; j++)
                            {
                                newBasicPointArray[j - 1] = this.m_BasePointArray[j];
                            }
                            this.m_BasePointArray = newBasicPointArray;
                            if (this.m_WantSPL)
                            {
                                this.SPL();
                            }
                            else
                            {
                                this.m_PathPointArray = this.m_BasePointArray;
                            }
                            result = true;
                            return result;
                        }
                    }
                }
                result = false;
            }
            return result;
        }

        public void DrawCurve(System.Drawing.Graphics g, Projection p)
        {
            this.DrawCurve(g, p, null);
        }

        public void DrawCurve(System.Drawing.Graphics g, Projection p, System.Drawing.Bitmap maskBitmap)
        {
            if (this.m_PathPointArray.Length > 1)
            {
                System.Drawing.Point[] PathPoint = new System.Drawing.Point[this.m_PathPointArray.Length];
                for (int i = 0; i < this.m_PathPointArray.Length; i++)
                {
                    PathPoint[i] = p.LonLat2XY(this.m_PathPointArray[i].X, this.m_PathPointArray[i].Y);
                }
                System.Drawing.Pen CurvePen = new System.Drawing.Pen(this.CurveColor, (float)this.LineWidth);
                switch (this.LineStyle)
                {
                    case System.Drawing.Drawing2D.DashStyle.Dash:
                        CurvePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        CurvePen.DashPattern = new float[]
					{
						10f,
						3f
					};
                        break;
                    case System.Drawing.Drawing2D.DashStyle.Dot:
                        CurvePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        CurvePen.DashPattern = new float[]
					{
						2f,
						1f
					};
                        break;
                    case System.Drawing.Drawing2D.DashStyle.DashDot:
                        CurvePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        CurvePen.DashPattern = new float[]
					{
						10f,
						2f,
						3f,
						2f
					};
                        break;
                    case System.Drawing.Drawing2D.DashStyle.DashDotDot:
                        CurvePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        CurvePen.DashPattern = new float[]
					{
						10f,
						2f,
						3f,
						2f,
						3f,
						2f
					};
                        break;
                    default:
                        CurvePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                }
                g.DrawLines(CurvePen, PathPoint);
            }
        }

        public void DrawArrow(System.Drawing.Graphics g, Projection p, int ArrowSplit, bool ArrowPositiveDir)
        {
            float a150 = 2.8798f;
            int ArrowLen = 10;
            System.Drawing.Pen ArrowPen = new System.Drawing.Pen(this.CurveColor, (float)this.LineWidth);
            if (ArrowPositiveDir)
            {
                for (int i = 0; i < this.m_PathPointArray.Length - 1; i++)
                {
                    if (i % ArrowSplit == 0)
                    {
                        System.Drawing.Point xy = p.LonLat2XY(this.m_PathPointArray[i].X, this.m_PathPointArray[i].Y);
                        System.Drawing.Point xy2 = p.LonLat2XY(this.m_PathPointArray[i + 1].X, this.m_PathPointArray[i + 1].Y);
                        float xx = (float)xy.X;
                        float yy = (float)xy.Y;
                        float xx2 = (float)xy2.X;
                        float yy2 = (float)xy2.Y;
                        float dir = (float)System.Math.Atan2((double)(yy2 - yy), (double)(xx2 - xx));
                        g.DrawLine(ArrowPen, xx2, yy2, (float)((double)xx2 + (double)ArrowLen * System.Math.Cos((double)(dir + a150))), (float)((double)yy2 + (double)ArrowLen * System.Math.Sin((double)(dir + a150))));
                        g.DrawLine(ArrowPen, xx2, yy2, (float)((double)xx2 + (double)ArrowLen * System.Math.Cos((double)(dir - a150))), (float)((double)yy2 + (double)ArrowLen * System.Math.Sin((double)(dir - a150))));
                    }
                }
            }
            else
            {
                for (int i = this.m_PathPointArray.Length - 1; i >= 1; i--)
                {
                    if (i % ArrowSplit == 0)
                    {
                        System.Drawing.Point xy = p.LonLat2XY(this.m_PathPointArray[i].X, this.m_PathPointArray[i].Y);
                        System.Drawing.Point xy2 = p.LonLat2XY(this.m_PathPointArray[i - 1].X, this.m_PathPointArray[i - 1].Y);
                        float xx = (float)xy.X;
                        float yy = (float)xy.Y;
                        float xx2 = (float)xy2.X;
                        float yy2 = (float)xy2.Y;
                        float dir = (float)System.Math.Atan2((double)(yy2 - yy), (double)(xx2 - xx));
                        g.DrawLine(ArrowPen, xx2, yy2, (float)((double)xx2 + (double)ArrowLen * System.Math.Cos((double)(dir + a150))), (float)((double)yy2 + (double)ArrowLen * System.Math.Sin((double)(dir + a150))));
                        g.DrawLine(ArrowPen, xx2, yy2, (float)((double)xx2 + (double)ArrowLen * System.Math.Cos((double)(dir - a150))), (float)((double)yy2 + (double)ArrowLen * System.Math.Sin((double)(dir - a150))));
                    }
                }
            }
        }

        public void FillCurve(System.Drawing.Graphics g, Projection p, int FillAlpha, ColorManager cmFill)
        {
            if (this.m_IsClosed && this.CurveRelationTreeNode != null)
            {
                System.Drawing.Point[] PathPoint = new System.Drawing.Point[this.m_PathPointArray.Length];
                for (int i = 0; i < this.m_PathPointArray.Length; i++)
                {
                    PathPoint[i] = p.LonLat2XY(this.m_PathPointArray[i].X, this.m_PathPointArray[i].Y);
                }
                System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
                myPath.AddLines(PathPoint);
                this.m_FillRegion = new System.Drawing.Region(myPath);
                System.Drawing.RectangleF myRect = myPath.GetBounds();
                foreach (TreeNodeCurve childNode in this.CurveRelationTreeNode.Nodes)
                {
                    //TreeNodeCurve childNode;
                    System.Drawing.Point[] childPathPoint = new System.Drawing.Point[childNode.MyCurve.PathPointArray.Length];
                    for (int j = 0; j < childNode.MyCurve.PathPointArray.Length; j++)
                    {
                        childPathPoint[j] = p.LonLat2XY(childNode.MyCurve.PathPointArray[j].X, childNode.MyCurve.PathPointArray[j].Y);
                    }
                    System.Drawing.Drawing2D.GraphicsPath childPath = new System.Drawing.Drawing2D.GraphicsPath();
                    childPath.AddLines(childPathPoint);
                    System.Drawing.Region thisChildRegion = new System.Drawing.Region(myRect);
                    thisChildRegion.Xor(new System.Drawing.Region(childPath));
                    this.m_FillRegion.Intersect(thisChildRegion);
                }
                if (this.CurveRelationTreeNode.MyNodeID == 10)
                {
                }
                System.Drawing.Color myFillColor = this.FillColor;
                if (this.CurveRelationTreeNode.Nodes.Count != 0)
                {
                    TreeNodeCurve childNode = (TreeNodeCurve)this.CurveRelationTreeNode.Nodes[0];
                    float valMin = this.CurveValue;
                    float valMax = childNode.MyCurve.CurveValue;
                    if (valMin > valMax)
                    {
                        float temp = valMin;
                        valMin = valMax;
                        valMax = temp;
                    }
                    int indexMin = cmFill.GetColorItemIndexByValue(valMin);
                    int indexMax = cmFill.GetColorItemIndexByValue(valMax);
                    myFillColor = cmFill.m_ColorItems[indexMin].myColor;
                }
                else if (this.CurveRelationTreeNode.Parent != null)
                {
                    int colorID = cmFill.GetColorItemIndexByValue(this.CurveValue);
                    TreeNodeCurve parentNode = (TreeNodeCurve)this.CurveRelationTreeNode.Parent;
                    if (parentNode.MyCurve != null && parentNode.MyCurve.CurveValue >= this.CurveValue)
                    {
                        colorID--;
                    }
                    ColorItem colorItem = cmFill.GetColorItemByIndex(colorID);
                    if (colorItem != null)
                    {
                        myFillColor = colorItem.myColor;
                    }
                }
                g.FillRegion(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(FillAlpha, myFillColor)), this.m_FillRegion);
            }
        }

        public void DrawSelectedCurve(System.Drawing.Graphics g, Projection p)
        {
            System.Drawing.Pen BasePointPen = new System.Drawing.Pen(System.Drawing.Color.Red, 2f);
            System.Drawing.Point[] BasePoint = new System.Drawing.Point[this.m_BasePointArray.Length];
            for (int i = 0; i < this.m_BasePointArray.Length; i++)
            {
                BasePoint[i] = p.LonLat2XY(this.m_BasePointArray[i].X, this.m_BasePointArray[i].Y);
            }
            g.DrawLines(BasePointPen, BasePoint);
            System.Drawing.Pen PathPointPen = new System.Drawing.Pen(System.Drawing.Color.White, 2f);
            PathPointPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            System.Drawing.Point[] PathPoint = new System.Drawing.Point[this.m_PathPointArray.Length];
            for (int i = 0; i < this.m_PathPointArray.Length; i++)
            {
                PathPoint[i] = p.LonLat2XY(this.m_PathPointArray[i].X, this.m_PathPointArray[i].Y);
            }
            g.DrawLines(PathPointPen, PathPoint);
            for (int i = 0; i < this.m_BasePointArray.Length; i++)
            {
                if (this.m_SelectedIndex == i)
                {
                    g.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Yellow), BasePoint[i].X - 5, BasePoint[i].Y - 5, 10, 10);
                }
                else
                {
                    g.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Blue), BasePoint[i].X - 3, BasePoint[i].Y - 3, 6, 6);
                }
            }
        }

        public Curve Clone()
        {
            return new Curve
            {
                ColorManagerCurve = this.ColorManagerCurve,
                ColorManagerFill = this.ColorManagerFill,
                BasePointArray = (System.Drawing.PointF[])this.BasePointArray.Clone(),
                PathPointArray = (System.Drawing.PointF[])this.PathPointArray.Clone(),
                CurveColorIndex = this.CurveColorIndex,
                FillColorIndex = this.FillColorIndex,
                LineWidth = this.LineWidth,
                LineStyle = this.LineStyle,
                IsClosed = this.IsClosed,
                CurveRelationTreeNode = this.CurveRelationTreeNode,
                IsSelected = this.IsSelected
            };
        }

        public int PointInMe(System.Drawing.PointF Pa)
        {
            int result;
            if (!this.m_IsClosed)
            {
                result = 0;
            }
            else
            {
                bool M = false;
                bool atBdy = false;
                float xP = Pa.X;
                float yP = Pa.Y;
                for (int i = 0; i < this.m_BasePointArray.Length - 1; i++)
                {
                    float xi = this.m_BasePointArray[i].X;
                    float yi = this.m_BasePointArray[i].Y;
                    float xip = this.m_BasePointArray[(i + 1) % (this.m_BasePointArray.Length - 1)].X;
                    float yip = this.m_BasePointArray[(i + 1) % (this.m_BasePointArray.Length - 1)].Y;
                    if ((xP >= xi || xP >= xip) && (xP < xi || xP < xip) && (yP >= yi || yP >= yip))
                    {
                        double y = (double)yi + (double)((xP - xi) * (yip - yi)) / (double)(xip - xi);
                        if (System.Math.Abs(y - (double)yP) < 0.0001)
                        {
                            atBdy = true;
                            break;
                        }
                        if (y < (double)yP)
                        {
                            M = !M;
                        }
                    }
                }
                if (!atBdy)
                {
                    if (M)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                else
                {
                    result = 2;
                }
            }
            return result;
        }

        public bool CurveInMe(Curve curve)
        {
            return this.IsClosed && curve.IsClosed && (this.PointInMe(curve.BasePointArray[0]) != 0 || this.PointInMe(curve.BasePointArray[curve.BasePointArray.Length / 2]) != 0);
        }

        private double DistanceD(System.Drawing.PointF Pa, System.Drawing.PointF Pb, System.Drawing.PointF Pc)
        {
            double Dbc = System.Math.Sqrt((double)((Pb.X - Pc.X) * (Pb.X - Pc.X) + (Pb.Y - Pc.Y) * (Pb.Y - Pc.Y)));
            return (double)((Pb.X - Pc.X) * (Pa.Y - Pc.Y) - (Pa.X - Pc.X) * (Pb.Y - Pc.Y)) / Dbc;
        }

        private float X(float U)
        {
            float V = 0f;
            for (int i = 0; i < this.m_BasePointArray.Length; i++)
            {
                V += this.m_BasePointArray[i].X * this.Blend(i, 3, U);
            }
            return V;
        }

        private float Y(float U)
        {
            float V = 0f;
            for (int i = 0; i < this.m_BasePointArray.Length; i++)
            {
                V += this.m_BasePointArray[i].Y * this.Blend(i, 3, U);
            }
            return V;
        }

        private float Blend(int i, int k, float U)
        {
            float result;
            if (k == 1)
            {
                if (this.t[i] <= U && U < this.t[i + 1])
                {
                    result = 1f;
                }
                else if (U == (float)this.m_BasePointArray.Length && this.t[i] <= U && U <= this.t[i + 1])
                {
                    result = 1f;
                }
                else
                {
                    result = 0f;
                }
            }
            else
            {
                float demon = this.t[i + k - 1] - this.t[i];
                float V;
                if (demon == 0f)
                {
                    V = 0f;
                }
                else
                {
                    float numer = (U - this.t[i]) * this.Blend(i, k - 1, U);
                    V = numer / demon;
                }
                demon = this.t[i + k] - this.t[i + 1];
                float V2;
                if (demon == 0f)
                {
                    V2 = 0f;
                }
                else
                {
                    float numer = (this.t[i + k] - U) * this.Blend(i + 1, k - 1, U);
                    V2 = numer / demon;
                }
                result = V + V2;
            }
            return result;
        }

        private void SPL()
        {
            if (this.m_BasePointArray != null && this.m_BasePointArray.Length != 0)
            {
                if (this.m_BasePointArray.Length <= 2)
                {
                    this.m_PathPointArray = (System.Drawing.PointF[])this.m_BasePointArray.Clone();
                }
                else
                {
                    this.t = new float[this.m_BasePointArray.Length + 3 + 1];
                    for (int i = 0; i < this.t.Length; i++)
                    {
                        if (i < 3)
                        {
                            this.t[i] = 0f;
                        }
                        else if (i <= this.m_BasePointArray.Length)
                        {
                            this.t[i] = (float)(i - 3 + 1);
                        }
                        else
                        {
                            this.t[i] = (float)(this.m_BasePointArray.Length - 3 + 1);
                        }
                    }
                    int r = this.m_BasePointArray.Length - 3 + 1;
                    int block = 10;
                    this.m_PathPointArray = new System.Drawing.PointF[r * block + 1];
                    for (int i = 0; i < r * block + 1; i++)
                    {
                        float U = (float)i * 1f / (float)block;
                        this.m_PathPointArray[i] = new System.Drawing.PointF(this.X(U), this.Y(U));
                    }
                    this.m_PathPointArray[r * block] = this.m_BasePointArray[this.m_BasePointArray.Length - 1];
                    this.t = null;
                }
            }
        }
    }
}
