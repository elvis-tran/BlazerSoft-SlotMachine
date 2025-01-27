namespace BlazerSoft_SlotMachine_Infrastructure
{
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class PlayerInfoRepository<T>: IRepository<T> where T : class
    {
        //
        MongoClient dbclient = new MongoClient("mongodb+srv://elvistrann7:u0mdpkyK6KSNRvjI@cluster0.gy218.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void GetPlayerById(int id)
        {

        }

        public int AddNewPlayer()
        {
            return 0;
        }
    }
}
