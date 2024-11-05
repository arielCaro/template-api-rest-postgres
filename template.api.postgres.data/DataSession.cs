using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.api.postgres.data.Models;

namespace template.api.postgres.data
{
    public class DataSession
    {
        public static async Task<TbSession> Get(DbtemplateRestContext context, long id)
        {
            try
            {
                return await context.TbSessions.FirstOrDefaultAsync(t => t.IdUser == id && t.Active == true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<TbSession>> Get(DbtemplateRestContext context, DateTime dateInicial, DateTime dateFinal, long idUser)
        {
            try
            {
                return await context.TbSessions.Where(t => t.SessionOn >= dateInicial
                                                           && t.SessionOut <= dateFinal
                                                           && t.IdUser == idUser).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<TbSession> Get(DbtemplateRestContext context, string token)
        {
            try
            {
                return await context.TbSessions.FirstOrDefaultAsync(t => t.TokenBearer == token && t.Active);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task Create(DbtemplateRestContext context, TbSession tbSession)
        {
            try
            {
                context.TbSessions.Add(tbSession);
                context.Entry(tbSession).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task Update(DbtemplateRestContext context, TbSession tbSession)
        {
            try
            {
                context.TbSessions.Update(tbSession);
                context.Entry(tbSession).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
