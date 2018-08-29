using System;
using System.Linq.Expressions;

namespace RecursosCompartilhados.Aplicacao.AutoMapper
{
    public static class FunctionCompositionExtensions
    {
        public static Expression<Func<X, Y>> Compose<X, Y, Z>(this Expression<Func<Z, Y>> outer, Expression<Func<X, Z>> inner)
        {
            return Expression.Lambda<Func<X, Y>>(ParameterReplacer.Replace(outer.Body, outer.Parameters[0], inner.Body), inner.Parameters[0]);
        }
    }

    class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        private readonly Expression _replacement;

        private ParameterReplacer(ParameterExpression parameter, Expression replacement)
        {
            _parameter = parameter;
            _replacement = replacement;
        }

        public static Expression Replace(Expression expression, ParameterExpression parameter, Expression replacement)
        {
            return new ParameterReplacer(parameter, replacement).Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (parameter == _parameter)
            {
                return _replacement;
            }
            return base.VisitParameter(parameter);
        }
    }
}
