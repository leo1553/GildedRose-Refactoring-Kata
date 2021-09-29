using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GildedRoseKata.Utils {
    public class TypeSearcher {
        private readonly Func<Type, bool> selector;
        private readonly List<Assembly> loadedAssemblies = new List<Assembly>();

        private readonly List<Type> foundTypes = new List<Type>();
        public IReadOnlyList<Type> FoundTypes => this.foundTypes.AsReadOnly();

        public TypeSearcher(Func<Type, bool> selector) {
            this.selector = selector;
        }

        public void SearchAssembly(Assembly assembly) {
            if(this.loadedAssemblies.Contains(assembly))
                return;
            this.loadedAssemblies.Add(assembly);
            this.foundTypes.AddRange(
                assembly.GetTypes()
                        .Where(this.selector));
        }
    }
}
