using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using Tchat.Core.Models;

namespace Tchat.Infrastructure.DAL
{
    public class TchatInitializer : DropCreateDatabaseIfModelChanges<TchatContext>
    {
        protected override void Seed(TchatContext context)
        {

        }
    }
}