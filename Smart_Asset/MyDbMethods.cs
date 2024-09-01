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


        //TEST MONGODB CONNECTION
        public static async Task TestMongoDBConnection()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Create a MongoClient to test the connection
                    var client = new MongoClient(DefaultConnectionString);

                    // Attempt to access the server and retrieve database names as a test
                    var databases = client.ListDatabaseNames().ToList();

                    // If successful, MongoDB is working
                    Console.WriteLine("Database connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // If an exception is caught, display an error message
                    MessageBox.Show($"Database Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
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





        public static void Read_SerialNo(string dbName, DataGridView dataGridViewName, string serialNoVal)
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

        public static void ReadLocation(string dbName, DataGridView dataGridViewName, string collectionName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get the specified collection by name
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Retrieve all documents from the collection (you can add filters if needed)
            var documents = collection.Find(new BsonDocument()).ToList();



            var allDocuments = new List<Read_Model>();



            // Map BsonDocument results to Read_Model objects
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

            if (allDocuments.Count == 0)
            {
                // Display "not found" message
                MessageBox.Show("No records found in the specified collection.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
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



        //FOR UPDATING USING LOCATION
        public static void UpdateUsingLocation(string dbName, DataGridView dataGridViewName, string collectionName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Retrieve all documents from the collection
            var documents = collection.Find(new BsonDocument()).ToList();

            var allDocuments = new List<Read_Model>();

            // Map BsonDocument results to Read_Model objects
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

            if (allDocuments.Count == 0)
            {
                // Display "not found" message
                MessageBox.Show("No records found in the specified collection.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;

            // Lock specified columns and set cell styles
            LockColumns(dataGridViewName);

            // Subscribe to events for cursor changes
            dataGridViewName.CellMouseEnter += DataGridView_CellMouseEnter;
            dataGridViewName.CellMouseLeave += DataGridView_CellMouseLeave;
        }


        public static void UpdateUsingSerialNo(string dbName, DataGridView dataGridViewName, string serialNo)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            var allDocuments = new List<Read_Model>();

            // Retrieve all collections
            var collectionNames = database.ListCollectionNames().ToList();

            foreach (var collectionName in collectionNames)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Filter documents by SerialNo
                var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);
                var documents = collection.Find(filter).ToList();

                // Map BsonDocument results to Read_Model objects
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
                MessageBox.Show($"No records found with SerialNo: {serialNo}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;

            // Lock specified columns and set cell styles
            LockColumns(dataGridViewName);

            // Subscribe to events for cursor changes
            dataGridViewName.CellMouseEnter += DataGridView_CellMouseEnter;
            dataGridViewName.CellMouseLeave += DataGridView_CellMouseLeave;
        }

        private static void LockColumns(DataGridView dataGridView)
        {
            // Set columns to read-only
            var readOnlyColumns = new[] { "Id", "Type", "WarrantyStatus", "Usage", "Location" };
            foreach (var columnName in readOnlyColumns)
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns[columnName].ReadOnly = true;
                    dataGridView.Columns[columnName].DefaultCellStyle.BackColor = Color.LightGray;
                    dataGridView.Columns[columnName].DefaultCellStyle.ForeColor = Color.DarkGray;
                }
            }
        }

        // Event handler to change cursor to hand when mouse enters a read-only cell
        private static void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null || e.ColumnIndex < 0 || e.RowIndex < 0) return; // Check for valid indices

            if (e.ColumnIndex < dataGridView.Columns.Count && dataGridView.Columns[e.ColumnIndex].ReadOnly)
            {
                dataGridView.Cursor = Cursors.No;
            }
        }

        // Event handler to revert cursor to default when mouse leaves a read-only cell
        private static void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null || e.ColumnIndex < 0 || e.RowIndex < 0) return; // Check for valid indices

            if (e.ColumnIndex < dataGridView.Columns.Count && dataGridView.Columns[e.ColumnIndex].ReadOnly)
            {
                dataGridView.Cursor = Cursors.Default;
            }
        }


        public static void UpdateChangesToDatabase(string dbName, DataGridView dataGridView, string collectionName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            LockColumns(dataGridView);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Check if the row is not new and has data
                if (row.IsNewRow) continue;

                // Get the Id value from the DataGridView row (ensure your ID column is correctly named)
                var id = row.Cells["Id"].Value?.ToString();
                if (string.IsNullOrEmpty(id)) continue;

                // Create a filter to find the document by Id
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

                // Create an update definition with only the modified fields
                var update = Builders<BsonDocument>.Update
                    .Set("Type", row.Cells["Type"].Value?.ToString())
                    .Set("Model", row.Cells["Model"].Value?.ToString())
                    .Set("SerialNo", row.Cells["SerialNo"].Value?.ToString())
                    .Set("Cost", row.Cells["Cost"].Value?.ToString())
                    .Set("Supplier", row.Cells["Supplier"].Value?.ToString())
                    .Set("Warranty", row.Cells["Warranty"].Value?.ToString())
                    .Set("PurchaseDate", row.Cells["PurchaseDate"].Value?.ToString());

                // Update the document in MongoDB
                collection.UpdateOne(filter, update);
            }

            MessageBox.Show("Changes updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        // Attach this event handler to your DataGridView's CellFormatting event
        private static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null) return;

            // Add an arrow symbol to indicate read-only cells
            if (dataGridView.Columns[e.ColumnIndex].ReadOnly)
            {
                e.CellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Italic);
                e.Value = $"→ {e.Value}";
            }
        }


        public static async Task LoadDatabase_AllSerialNo(string dbName, System.Windows.Forms.ComboBox comboBox)
        {
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collectionNames = await database.ListCollectionNamesAsync();

                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                // Clear existing items
                comboBox.Items.Clear();

                foreach (var collName in await collectionNames.ToListAsync())
                {
                    var collection = database.GetCollection<BsonDocument>(collName);
                    var filter = Builders<BsonDocument>.Filter.Exists("SerialNo");
                    var projection = Builders<BsonDocument>.Projection.Include("SerialNo").Exclude("_id");

                    var items = await collection.Find(filter).Project(projection).ToListAsync();

                    foreach (var item in items)
                    {
                        var serialNo = item["SerialNo"].AsString;
                        comboBox.Items.Add(serialNo);
                        autoCompleteCollection.Add(serialNo);
                    }
                }

                comboBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        public class Type_AllSerialNo
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("List")]
            public string List { get; set; }
        }
















    }
}