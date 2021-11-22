using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGDIFramework;

namespace Launchkit_Backend
{
    public class Toast
    {
        Form attachForm;
        Form toastLayer;
        Timer animTimer;
        GdiSystem gdi;
        Font f;
        public Toast(Form attachForm,Font f = null) {
            this.attachForm = attachForm;
            toastLayer = new Form();
            toastLayer.ShowInTaskbar = false;
            toastLayer.Size = new System.Drawing.Size(640, 360);
            toastLayer.FormBorderStyle = FormBorderStyle.None;
            toastLayer.StartPosition = FormStartPosition.CenterParent;
            toastLayer.Load += AttachForm_Load;
            attachForm.Move += AttachForm_Move;
            attachForm.SizeChanged += AttachForm_Move;
            attachForm.Disposed += AttachForm_Disposed;
            animTimer = new Timer();
            animTimer.Interval = 1;
            animTimer.Enabled = false;
            animTimer.Tick += AnimTimer_Tick;
            toastLayer.Show(attachForm);
            if (f == null)
            {
                this.f = new Font(FontFamily.GenericSansSerif, 20);
            }
            else {
                this.f = f;
            }
        }

        private void AttachForm_Disposed(object sender, EventArgs e)
        {
            animTimer.Dispose();
            toastLayer.Dispose();

        }

        int animCd = 0;
        Brush bgBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
        Brush textBrush = new SolidBrush(Color.White);
        Pen fgBrush = new Pen(Color.White,2);
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            if (animCd > 0)
            {
                gdi.Graphics.Clear(Color.Transparent);
                gdi.Graphics.ResetTransform();
                gdi.Graphics.TranslateTransform(320, 0);
                if (animCd > 192 - 32)
                {
                    gdi.Graphics.ScaleTransform((193f - animCd) / 32f, 1);

                }
                else if (animCd > 32)
                {

                }
                else {
                    gdi.Graphics.ScaleTransform(((animCd+1) / 32f), 1);
                }
                animCd--;
                animCd--;

                gdi.Graphics.FillRectangle(bgBrush, region);
                gdi.Graphics.DrawRectangle(fgBrush, region);
                gdi.Graphics.DrawString(message, f, textBrush, region, center);

                gdi.UpdateWindow();
            }
            else {
                gdi.Graphics.Clear(Color.Transparent);
                gdi.UpdateWindow(); 
                animTimer.Enabled = false;
            }
        }

        private String message = "";

        private Rectangle region = Rectangle.Empty;

        StringFormat center = new StringFormat() {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
       

        public void ShowMessage(String msg) {

            this.message = msg;
            animCd = 192;
            animTimer.Enabled = true;

            SizeF s = gdi.Graphics.MeasureString(msg, f);
            SizeF charSize = gdi.Graphics.MeasureString("觉", f);

            float w = s.Width;
            float h = s.Height+5;
            while (w > 630) {
                h += charSize.Height;
                w -= 630;
            }
            w += 30;
            h += 30;
            region = new Rectangle((int)(-w / 2), (int)(360 - h) - 10, (int)w, (int)h) ;
            if (attachForm.WindowState == FormWindowState.Minimized)
            {
                toastLayer.Visible = false;
            }
            else
            {
                toastLayer.Visible = true;
                toastLayer.Left = attachForm.Left + attachForm.Width / 2 - toastLayer.Width / 2;
                toastLayer.Top = attachForm.Top + attachForm.Height / 2 - toastLayer.Height / 2;
            }
        }

        private void AttachForm_Load(object sender, EventArgs e)
        {

            gdi = new GdiSystem(toastLayer);
            gdi.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gdi.Graphics.Clear(Color.Transparent);
            gdi.UpdateWindow();
            
        }

        private void AttachForm_Move(object sender, EventArgs e)
        {
            if (attachForm.WindowState == FormWindowState.Minimized)
            {
                toastLayer.Visible = false;
            }
            else {
                toastLayer.Visible = true;
                toastLayer.Left = attachForm.Left + attachForm.Width / 2 - toastLayer.Width / 2;
                toastLayer.Top = attachForm.Top + attachForm.Height / 2 - toastLayer.Height / 2;
            }
        }
    }
}
