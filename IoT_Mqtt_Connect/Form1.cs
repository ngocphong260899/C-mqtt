using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace IoT_Mqtt_Connect
{
    public partial class Form1 : Form
    {
         MqttClient client;
         string data_recv;
        render_btn_state render_state = new render_btn_state();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new MqttClient("mqtt.ngoinhaiot.com", 1111, false, null, null, MqttSslProtocols.None);
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId, "ngocphong260899", "ngocphong260899");

            client.Subscribe(new string[] { "ngocphong260899" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            /*
            string relay1_on = "{\"status\":\"onnk\"}";
            client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(relay1_on), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            */
        }


        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            var msgs = Encoding.UTF8.GetString(e.Message);
            data_recv = msgs.ToString();
            Console.WriteLine("this is data recv : " + data_recv);
            //string relay1_on = "{\"status\":1}";
            try
            {
                parseJson str_json = JsonConvert.DeserializeObject<parseJson>(data_recv);
                if (str_json == null)
                {
                    Console.WriteLine("-***- Json not DeserializeObject -***-");
                    return;
                }

                string stt = str_json.status;
                string pos = str_json.pos;
                int position = Int32.Parse(pos);

                switch(position)
                {
                    case 1:
                        {
                            render_state.render_state(button2, stt);
                        }
                        break;

                    case 2:
                        {
                            render_state.render_state(button3, stt);
                        }
                        break;
                    case 3:
                        {
                            render_state.render_state(button4, stt);
                        }
                        break;
                }

             






            }
            catch
            {
                Console.WriteLine("Phong hg 56: Json not convert");
            }
            


        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            MqttClient client = new MqttClient("mqtt.ngoinhaiot.com", 1111, false, null, null, MqttSslProtocols.None);

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId,"ngocphong260899","ngocphong260899");
            */
            string strValue = Convert.ToString(textBox1.Text);
            client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.Text == "on")
                {
                    string value = "{\"status\":0}";
                    client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                else if (button2.Text == "off")
                {
                    string value = "{\"status\":1}";
                    client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
            }
            catch
            {
                MessageBox.Show("Phonghg56: Error data send");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (button3.Text == "on")
                {
                    string value = "{\"status\":0}";
                    client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                else if (button3.Text == "off")
                {
                    string value = "{\"status\":1}";
                    client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
            }
            catch
            {
                MessageBox.Show("Phonghg56: Error data send");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (button4.Text == "on")
                {
                    string value = "{\"status\":0}";
                    client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                else if (button4.Text == "off")
                {
                    string value = "{\"status\":1}";
                    client.Publish("ngocphong260899", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
            }
            catch
            {
                MessageBox.Show("Phonghg56: Error data send");
            }
        }
    }
}
