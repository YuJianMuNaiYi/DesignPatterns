namespace AdapterPattern
{
    public class OracleAdapter:IDataBaseAdapter
    {
        private readonly OracleDataBase oracleDataBase =new OracleDataBase();

        public string PridoverName
        {
            get { return oracleDataBase.GetDataBaseName; }
        }
    }
}
