namespace Nivaes.DataTestGenerator.Xunit
{
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

    public class GenericGeneratorDataDiscoverer
        : DataDiscoverer
    {
        public override bool SupportsDiscoveryEnumeration(IAttributeInfo dataAttribute, IMethodInfo testMethod)
        {
            return true;
        }
    }
}
