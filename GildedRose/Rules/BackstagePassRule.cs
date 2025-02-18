namespace GildedRoseKata.Rules
{
    public class BackstagePassRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality();
            }
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.ResetQuality();
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}
