using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Entities;

namespace AppSis
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            Program.cityName = txtCiudad.Text;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "http://api.openweathermap.org/data/2.5/weather?q=" + Program.cityName + "&APPID=3b020d6c397ef16f09854fa2f59554e3";

                Program.cityName = txtCiudad.Text;


                WebRequest solicitud = WebRequest.Create(str);
                solicitud.Method = "POST";
                solicitud.ContentType = "application/x-www-urlencoded";

                WebResponse respuesta = await solicitud.GetResponseAsync();

                string resp = "";

                using (Stream s = respuesta.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        resp = await reader.ReadToEndAsync();
                    }
                }

                respuesta.Close();
                

                Domain.Entities.Clima oW = JsonConvert.DeserializeObject<Domain.Entities.Clima>(resp);
                

                picIcon.ImageLocation = "https://api.openweathermap.org/img/w/" + oW.weather[0].icon + ".png";
                label1.Text = "Temperatura en celsius: " + oW.main.temp.ToString("0.0");
                label2.Text = "Frescura: " + oW.main.feels_like.ToString("0.0");
                label3.Text = "Humedad, %: " + oW.main.humidity.ToString();
                label4.Text = "Presion, mm: " + ((int)oW.main.pressure).ToString();
                label6.Text = "Temperatura maxima: " + ((int)oW.main.temp_max).ToString();
                label7.Text = "Temperatura minima: " + ((int)oW.main.temp_min).ToString();
                lblCond.Text = "Condicion: " + oW.weather[0].main;
                lblDet.Text = "Detalles del clima: " + oW.weather[0].description;
               
                


            }
             catch            
            {
                if (String.IsNullOrEmpty(txtCiudad.Text))
                {

                    MessageBox.Show("Carga fallida...");
                }
              
               
            }
            
        }

       

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede numeros");
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
