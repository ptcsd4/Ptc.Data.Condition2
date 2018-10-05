

using Ptc.Data.Condition2.Common;
using Ptc.Data.Condition2.Interface.Abstract;
using Ptc.Data.Condition2.Interface.Attribute;
using Ptc.Data.Condition2.Interface.Class;
using Ptc.Data.Condition2.Interface.Type;
using Ptc.Data.Condition2.Mssql.Attribute;
using Ptc.Data.Condition2.Mssql.Operator;
using Ptc.Data.Condition2.Mssql.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Class
{
    public class MSSQLCondition<TSource> : PagerCondition, ICondition<TSource> where TSource : class, new()
    {

        private Order<TSource> Order = new Order<TSource>();

        private Filter<TSource> Filter = new Filter<TSource>();

        private Include<TSource> Include = new Include<TSource>();

        private Modifier<TSource> Modifier = new Modifier<TSource>();

        private Allow<TSource> Allower = new Allow<TSource>();

        public Object Extension { get; set; }


        public MSSQLCondition() { }
        public MSSQLCondition(int PageIndex = 0, int PageSize = 0)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }
        public MSSQLCondition(params Expression<Func<TSource, bool>>[] FilterExp)
        {
            Array.ForEach(FilterExp, exp => this.Filter.Add(exp, PredicateType.And));
        }
        public MSSQLCondition(object Term, int PageIndex = 0, int PageSize = 0) : this(PageIndex, PageSize)
        {
            this.TermToExpression(Term)?
                .ToList()
                .ForEach(x => this.Filter.Add(x.Item1, x.Item2));
        }

        public MSSQLCondition(IEnumerable<object> Terms, int PageIndex = 0, int PageSize = 0) : this(PageIndex, PageSize)
        {

            Terms?.ToList().ForEach(Term =>
            {

                var exps = this.TermToExpression(Term)?
                               .Select(x => x.Item1)
                               .ToList();

                OrExpression(exps);

            });

        }

        public void And(Expression<Func<TSource, bool>> Expression) => Filter.Add(Expression, PredicateType.And);
        public void Or(Expression<Func<TSource, bool>> Expression) => Filter.Add(Expression, PredicateType.Or);
        public void OrderBy(Expression<Func<TSource, object>> Expression, OrderType OrderType) => Order.Add(Expression, OrderType);
        public void OrderBy(string Prop, OrderType OrderType) => Order.Add(Prop, OrderType);
        public void Modify(Expression<Func<TSource, object>> Expression, EntityState EntityState = EntityState.Modified) => Modifier.Add(Expression, EntityState);
        public void Modify(string Prop, EntityState EntityState) => Modifier.Add(Prop, EntityState);
        public void Allow(Expression<Func<TSource, object>> Expression, Boolean IsModified) => Allower.Add(Expression, IsModified);
        public void Allow(string Prop, Boolean IsModified) => Allower.Add(Prop, IsModified);

        public void IncludeBy(Expression<Func<TSource, object>> Expression) => Include.Add(Expression);
        public void IncludeBy(string Prop) => Include.Add(Prop);
        public void Reset()
        {
            this.ClearIncludes();
            this.ClearOrders();
            this.ClearFilters();
            this.ClearModifies();
        }
        public void ClearIncludes() => this.Include.Clear();
        public void ClearOrders() => this.Order.Clear();
        public void ClearFilters() => this.Filter.Clear();
        public void ClearModifies() => this.Modifier.Clear();

        public (Expression<Func<TSource, object>> Expression, OrderType OrderType) GetPrimary() => this.Order.GetPrimary();
        public List<(Expression<Func<TSource, object>> Expression, OrderType OrderType)> GetOthers() => this.Order.GetOthers();
        public List<(Expression<Func<TSource, bool>> Expression, PredicateType PredicateType)> GetFilters() => this.Filter.GetAll();
        public List<(Expression<Func<TSource, object>> Expression, Boolean IsModified)> GetAllows() => this.Allower.GetAll();
        public List<Expression<Func<TSource, object>>> GetIncludes() => this.Include.GetAll();
        public List<(Expression<Func<TSource, object>> Expression, EntityState EntityState)> GetModifies() => this.Modifier.GetAll();



        public void OrExpression(List<Expression<Func<TSource, Boolean>>> Exps)
        {

            Expression<Func<TSource, Boolean>> exp = null;

            Exps.ForEach(x => exp = (exp == null) ? x : LambdaUtility.ConcatExpression(x, exp));

            if (exp != null)
                this.Filter.Add(exp, PredicateType.Or);

        }

        private IEnumerable<(Expression<Func<TSource, bool>>, PredicateType)> TermToExpression(object Term)
        {

            IEnumerable<IMSSQLFilterAtrribute> avatars = Term.GetFilters();

            return avatars.ToList()
                          .Select(filter => IteratorOfFilter(filter));
        }
        private (Expression<Func<TSource, bool>>, PredicateType) IteratorOfFilter(IMSSQLFilterAtrribute Filter)
        {
            dynamic expression = null;
            dynamic attribite = null;

            if (Filter.GetType() == typeof(MSSQLFilterAttribute<TSource>))
            {
                attribite = ((MSSQLFilterAttribute<TSource>)Filter);

                expression = LambdaUtility.GeneratorExpression(attribite.Expression, attribite.Value, attribite.ExpressionType);

                return (expression, attribite.PredicateType);

            }
            else if (Filter.GetType() == typeof(MSSQLFilterAttribute))
            {
                attribite = ((MSSQLFilterAttribute)Filter);

                expression = LambdaUtility.GeneratorExpression<TSource>(attribite.Target, attribite.Value, attribite.ExpressionType);

                return (expression, attribite.PredicateType);
            }


            return (expression, attribite.PredicateType);

        }
    }
}
