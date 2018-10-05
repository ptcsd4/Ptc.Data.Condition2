using Ptc.Data.Condition2.Common;
using Ptc.Data.Condition2.Interface.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Operator
{
    public class Order<T>
    {

        private (Expression<Func<T, object>> Expression, OrderType OrderType) PrimaryOrder
            = default((Expression<Func<T, object>> Expression, OrderType OrderType));

        private List<(Expression<Func<T, object>> Expression, OrderType OrderType)> OthersOrder
           = new List<(Expression<Func<T, object>> Expression, OrderType OrderType)>();

        private Boolean HasPrimary() => PrimaryOrder.Equals(default((Expression<Func<T, object>> Expression, OrderType OrderType)));
        public void Add(string OrderBy, OrderType OrderType)
        {
            if (string.IsNullOrEmpty(OrderBy)) throw new NullReferenceException("[PTC_DATA] ORDER 並未給入欄位");

            var expression = LambdaUtility.GeneratorExpressionFromPath<T>(OrderBy);

            if (HasPrimary())
            {
                PrimaryOrder = (expression, OrderType);
            }
            else
            {
                OthersOrder.Add((expression, OrderType));
            }

        }
        public void Add(Expression<Func<T, object>> Expression, OrderType OrderType)
        {
            if (Expression == null) throw new NullReferenceException("[PTC_DATA] ORDER 並未給入欄位");


            if (HasPrimary())
            {
                PrimaryOrder = (Expression, OrderType);
            }
            else
            {
                OthersOrder.Add((Expression, OrderType));
            }

        }
        public void Clear()
        {
            this.PrimaryOrder = default((Expression<Func<T, object>> Expression, OrderType OrderType));
            this.OthersOrder.Clear();
        }
        public Expression<Func<T, object>> GetPrimaryExpression() => PrimaryOrder.Expression;
        public List<Expression<Func<T, object>>> GetOthersExpression() => OthersOrder.Select(x => x.Expression).ToList();
        public string GetPrimaryKey() => LambdaUtility.GetExpressionBodyName<T, object>(PrimaryOrder.Expression);
        public List<string> GetOthersKey() => OthersOrder.Select(x => LambdaUtility.GetExpressionBodyName(x.Expression)).ToList();
        public (Expression<Func<T, object>> Expression, OrderType OrderType) GetPrimary() => this.PrimaryOrder;
        public List<(Expression<Func<T, object>> Expression, OrderType OrderType)> GetOthers() => this.OthersOrder;

    }
}
