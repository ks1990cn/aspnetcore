﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Routing.Matchers
{
    internal sealed class MatcherEndpoint : Endpoint
    {
        public MatcherEndpoint(
            Func<RequestDelegate, RequestDelegate> invoker,
            string template,
            object values,
            int order,
            EndpointMetadataCollection metadata,
            string displayName)
            : base(metadata, displayName)
        {
            if (invoker == null)
            {
                throw new ArgumentNullException(nameof(invoker));
            }

            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            Invoker = invoker;
            Template = template;
            Values = new RouteValueDictionary(values);
        }

        public int Order { get; }
        public Func<RequestDelegate, RequestDelegate> Invoker { get; }
        public string Template { get; }

        public IReadOnlyDictionary<string, object> Values { get; }
    }
}
