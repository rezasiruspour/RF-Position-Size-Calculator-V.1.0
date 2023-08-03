using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Position_Size
{
    class Ntextbox : System.Windows.Forms.TextBox
    {

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {

            // عدد اعشاری
            Boolean CheckFordecimal = !SelectedText.Contains(".");
            if (CheckFordecimal)
            {
                CheckFordecimal = Text.Contains(".");
            }

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || (e.KeyChar == '.' && !CheckFordecimal))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            // عدد

        }


        protected override void OnEnter(EventArgs e)
        {
            // Statements

            this.BackColor = Color.Yellow;
            base.OnEnter(e);
        }


        protected override void OnLeave(EventArgs e)
        {
            // Statements
            this.BackColor = Color.White;
            base.OnLeave(e);
        }

    }

}
