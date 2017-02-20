using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tempConverterHW3
{
    
    public partial class TempConverter : Form
    {
        object[] tempScales = new object[]
         {
                tempConverterHW3.TemperatureBaseKelvin.Farenheit,
                 tempConverterHW3.TemperatureBaseKelvin.Celsius,
                  tempConverterHW3.TemperatureBaseKelvin.Kelvin

         };
        decimal degreesInputVal;
        bool degInReady = false;
        bool scaleInReady = false;
        bool scaleOutReady = false;
        UnitScale<TemperatureBaseKelvin> scaleInVal;
        UnitScale<TemperatureBaseKelvin> scaleOutVal;
        public TempConverter()
        {
            InitializeComponent();
        }

        private void Recalculate(object sender, EventArgs e)
        {
            if(degInReady && scaleInReady && scaleOutReady)
            {
                degreesOutput.Text=
                scaleOutVal.FromBase(scaleInVal.ToBase(degreesInputVal)).ToString();

            }
            else
            {
                message.Text = "complete all the fields";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.scaleOut.Items.AddRange(tempScales);
            this.scaleIn.Items.AddRange(tempScales);
        }

        private void degreesOutput_Click(object sender, EventArgs e)
        {
        }

        private void degreesInput_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(degreesInput.Text, out degreesInputVal))
            {
                message.Text = "must put in a valid decimal number";
            }
            else
            {
                degInReady = true;
                Recalculate(sender, e);
            }
        }

        private void scaleIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            scaleInVal = (scaleIn.SelectedItem as UnitScale<TemperatureBaseKelvin>);
            if (scaleInVal != null)
            {
                scaleInReady = true;
                Recalculate(sender, e);
            }
            else
            {
                message.Text = "something went wrong with your unitscale";
            }
        }

        private void scaleOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            scaleOutVal = (scaleOut.SelectedItem as UnitScale<TemperatureBaseKelvin>);
            if (scaleOutVal != null)
            {
                scaleOutReady = true;
                Recalculate(sender, e);
            }
            else
            {
                message.Text = "something went wrong with your unitscale";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
