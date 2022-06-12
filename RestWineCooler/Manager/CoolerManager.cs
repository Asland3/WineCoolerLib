using WineCoolerLib;

namespace RestWineCooler.Manager
{
    public class CoolerManager
    {

        private static int nextId = 1;
        private static List<Cooler> data = new List<Cooler>()
        {
            new Cooler() {CoolerId = nextId++, CapacityOfBottles = 4, BottlesInStorage= 4, Temp = 18 },
            new Cooler() {CoolerId = nextId++, CapacityOfBottles = 4, BottlesInStorage= 0, Temp = 12 },
            new Cooler() {CoolerId = nextId++, CapacityOfBottles = 3, BottlesInStorage= 1, Temp = 12 },
            new Cooler() {CoolerId = nextId++, CapacityOfBottles = 5, BottlesInStorage= 3, Temp = 14 }
        };

        public List<Cooler> GetAll(int? coolerIdFilter)
        {
            List<Cooler> result = new List<Cooler>(data);

            if (coolerIdFilter == null)
            {
                return result;
            }
            return data.Where(m => m.CoolerId == coolerIdFilter).ToList();

            //return result;
        }

        public Cooler GetById(int id)
        {
            return data.Find(c => c.CoolerId == id);
        }

        public Cooler Add(Cooler newCooler)
        {
            newCooler.CoolerId = nextId++;
            data.Add(newCooler);
            return newCooler;
        }

        public int AddWine (int id)
        {
            Cooler cooler = GetById(id);

            int result = cooler.AddWine();

            return result; 
        }

        public Cooler Delete(int id)
        {
            Cooler cooler = GetById(id);
            if (cooler == null) return null;
            data.Remove(cooler);
            return cooler;
        }

        public Cooler Update(int id, Cooler updates)
        {
            Cooler cooler = data.Find(Cooler => Cooler.CoolerId == id);
            if (cooler == null) return null;
            cooler.BottlesInStorage = updates.BottlesInStorage;
            cooler.CapacityOfBottles = updates.CapacityOfBottles;
            cooler.Temp = updates.Temp; 
            return cooler;
        }
    }
}
