using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class CustomerDA
    {
        public List<Customer> GetAll(string firstName)
        {
            var result = new List<Customer>();
            using (var db = new DBModel())
            {
                result = db.Customer
                    .Where(a => string.Concat(a.FirstName," ",a.LastName).Contains(firstName))
                    .OrderBy(a => a.LastName)
                    .ThenBy(a=>a.FirstName)
                    .ToList();
            }
            return result;
        }

        public Customer Get(int id)
        {
            var result = new Customer();
            using (var db = new DBModel())
            {
                result = db.Customer.Find(id);
            }
            return result;
        }

        public int Insert(Customer  customer)
        {
            var result = 0;
            using (var db = new DBModel())
            {
                //Agrega la entidad al contexo
                db.Customer.Add(customer);
                //Se confirma la transaccion
                db.SaveChanges();

                result = customer.CustomerId;
            }
            return result;
        }

        public bool Update(Customer customer)
        {
            var result = false;
            using (var db = new DBModel())
            {
                //Atachamos la entidad al contexto
                db.Customer.Attach(customer);

                //Cambiando el estado de la entidad
                db.Entry(customer).State = EntityState.Modified;

                //Confirmando la transaccion
                db.SaveChanges();

                result = true;
            }
            return result;
        }

        public bool Delete(int customerId)
        {
            var result = false;
            using (var db = new DBModel())
            {
                var customer = new Customer
                {
                    CustomerId = customerId
                };
                db.Customer.Attach(customer);
                db.Customer.Remove(customer);

                //Confirmando la transaccion
                db.SaveChanges();

                result = true;
            }
            return result;
        }
    }
}
