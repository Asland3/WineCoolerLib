namespace WineCoolerLib
{
    public class Cooler
    {
        private int _coolerId;
        private int _capacityOfBottles;
        private int _temp;
        private int _bottlesInStorage;


        public Cooler(int coolerId, int capacityOfBottles, int temp, int bottlesInStorage)
        {
            CoolerId = coolerId;
            CapacityOfBottles = capacityOfBottles;
            Temp = temp;
            BottlesInStorage = bottlesInStorage; 
        }
        public Cooler()
        {
             
        }
        public int CoolerId
        {
            get => _coolerId;
            set => _coolerId = value;
        }

        public int CapacityOfBottles
        {
            get => _capacityOfBottles;
            set
            {
                //if (value >= 20) throw new ArgumentOutOfRangeException("Capacity", value, "Capacity is full"); 
                _capacityOfBottles = value;
            }
        }

        public int Temp
        {
            get => _temp;
            set =>_temp = value;
            
        }

        public int BottlesInStorage
        {
            get => _bottlesInStorage;
            set
            {
               // if (value >= CapacityOfBottles)throw new ArgumentOutOfRangeException("BottleInStorage", value, "test");
                //if (value <= 0) throw new ArgumentOutOfRangeException("BottleInStorage", value, "Cannot be blow 0");
                _bottlesInStorage = value;
            }
        }

        public bool CoolerIsFull()
        {
            if (CapacityOfBottles == BottlesInStorage)
            {
                return true; 
            }
            return false;
        }

        public int AddWine()
        {
            if (CoolerIsFull())
            {
                throw new ArgumentOutOfRangeException("cooler is full!");
            }
            BottlesInStorage++;
            return BottlesInStorage; 
        }
    }
}