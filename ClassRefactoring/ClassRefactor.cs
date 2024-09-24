using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public SwallowAbstract GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.African:
                    return new AfricaSwallow(false);
                case SwallowType.European:
                    return new EuropeanSwallow(false);
            }
            return new AfricaSwallow(false);
        }
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            if (Type == SwallowType.African && Load == SwallowLoad.None)
            {
                return 22;
            }
            if (Type == SwallowType.African && Load == SwallowLoad.Coconut)
            {
                return 18;
            }
            if (Type == SwallowType.European && Load == SwallowLoad.None)
            {
                return 20;
            }
            if (Type == SwallowType.European && Load == SwallowLoad.Coconut)
            {
                return 16;
            }
            throw new InvalidOperationException();
        }
    }

    public abstract class SwallowAbstract
    {
        public virtual bool HasLoad { get; set; }

        public virtual void ApplyLoad(bool hasLoad)
        {
            HasLoad = hasLoad;
        }

        public virtual double GetAirspeedVelocity() { return 0.0; }
    }

    public class AfricaSwallow : SwallowAbstract
    {
        public AfricaSwallow(bool hasLoad)
        { 
            base.HasLoad = hasLoad;
        }

        public override double GetAirspeedVelocity()
        {
            if (!HasLoad)
                return 22;
            else return 18;
        }

    }

    public class EuropeanSwallow : SwallowAbstract
    {
        public EuropeanSwallow(bool hasLoad)
        {
            base.HasLoad = hasLoad;
        }

        public override double GetAirspeedVelocity()
        {
            if (!HasLoad)
                return 20;
            else return 16;
        }

    }
}