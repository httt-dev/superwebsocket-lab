using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperWebSocket
{
    public partial class Server : Form
    {
        private WebSocketServerX _server;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // private static readonly ILogger log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public Server()
        {
            InitializeComponent();

            string ip = "127.0.0.1"; // IP address to bind the server to
            int port = 8080; // Port to listen for incoming WebSocket connections

            
            log.Debug(new MockLogInfo());

            _server = new WebSocketServerX(ip, port);

            _server.frm = this;

            //Console.WriteLine("Press any key to stop the server...");
            //Console.ReadKey();

            // server.Stop();

        }

        public void SetReceivedText(string text)
        {
            this.txtReceived.Invoke((MethodInvoker)delegate
            {
                this.txtReceived.AppendText(text);
            });
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            _server.Send(txtSend.Text);
        }
    }

    public class MockLogInfo
    {
        public MockLogInfo()
        {
            this.Message = "Message log";
            this.RequestInfo = new RequestInfo();
        }

        public string Message { get; set; }
        public RequestInfo RequestInfo { get; set; }

    }
    public class RequestInfo
    {
        public string RequestId { get; set; }
        public string Url { get; set; }
        public int Port { get; set; }

        public RequestDetailInfo RequestDetailData { get; set; }

        public RequestInfo()
        {
            this.RequestId = "RequestId";
            this.Url = "Url sample";
            this.Port = 100;
            this.RequestDetailData = new RequestDetailInfo();

        }

    }
    public class RequestDetailInfo
    {
        public string RequestId { get; set; }
        public string Url { get; set; }
        public int Port { get; set; }

        public RequestDetailInfo()
        {
            this.RequestId = "RequestId Detail";
            this.Url = "Url sample";
            this.Port = 100;

        }

    }

}
