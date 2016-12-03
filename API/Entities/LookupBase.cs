namespace Skillustrator.Api.Entities
{
    public class LookupBase : EntityBase, ILookupBase
    {
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
