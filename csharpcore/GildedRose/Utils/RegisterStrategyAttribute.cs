using System;

namespace GildedRoseKata.Utils {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterStrategyAttribute : Attribute {
        public object For { get; set; }
    }
}
