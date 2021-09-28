namespace GildedRoseKata.Models {
    /// <summary>
    /// Esta inteface seria responsavel pelas propriedades de <see cref="GildedRoseKata.Item"/> caso o Goblin
    /// não tivesse problemas com a cultura de código compartilhado.
    /// </summary>
    public interface IItemData  {
        /* IItem */ Item Item { get; set; }
        ILateQualityUpdateStrategy LateQualityUpdateStrategy { get; set; }
        IQualityLimiterStrategy QualityLimiterStrategy { get; set; }
        IQualityUpdateStrategy QualityUpdateStrategy { get; set; }
        ISellInUpdateStrategy SellInUpdateStrategy { get; set; }
    }
}
