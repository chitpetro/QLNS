using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace QLNS
{
    public partial class f_form1 : DevExpress.XtraEditors.XtraForm
    {
        public f_form1()
        {
            InitializeComponent();
        }

        private void f_form1_Load(object sender, EventArgs e)
        {
            label1.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}