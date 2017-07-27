using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PointOfSale.Infrastructure.Repository.EF
{
    public class ContextManager
    {
        private const string ContextKey = "ContextManager.PointOfSaleContext";

        public DbContext Context
        {
            get
            {
                if(HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new PointOfSaleContext();
                }

                return (PointOfSaleContext)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}
