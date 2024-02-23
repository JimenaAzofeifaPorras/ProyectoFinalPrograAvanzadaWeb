using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class RepuestoDALImpl : DALGenericoImpl<Repuesto>, IRepuestoDAL
    {
        public RepuestoDALImpl(GestionPiscinasContext context) : base(context)
        {

        }
    }
}
