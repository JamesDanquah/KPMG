using Xunit.Extensions;

namespace TestProject.Test.Unit
{
    public abstract class BddSpecification : Specification
    {
        protected BddSpecification()
        {
            EstablishSupportingContext();
            EstablishContext();
        }

        protected virtual void EstablishSupportingContext() { }
        protected virtual void EstablishContext() { }
    }
}