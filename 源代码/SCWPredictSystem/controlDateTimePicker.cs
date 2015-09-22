using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCWPredictSystem
{
    public partial class controlDateTimePicker : UserControl
    {
        public event EventHandler DateTimeChanged;
        public DateTime selectedDateTime
        {
            get
            {
                DateTime dt = new DateTime(dateTimePicker1.Value.Year,
                                          dateTimePicker1.Value.Month,
                                          dateTimePicker1.Value.Day,
                                          radioButton08H.Checked == true ? 08 : 20,
                                          0, 0);
                return dt;
            }
            set
            {
                dateTimePicker1.Value = value;
                if (value.Hour <= 14)
                    radioButton08H.Checked = true;
                else
                    radioButton20H.Checked = true;
                if (DateTimeChanged != null)
                {
                    DateTimeChanged.Invoke(this, new EventArgs());
                }
            }
        }

        public controlDateTimePicker()
        {
            InitializeComponent();
        }

        private void buttonNow_Click(object sender, EventArgs e)
        {
            selectedDateTime = DateTime.Now;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            selectedDateTime = selectedDateTime - new TimeSpan(12, 0, 0);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            selectedDateTime = selectedDateTime + new TimeSpan(12, 0, 0);
        }
    }
}
