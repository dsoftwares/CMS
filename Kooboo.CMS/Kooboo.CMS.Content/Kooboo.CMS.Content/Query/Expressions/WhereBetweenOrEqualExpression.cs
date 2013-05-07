﻿#region License
// 
// Copyright (c) 2013, Kooboo team
// 
// Licensed under the BSD License
// See the file LICENSE.txt for details.
// 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.CMS.Content.Query.Expressions
{
    public class WhereBetweenOrEqualExpression : WhereBetweenExpression
    {
        public WhereBetweenOrEqualExpression(IExpression expression, string fieldName, object start, object end)
            : base(expression, fieldName, start, end)
        { }

    }
}
