namespace GildedRoseKata.Models.QualityLimiters {
    public class DefaultQualityLimiterStrategy : IQualityLimiterStrategy {
        /// <summary>
        /// Limita o valor de <paramref name="quality"/> entre 0 e 50.
        /// </summary>
        /// <returns>
        /// 0 se <paramref name="quality"/> for menor que zero, 50 se <paramref name="quality"/> for maior que 50
        /// ou <paramref name="quality"/> se nenhum dos casos.
        /// </returns>
        public int Limit(int quality) {
            if(quality < 0)
                return 0;
            else if(quality > 50)
                return 50;
            else
                return quality;
        }
    }
}
