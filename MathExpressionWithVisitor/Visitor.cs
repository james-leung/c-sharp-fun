namespace MathExpressionWithVisitor
{
    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value ex);
        public abstract void Visit(AdditionExpression ex);
        public abstract void Visit(MultiplicationExpression ex);
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private string str = "";
        public override void Visit(Value value)
        {
            str += value.TheValue;
        }

        public override void Visit(AdditionExpression ae)
        {
            str += "(";
            ae.LHS.Accept(this);
            str += "+";
            ae.RHS.Accept(this);
            str += ")";
        }

        public override void Visit(MultiplicationExpression me)
        {
            me.LHS.Accept(this);
            str += "*";
            me.RHS.Accept(this);
        }

        public override string ToString()
        {
            return str;
        }
    }
}
