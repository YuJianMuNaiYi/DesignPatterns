using System;

namespace AdapterPattern
{
    public class Adaptee3
    {
        public int Code
        {
            get
            {
                return new Random().Next();
            }
        }
    }
}
