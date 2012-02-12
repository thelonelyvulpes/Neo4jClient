﻿using System.Collections.Generic;

namespace Neo4jClient.Cypher
{
    public class CypherFluentQuery<TResult> :
        CypherFluentQuery,
        ICypherFluentQueryReturned<TResult>
        where TResult : new()
    {
        public CypherFluentQuery(IGraphClient client, CypherQueryBuilder builder)
            : base(client, builder)
        {}

        public ICypherFluentQueryReturned<TResult> Limit(int? limit)
        {
            var newBuilder = Builder.SetLimit(limit);
            return new CypherFluentQuery<TResult>(Client, newBuilder);
        }

        public IEnumerable<TResult> Results
        {
            get
            {
                return Client.ExecuteGetCypherResults<TResult>(Query);
            }
        }
    }
}