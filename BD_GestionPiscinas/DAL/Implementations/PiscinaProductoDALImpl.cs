﻿using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PiscinaProductoDALImpl : DALGenericoImpl<Producto>, IPiscinaProductoDAL
    {
        public PiscinaProductoDALImpl(GestionPiscinasContext context) : base(context)
        {

        }

    }
}
