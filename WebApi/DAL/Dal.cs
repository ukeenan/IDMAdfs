using WebApi.Models;
using System.Data.Entity; 

namespace WebApi.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class Dal : DbContext
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 

        }
    }
}