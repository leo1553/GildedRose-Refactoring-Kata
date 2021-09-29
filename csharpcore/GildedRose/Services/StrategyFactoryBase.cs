using System;
using System.Collections.Generic;

namespace GildedRoseKata.Services {
    public abstract class StrategyFactoryBase<TIn, TOut> {
        protected TIn defaultValue;
        protected readonly Dictionary<TIn, Func<TOut>> strategies;

        protected StrategyFactoryBase(TIn defaultValue) {
            this.defaultValue = defaultValue;
            this.strategies = new Dictionary<TIn, Func<TOut>>();
        }

        protected void Register(TIn @in, Func<TOut> @out) {
            this.strategies.Add(@in, @out);
        }

        public TOut CreateInstance(TIn @in) {
            if(this.strategies.Count == 0)
                return default;
            if(!this.strategies.ContainsKey(@in))
                return this.strategies[this.defaultValue]();
            return this.strategies[@in]();
        }
    }
}
