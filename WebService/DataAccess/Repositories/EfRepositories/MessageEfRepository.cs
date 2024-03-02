using DataAccess.DBContexts;
using DataAccess.Entities;

namespace DataAccess.Repositories.EfRepositories;

public class MessageEfRepository : BaseEfRepository<Message>
{
    public MessageEfRepository(DatabaseContext databaseContext)
        : base(databaseContext) { }
}