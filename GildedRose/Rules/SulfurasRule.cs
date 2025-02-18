using System;

namespace GildedRoseKata.Rules
{
    public class SulfurasRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            // Do nothing, this item does not change in quality
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            // Do nothing, this item does not lower sell in
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            // Do nothing, this item does not change in quality
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
