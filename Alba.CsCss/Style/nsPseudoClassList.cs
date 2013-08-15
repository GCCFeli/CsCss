﻿using System.Collections.Generic;
using Alba.CsCss.Internal.Extensions;

namespace Alba.CsCss.Style
{
    public class nsPseudoClassList
    {
        internal CssPseudoClass mType;
        internal nsPseudoClassList mNext;
        private object mData;

        internal nsPseudoClassList (CssPseudoClass aType, string aString)
        {
            mType = aType;
            mString = aString;
        }

        internal nsPseudoClassList (CssPseudoClass aType, int[] aNumbers)
        {
            mType = aType;
            mNumbers = aNumbers;
        }

        internal nsPseudoClassList (CssPseudoClass aType, nsCSSSelectorList aSelectors)
        {
            mType = aType;
            mSelectors = aSelectors;
        }

        internal nsPseudoClassList (CssPseudoClass aType)
        {
            mType = aType;
            mData = null;
        }

        internal string mString
        {
            get { return (string)mData; }
            set { mData = value; }
        }

        internal int[] mNumbers
        {
            get { return (int[])mData; }
            set { mData = value; }
        }

        internal nsCSSSelectorList mSelectors
        {
            get { return (nsCSSSelectorList)mData; }
            set { mData = value; }
        }

        internal static void AddItem (ref nsPseudoClassList @this, nsPseudoClassList item)
        {
            while (@this != null)
                @this = @this.mNext;
            @this = item;
        }

        // Public interface

        public string String
        {
            get { return mString; }
        }

        public IEnumerable<int> Numbers
        {
            get { return mNumbers; }
        }

        public IEnumerable<nsCSSSelectorList> Selectors
        {
            get { return mSelectors.Items; }
        }

        internal IEnumerable<nsPseudoClassList> Items
        {
            get { return this.TraverseList(i => i.mNext); }
        }
    }
}