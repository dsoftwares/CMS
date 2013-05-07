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
    public class WhereContainsExpression : BinaryExpression
    {
        public WhereContainsExpression(IExpression expression, string fieldName, object value)
            : base(expression, fieldName, value)
        {

        }

    }
}
