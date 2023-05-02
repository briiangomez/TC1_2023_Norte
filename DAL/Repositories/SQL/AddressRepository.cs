using DAL.Contracts;
using DAL.Tools;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SQL
{
    internal class AddressRepository : IGenericRepository<Address>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Address] (IdAddress,Street, Number, City) VALUES (@IdAddress,@Street, @Number, @City)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Address] SET (Street, Number, City) WHERE IdAddress = @IdAddress";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Address] WHERE IdAddress = @IdAddress";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdAddress, Street, Number, City FROM [dbo].[Address] WHERE IdAddress = @IdAddress";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdAddress, Street, Number, City FROM [dbo].[Address]";
        }
        #endregion

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            return new List<Address>();
        }

        public Address GetOne(Guid id)
        {
            Address address = default;

            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                                    new SqlParameter[] { new SqlParameter("@IdAddress", id) }))
            {
                if (dr.Read())
                {
                    //En este caso tendremos un solo registro...
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);

                    //DATA MAPPER IdAddress, Street, Number, City
                    address = new Address();
                    address.IdAddress = Guid.Parse(values[0].ToString());
                    address.Street = values[1].ToString();
                    address.Number = int.Parse(values[2].ToString());
                    address.City = values[3].ToString();
                }
            }

            return address;
        }

        public void Insert(Address obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text,
                new SqlParameter[] { new SqlParameter("@IdAddress", obj.IdAddress),
                    new SqlParameter("@Street", obj.Street),
                new SqlParameter("@Number", obj.Number) ,
                new SqlParameter("@City", obj.City) });
        }

        public void Update(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}
