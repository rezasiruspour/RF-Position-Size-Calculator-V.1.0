//REweHbBgxKMpXe0kWhqWdjCe6kbLhZ52C7XdFVR4U7aRYlSjsZPnlNaaKUcmxHzQpr+Mfq+5cbmxfgGv7oGk5lajpekrBKJ4WWbA+YDvRpc=
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Linq;
using HtmlAgilityPack;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace Position_Size
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ntextbox1.BackColor = Color.White;
            ntextbox2.BackColor = Color.White;
            ntextbox3.BackColor = Color.White;
            ntextbox4.BackColor = Color.White;
            ntextbox5.BackColor = Color.White;
            ntextbox6.BackColor = Color.White; 
            ntextbox7.BackColor = Color.White;
            ntextbox8.BackColor = Color.White;
            ntextbox9.BackColor = Color.White;
            ntextbox9.Enabled = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox7.Parent = pictureBox1;
            pictureBox7.Location = new Point( (pictureBox1.Width / 2) - (pictureBox7.Width/2)+2, (pictureBox1.Height / 2) - pictureBox7.Height / 2);
            label2.Visible = false;
            comboBox2.Items.Add("CUSTOM");
            comboBox2.Text = "CUSTOM";
            comboBox1.Items.Add("CUSTOM");
            comboBox1.Text = "CUSTOM";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            timer3.Enabled = true;
            ntextbox5.MaxLength = 10;
            ntextbox1.MaxLength = 10;
            try
            {
                string url = pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7GztCpqegBnECA4kj+zRPkY5KM9acZvbzk9JcZL1stMb992AP+OQGB1WMYNMYwbMbQA==");
                HttpClient client = new HttpClient();
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        string thumbnail = result.Substring(result.IndexOf(textBox1.Text));
                        int hqdefault = thumbnail.IndexOf("/hqdefault.jpg");
                        thumbnail = thumbnail.Substring(thumbnail.IndexOf(textBox1.Text), hqdefault);
                        thumbnail = thumbnail.Replace(textBox1.Text, "");
                        string lastimg = thumbnail + "/hqdefault.jpg";
                        string lastlink = thumbnail.Replace(pipvalueforex.valuenumber("C43WqRvt6N2/MrUr9A/NlJJTx37gu/2CsSD8zDReah0="), pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7G2b8xlaQlGBgdYs+L41UbR25dwJCuyXIoow3RZDVlTmm"));
                        pictureBox1.ImageLocation = lastimg;
                        pictureBox6.Visible = true;
                        pictureBox1.Cursor = Cursors.Hand;
                        textBox2.Text = lastlink;
                        pictureBox7.Visible = true;
                        label2.Visible = true;
                        label2.Cursor = Cursors.Hand;
                        timer1.Enabled = true;
                        pictureBox10.Visible = false;
                    }
                }
            }
            catch
            {
            }
            forexpip();
        }
        private void ntextbox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt5, txt6, txt7, txt8;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                if (txt7 > txt8)
                {
                    label30.Text = "Long (BUY)";
                    label30.ForeColor = Color.FromArgb(153, 255, 102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString(); 
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt7 - txt8);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2)+ " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                else
                {
                    //R + aRCWoN7wjlAe1CKFjYlZiTg7NT5ry4qTZJ62OON6 + 9j1hHc0S8RDPBxC4OhEzP
                    label30.Text = "Short (SELL)";
                     label30.ForeColor = Color.FromArgb(255,102,102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt8 - txt7);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                double loss = txt5 * (txt6 / 100);
                loss = Math.Round(loss, 2);
                this.label34.Text = (loss + " USDT").ToString();
            }
            catch (Exception)
            {
                this.label24.Text = "0 USDT";
                this.label30.Text = "-";
                this.label26.Text = "0 %";
                this.label28.Text = "0";
                this.label32.Text = "0";
                this.label34.Text = "0 USDT";
                label32.ForeColor = Color.White;
                label31.ForeColor = Color.White;
                label30.ForeColor = Color.White;
                ntextbox9.Text = "0";
                ntextbox9.Enabled = false;
            }
            try
            {
                double txt5, txt6, txt7, txt8, txt11;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                txt11 = double.Parse(this.ntextbox11.Text);
                if (txt7 > txt8)
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = ((psa * txt11) / txt7) - psa;
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
                else
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = psa - ((psa * txt11) / txt7);
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
            }
            catch (Exception)
            {
                this.label44.Text = "0 USDT";
                this.label47.Text = "0";
            }
        }
        private void ntextbox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt5, txt6, txt7, txt8;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                if (txt7 > txt8)
                {
                    label30.Text = "Long (BUY)";
                    label30.ForeColor = Color.FromArgb(153, 255, 102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt7 - txt8);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                else
                {
                    label30.Text = "Short (SELL)";
                     label30.ForeColor = Color.FromArgb(255,102,102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt8 - txt7);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                double loss = txt5 * (txt6 / 100);
                loss = Math.Round(loss, 2);
                this.label34.Text = (loss + " USDT").ToString();
            }
            catch (Exception)
            {
                this.label24.Text = "0 USDT";
                this.label30.Text = "-";
                this.label26.Text = "0 %";
                this.label28.Text = "0";
                this.label32.Text = "0";
                this.label34.Text = "0 USDT";
                label32.ForeColor = Color.White;
                label31.ForeColor = Color.White;
                label30.ForeColor = Color.White;
                ntextbox9.Text = "0";
                ntextbox9.Enabled = false;
            }
            try
            {
                double txt5, txt6, txt7, txt8, txt11;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                txt11 = double.Parse(this.ntextbox11.Text);
                if (txt7 > txt8)
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = ((psa * txt11) / txt7) - psa;
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
                else
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = psa - ((psa * txt11) / txt7);
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
            }
            catch (Exception)
            {
                this.label44.Text = "0 USDT";
                this.label47.Text = "0";
            }
        }
        private void ntextbox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt5, txt6, txt7, txt8;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                if (txt7 > txt8)
                {
                    label30.Text = "Long (BUY)";
                    label30.ForeColor = Color.FromArgb(153, 255, 102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt7 - txt8);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                else
                {
                    //R + aRCWoN7wjlAe1CKFjYlZiTg7NT5ry4qTZJ62OON6 + 9j1hHc0S8RDPBxC4OhEzP
                    label30.Text = "Short (SELL)";
                     label30.ForeColor = Color.FromArgb(255,102,102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt8 - txt7);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                double loss = txt5 * (txt6 / 100);
                loss = Math.Round(loss, 2);
                this.label34.Text = (loss + " USDT").ToString();
            }
            catch (Exception)
            {
                this.label24.Text = "0 USDT";
                this.label30.Text = "-";
                this.label26.Text = "0 %";
                this.label28.Text = "0";
                this.label32.Text = "0";
                this.label34.Text = "0 USDT";
                label32.ForeColor = Color.White;
                label31.ForeColor = Color.White;
                label30.ForeColor = Color.White;
                ntextbox9.Text = "0";
                ntextbox9.Enabled = false;
            }
            try
            {
                double txt5, txt6, txt7, txt8, txt11;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                txt11 = double.Parse(this.ntextbox11.Text);
                if (txt7 > txt8)
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = ((psa * txt11) / txt7) - psa;
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
                else
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = psa - ((psa * txt11) / txt7);
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
            }
            catch (Exception)
            {
                this.label44.Text = "0 USDT";
                this.label47.Text = "0";
            }
        }
        private void ntextbox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt5, txt6, txt7, txt8;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                if (txt7 > txt8)
                {
                    label30.Text = "Long (BUY)";
                    label30.ForeColor = Color.FromArgb(153, 255, 102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7)/txt5)*100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt7 - txt8);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa / txt5).ToString();
                    if (psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                else 
                { 
                    label30.Text = "Short (SELL)";
                     label30.ForeColor = Color.FromArgb(255,102,102);
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7) / txt5) * 100;
                    psp = Math.Round(psp, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt8 - txt7);
                    this.label28.Text = psu.ToString();
                    ntextbox9.Text = "1";
                    this.label32.Text = Math.Ceiling(psa/txt5).ToString();
                    if(psa / txt5 < 1)
                    {
                        label32.ForeColor = Color.White;
                        label31.ForeColor = Color.White;
                    }
                    else
                    {
                        label32.ForeColor = Color.Yellow;
                        label31.ForeColor = Color.Yellow;
                        psp = Math.Round(psp, 2);
                        this.label24.Text = (Math.Round((psa / Math.Ceiling(psa / txt5)), 2) + " USDT").ToString();
                        this.label26.Text = (Math.Round((psp / Math.Ceiling(psa / txt5)), 2) + " %").ToString();
                        this.label28.Text = (psu / Math.Ceiling(psa / txt5)).ToString();
                        ntextbox9.Text = Math.Ceiling(psa / txt5).ToString();
                    }
                    ntextbox9.Enabled = true;
                }
                double loss = txt5 * (txt6 / 100) ;
                loss = Math.Round(loss, 2);
                this.label34.Text = (loss + " USDT").ToString();
            }
            catch (Exception)
            {
                this.label24.Text = "0 USDT";
                this.label30.Text = "-";
                this.label26.Text = "0 %";
                this.label28.Text = "0";
                this.label32.Text = "0";
                this.label34.Text = "0 USDT";
                label32.ForeColor = Color.White;
                label31.ForeColor = Color.White;
                label30.ForeColor = Color.White;
                ntextbox9.Text = "0";
                ntextbox9.Enabled = false;
            }
            try
            {
                double txt5, txt6, txt7, txt8, txt11;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                txt11 = double.Parse(this.ntextbox11.Text);
                if (txt7 > txt8)
                {
                    //R+aRCWoN7wjlAe1CKFjYlZiTg7NT5ry4qTZJ62OON6+9j1hHc0S8RDPBxC4OhEzP
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = ((psa * txt11) / txt7) - psa;
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
                else
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = psa - ((psa * txt11) / txt7);
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
            }
            catch (Exception)
            {
                this.label44.Text = "0 USDT";
                this.label47.Text = "0";
            }
        }
        private void ntextbox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            base.OnKeyPress(e);
        }
        private void ntextbox9_TextChanged(object sender, EventArgs e)
        {
            if (ntextbox9.Text == "0")
            {
                ntextbox9.Text = "";
            }
            try
            {
                double txt5, txt6, txt7, txt8, txt9;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                txt9 = double.Parse(this.ntextbox9.Text);
                if (txt7 > txt8)
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa/txt9, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7) / txt5) * 100;
                    psp = Math.Round(psp / txt9, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt7 - txt8);
                    this.label28.Text = (psu/txt9).ToString();
                }
                else
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa / txt9, 2);
                    this.label24.Text = (psa + " USDT").ToString();
                    double psp = (((txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7) / txt5) * 100;
                    psp = Math.Round(psp / txt9, 2);
                    this.label26.Text = (psp + " %").ToString();
                    double psu = (txt5 * (txt6 * 0.01)) / (txt8 - txt7);
                    this.label28.Text = (psu / txt9).ToString();
                }
            }
            catch (Exception)
            {

            }
        }
        private void ntextbox9_Enter(object sender, EventArgs e)
        {
            ntextbox9.BackColor = Color.Yellow;
        }
        private void ntextbox9_Leave(object sender, EventArgs e)
        {
            ntextbox9.BackColor = Color.White;
        }
        private void ntextbox6_Enter(object sender, EventArgs e)
        {

        }
        private void ntextbox6_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(ntextbox6, "A Good Starting Could Be 0.5% Of Your Available Trading Capital");
        }
        private void ntextbox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt1, txt2, txt3, txt4;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt4 = double.Parse(this.ntextbox4.Text);
                    double aar = txt1 * (txt2 / 100);
                    aar = Math.Round(aar, 2);
                    this.label10.Text = (aar + " USD").ToString();
                double slots = (txt1 *txt2)/(100*txt3*txt4) ;
                slots = Math.Round(slots, 4);
                this.label35.Text = slots.ToString();
                double psunits = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100000;
                psunits = Math.Round(psunits, 4);
                this.label12.Text = psunits.ToString();
                double minilots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 10;
                minilots = Math.Round(minilots, 4);
                this.label37.Text = minilots.ToString();
                double microlots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100;
                microlots = Math.Round(microlots, 4);
                this.label39.Text = microlots.ToString();
            }
            catch (Exception)
            {
                this.label10.Text = "0 USD";
                this.label12.Text = "0";
                this.label35.Text = "0";
                this.label37.Text = "0";
                this.label39.Text = "0";
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
            try
            {
                double txt1, txt2, txt3, txt4, txt10;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt10 = double.Parse(this.ntextbox10.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double profitf = (txt10 / txt3) * aar;
                profitf = Math.Round(profitf, 1);
                this.label48.Text = (profitf + " USD").ToString();
                double rrrf = txt10 / txt3;
                rrrf = Math.Round(rrrf, 2);
                this.label53.Text = (rrrf).ToString();
            }
            catch (Exception)
            {
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
        }
        private void ntextbox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt1, txt2, txt3, txt4;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt4 = double.Parse(this.ntextbox4.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double slots = (txt1 * txt2) / (100 * txt3 * txt4);
                slots = Math.Round(slots, 4);
                this.label35.Text = slots.ToString();
                double psunits = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100000;
                psunits = Math.Round(psunits, 4);
                this.label12.Text = psunits.ToString();
                double minilots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 10;
                minilots = Math.Round(minilots, 4);
                this.label37.Text = minilots.ToString();
                double microlots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100;
                microlots = Math.Round(microlots, 4);
                this.label39.Text = microlots.ToString();
            }
            catch (Exception)
            {
                this.label10.Text = "0 USD";
                this.label12.Text = "0";
                this.label35.Text = "0";
                this.label37.Text = "0";
                this.label39.Text = "0";
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
            try
            {
                double txt1, txt2, txt3, txt4, txt10;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt10 = double.Parse(this.ntextbox10.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double profitf = (txt10 / txt3) * aar;
                profitf = Math.Round(profitf, 1);
                this.label48.Text = (profitf + " USD").ToString();
                double rrrf = txt10 / txt3;
                rrrf = Math.Round(rrrf, 2);
                this.label53.Text = (rrrf).ToString();
            }
            catch (Exception)
            {
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
        }
        private void ntextbox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt1, txt2, txt3, txt4;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt4 = double.Parse(this.ntextbox4.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double slots = (txt1 * txt2) / (100 * txt3 * txt4);
                slots = Math.Round(slots, 4);
                this.label35.Text = slots.ToString();
                double psunits = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100000;
                psunits = Math.Round(psunits, 4);
                this.label12.Text = psunits.ToString();
                double minilots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 10;
                minilots = Math.Round(minilots, 4);
                this.label37.Text = minilots.ToString();
                double microlots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100;
                microlots = Math.Round(microlots, 4);
                this.label39.Text = microlots.ToString();
            }
            catch (Exception)
            {
                this.label10.Text = "0 USD";
                this.label12.Text = "0";
                this.label35.Text = "0";
                this.label37.Text = "0";
                this.label39.Text = "0";
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
            try
            {
                double txt1, txt2, txt3, txt4, txt10;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt10 = double.Parse(this.ntextbox10.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double profitf = (txt10 / txt3) * aar;
                profitf = Math.Round(profitf, 1);
                this.label48.Text = (profitf + " USD").ToString();
                double rrrf = txt10 / txt3;
                rrrf = Math.Round(rrrf, 2);
                this.label53.Text = (rrrf).ToString();
            }
            catch (Exception)
            {
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
        }
        private void ntextbox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt1, txt2, txt3, txt4, txt10;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt10 = double.Parse(this.ntextbox10.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double profitf = (txt10 / txt3) * aar;
                profitf = Math.Round(profitf, 1);
                this.label48.Text = (profitf + " USD").ToString();
                double rrrf = txt10 / txt3;
                rrrf = Math.Round(rrrf, 2);
                this.label53.Text = (rrrf).ToString();
            }
            catch (Exception)
            {
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
            try
            {
                double txt1, txt2, txt3, txt4;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt4 = double.Parse(this.ntextbox4.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double slots = (txt1 * txt2) / (100 * txt3 * txt4);
                slots = Math.Round(slots, 4);
                this.label35.Text = slots.ToString();
                double psunits = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100000;
                psunits = Math.Round(psunits, 4);
                this.label12.Text = psunits.ToString();
                double minilots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 10;
                minilots = Math.Round(minilots, 4);
                this.label37.Text = minilots.ToString();
                double microlots = ((txt1 * txt2) / (100 * txt3 * txt4)) * 100;
                microlots = Math.Round(microlots, 4);
                this.label39.Text = microlots.ToString();
            }
            catch (Exception)
            {
                this.label10.Text = "0 USD";
                this.label12.Text = "0";
                this.label35.Text = "0";
                this.label37.Text = "0";
                this.label39.Text = "0";
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
        }
        private void ntextbox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(ntextbox2, "A Good Starting Could Be 0.5% Of Your Available Trading Capital");
        }
        private void ntextbox4_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(ntextbox4, "The Pip Value Is The Price Attributed To A One-Pip Move In A Forex Trade");
        }
        private void ntextbox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt5, txt6, txt7, txt8,txt11;
                txt5 = double.Parse(this.ntextbox5.Text);
                txt6 = double.Parse(this.ntextbox6.Text);
                txt7 = double.Parse(this.ntextbox7.Text);
                txt8 = double.Parse(this.ntextbox8.Text);
                txt11 = double.Parse(this.ntextbox11.Text);
                if (txt7 > txt8)
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt7 - txt8) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = ((psa *txt11)/txt7)-psa;
                    this.label44.Text = (Math.Round(profitc, 1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc /loss,2).ToString();
                }
                else
                {
                    double psa = (txt5 * (txt6 * 0.01)) / (txt8 - txt7) * txt7;
                    psa = Math.Round(psa, 2);
                    double profitc = psa - ((psa * txt11) / txt7);
                    this.label44.Text = (Math.Round(profitc,1) + " USDT").ToString();
                    double loss = txt5 * (txt6 / 100);
                    this.label47.Text = Math.Round(profitc / loss, 2).ToString();
                }
            }
            catch (Exception)
            {
                this.label44.Text = "0 USDT";
                this.label47.Text = "0";
            }
        }
        private void ntextbox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double txt1, txt2, txt3, txt4,txt10;
                txt1 = double.Parse(this.ntextbox1.Text);
                txt2 = double.Parse(this.ntextbox2.Text);
                txt3 = double.Parse(this.ntextbox3.Text);
                txt10 = double.Parse(this.ntextbox10.Text);
                double aar = txt1 * (txt2 / 100);
                aar = Math.Round(aar, 2);
                this.label10.Text = (aar + " USD").ToString();
                double profitf = (txt10 /txt3)*aar ;
                profitf = Math.Round(profitf, 1);
                this.label48.Text = (profitf + " USD").ToString();
                double rrrf = txt10 / txt3;
                rrrf = Math.Round(rrrf, 2);
                this.label53.Text = (rrrf).ToString();
            }
            catch (Exception)
            {
                this.label48.Text = "0 USD";
                this.label53.Text = "0";
            }
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Height = 63;
            pictureBox2.Width = 330;
            pictureBox2.Location = new Point(6, 260);
            pictureBox2.Cursor = Cursors.Hand;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Height = 57;
            pictureBox2.Width = 300;
            pictureBox2.Location = new Point(20, 260);
            pictureBox2.Cursor = Cursors.Default;
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Height = 63;
            pictureBox3.Width = 330;
            pictureBox3.Location = new Point(6, 323);
            pictureBox3.Cursor = Cursors.Hand;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Height = 57;
            pictureBox3.Width = 300;
            pictureBox3.Location = new Point(20, 323);
            pictureBox3.Cursor = Cursors.Default;
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Height = 63;
            pictureBox4.Width = 330;
            pictureBox4.Location = new Point(6, 386);
            pictureBox4.Cursor = Cursors.Hand;
        }
        private void pictureBox4_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox4.Height = 57;
            pictureBox4.Width = 300;
            pictureBox4.Location = new Point(20, 386);
            pictureBox4.Cursor = Cursors.Default;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("0 + IPkfwlRvO6ALy8GPU7GztCpqegBnECA4kj + zRPkY5KM9acZvbzk9JcZL1stMb9mis + QfYd02HrnkWaZpXEFU2OfbeBAEBcwGEM / HxK / kQ ="));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("TTXCd80FuZWw2/kSUZ0ml+ISQEvvMAFg89xVvEafxqs="));
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("344HBqI6xPYh0vU7wn8DjhF8MPEDtAZbGTvdseXTzVOaS1EJbm0E1dlh+cejIzbA"));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(textBox2.Text);
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7G2b8xlaQlGBgdYs+L41UbR0arDUkxnnHiaUsDZbVKeQK"));
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7G2b8xlaQlGBgdYs+L41UbR0B6q6mTWMgQuh5LN+KxS1I"));
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7G2b8xlaQlGBgdYs+L41UbR1k28YQhLwSFWCGwwdPIjL9"));
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Process.Start(pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7G2b8xlaQlGBgdYs+L41UbR0WgzvwYUhBfwVA5856HnMS"));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
            timer2.Enabled = true;
            timer1.Enabled = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label2.Text== pipvalueforex.valuenumber("KFMXQMJpPA3acz2XkjRmF1s7OisbTg60yjXBL1JItiI="))
            { 
                label2.Text = "Click Me!";
                label2.Location = new Point(141, 225);
            }
            else 
            { 
                label2.Text = pipvalueforex.valuenumber("KFMXQMJpPA3acz2XkjRmF1s7OisbTg60yjXBL1JItiI=");
                label2.Location = new Point(73, 225);
            }

            label2.Visible = true;
            timer1.Enabled = true;
            timer2.Enabled = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start(textBox2.Text);
        }
        public static string[] splitLines(string text)
        {
            string[] lines = text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            return lines;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int f = comboBox1.SelectedIndex;
            string text = comboBox2.Items[f].ToString();

            if (f == 0)
            {ntextbox4.Text  = ""; }
            else
            { ntextbox4.Text = text; }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process.Start(textBox2.Text);
        }
        public async void forexpip()
        {
            try
            {
                var html = @pipvalueforex.valuenumber("4fVI9BUpSPNt0 + JTIouL9Gi9 + xQuO17w5tBqjsNAmEVQMhTtSlcE6zlO + wa2wS6 +");
                HtmlWeb web = new HtmlWeb();
                var htmldoc = await web.LoadFromWebAsync(html);
                var symbol = htmldoc.DocumentNode.SelectNodes("//th[@class='font-blue']");
                var pipvalue = htmldoc.DocumentNode.SelectNodes("//td[@class='pipvalue']");
                foreach (var item in symbol)
                {
                    string str1 = item.InnerText.Substring(0, 3);
                    string str2 = item.InnerText.Substring(3);
                    comboBox1.Items.Add(str1 + " / " + str2);
                }
                foreach (var item in pipvalue)
                {
                    comboBox3.Items.Add(item.InnerText);
                }

                for (int pipremove = 0; pipremove < comboBox3.Items.Count; pipremove += 3)
                {
                    comboBox2.Items.Add(comboBox3.Items[pipremove]);
                }
                timer3.Enabled = false;
                Bitmap b = (Bitmap)pictureBox9.Image;
                pictureBox8.Image = rotateImage(b, 0);
                pictureBox10.Image = rotateImage(b, 0);
            }
            catch
            {
                timer3.Enabled = false;
                Bitmap b = (Bitmap)pictureBox9.Image;
                pictureBox8.Image = rotateImage(b, 0);
                pictureBox10.Image = rotateImage(b, 0);
            }
        }
        int rot1 = 10;
        int rot2 = 10;
        private Bitmap rotateImage(Bitmap b, float angle)
        {
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            Bitmap b = (Bitmap)pictureBox9.Image;
            pictureBox10.Image = rotateImage(b, rot1);
            rot1 = rot1 + 10;
            pictureBox8.Image = rotateImage(b, rot2);
            rot2 = rot2 + 10;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("CUSTOM");
            comboBox2.Text = "CUSTOM";
            comboBox1.Items.Add("CUSTOM");
            comboBox1.Text = "CUSTOM";
            timer3.Enabled = true;
            forexpip();
        }
        private async void pictureBox10_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("CUSTOM");
            comboBox2.Text = "CUSTOM";
            comboBox1.Items.Add("CUSTOM");
            comboBox1.Text = "CUSTOM";
            timer3.Enabled = true;
            try
            {
                string url = pipvalueforex.valuenumber("0+IPkfwlRvO6ALy8GPU7GztCpqegBnECA4kj+zRPkY5KM9acZvbzk9JcZL1stMb992AP+OQGB1WMYNMYwbMbQA==");
                HttpClient client = new HttpClient();
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        string thumbnail = result.Substring(result.IndexOf(textBox1.Text));
                        int hqdefault = thumbnail.IndexOf(pipvalueforex.valuenumber("9idMLOWBVPEq0cku0eJovQ =="));
                        thumbnail = thumbnail.Substring(thumbnail.IndexOf(textBox1.Text), hqdefault);
                        thumbnail = thumbnail.Replace(textBox1.Text, "");
                        string lastimg = thumbnail + pipvalueforex.valuenumber("9idMLOWBVPEq0cku0eJovQ ==");
                        string lastlink = thumbnail.Replace(pipvalueforex.valuenumber("C43WqRvt6N2 / MrUr9A / NlJJTx37gu / 2CsSD8zDReah0 ="), pipvalueforex.valuenumber("0 + IPkfwlRvO6ALy8GPU7G2b8xlaQlGBgdYs + L41UbR25dwJCuyXIoow3RZDVlTmm"));
                        pictureBox1.ImageLocation = lastimg;
                        pictureBox6.Visible = true;
                        pictureBox1.Cursor = Cursors.Hand;
                        textBox2.Text = lastlink;
                        pictureBox7.Visible = true;
                        label2.Visible = true;
                        label2.Cursor = Cursors.Hand;
                        timer1.Enabled = true;
                        pictureBox10.Visible = false;
                    }
                }
            }
            catch
            {
                //R+aRCWoN7wjlAe1CKFjYlZiTg7NT5ry4qTZJ62OON6+9j1hHc0S8RDPBxC4OhEzP
            }
            forexpip();   
        }
        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.Location = new Point(-10, 23);
            pictureBox11.Cursor = Cursors.Hand;
        }
        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Location = new Point(-19, 23);
            pictureBox11.Cursor = Cursors.Hand;
        }
        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.Location = new Point(-10, 135);
            pictureBox12.Cursor = Cursors.Hand;
        }
        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Location = new Point(-19, 135);
            pictureBox12.Cursor = Cursors.Hand;
        }
        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox13.Location = new Point(-10, 247);
            pictureBox13.Cursor = Cursors.Hand;
        }
        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.Location = new Point(-19, 247);
            pictureBox13.Cursor = Cursors.Hand;
        }
        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.Location = new Point(-10, 359);
            pictureBox14.Cursor = Cursors.Hand;
        }
        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.Location = new Point(-19, 359);
            pictureBox14.Cursor = Cursors.Hand;
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool isSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            if (e.Index > -1)
            {
                Color color = isSelected ? SystemColors.Highlight :
                    e.Index % 2 == 0 ? Color.WhiteSmoke : Color.LightGray;
                SolidBrush backgroundBrush = new SolidBrush(color);
                SolidBrush textBrush = new SolidBrush(e.ForeColor);
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);
                backgroundBrush.Dispose();
                textBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        private void label28_MouseClick(object sender, MouseEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.OwnerDraw = true;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            toolTip1.BackColor = System.Drawing.Color.MediumPurple;
            toolTip1.AutoPopDelay = 600;
            toolTip1.InitialDelay = 300;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.label28, " Copy ");
            Clipboard.SetText(label28.Text);
            PauseForMilliSeconds(4000);
            toolTip1.Active = false;
        }
        void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Arial", 9.0f, FontStyle.Bold);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.AliceBlue, new PointF(2, 2));
        }
        public static void PauseForMilliSeconds(int T)
        {
            DateTime TimeA = DateTime.Now;
            DateTime TimeB = TimeA.AddMilliseconds((double)T);
            while (TimeB >= TimeA)
            {
                System.Windows.Forms.Application.DoEvents();
                TimeA = DateTime.Now;
            }
        }
        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.OwnerDraw = true;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            toolTip1.BackColor = System.Drawing.Color.MediumPurple;
            toolTip1.AutoPopDelay = 600;
            toolTip1.InitialDelay = 300;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.label12, " Copy ");
            Clipboard.SetText(label12.Text);
            PauseForMilliSeconds(4000);
            toolTip1.Active = false;
        }
        public class pipvalueforex
        {
            private static readonly byte[] _key = { 0xF1, 0x46, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
            private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
            protected internal static string valuenumber(string Value)
            {
                SymmetricAlgorithm mCSP;
                ICryptoTransform ct = null;
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] byt;
                byte[] _result; mCSP = new RijndaelManaged();
                try
                {
                    mCSP.Key = _key;
                    mCSP.IV = _initVector;
                    ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                    byt = Convert.FromBase64String(Value);
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                    cs.Write(byt, 0, byt.Length); cs.FlushFinalBlock();
                    cs.Close();
                    _result = ms.ToArray();
                }
                catch (Exception ex)
                {
                    _result = null;
                    throw ex;
                }
                finally
                {
                    if (ct != null)
                        ct.Dispose();
                    if (ms != null)
                        ms.Dispose();
                    if (cs != null)
                        cs.Dispose();
                }
                return ASCIIEncoding.UTF8.GetString(_result);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}