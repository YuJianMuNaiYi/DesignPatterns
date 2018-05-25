namespace AdapterPattern
{
    public class SqlserverAdapter:IDataBaseAdapter
    {
        private readonly SqlServerDataBase sqlServerDataBase=new SqlServerDataBase();
        public string PridoverName { get { return sqlServerDataBase.DbName; } }
    }
}
