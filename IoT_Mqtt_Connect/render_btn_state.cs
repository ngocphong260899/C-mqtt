using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoT_Mqtt_Connect
{
    class render_btn_state
    {
        public void render_state( Button btn, string stt)
        {
            btn.Invoke((MethodInvoker)(() => btn.Text = stt));
        
        }

      
    }
}
