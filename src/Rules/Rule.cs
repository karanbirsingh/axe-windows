// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Axe.Windows.Core.Bases;

namespace Axe.Windows.Rules
{
    interface IRule
    {
        RuleInfo Info { get;  }
        Condition Condition { get; }
        EvaluationCode Evaluate(IA11yElement element);
        bool PassesTest(IA11yElement element);
    }

    abstract class Rule : IRule
    {
        public RuleInfo Info { get; private set; }
        public Condition Condition { get; private set; }

        protected Rule()
        {
            // keep these two calls in the following order or the RuleInfo.Condition string won't get populated
#pragma warning disable CA2214
            this.Condition = CreateCondition();
#pragma warning restore CA2214

            InitRuleInfo();
        }

        private void InitRuleInfo()
        {
            var info = GetRuleInfoFromAttributes();
            if (info == null) throw new Exception($"expected {this.GetType().Name} to have the RuleInfo attribute set");

            info.Condition = this.Condition?.ToString();

            this.Info = info;
        }

        private RuleInfo GetRuleInfoFromAttributes()
        {
            var type = this.GetType();

            foreach (var a in type.GetCustomAttributes(true))
            {
                if (a.GetType() == typeof(RuleInfo))
                    return a as RuleInfo;
            }

            return null;
        }

        public virtual EvaluationCode Evaluate(IA11yElement element)
        {
            // This base class function should never be called
            // once all rules have been converted to use RuleInfo.EvaluationCode, this function will be removed
            throw new NotImplementedException();
        }

        public virtual bool PassesTest(IA11yElement element)
        {
            // This base class function should never be called
            // once all rules have been converted to use RuleInfo.EvaluationCode, this function will be designated abstract
            throw new NotImplementedException();
        }

        protected abstract Condition CreateCondition();
    }
} // namespace
