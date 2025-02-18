﻿using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Rules;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class ItemQualityRuleEngine
    {
        private List<RuleBase> _rules = new List<RuleBase>();
        private ItemQualityRuleEngine(List<RuleBase> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
        }

        public class Builder
        {
            private List<RuleBase> _builderRules = new List<RuleBase>();

            public Builder WithAgedBrieRule()
            {
                _builderRules.Add(new AgedBrieRule());
                return this;
            }

            public ItemQualityRuleEngine Build()
            {
                _builderRules.Add(new NormalItemRule()); // every engine has a normal item rule

                return new ItemQualityRuleEngine(_builderRules);
            }
        }
    }
}