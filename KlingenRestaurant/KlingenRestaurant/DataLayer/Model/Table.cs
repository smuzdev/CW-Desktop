using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class Table
    {
        public int TableId { get; set; }

        public int NumberTable { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public Table()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj is Table)
            {
                Table table = obj as Table;
                if (table.TableId == this.TableId)
                    return true;
                else
                    return false;
            }
            return base.Equals(obj);
        }

    }
}
