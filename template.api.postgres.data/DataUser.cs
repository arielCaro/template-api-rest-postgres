using Microsoft.EntityFrameworkCore;
using template.api.postgres.data.Models;

namespace template.api.postgres.data
{
    public class DataUser
    {

        public static async void Create(Models.DbtemplateRestContext context, TbUser tbUser) 
        {
			try
			{
				context.TbUsers.Add(tbUser);
				context.Entry(tbUser).State = Microsoft.EntityFrameworkCore.EntityState.Added;
				await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }


		public static async void Update(Models.DbtemplateRestContext context, TbUser tbUser)
		{
			try
			{
                context.TbUsers.Update(tbUser);
                context.Entry(tbUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static async Task<TbUser> Get(Models.DbtemplateRestContext context, long id) 
		{
			try
			{
				return await context.TbUsers.FirstOrDefaultAsync(u => u.Id == id);		
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public static async Task<List<TbUser>> GetAll(Models.DbtemplateRestContext context)
        {
            try
            {
                return await context.TbUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
