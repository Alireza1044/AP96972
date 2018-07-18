using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository
    {
        public Context Context;

        public BaseRepository()
        {
            Context = new Context();
		}
    }
}