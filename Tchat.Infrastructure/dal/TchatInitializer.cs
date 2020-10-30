using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Infrastructure.dal
{
    public class TchatInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TchatContext>
    {
        protected override void Seed(TchatContext context)
        {
        }
    }
}
