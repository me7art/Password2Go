using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class NamedPipeHelper
    {
        const int TIMEOUT = 30;

        private static object _lock = new object();
        private bool _isPipeCreated = false;

        string _pipeName;
        string _content;

        public NamedPipeHelper(string pipeName, string content)
        {
            _pipeName = pipeName;
            _content = content;
        }

        public void StartInBackground()
        {
            Thread pipeThread = new Thread(() => CreatePipe());
            pipeThread.IsBackground = true;
            pipeThread.Start();
        }

        public bool WaitForPipeCreation()
        {
            for (int i = 0; i < 100; i++)  // 10 сек с шагом 100 мс
            {
                lock (_lock)
                {
                    if (_isPipeCreated)
                    {
                        return true;
                    }
                }
                Thread.Sleep(100);
            }

            return false;
        }

        private void CreatePipe()
        {
            var server = new NamedPipeServerStream(_pipeName);
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));

            try
            {
                lock (_lock)
                {
                    _isPipeCreated = true;
                }

                if (server.WaitForConnectionAsync(cts.Token).Wait(TimeSpan.FromSeconds(TIMEOUT)))
                {
                    using (StreamWriter writer = new StreamWriter(server))
                    {
                        writer.WriteLine(_content);
                        writer.Flush();
                    }
                }
            }
            finally
            {
                server.Dispose();
            }
        }
    }
}
