using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Common
{
    public static class LambdaUtility
    {
        public static Expression<Func<T, object>> GeneratorExpressionFromPath<T>(string Path)
        {
            var type = typeof(T);

            var expression = Expression.Parameter(type, "x");

            string[] nestedProperties = Path.Split('.');

            Expression member = expression;

            foreach (string prop in nestedProperties)
                member = Expression.PropertyOrField(member, prop);

            var metaType = ObjectUtility.GetNestedType(type, Path);

            if (metaType == null) throw new IndexOutOfRangeException("[PTC_DATA] 找不到 META_TYPE");

            var exp = Expression.Lambda(member, expression);

            var convert = Expression.Convert(exp.Body, typeof(object));

            var result = Expression.Lambda(convert, expression);

            return (Expression<Func<T, object>>)result;
        }
        public static Expression<Func<T, bool>> GeneratorExpression<T>(Expression<Func<T, object>> Func, object Value, ExpressionType ExpressionType)
        {
            
            var parameterExpression = Expression.Parameter(typeof(T), "x");

            var body = GetExpressionBodyName<T, object>(Func);

            string[] nestedProperties = body.Split('.');

            Expression member = parameterExpression;

            foreach (string prop in nestedProperties)
                member = Expression.PropertyOrField(member, prop);

            ConstantExpression propertyVal = ParseType(Value, member.Type);

            Expression expression = null;

            //如果NodeType為parameter,就走contains語法
            if (ExpressionType == ExpressionType.Parameter)
            {
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                expression = Expression.Call(member, method, propertyVal);
            }
            else
            {
                expression = Expression.MakeBinary(
                ExpressionType,
                member,
                propertyVal);
            }
            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

        }
        public static Expression<Func<T, bool>> GeneratorExpression<T>(string Prop, object Value, ExpressionType ExpressionType)
        {

            var parameterExpression = Expression.Parameter(typeof(T), "x");

            string[] nestedProperties = Prop.Split('.');

            Expression member = parameterExpression;

            foreach (string prop in nestedProperties)
                member = Expression.PropertyOrField(member, prop);

            ConstantExpression propertyVal = ParseType(Value, member.Type);

            Expression expression = null;

            //如果NodeType為parameter,就走contains語法
            if (ExpressionType == ExpressionType.Parameter)
            {
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                expression = Expression.Call(member, method, propertyVal);
            }
            else
            {
                expression = Expression.MakeBinary(
                ExpressionType,
                member,
                propertyVal);
            }
            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

        }
        public static string GetExpressionBodyName<TSource, TResult>(Expression<Func<TSource, TResult>> Expression)
        {
            StringBuilder pathBuilder = new StringBuilder();

            MemberExpression pro = Expression.Body as MemberExpression ??
                                  ((UnaryExpression)Expression.Body).Operand as MemberExpression;

            while (pro != null)
            {

                pathBuilder.Insert(0, "." + pro.Member.Name);
                pro = pro.Expression as MemberExpression;

                return (pathBuilder.ToString(1, pathBuilder.Length - 1));
            }

            throw new NullReferenceException("[PTC_DATA] 找不到Expression body");

        }
        public static Expression<Func<T, Boolean>> ConcatExpression<T>(Expression<Func<T, Boolean>> Expression1,
                                                                       Expression<Func<T, Boolean>> Expression2) where T : class
        {

            var invokedSecond = Expression.Invoke(Expression2, Expression1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, Boolean>>(
             Expression.And(Expression1.Body, invokedSecond), Expression1.Parameters);
        }

        public static Type GetExpressionBodyType<T>(Expression<Func<T, object>> Expression)
        {
            if ((Expression.Body.NodeType == ExpressionType.Convert) ||
                (Expression.Body.NodeType == ExpressionType.ConvertChecked))
            {
                var unary = Expression.Body as UnaryExpression;
                if (unary != null)
                    return unary.Operand.Type;
            }
            return Expression.Body.Type;
        }
        public static Expression<Func<T1, T2>> FuncToExpression<T1, T2>(Func<T1, T2> Func)
        {
            return x => Func(x);
        }
        private static ConstantExpression ParseType(object Value, Type TargetType)
        {
            var value = ValueFilter(Value, TargetType);

            return Expression.Constant(value, TargetType);
        }
        private static dynamic ValueFilter(object Value, Type TargetType)
        {
            if (Value is Enum) return (int)Value;

            return Value;
        }

    }
}
