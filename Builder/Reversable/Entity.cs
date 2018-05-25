using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder.Reversable
{
    public class Entity
    {
        public string A { get; set; }
        public int B { get; private set; }
        public double C { get; set; }
        public float D { get; private set; }
        public DateTime E { get; private set; }
        public List<string> F { get; set; }

        private Entity(Builder builder)
        {
            A = builder.AValue;
            B = builder.BValue;
            C = builder.CValue;
            D = builder.DValue;
            E = builder.EValue;
            F = builder.FValue;
        }
    }

    public class Builder
    {
        public string AValue;
        public int BValue;
        public double CValue;
        public float DValue;
        public DateTime EValue;
        public List<string> FValue;

        public Builder(string a,int b)
        {
            AValue = a;
            BValue = b;
            EValue = DateTime.Now;

        }

        public Builder A(string a)
        {
            AValue = a;
            return this;
        }

        public Builder B(int b)
        {
            BValue = b;
            return this;
        }
        public Builder C(double c)
        {
            CValue = c;
            return this;
        }

        public Builder D(float d)
        {
            DValue = d;
            return this;
        }

        public Builder E(DateTime e)
        {
            EValue = e;
            return this;
        }

        public Builder F(List<string> f)
        {
            FValue = f;
            return this;
        }
    }
}
