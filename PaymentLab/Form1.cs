using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace PaymentLab
{
    
    public partial class Form1 : Form
    {
        private static string ndcAppWebSocketUrl = "ws://localhost:8080"; // Thay thế bằng URL của NDCApp WebSocket
        private WebSocket websocket = null;
        interface ICommand
        {
            Task<bool> ExecuteAsync(WebSocket webSocket);
        }

        class OpenDeviceCommand : ICommand
        {
            private Form1 form;
            private EventHandler<MessageReceivedEventArgs> messageHandler;

            public OpenDeviceCommand(Form1 form)
            {
                this.form = form;
            }

            public async Task<bool> ExecuteAsync(WebSocket webSocket)
            {
                var tcs = new TaskCompletionSource<bool>();

                // Gỡ bỏ delegate cũ trước khi gán delegate mới
                if (messageHandler != null)
                    webSocket.MessageReceived -= messageHandler;

                // Thiết lập sự kiện cho việc nhận response từ NDCApp
                messageHandler = (sender, e) =>
                {
                    var isValid = HandleResponseFromNDCApp(sender, e, tcs);

                    form.UpdateUI($"Received message from NDCApp: {e.Message} == {isValid.ToString()}");

                    if (isValid)
                        webSocket.MessageReceived -= messageHandler; // Gỡ bỏ sự kiện sau khi nhận được phản hồi
                };

                // Gán sự kiện
                webSocket.MessageReceived += messageHandler;

                webSocket.Send("Open command request");

                // Sử dụng Task.Delay để đợi một khoảng thời gian nhất định trước khi timeout
                var delayTask = Task.Delay(15000); // Timeout sau 10 giây

                // Chờ cho đến khi một trong hai task hoàn thành: nhận response hoặc timeout
                var completedTask = await Task.WhenAny(tcs.Task, delayTask);

                // Nếu task delayTask (timeout task) hoàn thành trước
                if (completedTask == delayTask)
                {
                    // Hủy task tcs.Task (nhận response từ NDCApp)
                    tcs.TrySetCanceled();
                    Console.WriteLine("Timeout: No response received from NDCApp within 10 seconds.");
                }

                //return tcs.Task.Result;
                return await GetResultOrFalse(tcs.Task);
            }

            private async Task<bool> GetResultOrFalse(Task<bool> task)
            {
                try
                {
                    return await task;
                }
                catch (TaskCanceledException)
                {
                    return false;
                }
            }


            private bool HandleResponseFromNDCApp(object sender, MessageReceivedEventArgs e, TaskCompletionSource<bool> tcs)
            {
                // Xử lý response từ NDCApp ở đây
                if (e.Message == "1")
                    tcs.SetResult(true); // Giả sử là true nếu thành công
                Console.WriteLine("Received msg " +  e.Message);
                // Gọi UpdateUI của Form1
                form.UpdateUI($"Received message from NDCApp: {e.Message}");
                return e.Message == "1";
            }

        }

        class ClaimDeviceCommand : ICommand
        {
            private Form1 form;
            private EventHandler<MessageReceivedEventArgs> messageHandler;

            public ClaimDeviceCommand(Form1 form)
            {
                this.form = form;
            }
            public async Task<bool> ExecuteAsync(WebSocket webSocket)
            {
                var tcs = new TaskCompletionSource<bool>();

                // Gỡ bỏ delegate cũ trước khi gán delegate mới
                if (messageHandler != null)
                    webSocket.MessageReceived -= messageHandler;

                // Thiết lập sự kiện cho việc nhận response từ NDCApp
                messageHandler = (sender, e) =>
                {
                    var isValid = HandleResponseFromNDCApp(sender, e, tcs);

                    form.UpdateUI($"Received message from NDCApp: {e.Message} == {isValid.ToString()}");

                    if (isValid)
                        webSocket.MessageReceived -= messageHandler; // Gỡ bỏ sự kiện sau khi nhận được phản hồi

                };

                // Gán sự kiện
                webSocket.MessageReceived += messageHandler;

                webSocket.Send("Claim command request");

                // Sử dụng Task.Delay để đợi một khoảng thời gian nhất định trước khi timeout
                var delayTask = Task.Delay(20000); // Timeout sau 10 giây

                // Chờ cho đến khi một trong hai task hoàn thành: nhận response hoặc timeout
                var completedTask = await Task.WhenAny(tcs.Task, delayTask);

                // Nếu task delayTask (timeout task) hoàn thành trước
                if (completedTask == delayTask)
                {
                    // Hủy task tcs.Task (nhận response từ NDCApp)
                    tcs.TrySetCanceled();
                    Console.WriteLine("Timeout: No response received from NDCApp within 10 seconds.");
                }

                //return tcs.Task.Result;
                return await GetResultOrFalse(tcs.Task);
            }

            private async Task<bool> GetResultOrFalse(Task<bool> task)
            {
                try
                {
                    return await task;
                }
                catch (TaskCanceledException)
                {
                    return false;
                }
            }

            private bool HandleResponseFromNDCApp(object sender, MessageReceivedEventArgs e, TaskCompletionSource<bool> tcs)
            {
                // Xử lý response từ NDCApp ở đây
                if (e.Message == "2")
                    tcs.SetResult(true); // Giả sử là true nếu thành công

                Console.WriteLine("Received msg " + e.Message);

                // Gọi UpdateUI của Form1
                form.UpdateUI($"Received message from NDCApp: {e.Message}");

                return e.Message == "2";
            }
        }

        interface IObserver
        {
            void Update(string message);
        }

        class PaymentAppObserver : IObserver
        {
            public void Update(string message)
            {
                Console.WriteLine($"Received message from NDCApp: {message}");
                // Xử lý kết quả nhận được từ NDCApp ở đây

            }
        }

        class ResponseHandler
        {
            public ICommand Command { get; set; }
            public ResponseHandler NextHandler { get; set; }

            public async Task HandleResponseAsync(WebSocket webSocket , List<IObserver> observers)
            {
                bool success = await Command.ExecuteAsync(webSocket);
                if (success)
                {
                    foreach(var observer in observers)
                    {
                        observer.Update($"Response received from NDCApp: Success");
                    }
                }
                else
                {
                    foreach (var observer in observers)
                    {
                        observer.Update($"Response received from NDCApp: Failure");
                    }
                }

                if (NextHandler != null && success )
                {
                    await NextHandler.HandleResponseAsync(webSocket ,observers);
                }
            }

        }

        private static List<IObserver> observers = null;
        private static PaymentAppObserver paymentAppObserver = null;

        static void  ConnectAndHandleResponse(Form1 frm , WebSocket websocket)
        {
            
            
            paymentAppObserver = new PaymentAppObserver();

            // Thiết lập danh sách các Observer
            observers = new List<IObserver> { paymentAppObserver };

            websocket.Opened += async (sender, e) =>
            {
                Console.WriteLine("Connected to NDCApp WebSocket");
                // Tạo các đối tượng lệnh
                //ICommand openCommand = new OpenDeviceCommand(frm);
                //ICommand claimCommand = new ClaimDeviceCommand(frm);

                //// Thiết lập chuỗi xử lý
                //ResponseHandler responseHandler = new ResponseHandler()
                //{
                //    Command = openCommand,
                //    NextHandler = new ResponseHandler()
                //    {
                //        Command = claimCommand,
                //        NextHandler = null // Có thể thêm các bước xử lý tiếp theo ở đây
                //    }
                //};

                //// Mô phỏng việc nhận response từ NDCApp
                //await responseHandler.HandleResponseAsync(websocket, observers);
            };

            websocket.Closed += (sender, e) =>
            {
                Console.WriteLine("Disconnected from NDCApp WebSocket");
            };

            websocket.Error += (sender, e) =>
            {
                Console.WriteLine($"Error: {e.Exception}");
            };

            // Thử kết nối
            websocket.Open();

            // Đợi một chút để đảm bảo kết nối được thiết lập trước khi kết thúc chương trình
            //await Task.Delay(5000);

            // Đóng kết nối WebSocket
            //websocket.Close();
        }
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            websocket = new WebSocket(ndcAppWebSocketUrl);
            ConnectAndHandleResponse(this, websocket);
        }

        public void UpdateUI(string message)
        {
            this.txtLog.Invoke((MethodInvoker)delegate
            {
                this.txtLog.AppendText(message);
            });
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Task.Run(async () => {
                

                ICommand openCommand = new OpenDeviceCommand(this);
                ICommand claimCommand = new ClaimDeviceCommand(this);

                // Thiết lập chuỗi xử lý
                ResponseHandler responseHandler = new ResponseHandler()
                {
                    Command = openCommand,
                    NextHandler = new ResponseHandler()
                    {
                        Command = claimCommand,
                        NextHandler = null // Có thể thêm các bước xử lý tiếp theo ở đây
                    }
                };

                // Mô phỏng việc nhận response từ NDCApp
                await responseHandler.HandleResponseAsync(websocket, observers);

            });
        }
    }
}
