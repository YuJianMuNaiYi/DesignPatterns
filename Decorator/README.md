# 装饰模式
- #### Attach additional responsibilities to an object dynamically.Decorators provide a flexible alternative to subclassing for extending functionality
- #### 装饰模式的意图非常明确:动态为对象增加新的职责。
- #### 经典装饰模式的静态结构,如下图
![](Images/Decorator1.jpg)
- #### Notepad应用装饰模式后的静态结构,如下图
![](Images/Decorator2.jpg)
- #### 装饰模式的要义在于通过外部has-a+is-a的方式对目标类型进行扩展,对于待装饰对象本身不应有太多要求 。