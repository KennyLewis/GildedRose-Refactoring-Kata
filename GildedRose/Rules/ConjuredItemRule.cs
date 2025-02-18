namespace GildedRoseKata.Rules
{
    public class ConjuredItemRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Conjured Mana Cake";
        }
    }
}
