using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{
    public class MasterMessage
    {
        public string MessageId { get; set; }
        public Message MessageDetail { get; set; }

        // Phương thức chuyển đổi đối tượng thành JSON
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }


    }

    public class Message
    {
        public string Msg1 { get; set; }
        public string Msg2 { get; set; }
        public string Msg3 { get; set; }
    }

    public class CreateSampleMasterMessage
    {
        public List<MasterMessage> MockData()
        {
            // Đối tượng chứa dữ liệu JSON
            var jsonDatas = new List<MasterMessage>();

            jsonDatas.Add(new MasterMessage
            {
                MessageId = "EC0015" , 
                MessageDetail =  new Message { Msg1 = "Message 1", Msg2 = "Message 2", Msg3 = "Message 3" } ,
            });
            jsonDatas.Add(new MasterMessage
            {
                MessageId = "EB0015",
                MessageDetail = new Message { Msg1 = "Message 1", Msg2 = "Message 2", Msg3 = "Message 3" }
            });
            jsonDatas.Add(new MasterMessage
            {
                MessageId = "EA0015",
                MessageDetail = new Message { Msg1 = "Message 1", Msg2 = "Message 2", Msg3 = "Message 3" }
            } );



            return jsonDatas;
        }

        public Dictionary<string, Message> ReadJson()
        {
            // Đọc nội dung từ tệp JSON
            string jsonContent = File.ReadAllText("msg.json");

            // Chuyển đổi nội dung JSON thành Dictionary
            Dictionary<string, Message> jsonData = JsonConvert.DeserializeObject<Dictionary<string, Message>>(jsonContent);

            return jsonData;
        }
    }
}
