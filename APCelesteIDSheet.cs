using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.APCeleste
{
    public class APCelesteIDSheet
    {
        public Dictionary<EntityID,int> BerryIDToWorldID { get; }

        public APCelesteIDSheet()
        {
            BerryIDToWorldID = new Dictionary<EntityID, int>
            {
            };
        }
    }
}
