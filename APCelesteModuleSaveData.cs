using System.Collections.Generic;

namespace Celeste.Mod.APCeleste
{
    public class APCelesteModuleSaveData : EverestModuleSaveData
    {
        public int strawberryCount = 0;
        public List<long> collectedItems = new List<long>();

        public void addStrab()
        {
            strawberryCount++;
        }
        
        public void markItemAsProcessed(long id)
        {
            collectedItems.Add(id);
        }
    }
}