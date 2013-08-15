﻿using System.Diagnostics;
using System.Text;

namespace Alba.CsCss.Style
{
    [DebuggerDisplay (@"@supports {mCondition} \{ ({mRules.Count}) \}")]
    public class CSSSupportsRule : GroupRule
    {
        private readonly bool mUseGroup;
        private readonly string mCondition;

        internal CSSSupportsRule (ref bool aConditionMet, StringBuilder aCondition)
        {
            mUseGroup = aConditionMet;
            mCondition = aCondition.ToString();
        }

        internal static bool PrefEnabled ()
        {
            return true;
        }

        internal override RuleKind GetKind ()
        {
            return RuleKind.SUPPORTS;
        }

        // Public interface

        public bool IsSupported
        {
            get { return mUseGroup; }
        }

        public string Condition
        {
            get { return mCondition; }
        }
    }
}