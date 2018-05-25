using System.Web;

namespace Sinleton.UnitTest.Web
{
    public class Singleton
    {
        /// <summary>
        /// 足够复杂的一个key值，用于和HttpContext中的其他内容相区别
        /// </summary>
        private const string key = "MuNaiYiPattern.Sinleton.UnitTest.Web";

        Singleton() { }

        public static Singleton Instance
        {
            get
            {
                // 基于HttpContext的Lazy实例化过程
                var instance = (Singleton)HttpContext.Current.Items[key];
                if (instance != null) 
                    return instance;
                
                instance = new Singleton();
                HttpContext.Current.Items[key] = instance;
                return instance;
            }
        }
    }
}
