using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MongoDB.Bson;

namespace NoSQLvsRelational
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarks
    {
        private readonly MongoDB_CRUD mongodb_Crud = new MongoDB_CRUD();
        private readonly SQL_CRUD sql_Crud = new SQL_CRUD();

        /*[Benchmark]
        public async Task getAllDocumentsMongoDb()
        {
            await mongodb_Crud.getAllDocs();
        }*/

        [Benchmark]
        public async Task insertDocumentMongoDb()
        {
            await mongodb_Crud.insertDocument();
        }

        /*
        [Benchmark]
        public void updateDocumentMongoDb()
        {
            mongodb_Crud.updateDocument(new ObjectId("62af36d14249fb757d6e94f0"));
        }*/


        /*              SQL         */


        /*[Benchmark]
        public void getAllDocumentsSQL()
        {
           sql_Crud.getAllDocuments();
        }*/

        [Benchmark]
        public int insertDocumentSQL()
        {
            return sql_Crud.insertDocument();
        }
        /*
        [Benchmark]
        public void updateDocumentSQL()
        {
            sql_Crud.updateDocument();
        }*/
    }
}
