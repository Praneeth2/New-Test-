using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstmvc.Models
{
    public class persons:IDisposable

    {
        private databasenameEntities _dbContext;
        private Person p;
        internal object myperson;

        public Person P { get; private set; }


        public persons (databasenameEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Person> GetAll()
        {
            return _dbContext.People.ToList();

        }
        public Person Get(int id)
        {
            return _dbContext.People.SingleOrDefault(x => x.PersonID == id);
        }
        public void Insert(Person p)
        {
            _dbContext.People.Add(p);
            _dbContext.SaveChanges();
        }
        public void Update(Person newP)
        {
            int id = newP.PersonID;
            Person personFromDb = this.Get(id);
            if (personFromDb != null)
            {
                personFromDb.FirstName = newP.FirstName;
                personFromDb.LastName = newP.LastName;
                personFromDb.Address = newP.Address;
                personFromDb.City = newP.City;
                _dbContext.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            Person p = Get(id);
            if (p != null)

                _dbContext.People.Remove(p);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }

}