using BenchmarkDotNet.Running;
using NoSQLvsRelational;

//var mongoCrud = new MongoDB_CRUD();

//await mongoCrud.insertDocument();
//Console.WriteLine("Created");
//await mongoCrud.updateDocument(new ObjectId("62adf4bdf7226f59bd7e4975"));
//Console.WriteLine("Updated");
//await mongoCrud.deleteDocument(new ObjectId("62adf4bdf7226f59bd7e4975"));
//await mongoCrud.getDocumentById(new ObjectId("62ad015b6deefde2e3432afe"));
//await mongoCrud.getAllDocs();



//SQL
//var sql = new SQL_CRUD();
//sql.insertDocument();

//sql.getAllDocuments();
//sql.updateDocument();
//sql.deleteDocument();
//sql.getDocumentById(1);


BenchmarkRunner.Run<Benchmarks>();
