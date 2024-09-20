﻿using MongoDB.Bson;
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
using ComboBox = System.Windows.Forms.ComboBox;
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
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                    PurchaseDate = doc["PurchaseDate"].AsString,

                    // Calculate usage as years, months, and days
                    Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

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
                WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                PurchaseDate = doc["PurchaseDate"].AsString,

                // Calculate usage as years, months, and days
                Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

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

        public static async Task ReadAllInDatabase(string dbName, DataGridView dataGridViewName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get all collection names in the database
            var collectionNames = await database.ListCollectionNamesAsync();

            // Create a list to hold all documents from all collections
            var allDocuments = new List<Read_Model>();

            // Iterate over all collections, except the ones we want to exclude
            foreach (var collectionName in collectionNames.ToList())
            {
                if (collectionName != "RecycleBin" && collectionName != "Deployment_Unit_List" && collectionName != "Type_List" && collectionName != "Deployment_Location_List")  // Skip excluded collections
                {
                    var collection = database.GetCollection<BsonDocument>(collectionName);

                    // Retrieve all documents from the current collection asynchronously
                    var documents = await collection.Find(new BsonDocument()).ToListAsync();

                    // Map BsonDocument results to Read_Model objects and add to the list
                    var cpuList = documents.Select(doc =>
                    {
                        // Try to parse the purchase date, handle the case where it's not valid
                        string purchaseDateString = doc.GetValue("PurchaseDate", "").AsString;
                        DateTime purchaseDate;
                        bool isDateValid = DateTime.TryParse(purchaseDateString, out purchaseDate);

                        // Calculate the warranty status and usage only if the date is valid
                        string warrantyStatus = isDateValid && !string.IsNullOrEmpty(doc.GetValue("Warranty", "").AsString)
                            ? (MyCalculations.IsWarrantyValid(purchaseDate, doc.GetValue("Warranty", "").AsString) ? "In Warranty" : "Out of Warranty")
                            : "Unknown";

                        string usage = isDateValid ? MyCalculations.CalculateUsage(purchaseDate) : "Unknown";

                        return new Read_Model
                        {
                            Id = doc["_id"].ToString(),
                            Type = doc.GetValue("Type", "").AsString,
                            Model = doc.GetValue("Model", "").AsString,
                            SerialNo = doc.GetValue("SerialNo", "").AsString,
                            Cost = doc.GetValue("Cost", "").AsString,
                            Supplier = doc.GetValue("Supplier", "").AsString,
                            Warranty = doc.GetValue("Warranty", "").AsString,
                            WarrantyStatus = warrantyStatus,
                            PurchaseDate = purchaseDateString,  // Keep the original string value
                            Usage = usage,
                            Location = collectionName
                        };
                    }).ToList();

                    allDocuments.AddRange(cpuList);
                }
            }

            // If no documents are found, show a message and clear the DataGridView
            if (allDocuments.Count == 0)
            {
                MessageBox.Show("No records found in the specified collections.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }

        public static void ReadLocationWithNotes(string dbName, DataGridView dataGridViewName, string collectionName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get the specified collection by name
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Retrieve all documents from the collection
            var documents = collection.Find(new BsonDocument()).ToList();

            var allDocuments = new List<Read_ModelWithNotes>();

            // Map BsonDocument results to Read_ModelWithNotes objects
            var myList = documents.Select(doc => new Read_ModelWithNotes
            {
                Id = doc["_id"].ToString(),
                Type = doc.GetValue("Type", "").AsString,
                Model = doc.GetValue("Model", "").AsString,
                SerialNo = doc.GetValue("SerialNo", "").AsString,
                Cost = doc.GetValue("Cost", "").AsString,
                Supplier = doc.GetValue("Supplier", "").AsString,
                Warranty = doc.GetValue("Warranty", "").AsString,

                // Warranty status calculation
                WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                PurchaseDate = doc.GetValue("PurchaseDate", "").AsString,

                // Usage calculation
                Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                // Set the collection name
                Location = collectionName,

                // Safely retrieve the Notes field if it exists
                Notes = doc.Contains("Notes") ? doc["Notes"].AsString : string.Empty

            }).ToList();

            allDocuments.AddRange(myList);

            if (allDocuments.Count == 0)
            {
                // Display "not found" message
                MessageBox.Show("No records found in the specified collection.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }

        public static void SwapDocumentsByType(string dbName, string collection1Name, string collection2Name, string typeValue)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get the two specific collections
            var collection1 = database.GetCollection<BsonDocument>(collection1Name);
            var collection2 = database.GetCollection<BsonDocument>(collection2Name);

            // Trim the typeValue and define the filters for Type in both collections
            typeValue = typeValue.Trim();

            var filter1 = Builders<BsonDocument>.Filter.Eq("Type", typeValue);
            var filter2 = Builders<BsonDocument>.Filter.Eq("Type", typeValue);

            // Find the first documents with the matching Type in their respective collections
            var document1 = collection1.Find(filter1).FirstOrDefault();
            var document2 = collection2.Find(filter2).FirstOrDefault();

            // Log the results for debugging
            Console.WriteLine($"Type Value: '{typeValue}'");
            Console.WriteLine($"Collection1 Document Found: {document1 != null}");
            Console.WriteLine($"Collection2 Document Found: {document2 != null}");

            // Print document details for further debugging
            if (document1 != null)
            {
                Console.WriteLine("Document1 Details: ");
                Console.WriteLine(document1.ToString());
            }
            else
            {
                Console.WriteLine("No document found in Collection1 with Type: " + typeValue);
            }

            if (document2 != null)
            {
                Console.WriteLine("Document2 Details: ");
                Console.WriteLine(document2.ToString());
            }
            else
            {
                Console.WriteLine("No document found in Collection2 with Type: " + typeValue);
            }

            // Check if both documents were found
            if (document1 == null || document2 == null)
            {
                MessageBox.Show("One or both documents not found with the specified Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve SerialNo from both documents
            var serialNo1 = document1["SerialNo"].AsString;
            var serialNo2 = document2["SerialNo"].AsString;

            // Remove _id field from both documents to avoid conflicts when inserting
            document1.Remove("_id");
            document2.Remove("_id");

            // Swap documents between collections
            collection2.InsertOne(document1);
            collection1.InsertOne(document2);

            // Delete the original documents
            collection1.DeleteOne(Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo1));
            collection2.DeleteOne(Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo2));

            MessageBox.Show("Documents swapped successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        // FOR UPDATING USING LOCATION
        public static void UpdateUsingLocation(string dbName, DataGridView dataGridViewName, string collectionName)
        {
            var database = new MongoClient(DefaultConnectionString).GetDatabase(dbName);
            var documents = database.GetCollection<BsonDocument>(collectionName).Find(new BsonDocument()).ToList();

            var allDocuments = documents.Select(doc => new Read_Model
            {
                Id = doc["_id"].ToString(),
                Type = doc["Type"].AsString,
                Model = doc["Model"].AsString,
                SerialNo = doc["SerialNo"].AsString,
                Cost = doc["Cost"].AsString,
                Supplier = doc["Supplier"].AsString,
                Warranty = doc["Warranty"].AsString,
                WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",
                PurchaseDate = doc["PurchaseDate"].AsString,
                Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),
                Location = collectionName
            }).ToList();

            if (!allDocuments.Any())
            {
                MessageBox.Show("No records found in the specified collection.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewName.DataSource = null;
                return;
            }

            dataGridViewName.DataSource = allDocuments;
            LockColumns(dataGridViewName);
            dataGridViewName.CellMouseEnter += DataGridView_CellMouseEnter;
            dataGridViewName.CellMouseLeave += DataGridView_CellMouseLeave;
            dataGridViewName.CellClick += DataGridView_CellClick;
        }

        // FOR UPDATING USING SERIALNO
        public static void UpdateUsingSerialNo(string dbName, DataGridView dataGridViewName, string serialNo)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            var allDocuments = new List<Read_Model>();

            var collectionNames = database.ListCollectionNames().ToList();

            foreach (var collectionName in collectionNames)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);

                var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);
                var documents = collection.Find(filter).ToList();

                var cpuList = documents.Select(doc => new Read_Model
                {
                    Id = doc["_id"].ToString(),
                    Type = doc["Type"].AsString,
                    Model = doc["Model"].AsString,
                    SerialNo = doc["SerialNo"].AsString,
                    Cost = doc["Cost"].AsString,
                    Supplier = doc["Supplier"].AsString,
                    Warranty = doc["Warranty"].AsString,
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",
                    PurchaseDate = doc["PurchaseDate"].AsString,
                    Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),
                    Location = collectionName // Store the collection name
                }).ToList();

                allDocuments.AddRange(cpuList);
            }

            if (allDocuments.Count == 0)
            {
                MessageBox.Show($"No records found with SerialNo: {serialNo}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewName.DataSource = null;
                return;
            }

            dataGridViewName.DataSource = allDocuments;
            LockColumns(dataGridViewName);
            dataGridViewName.CellMouseEnter += DataGridView_CellMouseEnter;
            dataGridViewName.CellMouseLeave += DataGridView_CellMouseLeave;
            dataGridViewName.CellClick += DataGridView_CellClick;
        }

        private static DateTimePicker _dateTimePicker;

        private static void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (e.ColumnIndex == dataGridView.Columns["PurchaseDate"].Index && e.RowIndex >= 0)
            {
                _dateTimePicker?.Dispose();

                _dateTimePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dddd, MMMM d, yyyy",
                    Size = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Size,
                    Location = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location,
                    Visible = true
                };

                if (dataGridView.CurrentCell.Value != null)
                    _dateTimePicker.Value = DateTime.Parse(dataGridView.CurrentCell.Value.ToString());

                _dateTimePicker.CloseUp += (s, ev) =>
                {
                    dataGridView.CurrentCell.Value = _dateTimePicker.Value.ToString("dddd, MMMM d, yyyy");
                    dataGridView.RefreshEdit();
                    dataGridView.NotifyCurrentCellDirty(true);
                    _dateTimePicker.Dispose();
                };

                _dateTimePicker.LostFocus += (s, ev) => _dateTimePicker?.Dispose();
                _dateTimePicker.KeyPress += (s, ev) => { if (ev.KeyChar == (char)Keys.Escape) _dateTimePicker?.Dispose(); };

                dataGridView.Controls.Add(_dateTimePicker);
                _dateTimePicker.BringToFront();
                _dateTimePicker.Focus();
            }
            else
            {
                _dateTimePicker?.Dispose();
            }
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

            LockColumns(dataGridView);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var id = row.Cells["Id"].Value?.ToString();
                if (string.IsNullOrEmpty(id)) continue;

                var docCollectionName = row.Cells["Location"].Value?.ToString(); // Get the original collection name
                var collection = database.GetCollection<BsonDocument>(docCollectionName); // Use the correct collection

                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BsonDocument>.Update
                    .Set("Type", row.Cells["Type"].Value?.ToString())
                    .Set("Model", row.Cells["Model"].Value?.ToString())
                    .Set("SerialNo", row.Cells["SerialNo"].Value?.ToString())
                    .Set("Cost", row.Cells["Cost"].Value?.ToString())
                    .Set("Supplier", row.Cells["Supplier"].Value?.ToString())
                    .Set("Warranty", row.Cells["Warranty"].Value?.ToString())
                    .Set("PurchaseDate", row.Cells["PurchaseDate"].Value?.ToString());

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





        public static async Task TransferDocumentBySerialNo(string dbName, string transferColl, string serialNo, string notes)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

            BsonDocument document = null;
            string sourceCollectionName = null;

            using (var cursor = await database.ListCollectionNamesAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var collectionName in cursor.Current)
                    {
                        if (!excludeCollections.Contains(collectionName))
                        {
                            var collection = database.GetCollection<BsonDocument>(collectionName);
                            var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);

                            document = await collection.Find(filter).FirstOrDefaultAsync();

                            if (document != null)
                            {
                                sourceCollectionName = collectionName;
                                break;
                            }
                        }
                    }

                    if (document != null)
                    {
                        break;
                    }
                }
            }

            if (document != null && sourceCollectionName != null)
            {
                try
                {
                    // Step 2: Conditionally add the "OldLocation" field to the document
                    var exemptLocations = new[] { "Repairing", "Cleaning", "Disposed_Hardwares", "Borrowed_Hardwares", "Delete" };

                    if (!exemptLocations.Contains(sourceCollectionName))
                    {
                        document["OldLocation"] = sourceCollectionName;
                    }

                    // Add the "Notes" field to the document
                    document["Notes"] = notes;

                    // Step 3: Insert the document into the transfer collection
                    var transferCollection = database.GetCollection<BsonDocument>(transferColl);
                    await transferCollection.InsertOneAsync(document);

                    // Step 4: Delete the document from the source collection
                    var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
                    var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);
                    await sourceCollection.DeleteOneAsync(filter);

                    MessageBox.Show($"Document with SerialNo '{serialNo}' successfully transferred from '{sourceCollectionName}' to '{transferColl}'.", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during the transfer: {ex.Message}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Document with SerialNo '{serialNo}' not found in any collection.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        public static async Task TransferDocumentBySerialNo(string dbName, string transferColl, string serialNo)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

            BsonDocument document = null;
            string sourceCollectionName = null;

            using (var cursor = await database.ListCollectionNamesAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var collectionName in cursor.Current)
                    {
                        if (!excludeCollections.Contains(collectionName))
                        {
                            var collection = database.GetCollection<BsonDocument>(collectionName);
                            var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);

                            document = await collection.Find(filter).FirstOrDefaultAsync();

                            if (document != null)
                            {
                                sourceCollectionName = collectionName;
                                break;
                            }
                        }
                    }

                    if (document != null)
                    {
                        break;
                    }
                }
            }

            if (document != null && sourceCollectionName != null)
            {
                try
                {
                    // Step 3: Insert the document into the transfer collection
                    var transferCollection = database.GetCollection<BsonDocument>(transferColl);
                    await transferCollection.InsertOneAsync(document);

                    // Step 4: Delete the document from the source collection
                    var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
                    var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);
                    await sourceCollection.DeleteOneAsync(filter);

                    MessageBox.Show($"Document with SerialNo '{serialNo}' successfully transferred from '{sourceCollectionName}' to '{transferColl}'.", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during the transfer: {ex.Message}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Document with SerialNo '{serialNo}' not found in any collection.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        public static async Task TransferDocumentsByCollectionName(string dbName, string sourceCollectionName, string transferColl, string notes)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

            if (excludeCollections.Contains(sourceCollectionName))
            {
                MessageBox.Show($"The collection '{sourceCollectionName}' is excluded from transfers.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
            var documents = await sourceCollection.Find(new BsonDocument()).ToListAsync();

            if (documents == null || !documents.Any())
            {
                MessageBox.Show($"No documents found in the collection '{sourceCollectionName}'.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var transferCollection = database.GetCollection<BsonDocument>(transferColl);

                foreach (var document in documents)
                {
                    // Add the "OldLocation" field to the document
                    document["OldLocation"] = sourceCollectionName;

                    // Add the "Notes" field to the document
                    document["Notes"] = notes;

                    // Insert the document into the transfer collection
                    await transferCollection.InsertOneAsync(document);
                }

                // After transferring all documents, delete them from the source collection
                await sourceCollection.DeleteManyAsync(new BsonDocument());

                MessageBox.Show($"All documents from '{sourceCollectionName}' successfully transferred to '{transferColl}'.", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the transfer: {ex.Message}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public static async Task TransferManyUsingSerialNo(string dbName, List<string> serialNos)
        {
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

                // Retrieve all collection names
                using (var collectionsCursor = await database.ListCollectionNamesAsync())
                {
                    while (await collectionsCursor.MoveNextAsync())
                    {
                        foreach (var collectionName in collectionsCursor.Current)
                        {
                            try
                            {
                                if (!excludeCollections.Contains(collectionName)) // Skip excluded collections
                                {
                                    var collection = database.GetCollection<BsonDocument>(collectionName);

                                    // Build a filter to find documents that match the given SerialNo list
                                    var filter = Builders<BsonDocument>.Filter.In("SerialNo", serialNos);
                                    var documents = await collection.Find(filter).ToListAsync();

                                    if (documents.Count > 0)
                                    {
                                        foreach (var document in documents)
                                        {
                                            try
                                            {
                                                // Check if the document has an OldLocation field
                                                if (document.Contains("OldLocation"))
                                                {
                                                    var oldLocation = document["OldLocation"].AsString;

                                                    // Remove "OldLocation" and "notes" fields from the document
                                                    document.Remove("OldLocation");
                                                    document.Remove("Notes");

                                                    // Ensure the target collection exists (based on OldLocation)
                                                    var targetCollection = database.GetCollection<BsonDocument>(oldLocation);

                                                    // Insert the document into the target collection
                                                    await targetCollection.InsertOneAsync(document);

                                                    // Remove the document from the original collection
                                                    var idFilter = Builders<BsonDocument>.Filter.Eq("_id", document["_id"]);
                                                    await collection.DeleteOneAsync(idFilter);

                                                    Console.WriteLine($"Document with SerialNo: {document["SerialNo"]} transferred to {oldLocation}");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                // Handle individual document-level errors
                                                Console.WriteLine($"Error transferring document with SerialNo {document["SerialNo"]}: {ex.Message}");
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Handle errors at the collection level
                                Console.WriteLine($"Error processing collection '{collectionName}': {ex.Message}");
                            }
                        }
                    }
                }

                // Operation completion message
                MessageBox.Show("Retrieve operation completed.");
            }
            catch (Exception ex)
            {
                // Handle high-level errors (e.g., MongoDB connection issues)
                MessageBox.Show($"An error occurred during the retrieve operation: {ex.Message}");
                Console.WriteLine($"An error occurred during the retrieve operation: {ex}");
            }
        }


        public static async Task TransferDocumentsByCollectionName(string dbName, string sourceCollectionName, string transferColl)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

            // Check if the source collection is in the excluded list
            if (excludeCollections.Contains(sourceCollectionName))
            {
                MessageBox.Show($"The collection '{sourceCollectionName}' is excluded from transfers.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
            var documents = await sourceCollection.Find(new BsonDocument()).ToListAsync();

            // Check if there are any documents to transfer
            if (documents == null || !documents.Any())
            {
                MessageBox.Show($"No documents found in the collection '{sourceCollectionName}'.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var transferCollection = database.GetCollection<BsonDocument>(transferColl);

                foreach (var document in documents)
                {
                    // Insert the document into the transfer collection without modifying it
                    await transferCollection.InsertOneAsync(document);
                }

                // After transferring all documents, delete them from the source collection
                await sourceCollection.DeleteManyAsync(new BsonDocument());

                MessageBox.Show($"All documents from '{sourceCollectionName}' successfully transferred to '{transferColl}'.", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the transfer: {ex.Message}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







    }
}