using ErrorManager.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{
    // Định nghĩa lớp chứa danh sách mã lỗi
    public class ErrorCodeListInfo
    {
        [JsonProperty("error_code_list")]
        public List<ErrorCodeInfo> ErrorCodeList { get; set; }

        
    }

    // Định nghĩa lớp chứa thông tin của một mã lỗi
    public class ErrorCodeInfo
    {
        [JsonProperty("result_code")]
        public string ResultCode { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("center_error_code")]
        public string CenterErrorCode { get; set; }

        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("msg_id")]
        public string MessageID { get; set; }

        
    }

  

    public class CreateSampleErrorCodeList
    {
        public ErrorCodeListInfo ReadJson()
        {
            // Đọc nội dung từ tệp JSON
            string jsonContent = File.ReadAllText("error_code_list.json");

            // Chuyển đổi nội dung JSON thành đối tượng C#
            ErrorCodeListInfo errorCodeList = JsonConvert.DeserializeObject<ErrorCodeListInfo>(jsonContent);

            return errorCodeList;
        }

    }
}
