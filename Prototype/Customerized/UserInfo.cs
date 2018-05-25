using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Prototype.Customerized
{
    [Serializable]
    public class UserInfo : ISerializable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string[] Education { get; set; }

        public UserInfo()
        {

        }

        /// <summary>
        /// 还原过程
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected UserInfo(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Education = (string[])info.GetValue("Education", typeof(string[]));
        }

        /// <summary>
        ///定制序列化过程，仅序列化如下内容：Name 和 Education 记录的前三项 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Education", Education.Take(3).ToArray());
        }
    }
}
