using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    public class DateChangeTask
    {
        private CancellationTokenSource cancellationTokenSource;

        public void Start()
        {
            cancellationTokenSource = new CancellationTokenSource();

            // Chạy một task riêng để theo dõi việc chuyển ngày mới
            Task.Run(() => WatchForDateChange(cancellationTokenSource.Token), cancellationTokenSource.Token);
        }

        public void Stop()
        {
            // Hủy task nếu cần thiết
            cancellationTokenSource?.Cancel();
        }

        private async Task WatchForDateChange(CancellationToken cancellationToken)
        {
            string currentDate = DateTime.Now.ToString("yyyyMMdd");

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(1), cancellationToken); // Kiểm tra mỗi giờ

                string newDate = DateTime.Now.ToString("yyyyMMdd");

                if (newDate != currentDate)
                {
                    // Nếu đã sang ngày mới, cập nhật biến môi trường và gán lại giá trị currentDate
                    Environment.SetEnvironmentVariable("LOG_DATE", newDate);
                    currentDate = newDate;
                }
            }
        }
    }
}
