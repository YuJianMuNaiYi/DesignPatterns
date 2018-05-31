#### 通过.NET Remoting 和MarshalByRefObject的组合,借助代理类可以拦截调用过程,并"横切"锲入额外的控制逻辑。但遗憾的是这种方式把C#类型唯一一次继承机会让给MarshalBuRefObject,侵入性过高。尽管有很多不足,不过在项目中采用该方法实现一个透明的装饰属性框架,成本相对较低。另外,此示例中并没有提供对params参数,属性方法和带参数构造函数的支持,更为复杂的工程化实现可以参考微软的Policy Injection 和Unity 代码块。
#### 动态包装类型的执行过程
![](Images/DynamicDecoratorExecute.jpg)