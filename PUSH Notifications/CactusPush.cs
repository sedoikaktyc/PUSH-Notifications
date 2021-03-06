using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using PUSH_Notifications.Properties;


namespace PUSH_Notifications
{
    public partial class CactusPush : Form
    {

        public int StartX, StartY;
        List<Gradient> Gradients = new List<Gradient>();
        public int MaxMessages = 5;
        private CactusPush.Action _action;
        public delegate void FormClose();
        public FormClose formClose;
        private bool _closeDeligate { get; set; }
        Type typeForTimer;
        int TymerPrepInt = 1;
        bool isCloseDisable = false;

        public class Gradient
        {
            public string Name { get; set; }
            public Color _left { get; set; }
            public Color _right { get; set; }

        }

        private void addGradients()
        {
            Gradients.Add(new Gradient() { Name = "error", _left = Color.FromArgb(255, 92, 12, 228), _right = Color.FromArgb(255, 252, 0, 0) }); 
            Gradients.Add(new Gradient() { Name = "alert", _left = Color.FromArgb(255, 92, 12, 228), _right = Color.FromArgb(255, 255, 154, 100) });
            Gradients.Add(new Gradient() { Name = "success", _left = Color.FromArgb(255, 92, 12, 228), _right = Color.FromArgb(255, 100, 240, 174) });
            Gradients.Add(new Gradient() { Name = "info", _left = Color.FromArgb(255, 92, 12, 228), _right = Color.FromArgb(255, 255, 197, 0) });
            Gradients.Add(new Gradient() { Name = "successWindow", _left = Color.FromArgb(255, 17, 153, 142), _right = Color.FromArgb(255, 29, 151, 108) });
            Gradients.Add(new Gradient() { Name = "errorWindow", _left = Color.FromArgb(255, 237, 33, 58), _right = Color.FromArgb(255, 147, 41, 30) });
        }

        public CactusPush()
        {
            addGradients();
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            DoubleBuffered = true;
            
        }

        public enum Сategory
        {
            Success,
            Error,
            Alert,
            Info
        }

        public enum Type
        {
            System,
            Window
        }

        public enum Action
        {
            Animate,
            Execution,
            Prep,
            Close
        }

        private void setTimeIntervalPrep(int interval) {
            if (interval > 0)
            {
                TymerPrepInt = interval;
            }
            else {
                isCloseDisable = true;
            }
            
        }

        public void ShowMessage(string message, Сategory category, int time = -1, Type type = Type.System, Form formParent = null, bool closeDeligate = false)
        {
            setTimeIntervalPrep(time);
            typeForTimer = type;
            string newFormName = "";
            _closeDeligate = closeDeligate;
            string formName;

            switch (type)
            {
                case Type.System:
                    SizeF sizeF1 = new SizeF();
                    sizeF1 = new SizeF(1.0f, 1.0f);
                    this.Scale(sizeF1);
                    Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
                    newFormName = "CactusPush";
                    break;
                case Type.Window:
                    SizeF sizeF06 = new SizeF();
                    sizeF06 = new SizeF(0.5f, 0.5f);
                    this.Scale(sizeF06);
                    Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 4, 4));
                    newFormName = "CactusPushWin";
                    MaxMessages = 1;
                    break;

            }
            bool isMax = false;
            Opacity = 0.0;
            StartPosition = FormStartPosition.Manual;

            for (int i = 1; i < MaxMessages + 1; i++)
            {
                formName = newFormName + i.ToString();
                CactusPush form = (CactusPush)Application.OpenForms[formName];

                if (form == null)
                {
                    Name = formName;
                    switch (type)
                    {
                        case Type.System:

                            StartX = Screen.PrimaryScreen.WorkingArea.Width - Width + 100 + 150;
                            StartY = Screen.PrimaryScreen.WorkingArea.Height - Height * i - 5 * i;
                            Location = new Point(StartX, StartY);
                            StartX = Screen.PrimaryScreen.WorkingArea.Width - Width  -5;
                            break;
                        case Type.Window:

                            MessageLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                            StartX = formParent.Location.X + formParent.Width / 2 - Width / 2;
                            StartY = formParent.Location.Y;
                            Location = new Point(StartX, StartY);
                            StartY = formParent.Location.Y + 40;
                            break;
                    }

                    break;

                }

                if (i + 1 > MaxMessages)
                {
                    isMax = true;
                }

            }

            if (isMax) return;

            switch (category)
            {
                case Сategory.Success:
                    this.IconBox.Image = Resources.ok;
                    switch (type)
                    {
                        case Type.System:
                            cactusGradienPanels1.ColorLeft = Gradients.Find(item => item.Name == "success")._left;
                            cactusGradienPanels1.ColorRight = Gradients.Find(item => item.Name == "success")._right;
                            break;

                        case Type.Window:
                            cactusGradienPanels1.ColorLeft = Gradients.Find(item => item.Name == "successWindow")._left;
                            cactusGradienPanels1.ColorRight = Gradients.Find(item => item.Name == "successWindow")._right;
                            break;
                    }                
                    break;
                case Сategory.Error: 
                    this.IconBox.Image = Resources.error;
                    switch (type)
                    {
                        case Type.System:
                            cactusGradienPanels1.ColorLeft = Gradients.Find(item => item.Name == "error")._left;
                            cactusGradienPanels1.ColorRight = Gradients.Find(item => item.Name == "error")._right;
                            break;

                        case Type.Window:
                            cactusGradienPanels1.ColorLeft = Gradients.Find(item => item.Name == "errorWindow")._left;
                            cactusGradienPanels1.ColorRight = Gradients.Find(item => item.Name == "errorWindow")._right;
                            break;
                    }
                    break;
                case Сategory.Info:
                    this.IconBox.Image = Resources.refresh;
                    cactusGradienPanels1.ColorLeft = Gradients.Find(item => item.Name == "info")._left;
                    cactusGradienPanels1.ColorRight = Gradients.Find(item => item.Name == "info")._right;
                    break;
                case Сategory.Alert:
                    this.IconBox.Image = Resources.confetti;
                    cactusGradienPanels1.ColorLeft = Gradients.Find(item => item.Name == "alert")._left;
                    cactusGradienPanels1.ColorRight = Gradients.Find(item => item.Name == "alert")._right;
                    break;
            }


            MessageLabel.Text = message;
            this.TopMost = true;
            Show();
            _action = Action.Animate;
            Timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (_action)
            {
                case Action.Animate:
                    Timer.Interval = 1;
                    Opacity += 0.1;
                    switch (typeForTimer)
                    {
                        case Type.System:

                            if (StartX < Location.X)
                            {
                                Left -= 15;
                            }
                            else
                            {
                                if (Opacity == 1.0)
                                {
                                    _action = Action.Prep;
                                }
                            }
                            break;

                        case Type.Window:

                            if (StartY > Location.Y)
                            {
                                Top += 4;
                            }
                            else
                            {
                                if (Opacity == 1.0)
                                {
                                    _action = Action.Prep;
                                }
                            }
                            break;

                    }

                    break;
                case Action.Prep:
                    if (isCloseDisable)
                    {
                        Timer.Stop();
                    }
                    else {
                        Timer.Interval = TymerPrepInt;
                    }
                                        
                    _action = Action.Close;
                    break;
                case Action.Close:
                    Timer.Interval = 1;
                    Opacity -= 0.1;

                    switch (typeForTimer)
                    {
                        case Type.System:
                            Left -= 3;
                            break;
                        case Type.Window:
                            Opacity -= 0.1;
                            Top -= 3;
                            break;
                    }

                    if (Opacity == 0.0)
                    {
                        Timer.Stop();
                        Close();
                    }
                    break;
            }
        }






        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
       int nLeftRect,
       int nTopRect,
       int nRightRect,
       int nBottomRect,
       int nWidthEllipse,
       int nHeightEllipse
    );
        private void CloseNow()
        {
            Timer.Interval = 1;
           
            _action = Action.Close;
            Timer.Start();
        }

        private void IconBox_Click(object sender, EventArgs e)
        {
            CloseNow();
        }

        private void cactusGradienPanels1_Click(object sender, EventArgs e)
        {
            CloseNow();
        }

        private void MessageLabel_Click(object sender, EventArgs e)
        {
            CloseNow();
        }



        private void CactusPush_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_closeDeligate) formClose();
        }



    }


}
