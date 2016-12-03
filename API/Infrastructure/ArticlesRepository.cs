using Skillustrator.Api.Entities;

namespace Skillustrator.Api.Infrastructure.Repositories
{
    public class ArticlesRepository : BaseRepository<Article>, IArticlesRepository
    {
        public ArticlesRepository(SkillustratorContext context)
            : base(context)
        { }
    }
}