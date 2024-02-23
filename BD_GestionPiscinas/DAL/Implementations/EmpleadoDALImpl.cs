using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EmpleadoDALImpl : DALGenericoImpl<Empleado>, IEmpleadoDAL
    {
        public EmpleadoDALImpl(GestionPiscinasContext context) : base(context)
        {
  
        }
    }
}
