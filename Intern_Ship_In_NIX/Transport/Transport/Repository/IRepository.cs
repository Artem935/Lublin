using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Transport.Models.Objects;

namespace Transport.Repository
{
    public interface IRepository<T> where T : class
    {
        public void AddList(T properties);
        public void DeliteObject(int choice);
        public int FindObject(int choise);
        public T ReturnObjectById(int id);
        public void ShowAll();
    }
}
