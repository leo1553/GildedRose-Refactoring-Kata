namespace GildedRoseKata.Models.QualityLimiters {
    public class LegendaryQualityLimiterStrategy : IQualityLimiterStrategy {
        /// <summary>
        /// Itens lendarios tem sua qualidade em 80.
        /// </summary>
        /// <returns>80.</returns>
        public int Limit(int quality) {
            return 80;
        }
    }
}
