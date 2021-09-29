using GildedRoseKata.Utils;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.Services {
    public abstract class StrategyFactoryBase<TIn, TOut> where TOut : class {
        protected TIn defaultValue;
        protected readonly Dictionary<TIn, Func<TOut>> strategies;

        protected StrategyFactoryBase(TIn defaultValue) {
            this.defaultValue = defaultValue;
            this.strategies = new Dictionary<TIn, Func<TOut>>();
            this.SearchForTypes();
        }

        /// <summary>
        /// Procura por classes contendo um ou mais atributos <see cref="RegisterStrategyAttribute"/> que:<br/>
        /// 1. Não sejam abstratas;<br/>
        /// 2. Implementem <see cref="TOut"/>;<br/>
        /// 3. Possuam um construtor sem parâmetros.<br/>
        /// e registram a esta fabrica.
        /// <para>ATENÇÃO: As instâncias registradas são reaproveitadas (equivalente ao ciclo de vida Singleton).</para>
        /// </summary>
        private void SearchForTypes() {
            TypeSearcher typeSearcher = new TypeSearcher(
                type => type.IsClass && !type.IsAbstract && typeof(TOut).IsAssignableFrom(type)
                     && type.GetCustomAttributes(typeof(RegisterStrategyAttribute), false).Length > 0
                     && type.GetConstructor(new Type[] { }) != null);
            // Adiciona o assembly atual ao typeSearcher
            // TODO: permitir registrar assemblies externos
            typeSearcher.SearchAssembly(typeof(GildedRose).Assembly);
            foreach(Type type in typeSearcher.FoundTypes) {
                RegisterStrategyAttribute[] attributes = type.GetCustomAttributes(typeof(RegisterStrategyAttribute), false) as RegisterStrategyAttribute[];
                foreach(RegisterStrategyAttribute attribute in attributes) {
                    if(attribute.For is null)
                        throw new Exception($"{nameof(RegisterStrategyAttribute.For)} at {type.FullName} is not set.");
                    if(attribute.For is TIn @in) {
                        TOut @out = Activator.CreateInstance(type) as TOut;
                        this.Register(@in, () => @out);
                    }
                    else
                        throw new Exception($"{nameof(RegisterStrategyAttribute.For)} at {type.FullName} is not {typeof(TIn).FullName}.");
                }
            }
        }

        public void Register(TIn @in, Func<TOut> @out) {
            if(@in is null)
                throw new ArgumentNullException(nameof(@in));
            if(@out is null)
                throw new ArgumentNullException(nameof(@out));
            if(this.strategies.ContainsKey(@in))
                throw new Exception($"Key {@in} already registered in {this.GetType().FullName}.");
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
