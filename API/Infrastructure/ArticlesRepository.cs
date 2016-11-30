using ConsoleApplication.Entities;

namespace ConsoleApplication.Infrastructure.Repositories
{
    public class ArticlesRepository : BaseRepository<Article>, IArticlesRepository
    {
        public ArticlesRepository(SkillustratorContext context)
            : base(context)
        { }
    }
}