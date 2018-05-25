using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Prototype.Customerized
{
    /// <summary>
    /// 从测试实例不难看出,实现ISerializable的过程其实非常"八股",----就是按部就班 
    /// 地严格按照"将欲取之,必先与之"的原则完成,序列化时调用GetObjectData(),把
    /// 我们认为需要序列化的内容打包拿出来,内容的组织采用字典方式(Key/Value),然后在
    /// 反序列化过程中把我们之前打包好的内容发给新的实例,让它自己按照需要取出每一项,
    /// 并对自己的成员变量赋值.
    /// </summary>
    [Serializable]
    public class UserInfo2 : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Education { get; set; }

        public UserInfo2()
        {

        }
        /// <summary>
        /// 还原过程
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public UserInfo2(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Education = (string[])info.GetValue("Education", typeof(string[]));
        }

        /// <summary>
        ///细颗粒度定制序列化内容的过程 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            //只序列化前三项
            info.AddValue("Education",Education.Take(3).ToArray());
        }
    }
}
