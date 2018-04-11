using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSAWinForms.RSA;

namespace RSAWinForms
{
    public partial class Form1 : Form
    {
        private EncryptDecrypt _rsa;

        public Form1()
        {
            InitializeComponent();
            textBoxN.ReadOnly = true;
            textBoxD.ReadOnly = true;
            textBoxDecr.ReadOnly = true;
            textBoxEncr.ReadOnly = true;
            textBoxFN.ReadOnly = true;
            _rsa = new EncryptDecrypt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxQ.Text = AllFunctions.GeneratePrimaryNum().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxP.Text = AllFunctions.GeneratePrimaryNum().ToString();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var fn = Convert.ToInt32(textBoxFN.Text);
            textBoxE.Text = AllFunctions.GenerateE(fn).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var p = Convert.ToInt32(textBoxP.Text);
                var q = Convert.ToInt32(textBoxQ.Text);
                var E = Convert.ToInt32(textBoxE.Text);
                _rsa.InitKeys(p, q, E);
                textBoxD.Text = _rsa.PrivateKey.Key.ToString();
                textBoxN.Text = AllFunctions.ComputeN(p, q).ToString();
                textBoxFN.Text = AllFunctions.ComputeFn(p, q).ToString();
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Cant Parse");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxN.Text = AllFunctions.ComputeN(Convert.ToInt32(textBoxQ.Text), Convert.ToInt32(textBoxP.Text))
                    .ToString();
                textBoxFN.Text = AllFunctions.ComputeFn(Convert.ToInt32(textBoxQ.Text), Convert.ToInt32(textBoxP.Text))
                    .ToString();
            }
            catch
            {
                //ignore
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var msg = Convert.ToInt32(textBoxMessage.Text);
            if (msg > Convert.ToInt32(textBoxN.Text))
            {
                MessageBox.Show("msg must be lower than N");
            }
            else
            {
                textBoxEncr.Text = _rsa.Encrypr(msg).ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxDecr.Text = _rsa.Decrypt(Convert.ToInt32(textBoxEncr.Text)).ToString();
        }

        private void textBoxQ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxN.Text = AllFunctions.ComputeN(Convert.ToInt32(textBoxQ.Text), Convert.ToInt32(textBoxP.Text))
                    .ToString();
                textBoxFN.Text = AllFunctions.ComputeFn(Convert.ToInt32(textBoxQ.Text), Convert.ToInt32(textBoxP.Text))
                    .ToString();
            }
            catch
            {
                //ignore
            }
        }
    }
}
