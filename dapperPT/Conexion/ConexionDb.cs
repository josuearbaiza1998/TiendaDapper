namespace dapperPT.Conexion
{
    public class ConexionDb
    {
        private readonly string strConf;
        public ConexionDb(IConfiguration configuration)
        {
            strConf = configuration.GetConnectionString("OnePiece");
        }

        public string CadenaSql()
        {
            return strConf;
        }
    }
}
