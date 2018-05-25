using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder.UnitTest
{
    [TestClass]
    public class Computer
    {
        #region 属性
        public string Bus { get; private set; }

        /// <summary>
        /// 监控
        /// </summary>
        public string Monitor { get; private set; }

        /// <summary>
        /// 硬盘
        /// </summary>
        public string Disk { get; private set; }

        /// <summary>
        /// 内存
        /// </summary>
        public string Memory { get; private set; }

        /// <summary>
        /// 键盘
        /// </summary>
        public string KeyBoard { get; private set; }
        /// <summary>
        /// 鼠标
        /// </summary>
        public string Mouse { get; private set; }
        #endregion

        /// <summary>
        ///  缓存Computer类型的所有Property
        /// </summary>
        private static PropertyInfo[] propertyInfos = typeof(Computer).GetProperties();

        /// <summary>
        /// 获得Computer类型指定名称Property的Setter方法委托
        /// </summary>
        /// <param name="computer">Computer类型实例</param>
        /// <param name="name">Property名称</param>
        /// <returns>指定名称Property的Setter方法委托</returns>
        static Action<string> GetSetter(Computer computer, string name)
        {
            var propertyInfo = propertyInfos.FirstOrDefault(x => string.Equals(x.Name, name));
            return b =>
            {
                if (propertyInfo != null) propertyInfo.SetValue(computer, b, null);
            };
        }
        public static Action<string, Action<string>> BuildPartHandler = (x, y) =>
        {
            Trace.WriteLine("add " + x);
            y(x);
        };

        [BuildStep(1)]
        public void LayoutBus()
        {
            BuildPartHandler("Bus", GetSetter(this, "Bus"));
        }

        [BuildStep(2)]
        public void AddDiskAndMemory()
        {
            BuildPartHandler("Disk", GetSetter(this, "Disk"));
            BuildPartHandler("8G Memory", GetSetter(this, "Memory"));
        }

        [BuildStep(3)]
        public void AddUserInputDevice()
        {
            BuildPartHandler("USB Mouse", GetSetter(this, "Mouse"));
            BuildPartHandler("keyboard",GetSetter(this,"KeyBoard"));
        }

        [BuildStep(4)]
        public void ConnectMonitor()
        {
            BuildPartHandler("monitor",GetSetter(this,"Monitor"));
        }

        [TestMethod]
        public void BuildComputerByAttributeDirection()
        {
            Trace.WriteLine("\nassembly Computer");
            var computer = new Computer();
            Assert.IsNull(computer.KeyBoard);
            Assert.IsNull(computer.Memory);

            computer = new Builder<Computer>().BuildUp();
            Assert.IsNotNull(computer.Bus);
            Assert.IsNotNull(computer.Memory);
            Assert.IsNotNull(computer.Monitor);
            Assert.IsNotNull(computer.KeyBoard);
            Assert.IsNotNull(computer.Mouse);
            Assert.IsNotNull(computer.Disk);
        }
    }
}
