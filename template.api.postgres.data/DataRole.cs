using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.api.postgres.data.Models;

namespace template.api.postgres.data
{
    public class DataRole
    {

        public static async Task<TbRole> Get(DbtemplateRestContext dbContext, int id) 
        {
			try
			{
				return await dbContext.TbRoles.FirstOrDefaultAsync(r => r.Id == id);
			}
			catch (Exception ex)
			{

				throw new ArgumentNullException("", ex);
			}
        }

    }
}
