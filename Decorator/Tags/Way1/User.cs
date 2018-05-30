using System;

namespace MuNaiYiPattern.Decorator.Tags.Way1
{
    /// <inheritdoc />
    /// <summary>
    /// 业务对象
    /// </summary>
    public class User:MarshalByRefObject
    {
        private string name;
        private string title;

        [ArgumentTypeRestriction(typeof(string))] //提供拦截入口
        [ArgumentNotEmpty] //提供拦截入口
        public void SetUserInfo(object name, object title)
        {
            this.name = (string)name;
            this.title = (string)title;
        }
    }
}
