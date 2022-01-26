using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUSH_Notifications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Hello()
        {

            MessageBox.Show("Animation stoped");

        }

        public void Push(string message, CactusPush.Сategory Сategory)
        {
            CactusPush frm = new CactusPush();
            frm.ShowMessage(message, Сategory);
        }

        public void Notifications(string message, CactusPush.Сategory Сategory, CactusPush.Type Type, bool isCallBack)
        {
            CactusPush frm = new CactusPush();
            frm.formClose = Hello;
            frm.ShowMessage(message, Сategory, 500, Type, this, isCallBack);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Push("Success Alert", CactusPush.Сategory.Success);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Notifications("Success Alert Success Alert Success Alert", CactusPush.Сategory.Success, CactusPush.Type.Window, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Push("Success Alert", CactusPush.Сategory.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Push("Success Alert", CactusPush.Сategory.Alert);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Push("Success Alert", CactusPush.Сategory.Info);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Notifications("Success Alert Success Alert Success Alert", CactusPush.Сategory.Error, CactusPush.Type.Window, true);
        }
    }
}
