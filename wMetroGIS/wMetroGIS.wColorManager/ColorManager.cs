using System;
using System.Collections.Generic;
using System.Drawing;

namespace wMetroGIS.wColorManager
{
    public class ColorManager
    {
        public System.Collections.Generic.List<ColorItem> m_ColorItems;

        public float m_MinVal;

        public float m_MaxVal;

        public int m_MinColorID;

        public int m_MaxColorID;

        public ColorManager()
        {
            this.m_ColorItems = new System.Collections.Generic.List<ColorItem>();
        }

        public void CreateColorItems(float MinVal, float MaxVal, float StepVal, float BaseVal, int ColorID, System.Drawing.Color DefaultColor)
        {
            this.CreateColorItems(MinVal, MaxVal, StepVal, BaseVal, ColorID, DefaultColor, 0, 255, 1, "0", "");
        }

        public void CreateColorItems(float MinVal, float MaxVal, float StepVal, float BaseVal, int ColorID, System.Drawing.Color DefaultColor, int MinColorID, int MaxColorID, int TextStep)
        {
            this.CreateColorItems(MinVal, MaxVal, StepVal, BaseVal, ColorID, DefaultColor, 0, 255, 1, "0", "");
        }

        public void CreateColorItems(float MinVal, float MaxVal, float StepVal, float BaseVal, int ColorID, System.Drawing.Color DefaultColor, int MinColorID, int MaxColorID, int TextStep, string TextFormat)
        {
            this.CreateColorItems(MinVal, MaxVal, StepVal, BaseVal, ColorID, DefaultColor, 0, 255, 1, "0", "");
        }

        public void CreateColorItems(float MinVal, float MaxVal, float StepVal, float BaseVal, int ColorID, System.Drawing.Color DefaultColor, int MinColorID, int MaxColorID, int TextStep, string TextFormat, string ValueUnit)
        {
            //todo:自己添加的，防止间隔太短造成的bug
            StepVal = (MaxVal - MinVal) / 5;

            if (MinColorID < 0)
            {
                MinColorID = 0;
            }
            if (MaxColorID > 255)
            {
                MaxColorID = 255;
            }
            this.m_MinColorID = MinColorID;
            this.m_MaxColorID = MaxColorID;
            this.m_MinVal = BaseVal;
            if (this.m_MinVal >= MinVal)
            {
                while (this.m_MinVal >= MinVal)
                {
                    this.m_MinVal -= StepVal;
                }
                this.m_MinVal += StepVal;
            }
            else
            {
                while (this.m_MinVal <= MinVal)
                {
                    this.m_MinVal += StepVal;
                }
                this.m_MinVal -= StepVal;
            }
            this.m_MaxVal = this.m_MinVal;
            while (this.m_MaxVal <= MaxVal)
            {
                this.m_MaxVal += StepVal;
            }
            this.m_MaxVal -= StepVal;
            this.m_ColorItems.Clear();
            //todo:test
            //if (this.m_MinVal == this.m_MaxVal)
            //{
            //    return;
            //}
            ColorTable ct = new ColorTable(ColorID, DefaultColor);
            for (float thisVal = this.m_MinVal; thisVal <= this.m_MaxVal; thisVal += StepVal)
            {
                int i = System.Convert.ToInt32((float)this.m_MinColorID + (float)(this.m_MaxColorID - this.m_MinColorID) * (thisVal - this.m_MinVal) / (this.m_MaxVal - this.m_MinVal));
                ColorItem newItem = new ColorItem(ct.GetColor(i), thisVal, string.Format("{0:" + TextFormat + "}{1}", thisVal, ValueUnit), TextFormat, ValueUnit);
                this.m_ColorItems.Add(newItem);
            }
            for (int j = 0; j < this.m_ColorItems.Count; j++)
            {
                if (j % TextStep != 0)
                {
                    this.m_ColorItems[j].myValueText = "";
                }
            }
        }

        public int GetColorItemIndexByValue(float Value)
        {
            int result;
            for (int i = 0; i < this.m_ColorItems.Count; i++)
            {
                if ((double)System.Math.Abs(this.m_ColorItems[i].myValue - Value) < 0.01)
                {
                    result = i;
                    return result;
                }
            }
            result = 0;
            return result;
        }

        public ColorItem GetColorItemByIndex(int Index)
        {
            ColorItem result;
            if (Index < 0 || Index >= this.m_ColorItems.Count)
            {
                result = null;
            }
            else
            {
                result = this.m_ColorItems[Index];
            }
            return result;
        }

        public ColorItem GetColorItemByValue(float Value)
        {
            ColorItem result;
            foreach (ColorItem thisItem in this.m_ColorItems)
            {
                if (thisItem.myValue == Value)
                {
                    result = thisItem;
                    return result;
                }
            }
            result = null;
            return result;
        }
    }
}
