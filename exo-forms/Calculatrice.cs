using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exo_forms
{
    public partial class Calculatrice : Form
    {

        public Calculatrice()
        {
            InitializeComponent();
        }

        public void buttonNumber_Click(Object sender, EventArgs e)
        {
            var btn = (Button)sender;
            lblHistoCalc.Text += btn.Text;
        }

        public void buttonOp_Click(Object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if(btn.Text != "=")
            {         
                lblHistoCalc.Text += " " + btn.Text + " ";
            } 
            else
            {
                CalculResult();
            }    
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (lblHistoCalc.Text.Length > 0)
            {
                string txt = lblHistoCalc.Text;
                txt = txt.Remove(txt.Length - 1);
                lblHistoCalc.Text = txt;
            }
        }

        private void CalculResult()
        {
            string strCalc = lblHistoCalc.Text;
            string[] listOp = strCalc.Split(' ');
            double cur = Double.Parse(listOp[0]);

            for (int i = 0; i < listOp.Length; i++)
            {
                switch (listOp[i])
                {
                    case "+":
                        cur = cur + Double.Parse(listOp[i + 1]);
                        break;
                    case "-":
                        cur = cur - Double.Parse(listOp[i + 1]);
                        break;
                    case "*":
                        cur = cur * Double.Parse(listOp[i + 1]);
                        break;
                    case "/":
                        cur = cur / Double.Parse(listOp[i + 1]);
                        break;
                    default:
                        break;
                }
            }

            lblResult.Text = cur.ToString();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            lblHistoCalc.Text = "";
            lblResult.Text = "";
        }

        private void buttonVirg_Click(object sender, EventArgs e)
        {
            lblHistoCalc.Text += ",";
        }
    }
}
