﻿using System;

namespace Webservice.UriBuilding
{
    class SqAuthValidationUriBuilder : SqUriBuilder
    {
        public SqAuthValidationUriBuilder(string baseUri, string username, string password) : base(baseUri)
        {
            AppendToPath("api/authentication/validate");
            UserCredentials(username, password);
        }

        public override ISqUriBuilder MetricKeys(string metricKeys)
        {
            return this;
        }

        public override ISqUriBuilder Page(int page)
        {
            return this;
        }

        public override ISqUriBuilder PageSize(int pageSize)
        {
            return this;
        }

        public override ISqUriBuilder ProjectKey(string projektKey)
        {
            return this;
        }
    }
}