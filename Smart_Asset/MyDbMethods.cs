using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Smart_Asset.Read;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Smart_Asset
{
    public class MyDbMethods
    {
        private static readonly string DefaultConnectionString = "mongodb+srv://SmartAssetDb:SmartAssetDb_Pass@smartasset-serverlessin.lmjehif.mongodb.net/?retryWrites=true&w=majority&appName=SmartAsset-ServerlessInstance0";
        private static readonly MyDbMethods instance = new MyDbMethods();

        private string connectionString;
        private string dbName;
        private string collectionName;

        private MyDbMethods()
        {
            ConnectionString = DefaultConnectionString;
        }

        public static MyDbMethods Instance => instance;

        public string ConnectionString
        {
            get => connectionString;
            private set => connectionString = value;
        }

        public string DbName
        {
            get => dbName;
            set => dbName = value;
        }

        public string CollectionName
        {
            get => collectionName;
            set => collectionName = value;
        }

        public static async Task CreateDatabaseAsync(string dbName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var databaseNames = await client.ListDatabaseNames().ToListAsync();
            bool databaseExists = databaseNames.Contains(dbName);

            if (!databaseExists)
            {
                var database = client.GetDatabase(dbName);
                await database.CreateCollectionAsync("initial_collection");
                Console.WriteLine($"Database '{dbName}' and collection 'initial_collection' created.");
            }
            else
            {
                Console.WriteLine($"Database '{dbName}' already exists.");
            }
        }

        public static async Task CreateCollectionAsync(string dbName, string collName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collectionNames = await database.ListCollectionNames().ToListAsync();
            bool collectionExists = collectionNames.Contains(collName);

            if (!collectionExists)
            {
                await database.CreateCollectionAsync(collName);
                Console.WriteLine($"Collection '{collName}' created.");
            }
            else
            {
                Console.WriteLine($"Collection '{collName}' already exists.");
            }
        }

        public static async Task InsertDocument(string dbName, string collName, Dictionary<string, string> fields)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collName);
            var document = new BsonDocument(fields);

            await collection.InsertOneAsync(document);
            Console.WriteLine("Document inserted successfully.");
        }

        public static async Task LoadDatabase_TypeList(string dbName, string collName, System.Windows.Forms.ComboBox comboBox)
        {
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<Type_List_Items>(collName);

                var items = await collection.Find(FilterDefinition<Type_List_Items>.Empty).ToListAsync();
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                // Clear existing items
                comboBox.Items.Clear();

                foreach (var item in items)
                {
                    comboBox.Items.Add(item.List);
                    autoCompleteCollection.Add(item.List);
                }

                comboBox.AutoCompleteCustomSource = autoCompleteCollection;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        public class Type_List_Items
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("List")]
            public string List { get; set; }
        }



        public static async Task LoadDatabase_SerialNo(string dbName, string collName, System.Windows.Forms.ComboBox comboBox, string val)
        {
            try
            {
                // Create a MongoDB client and access the database and collection
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<BsonDocument>(collName);

                // Create a filter to get only documents where Type = "CPU"
                var filter = Builders<BsonDocument>.Filter.Eq("Type", $"{val}");

                // Use the filter in the Find method to get the matching documents
                var items = await collection.Find(filter).ToListAsync();

                // Create an AutoCompleteStringCollection to handle autocomplete functionality
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                // Clear existing items in the ComboBox
                comboBox.Items.Clear();

                // Iterate over the filtered documents and add the "Serial No." to the ComboBox
                foreach (var item in items)
                {
                    // Extract the "Serial No." field from the document
                    if (item.Contains("SerialNo"))
                    {
                        var serialNo = item["SerialNo"].AsString;

                        // Add the "Serial No." value to the ComboBox and AutoComplete collection
                        comboBox.Items.Add(serialNo);
                        autoCompleteCollection.Add(serialNo);
                    }
                }

                // Set the AutoComplete source for the ComboBox
                comboBox.AutoCompleteCustomSource = autoCompleteCollection;

            }
            catch (Exception ex)
            {
                // Display any errors that occur during the database operation
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        public class SerialNo_Items
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("Type")]
            public string Type { get; set; }
        }



        public static async Task LoadDatabase_SerialNo(string dbName, string collName, TextBox tb, string val)
        {
            try
            {
                // Create a MongoDB client and access the database and collection
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<BsonDocument>(collName);

                // Create a filter to get only documents where Type = "CPU"
                var filter = Builders<BsonDocument>.Filter.Eq("Type", $"{val}");

                // Use the filter in the Find method to get the matching documents
                var items = await collection.Find(filter).ToListAsync();

                // Create an AutoCompleteStringCollection to handle autocomplete functionality
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                // Iterate over the filtered documents and add the "Serial No." to the AutoComplete collection
                foreach (var item in items)
                {
                    // Extract the "Serial No." field from the document
                    if (item.Contains("SerialNo"))
                    {
                        var serialNo = item["SerialNo"].AsString;

                        // Add the "Serial No." value to the AutoComplete collection
                        autoCompleteCollection.Add(serialNo);
                    }
                }

                // Set the AutoComplete source for the TextBox
                tb.AutoCompleteCustomSource = autoCompleteCollection;

                // Set the AutoComplete mode and source for the TextBox
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
            catch (Exception ex)
            {
                // Display any errors that occur during the database operation
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }





        public static void Read_LoadData(string dbName, DataGridView dataGridViewName, string serialNoVal)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get all collection names
            var collectionNames = database.ListCollectionNames().ToList();

            var allDocuments = new List<Read_Model>();

            // Define the filter
            var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNoVal);

            // Iterate over each collection and apply the filter
            foreach (var collectionName in collectionNames)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);
                var documents = collection.Find(filter).ToList();

                // Map BsonDocument results to Read_Model objects with collection name
                var cpuList = documents.Select(doc => new Read_Model
                {
                    Id = doc["_id"].ToString(),
                    Type = doc["Type"].AsString,
                    Model = doc["Model"].AsString,
                    SerialNo = doc["SerialNo"].AsString,
                    Cost = doc["Cost"].AsString,
                    Supplier = doc["Supplier"].AsString,
                    Warranty = doc["Warranty"].AsString,

                    // Calculate warranty status if still valid
                    WarrantyStatus = MyMethods.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                    PurchaseDate = doc["PurchaseDate"].AsString,

                    // Calculate usage as years, months, and days
                    Usage = MyMethods.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                    // Set the collection name
                    Location = collectionName
                }).ToList();

                allDocuments.AddRange(cpuList);
            }

            if (allDocuments.Count == 0)
            {
                // Display "not found" message
                MessageBox.Show("No records found matching the criteria.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }



        public static async Task<bool> MoveDocument(string dbName, string sourceCollectionName, string targetCollectionName, string type, string serialNo)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            try
            {
                // Access the source and target collections
                var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
                var targetCollection = database.GetCollection<BsonDocument>(targetCollectionName);

                // Trim and ensure correct case for the type and serial number
                type = type.Trim();
                serialNo = serialNo.Trim();

                // Create a filter to find the document by Type and Serial No.
                var filter = Builders<BsonDocument>.Filter.Eq("Type", type) &
                             Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);

                // Find the document in the source collection
                var document = await sourceCollection.Find(filter).FirstOrDefaultAsync();

                if (document != null)
                {
                    // Insert the document into the target collection
                    await targetCollection.InsertOneAsync(document);

                    // Delete the document from the source collection
                    await sourceCollection.DeleteOneAsync(filter);

                    Console.WriteLine("Document moved successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Document not found in the source collection.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static void LoadAllCollData(string dbName, string collName, DataGridView datagridViewName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collName);

            var documents = collection.Find(new BsonDocument()).ToList();
            var dataTable = new DataTable();

            if (documents.Count > 0)
            {
                // Create columns and keep track of the index of the "Warranty" column
                int warrantyColumnIndex = -1;
                int currentIndex = 0;
                foreach (var element in documents[0])
                {
                    dataTable.Columns.Add(element.Name, typeof(string));
                    if (element.Name == "Warranty")
                    {
                        warrantyColumnIndex = currentIndex;
                    }
                    currentIndex++;
                }

                // Add the WarrantyStatus column after the Warranty column
                if (warrantyColumnIndex != -1)
                {
                    dataTable.Columns.Add("WarrantyStatus", typeof(string));
                    dataTable.Columns["WarrantyStatus"].SetOrdinal(warrantyColumnIndex + 1);
                }

                // Create rows
                foreach (var document in documents)
                {
                    var row = dataTable.NewRow();
                    foreach (var element in document)
                    {
                        row[element.Name] = element.Value.ToString();
                    }

                    // Calculate WarrantyStatus
                    DateTime purchaseDate = DateTime.Parse(document["PurchaseDate"].AsString);
                    string warranty = document["Warranty"].AsString;
                    string warrantyStatus = MyMethods.IsWarrantyValid(purchaseDate, warranty) ? "In Warranty" : "Out of Warranty";

                    // Add WarrantyStatus to the row
                    row["WarrantyStatus"] = warrantyStatus;

                    dataTable.Rows.Add(row);
                }
            }

            // Bind DataTable to DataGridView
            datagridViewName.DataSource = dataTable;
        }

        public static void SwapDocumentsBySerialNo(string dbName, string collection1Name, string collection2Name, string serialNo1, string serialNo2)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get the two specific collections
            var collection1 = database.GetCollection<BsonDocument>(collection1Name);
            var collection2 = database.GetCollection<BsonDocument>(collection2Name);

            // Define the filters for SerialNo1 in collection1 and SerialNo2 in collection2
            var filter1 = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo1);
            var filter2 = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo2);

            // Find the documents in their respective collections
            var document1 = collection1.Find(filter1).FirstOrDefault();
            var document2 = collection2.Find(filter2).FirstOrDefault();

            // Check if both documents were found
            if (document1 == null || document2 == null)
            {
                MessageBox.Show("One or both documents not found with the specified SerialNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure the "Type" field values match between the two documents
            var type1 = document1["Type"].AsString;
            var type2 = document2["Type"].AsString;

            if (type1 != type2)
            {
                MessageBox.Show("The 'Type' value in both documents must be the same to perform a swap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Swap documents between collections
            collection2.InsertOne(document1);
            collection1.InsertOne(document2);

            // Delete the original documents
            collection1.DeleteOne(filter1);
            collection2.DeleteOne(filter2);

            MessageBox.Show("Documents swapped successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }







    }
}