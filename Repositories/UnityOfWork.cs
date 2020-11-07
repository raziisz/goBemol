using System.Threading.Tasks;
using backend.Data;

namespace backend.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DataContext _context;
        public UnityOfWork(DataContext context)
        {
           _context = context;

        }


        public void Rollback()
        {
           
        }



        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}