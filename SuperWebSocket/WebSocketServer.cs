using SuperSocket.SocketBase.Config;
using SuperWebSocket;
using System;
using System.Windows.Forms;

class WebSocketServerX
{
    private WebSocketServer _server;
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public Server frm {  get; set; }
    public WebSocketServerX(string ip, int port)
    {
        _server = new WebSocketServer();
        _server.Setup(new RootConfig(), new ServerConfig
        {
            Port = port,
            Ip = ip
        });

        _server.NewSessionConnected += OnNewSessionConnected;
        _server.NewMessageReceived += OnNewMessageReceived;

        if (!_server.Start())
        {
            Console.WriteLine("Failed to start WebSocket server!");
            return;
        }

        Console.WriteLine($"WebSocket server started at ws://{ip}:{port}");
        log.Info($"WebSocket server started at ws://{ip}:{port}");
    }

    private void OnNewSessionConnected(WebSocketSession session)
    {
        Console.WriteLine($"New session connected: {session.SessionID}");
        frm.SetReceivedText($"New session connected: {session.SessionID}");
    }

    private void OnNewMessageReceived(WebSocketSession session, string message)
    {
        Console.WriteLine($"Received message from {session.SessionID}: {message}");
        frm.SetReceivedText(Environment.NewLine + message);

        // Do something with the received message, like broadcasting to all connected clients
        //foreach (var s in _server.GetAllSessions())
        //{
        //    s.Send(message);
        //}
    }

    public void Send(string message)
    {

        foreach (var s in _server.GetAllSessions())
        {
            s.Send(message);
        }
    }
    public void Stop()
    {
        _server.Stop();
        Console.WriteLine("WebSocket server stopped.");
    }
}
