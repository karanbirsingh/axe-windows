// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Axe.Windows.Core.Bases;
using Axe.Windows.Core.Enums;
using Axe.Windows.Rules.PropertyConditions;
using Axe.Windows.Rules.Resources;
using static Axe.Windows.Rules.PropertyConditions.ControlType;

namespace Axe.Windows.Rules.Library
{
    [RuleInfo(ID = RuleId.ControlShouldSupportInvokePattern)]
    class ControlShouldSupportInvokePattern : Rule
    {
        public ControlShouldSupportInvokePattern()
        {
            this.Info.Description = Descriptions.ControlShouldSupportInvokePattern;
            this.Info.HowToFix = HowToFix.ControlShouldSupportInvokePattern;
            this.Info.Standard = A11yCriteriaId.AvailableActions;
        }

        public override EvaluationCode Evaluate(IA11yElement e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            return Patterns.Invoke.Matches(e) ? EvaluationCode.Pass : EvaluationCode.Error;
        }

        protected override Condition CreateCondition()
        {
            // Button is handled separately.
            return Hyperlink;
        }
    } // class
} // namespace
