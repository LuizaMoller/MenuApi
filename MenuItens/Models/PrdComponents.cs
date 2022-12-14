using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MenuItens.Models
{
    public class PrdComponents //Model for list of Menu Items under another Menu Item
    {
        public int PrdId { get; set; }

        //Navigation Navigation Property
        public virtual Product? Products { get; set; } 

        public int ChildPrdId { get; set; }

        //Navigation Navigation Property
        public virtual Product ProductChild { get; set; } 

    }
}
