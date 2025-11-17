using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Model
{
    [Index(nameof(Phone), IsUnique = true)]

    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public ICollection<ElderlyVisitor> ElderlyVisitors { get; set; } = new List<ElderlyVisitor>();

    }
}
