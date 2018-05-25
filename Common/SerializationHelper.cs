using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Common
{
    public enum FormatterType
    {
        /// <summary>
        /// SOAP消息格式编码
        /// </summary>
        Soap,

        /// <summary>
        /// 二进制消息格式编码
        /// </summary>
        Binary
    }
    public static class SerializationHelper
    {
        private const FormatterType DefaultFormatterType = FormatterType.Binary;

        /// <summary>
        /// 按照串行化的编码要求，生成对应的编码器。
        /// </summary>
        /// <param name="formatterType"></param>
        /// <returns></returns>
        static IRemotingFormatter GetFormatter(FormatterType formatterType)
        {
            switch (formatterType)
            {
                case FormatterType.Binary:
                    return new BinaryFormatter();
                case FormatterType.Soap:
                    return new SoapFormatter();
            }
            throw  new NotSupportedException();
        }
        
        /// <summary>
        /// 把对象序列化转换为字符串
        /// </summary>
        /// <param name="graph">可串行化对象实例</param>
        /// <param name="formatterType">消息格式编码</param>
        /// <returns>串行转化结果</returns>
        /// <remarks>
        /// 调用BinaryFormatter或SoapFormatter的Serialize方法实现主要转换过程。
        /// </remarks>
        public static string SerializeObjectToString(object graph,FormatterType formatterType=DefaultFormatterType)
        {
            using (var memoryStream=new MemoryStream())
            {
                var formatter = GetFormatter(formatterType);
                formatter.Serialize(memoryStream,graph);
                var arrayGraph = memoryStream.ToArray();
                return Convert.ToBase64String(arrayGraph);
            }
        }

        /// <summary>
        /// 把已序列化的字符串类型的对象反序列化为指定的类型
        /// </summary>
        /// <typeparam name="T">对象转换后的类型</typeparam>
        /// <param name="graph">已序列化为字符串类型的对象</param>
        /// <param name="formatterType">消息格式编码类型</param>
        /// <returns>串行化转化结果</returns>
        /// <remarks>
        /// 调用BinaryFormatter或SoapFormatter的Deserialize方法实现主要转换过程。
        /// </remarks>
        public static T DeserializeStringToObject<T>(string graph, FormatterType formatterType = DefaultFormatterType)
        {
            var arrayGraph = Convert.FromBase64String(graph);
            using (var memoryStream = new MemoryStream(arrayGraph))
            {
                var formatter = GetFormatter(formatterType);
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}
