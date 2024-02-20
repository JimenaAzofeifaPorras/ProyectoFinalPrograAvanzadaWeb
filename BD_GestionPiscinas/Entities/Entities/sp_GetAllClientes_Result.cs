using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Keyless]
    public class sp_GetAllClientes_Result
    {
        public int ClienteId { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }
    }
}
