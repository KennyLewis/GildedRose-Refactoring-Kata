namespace GildedRoseKata.Rules
{
    public class NormalItemRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
        }

        public override bool IsMatch(ItemProxy item)
        {
            return true; // This is the default and always true
        }
    }
}
