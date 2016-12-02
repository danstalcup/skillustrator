using Skillustrator.Api.Entities;

namespace Skillustrator.Api.Infrastructure
{
    public class ArticlesRepository : BaseRepository<Article>, IArticlesRepository
    {
        public ArticlesRepository(SkillustratorContext context)
            : base(context)
        { }
    }
}