using Dapper;
using dapperPT.Modelos;
using System.Data.SqlClient;

namespace dapperPT.Datos
{
    public class TiendaDatos
    {

        private readonly Conexion.ConexionDb _conexionDb;
        private readonly ILogger<TiendaDatos> _logger;
        public TiendaDatos(Conexion.ConexionDb conexionDb, ILogger<TiendaDatos> logger)
        {
            _conexionDb = conexionDb;
            _logger = logger;
        }

        public async Task<List<ProductoModel>> GetAllProducts()
        {
            using var sql = new SqlConnection(_conexionDb.CadenaSql());
            await sql.OpenAsync();

            var query = "SELECT Id, Nombre, Precio FROM Productos";

            var result = await sql.QueryAsync<ProductoModel>(query);

            return result.ToList();
        }


    }
}
