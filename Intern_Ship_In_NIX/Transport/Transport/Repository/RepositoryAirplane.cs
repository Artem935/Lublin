using Transport.Models.Objects;
using Transport.DisplayConsole;

namespace Transport.Repository
{
    [Serializable]
    internal class RepositoryAirplane: IRepository<Airplane>
    {
        List<Airplane> transport = new List<Airplane>();
        public void AddList(Airplane properties)
        {
            int Id = transport.Count;
            transport .Add(new Airplane(Id, properties.Model, properties.Brand, properties.FuelConsumption, properties.Price));
            new DataVerification().Complete($"You add {Id}th object");
        }
        public void DeliteObject(int choice)
        {
            DataVerification сorrectData = new DataVerification();
            if (choice == 1)
            {
                Airplane obj = ReturnObjectById(new DataVerification().CorrectDataInt("Enter id: "));
                transport .RemoveAt(obj.Id);
                Console.WriteLine(new Airplane().PrintAllProperties());
                Console.WriteLine(obj);
                OverwriteId();
                сorrectData.Complete("Was delite");
            }
            else if (choice == 2)
            {
                Console.Write("Enter brand name: ");
                string? brand = Console.ReadLine();
                var obj = transport .Where(b => b.Brand == brand);
                if (obj == null)
                {
                    сorrectData.Erore("There is no such objects");
                }
                else
                {
                    Console.WriteLine(new Airplane().PrintAllProperties());
                    foreach (var item in obj.ToList())
                    {
                        Console.WriteLine(item);
                        transport .Remove(item);
                    }
                    new DataVerification().Complete("Was delite");
                }
                OverwriteId();
            }
        }
        public int FindObject(int choice)
        {
            if (choice == 1)
            {
                var resulr = ReturnObjectById(new DataVerification().CorrectDataInt("Enter id: "));
                if (resulr == null )
                    new DataVerification().Erore("No such number");
                else
                    Console.WriteLine(resulr);
            }
            else if (choice == 2)
            {
                Console.Write("Enter brand name: ");
                string? brand = Console.ReadLine();
                Console.WriteLine(new Airplane().PrintAllProperties());
                var res = transport .Where((a) => a.Brand == brand);
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
            }
            return -1;
        }
        // ???????????????????????????????????
        public Airplane ReturnObjectById(int id)
        {
            return transport .FirstOrDefault(a => a.Id == id);
        }
        public void ShowAll()
        {
            Console.WriteLine(new Airplane().PrintAllProperties());
            var res = transport ;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        public void OverwriteId()
        {
            for (int i = 0; i < transport .Count(); i++) { transport [i].Id = i; }
        }
    }
}

