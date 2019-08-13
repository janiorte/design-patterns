using System;

namespace Coding.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var ob = func();
            var ob2 = func();
            return ob == ob2;
        }
    }
}
