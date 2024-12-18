﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static Smart_Asset.Read;
using TextBox = System.Windows.Forms.TextBox;
using ExcelDataReader;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using iText.Commons.Bouncycastle.Crypto;
using Amazon.SecurityToken.Model;
using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using Control = System.Windows.Forms.Control;

namespace Smart_Asset
{
    public class MyDbMethods
    {
        //private static readonly string DefaultConnectionString = "mongodb+srv://SmartAssetDb:SmartAssetDb_Pass@smartasset-serverlessin.lmjehif.mongodb.net/?retryWrites=true&w=majority&appName=SmartAsset-ServerlessInstance0";
        private static readonly string DefaultConnectionString = "mongodb://SmartAssetDb:SmartAssetDb_Pass@smartassetfinalcluster-shard-00-00.b9c9x.mongodb.net:27017,smartassetfinalcluster-shard-00-01.b9c9x.mongodb.net:27017,smartassetfinalcluster-shard-00-02.b9c9x.mongodb.net:27017/?ssl=true&replicaSet=atlas-x13njr-shard-0&authSource=admin&retryWrites=true&w=majority&appName=SmartAssetFinalCluster";

        private static readonly MyDbMethods instance = new MyDbMethods();

        private string connectionString;
        private string dbName;
        private string collectionName;
        private string decryptedPass { get; set; }

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



        // Class-level static fields for API details
        private static readonly string ApiUrl = "https://cloud.mongodb.com/api/atlas/v1.0";
        private static readonly string ApiPublicKey = "brnsuaaq";
        private static readonly string ApiPrivateKey = "aa731669-6a93-4382-ab94-53ca5a026ff8";
        private static readonly string GroupId = "66b0584610c48008642ca6ca";
        private static readonly string ClusterName = "Smart_Asset_Project";



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
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<BsonDocument>(collName);
                var document = new BsonDocument(fields);

                await collection.InsertOneAsync(document);

                // Show success message
                MessageBox.Show("Document inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //OVERLOADING METHOD FOR INSERTDOCUMENT WITH DICTIONARY <string, Object>
        public static async Task InsertDocument(string dbName, string collName, Dictionary<string, object> fields)
        {
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<BsonDocument>(collName);

                // Manually create the BsonDocument to handle mixed types
                var document = new BsonDocument();
                foreach (var field in fields)
                {
                    document.Add(field.Key, BsonValue.Create(field.Value));
                }

                await collection.InsertOneAsync(document);

                // Show success message
                MessageBox.Show("Document inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //OVERLOADING METHOD WITH MESSAGEBOX PARAMETER
        public static async Task InsertDocument(string dbName, string collName, Dictionary<string, string> fields, bool showMessage)
        {
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<BsonDocument>(collName);
                var document = new BsonDocument(fields);

                await collection.InsertOneAsync(document);

                // Show success message if showMessage is true
                if (showMessage)
                {
                    MessageBox.Show("Document inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Show error message regardless of showMessage
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            // Split the input serial numbers by commas and remove any extra spaces
            var serialNoList = serialNoVal.Split(',').Select(s => s.Trim()).ToList();

            // Get all collection names
            var collectionNames = database.ListCollectionNames().ToList();

            var allDocuments = new List<Read_Model>();

            // Define the filter for multiple serial numbers
            var filter = Builders<BsonDocument>.Filter.In("SerialNo", serialNoList);

            // Iterate over each collection and apply the filter
            foreach (var collectionName in collectionNames)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);
                var documents = collection.Find(filter).ToList();

                // Map BsonDocument results to Read_Model objects with collection name
                var cpuList = documents.Select(doc => new Read_Model
                {
                    Type = doc["Type"].AsString,
                    Brand = doc["Brand"].AsString,
                    Model = doc["Model"].AsString,
                    PropertyID = doc["PropertyID"].AsString,
                    SerialNo = doc["SerialNo"].AsString,
                    PONumber = doc["PONumber"].AsString,
                    SINumber = doc["SINumber"].AsString,
                    Cost = doc["Cost"].AsString,
                    Warranty = doc["Warranty"].AsString,
                    Supplier = doc["Supplier"].AsString,

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
                MessageBox.Show("No records found in the specified collection.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Type = doc["Type"].AsString,
                Brand = doc["Brand"].AsString,
                Model = doc["Model"].AsString,
                PropertyID = doc["PropertyID"].AsString,
                SerialNo = doc["SerialNo"].AsString,
                PONumber = doc["PONumber"].AsString,
                SINumber = doc["SINumber"].AsString,
                Cost = doc["Cost"].AsString,
                Warranty = doc["Warranty"].AsString,
                Supplier = doc["Supplier"].AsString,

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
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }


        //OVERLOADED FOR N/A UNIT
        public static void ReadLocation(string dbName, DataGridView dataGridViewName, string collectionName, bool isNA)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            var allDocuments = new List<Read_Model>();

            if (isNA)
            {
                // Get all collection names in the database
                var collections = database.ListCollectionNames().ToList();

                // Filter the collections that contain collectionName in their names
                var filteredCollections = collections.Where(name => name.Contains(collectionName)).ToList();

                foreach (var filteredCollection in filteredCollections)
                {
                    // Get the collection by name
                    var collection = database.GetCollection<BsonDocument>(filteredCollection);

                    // Retrieve all documents from the collection
                    var documents = collection.Find(new BsonDocument()).ToList();

                    // Map BsonDocument results to Read_Model objects
                    var cpuList = documents.Select(doc => new Read_Model
                    {
                        Type = doc.Contains("Type") ? doc["Type"].AsString : string.Empty,
                        Brand = doc.Contains("Brand") ? doc["Brand"].AsString : string.Empty,
                        Model = doc.Contains("Model") ? doc["Model"].AsString : string.Empty,
                        PropertyID = doc.Contains("PropertyID") ? doc["PropertyID"].AsString : string.Empty,
                        SerialNo = doc.Contains("SerialNo") ? doc["SerialNo"].AsString : string.Empty,
                        PONumber = doc.Contains("PONumber") ? doc["PONumber"].AsString : string.Empty,
                        SINumber = doc.Contains("SINumber") ? doc["SINumber"].AsString : string.Empty,
                        Cost = doc.Contains("Cost") ? doc["Cost"].AsString : string.Empty,
                        Warranty = doc.Contains("Warranty") ? doc["Warranty"].AsString : string.Empty,
                        Supplier = doc.Contains("Supplier") ? doc["Supplier"].AsString : string.Empty,




                        // Calculate warranty status if still valid
                        WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                        PurchaseDate = doc["PurchaseDate"].AsString,

                        // Calculate usage as years, months, and days
                        Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                        // Set the collection name as the location
                        Location = filteredCollection
                    }).ToList();

                    allDocuments.AddRange(cpuList);
                }
            }
            else
            {
                // Get the specified collection by name
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Retrieve all documents from the collection
                var documents = collection.Find(new BsonDocument()).ToList();

                // Map BsonDocument results to Read_Model objects
                var cpuList = documents.Select(doc => new Read_Model
                {
                    Type = doc.Contains("Type") ? doc["Type"].AsString : string.Empty,
                    Brand = doc.Contains("Brand") ? doc["Brand"].AsString : string.Empty,
                    Model = doc.Contains("Model") ? doc["Model"].AsString : string.Empty,
                    PropertyID = doc.Contains("PropertyID") ? doc["PropertyID"].AsString : string.Empty,
                    SerialNo = doc.Contains("SerialNo") ? doc["SerialNo"].AsString : string.Empty,
                    PONumber = doc.Contains("PONumber") ? doc["PONumber"].AsString : string.Empty,
                    SINumber = doc.Contains("SINumber") ? doc["SINumber"].AsString : string.Empty,
                    Cost = doc.Contains("Cost") ? doc["Cost"].AsString : string.Empty,
                    Warranty = doc.Contains("Warranty") ? doc["Warranty"].AsString : string.Empty,
                    Supplier = doc.Contains("Supplier") ? doc["Supplier"].AsString : string.Empty,

                    // Calculate warranty status if still valid
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                    PurchaseDate = doc["PurchaseDate"].AsString,

                    // Calculate usage as years, months, and days
                    Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                    // Set the collection name as the location
                    Location = collectionName
                }).ToList();

                allDocuments.AddRange(cpuList);
            }

            if (allDocuments.Count == 0)
            {
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }


        //OVERLOADING FOR READING ONLY SPECIFIC FIELDNAME AND TYPE FIELDVALUE.
        public static void ReadLocation(string dbName, DataGridView dataGridViewName, string collectionName, bool isNA, string typeName, string typeValue)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            var allDocuments = new List<Read_Model>();

            // Create a filter to only include documents where "Type" is "CPU"
            var filter = Builders<BsonDocument>.Filter.Eq(typeName, typeValue);

            if (isNA)
            {
                // Get all collection names in the database
                var collections = database.ListCollectionNames().ToList();

                // Filter the collections that contain collectionName in their names
                var filteredCollections = collections.Where(name => name.Contains(collectionName)).ToList();

                foreach (var filteredCollection in filteredCollections)
                {
                    // Get the collection by name
                    var collection = database.GetCollection<BsonDocument>(filteredCollection);

                    // Retrieve all documents from the collection where "Type" is "CPU"
                    var documents = collection.Find(filter).ToList();

                    // Map BsonDocument results to Read_Model objects
                    var cpuList = documents.Select(doc => new Read_Model
                    {
                        Type = doc.Contains("Type") ? doc["Type"].AsString : string.Empty,
                        Brand = doc.Contains("Brand") ? doc["Brand"].AsString : string.Empty,
                        Model = doc.Contains("Model") ? doc["Model"].AsString : string.Empty,
                        PropertyID = doc.Contains("PropertyID") ? doc["PropertyID"].AsString : string.Empty,
                        SerialNo = doc.Contains("SerialNo") ? doc["SerialNo"].AsString : string.Empty,
                        PONumber = doc.Contains("PONumber") ? doc["PONumber"].AsString : string.Empty,
                        SINumber = doc.Contains("SINumber") ? doc["SINumber"].AsString : string.Empty,
                        Cost = doc.Contains("Cost") ? doc["Cost"].AsString : string.Empty,
                        Warranty = doc.Contains("Warranty") ? doc["Warranty"].AsString : string.Empty,
                        Supplier = doc.Contains("Supplier") ? doc["Supplier"].AsString : string.Empty,

                        // Calculate warranty status if still valid
                        WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                        PurchaseDate = doc["PurchaseDate"].AsString,

                        // Calculate usage as years, months, and days
                        Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                        // Set the collection name as the location
                        Location = filteredCollection
                    }).ToList();

                    allDocuments.AddRange(cpuList);
                }
            }
            else
            {
                // Get the specified collection by name
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Retrieve all documents from the collection where "Type" is "CPU"
                var documents = collection.Find(filter).ToList();

                // Map BsonDocument results to Read_Model objects
                var cpuList = documents.Select(doc => new Read_Model
                {
                    Type = doc.Contains("Type") ? doc["Type"].AsString : string.Empty,
                    Brand = doc.Contains("Brand") ? doc["Brand"].AsString : string.Empty,
                    Model = doc.Contains("Model") ? doc["Model"].AsString : string.Empty,
                    PropertyID = doc.Contains("PropertyID") ? doc["PropertyID"].AsString : string.Empty,
                    SerialNo = doc.Contains("SerialNo") ? doc["SerialNo"].AsString : string.Empty,
                    PONumber = doc.Contains("PONumber") ? doc["PONumber"].AsString : string.Empty,
                    SINumber = doc.Contains("SINumber") ? doc["SINumber"].AsString : string.Empty,
                    Cost = doc.Contains("Cost") ? doc["Cost"].AsString : string.Empty,
                    Warranty = doc.Contains("Warranty") ? doc["Warranty"].AsString : string.Empty,
                    Supplier = doc.Contains("Supplier") ? doc["Supplier"].AsString : string.Empty,

                    // Calculate warranty status if still valid
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                    PurchaseDate = doc["PurchaseDate"].AsString,

                    // Calculate usage as years, months, and days
                    Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                    // Set the collection name as the location
                    Location = collectionName
                }).ToList();

                allDocuments.AddRange(cpuList);
            }

            if (allDocuments.Count == 0)
            {
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
                if (collectionName != "RecycleBin" && collectionName != "Deployment_Unit_List" && collectionName != "Type_List" && collectionName != "Deployment_Location_List" && collectionName != "Serial_List" && collectionName != "Images" && collectionName != "Users" && collectionName != "CustomUsers_Permissions")  // Skip excluded collections
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
                            Type = doc.GetValue("Type", "").AsString,
                            Brand = doc.GetValue("Brand", "").AsString,
                            Model = doc.GetValue("Model", "").AsString,
                            PropertyID = doc.GetValue("PropertyID", "").AsString,
                            SerialNo = doc.GetValue("SerialNo", "").AsString,
                            PONumber = doc.GetValue("PONumber", "").AsString,
                            SINumber = doc.GetValue("SINumber", "").AsString,
                            Cost = doc.GetValue("Cost", "").AsString,
                            Warranty = doc.GetValue("Warranty", "").AsString,
                            Supplier = doc.GetValue("Supplier", "").AsString,
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
                Type = doc.GetValue("Type", "").AsString,
                Brand = doc.GetValue("Brand", "").AsString,
                Model = doc.GetValue("Model", "").AsString,
                PropertyID = doc.GetValue("PropertyID", "").AsString,
                SerialNo = doc.GetValue("SerialNo", "").AsString,
                PONumber = doc.GetValue("PONumber", "").AsString,
                SINumber = doc.GetValue("SINumber", "").AsString,
                Cost = doc.GetValue("Cost", "").AsString,
                Warranty = doc.GetValue("Warranty", "").AsString,
                Supplier = doc.GetValue("Supplier", "").AsString,

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
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }


        //OVERLOADING METHOD FOR BORROWED HARDWARES
        public static void ReadLocationWithNotes(string dbName, DataGridView dataGridViewName, string collectionName, bool isForBorrow)
        {
            if (isForBorrow == true)
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);

                // Get the specified collection by name
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Retrieve all documents from the collection
                var documents = collection.Find(new BsonDocument()).ToList();

                var allDocuments = new List<Read_Model_ForBorrow>();

                // Map BsonDocument results to Read_ModelWithNotes objects
                var myList = documents.Select(doc => new Read_Model_ForBorrow
                {
                    Type = doc.GetValue("Type", "").AsString,
                    Brand = doc.GetValue("Brand", "").AsString,
                    Model = doc.GetValue("Model", "").AsString,
                    PropertyID = doc.GetValue("PropertyID", "").AsString,
                    SerialNo = doc.GetValue("SerialNo", "").AsString,
                    PONumber = doc.GetValue("PONumber", "").AsString,
                    SINumber = doc.GetValue("SINumber", "").AsString,
                    Cost = doc.GetValue("Cost", "").AsString,
                    Warranty = doc.GetValue("Warranty", "").AsString,
                    Supplier = doc.GetValue("Supplier", "").AsString,

                    // Warranty status calculation
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                    PurchaseDate = doc.GetValue("PurchaseDate", "").AsString,

                    // Usage calculation
                    Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),

                    // Set the collection name
                    Location = collectionName,

                    // Set the name of borrower
                    Name = doc.GetValue("Name", "").AsString,

                    // Set the returnDate of borrower
                    ReturnDate = doc.GetValue("ReturnDate", "").AsString,

                    // Safely retrieve the Notes field if it exists
                    Notes = doc.Contains("Notes") ? doc["Notes"].AsString : string.Empty

                }).ToList();

                allDocuments.AddRange(myList);

                if (allDocuments.Count == 0)
                {
                    dataGridViewName.DataSource = null;
                    return;
                }

                // Bind the list to the DataGridView
                dataGridViewName.DataSource = allDocuments;
            }
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
                Type = doc.GetValue("Type", "").AsString,
                Brand = doc.GetValue("Brand", "").AsString,
                Model = doc.GetValue("Model", "").AsString,
                PropertyID = doc.GetValue("PropertyID", "").AsString,
                SerialNo = doc.GetValue("SerialNo", "").AsString,
                PONumber = doc.GetValue("PONumber", "").AsString,
                SINumber = doc.GetValue("SINumber", "").AsString,
                Cost = doc.GetValue("Cost", "").AsString,
                Warranty = doc.GetValue("Warranty", "").AsString,
                Supplier = doc.GetValue("Supplier", "").AsString,
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

        // FOR UPDATING USING SERIALNOS
        public static void UpdateUsingSerialNo(string dbName, DataGridView dataGridViewName, string serialNos)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            var allDocuments = new List<Read_Model>();

            // Split the input by commas and trim spaces
            var serialNoList = serialNos.Split(',')
                                        .Select(s => s.Trim())
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .ToList();

            if (serialNoList.Count == 0)
            {
                MessageBox.Show("Please provide valid SerialNo(s).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var collectionNames = database.ListCollectionNames().ToList();

            foreach (var collectionName in collectionNames)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Use In filter to match any of the provided serial numbers
                var filter = Builders<BsonDocument>.Filter.In("SerialNo", serialNoList);
                var documents = collection.Find(filter).ToList();

                var cpuList = documents.Select(doc => new Read_Model
                {
                    Type = doc.GetValue("Type", "").AsString,
                    Brand = doc.GetValue("Brand", "").AsString,
                    Model = doc.GetValue("Model", "").AsString,
                    PropertyID = doc.GetValue("PropertyID", "").AsString,
                    SerialNo = doc.GetValue("SerialNo", "").AsString,
                    PONumber = doc.GetValue("PONumber", "").AsString,
                    SINumber = doc.GetValue("SINumber", "").AsString,
                    Cost = doc.GetValue("Cost", "").AsString,
                    Warranty = doc.GetValue("Warranty", "").AsString,
                    Supplier = doc.GetValue("Supplier", "").AsString,
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",
                    PurchaseDate = doc["PurchaseDate"].AsString,
                    Usage = MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)),
                    Location = collectionName // Store the collection name
                }).ToList();

                allDocuments.AddRange(cpuList);
            }

            if (allDocuments.Count == 0)
            {
                MessageBox.Show($"No records found with the provided SerialNos.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            bool isSuccess = true;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var serialNo = row.Cells["SerialNo"].Value?.ToString();
                if (string.IsNullOrEmpty(serialNo)) continue;

                var docCollectionName = row.Cells["Location"].Value?.ToString();
                var collection = database.GetCollection<BsonDocument>(docCollectionName);

                var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);

                var update = Builders<BsonDocument>.Update
                    .Set("Type", row.Cells["Type"].Value?.ToString())
                    .Set("Brand", row.Cells["Brand"].Value?.ToString())
                    .Set("Model", row.Cells["Model"].Value?.ToString())
                    .Set("PropertyID", row.Cells["PropertyID"].Value?.ToString())
                    .Set("PONumber", row.Cells["PONumber"].Value?.ToString())
                    .Set("SINumber", row.Cells["SINumber"].Value?.ToString())
                    .Set("Cost", row.Cells["Cost"].Value?.ToString())
                    .Set("Warranty", row.Cells["Warranty"].Value?.ToString())
                    .Set("Supplier", row.Cells["Supplier"].Value?.ToString())
                    .Set("PurchaseDate", row.Cells["PurchaseDate"].Value?.ToString());

                try
                {
                    collection.UpdateOne(filter, update);
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    MessageBox.Show($"Error updating SerialNo {serialNo}: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (isSuccess)
            {
                MessageBox.Show("Changes updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public static void UpdateUsingUserID(string dbName, string collectionName, DataGridView dataGridViewName, string userIds)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            var allDocuments = new List<Read_Model_ForManageUsers>();

            // Split the input by commas and trim spaces, then convert to ObjectId
            var userIdList = userIds.Split(',')
                                     .Select(s => s.Trim())
                                     .Where(s => !string.IsNullOrEmpty(s))
                                     .Select(id => ObjectId.Parse(id)) // Convert to ObjectId
                                     .ToList();

            if (userIdList.Count == 0)
            {
                MessageBox.Show("Please provide valid UserID(s).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine("UserIDs to search: " + string.Join(", ", userIdList));

            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Use In filter to match any of the provided ObjectIds in userID
            var filter = Builders<BsonDocument>.Filter.In("userID", userIdList);
            var documents = collection.Find(filter).ToList();

            Console.WriteLine("Documents found: " + documents.Count);

            foreach (var document in documents)
            {
                var update = Builders<BsonDocument>.Update
                    .Set("name", document.GetValue("name", "").AsString)
                    .Set("username", document.GetValue("username", "").AsString);

                // Apply the update using the ObjectId from "userID"
                collection.UpdateOne(
                    Builders<BsonDocument>.Filter.Eq("userID", document.GetValue("userID").AsObjectId),
                    update
                );
            }

            var userList = documents.Select(doc => new Read_Model_ForManageUsers
            {
                UserID = doc.GetValue("userID").AsObjectId.ToString(), // Convert ObjectId to String
                Name = doc.GetValue("name", "").AsString,
                Username = doc.GetValue("username", "").AsString,
            }).ToList();

            allDocuments.AddRange(userList);

            if (allDocuments.Count == 0)
            {
                MessageBox.Show($"No records found with the provided UserIDs.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewName.DataSource = null;
                return;
            }

            dataGridViewName.DataSource = allDocuments;

            // Make UserID column read-only and set up event handlers
            if (dataGridViewName.Columns.Contains("UserID"))
            {
                var userIdColumn = dataGridViewName.Columns["UserID"];
                userIdColumn.ReadOnly = true;

                // Set the background color and forecolor to match the style in the provided image
                userIdColumn.DefaultCellStyle.BackColor = Color.LightGray;
                userIdColumn.DefaultCellStyle.ForeColor = Color.Gray;
            }

            dataGridViewName.CellMouseEnter += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dataGridViewName.Columns[e.ColumnIndex].Name == "UserID")
                {
                    dataGridViewName.Cursor = Cursors.No;
                }
            };

            dataGridViewName.CellMouseLeave += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dataGridViewName.Columns[e.ColumnIndex].Name == "UserID")
                {
                    dataGridViewName.Cursor = Cursors.Default;
                }
            };

            LockColumns(dataGridViewName);
            dataGridViewName.CellMouseEnter += DataGridView_CellMouseEnter;
            dataGridViewName.CellMouseLeave += DataGridView_CellMouseLeave;
        }


        public static void UpdateChangesToUsers(string dbName, DataGridView dataGridView, string collectionName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            LockColumns(dataGridView);
            bool isSuccess = true;
            int updatedCount = 0;  // Tracks number of successful updates
            int skippedCount = 0;  // Tracks number of skipped updates

            // Access the specified collection using collectionName
            var collection = database.GetCollection<BsonDocument>(collectionName);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var userId = row.Cells["UserID"].Value?.ToString();
                var username = row.Cells["Username"].Value?.ToString();

                // Check if userId and username are provided
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username)) continue;

                // Parse userId as ObjectId for filter
                if (!ObjectId.TryParse(userId, out var objectId))
                {
                    MessageBox.Show($"Invalid UserID format for row {row.Index + 1}. Skipping update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    skippedCount++;
                    continue;
                }

                // Check if the username is already used by another document
                var usernameFilter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("username", username),
                    Builders<BsonDocument>.Filter.Ne("userID", objectId) // Ensure userID is treated as ObjectId
                );

                var existingUser = collection.Find(usernameFilter).FirstOrDefault();
                if (existingUser != null)
                {
                    MessageBox.Show($"Username '{username}' is already used by another user. Update canceled for row {row.Index + 1}.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    skippedCount++;
                    continue; // Skip update for this row
                }

                // Define the filter to find the document by userID
                var filter = Builders<BsonDocument>.Filter.Eq("userID", objectId);

                // Build the update definition with necessary fields
                var update = Builders<BsonDocument>.Update
                    .Set("name", row.Cells["Name"].Value?.ToString())
                    .Set("username", username);

                try
                {
                    var result = collection.UpdateOne(filter, update);
                    if (result.ModifiedCount > 0)
                    {
                        updatedCount++;
                    }
                    else
                    {
                        MessageBox.Show($"No document with UserID {userId} was updated. It may not exist in the database.", "Update Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        skippedCount++;
                    }
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    MessageBox.Show($"Error updating UserID {userId}: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    skippedCount++;
                }
            }

            // Summary message after processing all rows
            if (isSuccess)
            {
                MessageBox.Show($"{updatedCount} record(s) updated successfully.\n{skippedCount} record(s) skipped due to errors or warnings.", "Update Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Some updates failed.\n{updatedCount} record(s) updated successfully.\n{skippedCount} record(s) skipped due to errors or warnings.", "Update Summary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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





        public static async Task TransferDocumentBySerialNo(string dbName, string transferColl, string serialNos, string notes)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

            // Split the input by commas and trim spaces
            var serialNoList = serialNos.Split(',')
                                        .Select(s => s.Trim())
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .ToList();

            if (serialNoList.Count == 0)
            {
                MessageBox.Show("Please provide valid SerialNo(s).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var successfulTransfers = new List<string>();
            var failedTransfers = new List<string>();

            foreach (var serialNo in serialNoList)
            {
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
                        // Conditionally add the "OldLocation" field to the document
                        var exemptLocations = new[] { "Repairing", "Cleaning", "Disposed_Hardwares", "Borrowed_Hardwares", "Delete", "Images" };

                        if (!exemptLocations.Contains(sourceCollectionName))
                        {
                            document["OldLocation"] = sourceCollectionName;
                        }

                        // Add the "Notes" field to the document
                        document["Notes"] = notes;

                        // Insert the document into the transfer collection
                        var transferCollection = database.GetCollection<BsonDocument>(transferColl);
                        await transferCollection.InsertOneAsync(document);

                        // Delete the document from the source collection
                        var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
                        var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);
                        await sourceCollection.DeleteOneAsync(filter);

                        // Add to success list
                        successfulTransfers.Add(serialNo);
                    }
                    catch (Exception ex)
                    {
                        failedTransfers.Add($"{serialNo}: {ex.Message}");
                    }
                }
                else
                {
                    failedTransfers.Add($"{serialNo}: Not found in any collection.");
                }
            }

            // Display success message once
            if (successfulTransfers.Count > 0)
            {
                MessageBox.Show($"Documents with the following SerialNos were successfully transferred:\n{string.Join(", ", successfulTransfers)}", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Display failure message once
            if (failedTransfers.Count > 0)
            {
                MessageBox.Show($"The following SerialNos failed to transfer:\n{string.Join("\n", failedTransfers)}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async Task TransferDocumentBySerialNo(string dbName, string transferColl, string serialNos)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2" };

            var serialNoList = serialNos.Split(',')
                                        .Select(s => s.Trim())
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .ToList();

            if (serialNoList.Count == 0)
            {
                MessageBox.Show("Please provide valid SerialNo(s).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var successfulTransfers = new List<string>();
            var failedTransfers = new List<string>();

            foreach (var serialNo in serialNoList)
            {
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
                        var transferCollection = database.GetCollection<BsonDocument>(transferColl);
                        var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);

                        // Check if the document already exists in the target collection
                        var existingDocument = await transferCollection.Find(filter).FirstOrDefaultAsync();
                        if (existingDocument != null)
                        {
                            MessageBox.Show($"Done transferring, the serial number {serialNo} is already in the target collection.", "Transfer Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            await transferCollection.InsertOneAsync(document);

                            var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
                            await sourceCollection.DeleteOneAsync(filter);

                            successfulTransfers.Add(serialNo);
                        }
                    }
                    catch (Exception ex)
                    {
                        failedTransfers.Add($"{serialNo}: {ex.Message}");
                    }
                }
                else
                {
                    failedTransfers.Add($"{serialNo}: Not found in any collection.");
                }
            }

            if (successfulTransfers.Count > 0)
            {
                MessageBox.Show($"Documents with the following SerialNos were successfully transferred:\n{string.Join(", ", successfulTransfers)}", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (failedTransfers.Count > 0)
            {
                MessageBox.Show($"The following SerialNos failed to transfer:\n{string.Join("\n", failedTransfers)}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public static async Task TransferDocumentBySerialNo(string dbName, string transferColl, string serialNos, string notes, string name, string returnDate)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };

            var serialNoList = serialNos.Split(',')
                                        .Select(s => s.Trim())
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .ToList();

            if (serialNoList.Count == 0)
            {
                MessageBox.Show("Please provide valid SerialNo(s).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var successfulTransfers = new List<string>();
            var failedTransfers = new List<string>();

            foreach (var serialNo in serialNoList)
            {
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
                        document["OldLocation"] = sourceCollectionName;
                        document["Notes"] = notes;
                        document["Name"] = name;
                        document["ReturnDate"] = returnDate;

                        var transferCollection = database.GetCollection<BsonDocument>(transferColl);
                        await transferCollection.InsertOneAsync(document);

                        var sourceCollection = database.GetCollection<BsonDocument>(sourceCollectionName);
                        var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);
                        await sourceCollection.DeleteOneAsync(filter);

                        successfulTransfers.Add(serialNo);
                    }
                    catch (Exception ex)
                    {
                        failedTransfers.Add($"{serialNo}: {ex.Message}");
                    }
                }
                else
                {
                    failedTransfers.Add($"{serialNo}: Not found in any collection.");
                }
            }

            if (successfulTransfers.Count > 0)
            {
                MessageBox.Show($"Documents with the following SerialNos were successfully transferred:\n{string.Join(", ", successfulTransfers)}", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (failedTransfers.Count > 0)
            {
                MessageBox.Show($"The following SerialNos failed to transfer:\n{string.Join("\n", failedTransfers)}", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Join the SerialNos into a readable format, separated by new lines
                string serialNosDisplay = string.Join(", ", serialNos);

                // Show a MessageBox asking the user if they want to proceed
                var result = MessageBox.Show($"Do you want to proceed operation for this Serial No? \n{serialNosDisplay}", "Confirm Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks 'No', exit the method
                if (result == DialogResult.No)
                {
                    return;
                }

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
                MessageBox.Show("Operation completed.");
            }
            catch (Exception ex)
            {
                // Handle high-level errors (e.g., MongoDB connection issues)
                MessageBox.Show($"An error occurred during the retrieve operation: {ex.Message}");
                Console.WriteLine($"An error occurred during the retrieve operation: {ex}");
            }
        }

        // OVERLOADED METHOD
        public static async Task TransferManyUsingSerialNo(string dbName, List<string> serialNos, string targetCollectionName)
        {
            try
            {
                // Join the SerialNos into a readable format, separated by new lines
                string serialNosDisplay = string.Join(", ", serialNos);

                // Show a MessageBox asking the user if they want to proceed
                var result = MessageBox.Show($"Do you want to proceed operation for this Serial No? \n{serialNosDisplay}", "Confirm Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks 'No', exit the method
                if (result == DialogResult.No)
                {
                    return;
                }

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
                                                // Add or update the OldLocation field to store the original collection name
                                                document["OldLocation"] = collectionName;

                                                // Remove "Notes" field from the document if it exists
                                                if (document.Contains("Notes"))
                                                {
                                                    document.Remove("Notes");
                                                }

                                                // Ensure the target collection exists (based on the passed parameter)
                                                var targetCollection = database.GetCollection<BsonDocument>(targetCollectionName);

                                                // Insert the document into the target collection
                                                await targetCollection.InsertOneAsync(document);

                                                // Remove the document from the original collection
                                                var idFilter = Builders<BsonDocument>.Filter.Eq("_id", document["_id"]);
                                                await collection.DeleteOneAsync(idFilter);

                                                Console.WriteLine($"Document with SerialNo: {document["SerialNo"]} transferred to {targetCollectionName}");
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
                MessageBox.Show("Operation completed.");
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



        public static async Task showAllItemsInDb(string dbName, string collName, DataGridView dataGridName)
        {
            try
            {
                // Initialize MongoDB client and get the database and collection
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<Type_List_Items>(collName);

                // Fetch all documents from the collection
                var documents = await collection.Find(FilterDefinition<Type_List_Items>.Empty).ToListAsync();

                // Bind the documents to the DataGridView
                dataGridName.DataSource = documents;
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("The operation timed out. Please check your network connection or server status.\n" + ex.Message, "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MongoConnectionException ex)
            {
                MessageBox.Show("Failed to connect to the MongoDB server. Please check the connection string and server status.\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MongoCommandException ex)
            {
                MessageBox.Show("An error occurred while executing a MongoDB command. Please check your query or command.\n" + ex.Message, "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MongoException ex)
            {
                MessageBox.Show("An unexpected MongoDB error occurred.\n" + ex.Message, "MongoDB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.\n" + ex.Message, "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public static async Task<bool> CheckIfCollValueExists(string dbName, string collectionName, string fieldName, string valueToCheck)
        {
            var client = new MongoClient(DefaultConnectionString);  // Using your provided initialization
            var database = client.GetDatabase(dbName);

            // Access the specific collection
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Build the filter to check if a document has the field with the specific value
            var filter = Builders<BsonDocument>.Filter.Eq(fieldName, valueToCheck);

            // Check if there are any matching documents
            var matchingDocument = await collection.Find(filter).FirstOrDefaultAsync();

            // If a matching document is found, return true
            if (matchingDocument != null)
            {
                return true;
            }

            // If no matching document is found, return false
            return false;
        }


        //CONVERT IMG TO BYTE ARRAY
        public static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        //INSERT IMAGE TO DB
        public static async Task<bool> ImgInsertToDbAsync(string imagePath, string savingName, string dbName, string collName)
        {
            try
            {
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);
                var collection = database.GetCollection<BsonDocument>(collName);

                // Load the image from the specified path asynchronously
                Image image = await Task.Run(() => Image.FromFile(imagePath));

                // Convert the image to byte array asynchronously
                byte[] imageBytes = await Task.Run(() => ImageToByteArray(image));

                // Create a filter to check if a document with the same FileName already exists
                var filter = Builders<BsonDocument>.Filter.Eq("FileName", savingName);

                // Check if an existing document with the same FileName is present
                var existingDocument = await collection.Find(filter).FirstOrDefaultAsync();

                bool isOverwrite = false;  // Flag to track if an overwrite is happening

                if (existingDocument != null)
                {
                    // If an image with the same FileName exists, delete the old document
                    await collection.DeleteOneAsync(filter);
                    Console.WriteLine($"Existing image {savingName} deleted.");
                    isOverwrite = true;  // Set flag to true since an overwrite occurred
                }

                // Create a new MongoDB document to store the new image bytes and the image name
                var newDocument = new BsonDocument
                {
                    { "image", imageBytes },
                    { "FileName", savingName } // Store the custom image name
                };

                // Insert the new document into the collection asynchronously
                await collection.InsertOneAsync(newDocument);

                // Show the message box only if an overwrite occurred
                if (isOverwrite)
                {
                    MessageBox.Show($"Image {savingName} has been overwritten successfully.", "Overwrite Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Image {savingName} has been saved successfully.", "Overwrite Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Return true to indicate success
                return true;
            }
            catch (Exception ex)
            {
                // Log the error and return false to indicate failure
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }



        public static Task<Image> ByteArrayToImageAsync(byte[] byteArray)
        {
            return Task.Run(() =>
            {
                using (var ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            });
        }

        public static async Task ImgGetToPictureBoxAsync(string FileName, string dbName, string collName, PictureBox pictureBox)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collName);

            // Create a filter to find the document by FileName (as a string)
            var filter = Builders<BsonDocument>.Filter.Eq("FileName", FileName);

            // Asynchronously find the document
            var document = await collection.Find(filter).FirstOrDefaultAsync();

            if (document != null)
            {
                byte[] imageBytes = document["image"].AsByteArray;

                // Convert the byte array to an Image asynchronously and store it in the PictureBox
                pictureBox.Image = await ByteArrayToImageAsync(imageBytes);
            }
            else
            {
                pictureBox.Image = null; // Clear the PictureBox if no image is found
            }
        }

        public static async void SaveImageFromPictureBox(PictureBox pictureBox, string filePath, System.Drawing.Imaging.ImageFormat format)
        {
            if (pictureBox.Image != null)
            {
                try
                {
                    // Create a true copy of the image to avoid GDI+ errors and file locking issues
                    using (Bitmap bmp = new Bitmap(pictureBox.Image.Width, pictureBox.Image.Height))
                    {
                        // Draw the PictureBox image into the new Bitmap
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(pictureBox.Image, 0, 0, pictureBox.Image.Width, pictureBox.Image.Height);
                        }

                        // Save the bitmap copy to the specified file path in the desired format
                        bmp.Save(filePath, format);
                    }

                    MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the image: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No image to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static string OpenSaveFileDialog(string defaultFileName, string filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp|All Files|*.*")
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set default file name (optional)
                saveFileDialog.FileName = defaultFileName;

                // Set filter for file types
                saveFileDialog.Filter = filter;

                // Set the default extension for the file
                saveFileDialog.DefaultExt = "png"; // You can change this based on your preference

                // Show the dialog and get the result
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Return the selected file path
                    return saveFileDialog.FileName;
                }
            }

            // Return null if the user cancels or closes the dialog
            return null;
        }

        public static string SelectImageFromFileExplorer()
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only show image files (jpg, jpeg, png, bmp, gif)
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            // Set the title for the dialog
            openFileDialog.Title = "Select an Image";

            // Optionally set the initial directory (e.g., Desktop or any custom path)
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Show the dialog and check if a file was selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Return the selected image's file path
                return openFileDialog.FileName;
            }

            // Return null or an empty string if no file was selected
            return null;
        }

        public static string SelectFolderFromFileExplorer()
        {
            // Create an instance of FolderBrowserDialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Set the description for the dialog
                folderBrowserDialog.Description = "Select a folder to save files";

                // Optionally set the initial directory (e.g., Desktop or any custom path)
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Show the dialog and check if a folder was selected
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Return the selected folder's path
                    return folderBrowserDialog.SelectedPath;
                }
            }

            // Return null or an empty string if no folder was selected
            return null;
        }

        public static async Task<string> Get_LocationAsync(string dbName, string serialNoVal)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Split the input serial numbers by commas and remove any extra spaces
            var serialNoList = serialNoVal.Split(',').Select(s => s.Trim()).ToList();

            // Get all collection names asynchronously
            var collectionNames = await database.ListCollectionNamesAsync();
            var collectionNamesList = await collectionNames.ToListAsync();

            // Define the filter for multiple serial numbers
            var filter = Builders<BsonDocument>.Filter.In("SerialNo", serialNoList);

            // Iterate over each collection and apply the filter asynchronously
            foreach (var collectionName in collectionNamesList)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);
                var documents = await collection.Find(filter).ToListAsync();

                // If documents are found, return the collection name (location)
                if (documents.Count > 0)
                {
                    return collectionName;
                }
            }

            // Return null or an appropriate value if no document is found
            return null;
        }

        public static async Task ShowDocuContainsTextAsync(string dbName, DataGridView dataGridViewName, string CollNameFind)
        {
            // Connect to MongoDB using the provided connection string
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Exclude these collections
            var excludedCollections = new List<string> { "RecycleBin", "Deployment_Unit_List", "Type_List", "Deployment_Location_List", "Serial_List", "Images" };

            // Get all collection names from the database
            var collectionNames = await database.ListCollectionNames().ToListAsync();

            // Filter collections that contain the unitText and exclude the specified collections
            var matchingCollections = collectionNames
                .Where(collectionName => collectionName.Contains(CollNameFind) && !excludedCollections.Contains(collectionName))
                .ToList();

            // Initialize a list to store all documents
            var allDocuments = new List<Read_Model>();

            // Loop through each matching collection
            foreach (var collectionName in matchingCollections)
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Retrieve all documents from the collection
                var documents = await collection.Find(new BsonDocument()).ToListAsync();

                // Map BsonDocument results to Read_Model objects
                var mappedDocuments = documents.Select(doc => new Read_Model
                {
                    Type = doc.Contains("Type") ? doc["Type"].AsString : string.Empty,
                    Brand = doc.Contains("Brand") ? doc["Brand"].AsString : string.Empty,
                    Model = doc.Contains("Model") ? doc["Model"].AsString : string.Empty,
                    PropertyID = doc.Contains("PropertyID") ? doc["PropertyID"].AsString : string.Empty,
                    SerialNo = doc.Contains("SerialNo") ? doc["SerialNo"].AsString : string.Empty,
                    PONumber = doc.Contains("PONumber") ? doc["PONumber"].AsString : string.Empty,
                    SINumber = doc.Contains("SINumber") ? doc["SINumber"].AsString : string.Empty,
                    Cost = doc.Contains("Cost") ? doc["Cost"].AsString : string.Empty,
                    Warranty = doc.Contains("Warranty") ? doc["Warranty"].AsString : string.Empty,
                    Supplier = doc.Contains("Supplier") ? doc["Supplier"].AsString : string.Empty,

                    // Calculate warranty status if still valid
                    WarrantyStatus = MyCalculations.IsWarrantyValid(DateTime.Parse(doc["PurchaseDate"].AsString), doc["Warranty"].AsString) ? "In Warranty" : "Out of Warranty",

                    PurchaseDate = doc.Contains("PurchaseDate") ? doc["PurchaseDate"].AsString : string.Empty,

                    // Calculate usage as years, months, and days
                    Usage = doc.Contains("PurchaseDate") ? MyCalculations.CalculateUsage(DateTime.Parse(doc["PurchaseDate"].AsString)) : string.Empty,

                    // Set the collection name as location
                    Location = collectionName
                }).ToList();

                allDocuments.AddRange(mappedDocuments);
            }

            // If no documents were found, clear the DataGridView and notify the user
            if (allDocuments.Count == 0)
            {
                dataGridViewName.DataSource = null;
                MessageBox.Show("No documents found in any matching collection.");
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }

        public static async Task EnsureSuperAdminExistsAsync(string dbName, string collName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var usersCollection = database.GetCollection<BsonDocument>(collName);

            // Filter to find a document with role "SuperAdmin"
            var filter = Builders<BsonDocument>.Filter.Eq("role", "Super Admin");
            var superAdmin = await usersCollection.Find(filter).FirstOrDefaultAsync();

            // If no document with role "SuperAdmin" is found, create one with placeholder values
            if (superAdmin == null)
            {
                string encrypted = MyOtherMethods.EncryptPassword("SuperAdmin123");

                var defaultSuperAdmin = new BsonDocument
                {
                    { "_id", ObjectId.GenerateNewId() }, // Automatically generated ObjectId
                    { "name", "NotSet" },
                    { "username", "SuperAdmin" },
                    { "password", $"{encrypted}" },
                    { "role", "Super Admin" },
                    { "userID", ObjectId.GenerateNewId() } // Assigning userID as a new ObjectId for uniqueness
                };

                await usersCollection.InsertOneAsync(defaultSuperAdmin);
            }
        }

        public static async Task<UserDetails> GetUserDetailsAsync(string dbName, string collName, string username, string password)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var usersCollection = database.GetCollection<BsonDocument>(collName);

            // Build the filter for username and password
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("username", username),
                Builders<BsonDocument>.Filter.Eq("password", password)
            );

            // Search for the document with the specified username and password
            var userDocument = await usersCollection.Find(filter).FirstOrDefaultAsync();

            if (userDocument != null)
            {
                // Initialize a new UserDetails instance to store retrieved data
                var userDetails = new UserDetails
                {
                    Name = userDocument.Contains("name") ? userDocument["name"].AsString : null,
                    Username = userDocument.Contains("username") ? userDocument["username"].AsString : null,
                    Role = userDocument.Contains("role") ? userDocument["role"].AsString : null,
                    UserID = userDocument.Contains("userID") ? userDocument["userID"].ToString() : null // Convert to string
                };

                return userDetails; // Return the populated UserDetails object
            }

            // Return null if the user was not found
            return null;
        }

        public class UserDetails
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Role { get; set; }
            public string? UserID { get; set; } // Nullable string to handle missing values
        }


        public static void ReadManageUsers(string dbName, DataGridView dataGridViewName, string collectionName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Get the specified collection by name
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Retrieve all documents from the collection (you can add filters if needed)
            var documents = collection.Find(new BsonDocument()).ToList();

            var allDocuments = documents.Select(doc => new
            {
                // Aligning fields in the specified order
                UserID = doc.Contains("userID")
                         ? (doc["userID"].BsonType == BsonType.ObjectId
                            ? doc["userID"].AsObjectId.ToString()
                            : doc["userID"].AsString)
                         : string.Empty,

                Name = doc.Contains("name") && doc["name"].IsString ? doc["name"].AsString : string.Empty,
                Username = doc.Contains("username") && doc["username"].IsString ? doc["username"].AsString : string.Empty,
                //Password = doc.Contains("password") && doc["password"].IsString ? doc["password"].AsString : string.Empty,
                Role = doc.Contains("role") && doc["role"].IsString ? doc["role"].AsString : string.Empty
            }).ToList<object>();

            if (allDocuments.Count == 0)
            {
                // Optionally, clear the DataGridView or set it to an empty state
                dataGridViewName.DataSource = null;
                return;
            }

            // Bind the list to the DataGridView
            dataGridViewName.DataSource = allDocuments;
        }



        public static async Task<bool> UpsertDocumentAsync(string dbName, string collectionName, string userId, Dictionary<string, string> fields)
        {
            /*
            Console.WriteLine("Fields to upsert:");
            foreach (var field in fields)
            {
                Console.WriteLine($"Key: {field.Key}, Value: {field.Value}");
            }
            */

            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            var filter = Builders<BsonDocument>.Filter.Eq("userID", userId);
            var update = new BsonDocument("$set", new BsonDocument(fields));

            //Console.WriteLine($"Filter: {filter.ToJson()}");
            //Console.WriteLine($"Update Document: {update.ToJson()}");

            try
            {
                // Perform the upsert operation
                var result = await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

                //Console.WriteLine($"MatchedCount: {result.MatchedCount}, ModifiedCount: {result.ModifiedCount}, UpsertedId: {result.UpsertedId}");

                // Success if matched, modified, or inserted
                return result.MatchedCount > 0 || result.UpsertedId != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in upsert operation: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        // Method to check if a username already exists in the Users collection
        public static async Task<bool> IsUsernameAlreadyUsed(string dbName, string collName, string username)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collName);

            // Define a filter to search for the given username
            var filter = Builders<BsonDocument>.Filter.Eq("username", username);

            // Check if any documents match the filter
            var existingUser = await collection.Find(filter).FirstOrDefaultAsync();

            // Return true if a user is found, otherwise false
            return existingUser != null;
        }

        public static async Task UpdateFieldAsync(string dbName, string collectionName, string userId, string fieldName, string fieldValue)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Parse userId as ObjectId
            if (!ObjectId.TryParse(userId, out var objectId))
            {
                MessageBox.Show("Invalid UserID format.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define the filter to target the specific document by userID
            var filter = Builders<BsonDocument>.Filter.Eq("userID", objectId);

            // Define the update operation for the specified field
            var update = Builders<BsonDocument>.Update.Set(fieldName, fieldValue);

            try
            {
                // Perform the update operation
                var result = await collection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount == 0)
                {
                    MessageBox.Show("No document was updated. It may not exist in the database.", "Update Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Successfull.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating field: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        public static async Task<Dictionary<string, string>> RetrievePermissionsAsync(string dbName, string collectionName, string userId)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Parse userId as ObjectId for filter
            if (!ObjectId.TryParse(userId, out var objectId))
            {
                Console.WriteLine("Invalid UserID format.");
                return null;
            }

            // Define the filter to target the specific document by userID
            var filter = Builders<BsonDocument>.Filter.Eq("userID", objectId);

            // Retrieve the document from MongoDB
            var document = await collection.Find(filter).FirstOrDefaultAsync();

            if (document == null)
            {
                Console.WriteLine("No document found with the specified UserID.");
                return null;
            }

            // Initialize the permissions dictionary
            var permissions = new Dictionary<string, string>();

            // Loop through each element in the document and add it to the dictionary
            foreach (var element in document.Elements)
            {
                // Exclude system fields like "_id" if necessary
                if (element.Name != "_id" && element.Name != "userID")
                {
                    permissions[element.Name] = element.Value.ToString();
                }
            }

            return permissions;
        }



        public static async Task RemoveDocumentAsync(string dbName, string collectionName, string userId)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Define the filter to target the specific document by userID as a string
            var filter = Builders<BsonDocument>.Filter.Eq("userID", userId);

            try
            {
                // Perform the delete operation
                var deleteResult = await collection.DeleteOneAsync(filter);

                if (deleteResult.DeletedCount == 0)
                {
                    Console.WriteLine("No document found to delete. It may not exist in the database.");
                }
                else
                {
                    Console.WriteLine("Document successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting document: {ex.Message}");
            }
        }

        //OVERLOADING METHOD REMOVE ANY DOCUMENT WITH 
        public static async Task RemoveDocumentAsync(string dbName, string collectionName, string fieldName, string value)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Define the filter to target the specific document by userID as a string
            var filter = Builders<BsonDocument>.Filter.Eq($"{fieldName}", value);

            try
            {
                // Perform the delete operation
                var deleteResult = await collection.DeleteOneAsync(filter);

                if (deleteResult.DeletedCount == 0)
                {
                    Console.WriteLine("No document found to delete. It may not exist in the database.");
                }
                else
                {
                    Console.WriteLine("Document successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting document: {ex.Message}");
            }
        }


        public class UserPermissions
        {
            public string UserID { get; set; }
            public bool Add { get; set; }
            public bool Archive { get; set; }
            public bool Archived { get; set; }
            public bool ArtificialIntelligence { get; set; }
            public bool AssetHistory { get; set; }
            public bool Assets { get; set; }
            public bool BackupAndRestoreData { get; set; }
            public bool Borrow { get; set; }
            public bool Borrowed { get; set; }
            public bool Cleaning { get; set; }
            public bool CreateReport { get; set; }
            public bool Dashboard { get; set; }
            public bool Disposed { get; set; }
            public bool Edit { get; set; }
            public bool Replace { get; set; }
            public bool Replacement { get; set; }
            public bool Reserved { get; set; }
            public bool ShowImage { get; set; }
            public bool Transfer { get; set; }
        }

        public static async Task<UserPermissions> GetPermissionsAsync(string dbName, string collectionName, string userId)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<UserPermissions>(collectionName);

            Console.WriteLine($"Searching for userID: {userId} in database: {dbName}, collection: {collectionName}");

            // Define the filter to target the document by userID as a string
            var filter = Builders<UserPermissions>.Filter.Eq("userID", userId);

            try
            {
                // Retrieve the document with the specified filter
                var document = await collection.Find(filter).FirstOrDefaultAsync();

                if (document == null)
                {
                    Console.WriteLine("No document found with the specified userID.");
                }
                else
                {
                    Console.WriteLine("Document found.");
                }

                return document;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving permissions: {ex.Message}");
                return null;
            }
        }

        public static async Task<bool> ValidateUserUsingUserID(string dbName, string collName, string userId, string password)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var usersCollection = database.GetCollection<BsonDocument>(collName);

            // Parse userId as ObjectId
            if (!ObjectId.TryParse(userId, out var objectId))
            {
                Console.WriteLine("Invalid UserID format.");
                return false;
            }

            Console.WriteLine($"Parsed ObjectId: {objectId}");

            // Build the filter for userID and password
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("userID", objectId),
                Builders<BsonDocument>.Filter.Eq("password", password)
            );

            Console.WriteLine($"Filter: userID = {objectId}, password = {password}");

            // Check if a document with the specified userID and password exists
            var userDocument = await usersCollection.Find(filter).FirstOrDefaultAsync();

            if (userDocument != null)
            {
                Console.WriteLine("Document found.");
                return true;
            }
            else
            {
                Console.WriteLine("No document found with the specified userID and password.");
                return false;
            }
        }




        public static async Task<bool> DeleteUserByUserIDAsync(string dbName, string collName, string userId)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var usersCollection = database.GetCollection<BsonDocument>(collName);

            // Parse userId as ObjectId
            if (!ObjectId.TryParse(userId, out var objectId))
            {
                Console.WriteLine("Invalid UserID format.");
                return false;
            }

            // Build the filter for userID
            var filter = Builders<BsonDocument>.Filter.Eq("userID", objectId);


            try
            {
                // Attempt to delete the document with the specified userID
                var deleteResult = await usersCollection.DeleteOneAsync(filter);

                if (deleteResult.DeletedCount > 0)
                {
                    MessageBox.Show("Document successfully deleted.");
                    return true;
                }
                else
                {
                    MessageBox.Show("No document found with the specified userID.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting document: {ex.Message}");
                return false;
            }
        }


        public static async Task BatchUploadFromExcelAsync(string filePath)
        {
            try
            {
                // Initialize ExcelDataReader encoding provider
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase("SmartAssetDb");
                var reservedHardwareCollection = database.GetCollection<BsonDocument>("Reserved_Hardwares");
                var serialListCollection = database.GetCollection<BsonDocument>("Serial_List");
                var typeListCollection = database.GetCollection<BsonDocument>("Type_List");

                // Fetch the valid types from the Type_List collection
                var validTypes = await FetchValidTypesAsync(typeListCollection);

                // Fetch existing serial numbers from Serial_List
                var existingSerialNumbers = await FetchExistingSerialNumbersAsync(serialListCollection);
                var existingPropertyIDs = await FetchExistingPropertyIDsAsync(reservedHardwareCollection);
                var existingSINumbers = await FetchExistingSINumbersAsync(reservedHardwareCollection);

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var table = result.Tables[0];

                        var headers = new List<string>();
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            headers.Add(table.Rows[0][i].ToString());
                        }

                        var documents = new List<BsonDocument>();
                        var serialDocuments = new List<BsonDocument>();

                        // HashSets to track duplicates within the same Excel file
                        var serialNumbersSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        var propertyIDsSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        var siNumbersSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            var document = new BsonDocument();
                            string serialNo = string.Empty;
                            string propertyID = string.Empty;
                            string siNumber = string.Empty;

                            for (int j = 0; j < headers.Count; j++)
                            {
                                string header = headers[j];
                                string value = table.Rows[i][j]?.ToString() ?? string.Empty;

                                // Convert Type, Brand, Model, PropertyID to uppercase
                                if (header.Equals("Type", StringComparison.OrdinalIgnoreCase))
                                {
                                    value = value.ToUpper();
                                    value = CorrectType(value, validTypes);
                                    if (string.IsNullOrEmpty(value))
                                    {
                                        MessageBox.Show($"Invalid Type at row {i + 1}. It must match the Type_List collection.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (header.Equals("Brand", StringComparison.OrdinalIgnoreCase) ||
                                         header.Equals("Model", StringComparison.OrdinalIgnoreCase) ||
                                         header.Equals("PropertyID", StringComparison.OrdinalIgnoreCase))
                                {
                                    value = value.ToUpper();
                                }

                                // Validate PONumber and SINumber (numeric only)
                                if ((header.Equals("PONumber", StringComparison.OrdinalIgnoreCase) ||
                                     header.Equals("SINumber", StringComparison.OrdinalIgnoreCase)) &&
                                     !Regex.IsMatch(value, @"^\d+$"))
                                {
                                    MessageBox.Show($"Invalid value for {header} at row {i + 1}. Only numeric values are allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Validate the Cost field (numeric with one optional dot)
                                if (header.Equals("Cost", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (!Regex.IsMatch(value, @"^\d+(\.\d{1,2})?$"))
                                    {
                                        MessageBox.Show($"Invalid Cost at row {i + 1}. Only numbers and one optional decimal point are allowed (e.g., 12345.67).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                // Validate and correct Warranty format
                                if (header.Equals("Warranty", StringComparison.OrdinalIgnoreCase))
                                {
                                    value = CorrectWarrantyFormat(value);
                                }

                                // Validate and format PurchaseDate
                                if (header.Equals("PurchaseDate", StringComparison.OrdinalIgnoreCase))
                                {
                                    value = CorrectPurchaseDateFormat(value);
                                    if (string.IsNullOrEmpty(value))
                                    {
                                        MessageBox.Show($"Invalid PurchaseDate at row {i + 1}. Please check the date format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                // Check for duplicate SerialNo
                                if (header.Equals("SerialNo", StringComparison.OrdinalIgnoreCase))
                                {
                                    serialNo = value.ToUpper();
                                    if (existingSerialNumbers.Contains(serialNo) || !serialNumbersSet.Add(serialNo))
                                    {
                                        MessageBox.Show($"Duplicate SerialNo '{serialNo}' found at row {i + 1}.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    value = serialNo;
                                }

                                // Check for duplicate PropertyID
                                if (header.Equals("PropertyID", StringComparison.OrdinalIgnoreCase))
                                {
                                    propertyID = value.ToUpper();
                                    if (existingPropertyIDs.Contains(propertyID) || !propertyIDsSet.Add(propertyID))
                                    {
                                        MessageBox.Show($"Duplicate PropertyID '{propertyID}' found at row {i + 1}.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    value = propertyID;
                                }

                                // Check for duplicate SINumber
                                if (header.Equals("SINumber", StringComparison.OrdinalIgnoreCase))
                                {
                                    siNumber = value;
                                    if (existingSINumbers.Contains(siNumber) || !siNumbersSet.Add(siNumber))
                                    {
                                        MessageBox.Show($"Duplicate SINumber '{siNumber}' found at row {i + 1}.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                document[header] = value;
                            }

                            // Removed "Location" field as requested
                            document["DateThisAdded"] = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

                            documents.Add(document);
                            if (!string.IsNullOrWhiteSpace(serialNo))
                            {
                                var serialDocument = new BsonDocument { { "Serial", serialNo } };
                                serialDocuments.Add(serialDocument);
                            }
                        }

                        await reservedHardwareCollection.InsertManyAsync(documents);
                        await serialListCollection.InsertManyAsync(serialDocuments);
                    }
                }

                MessageBox.Show("Batch upload completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during batch upload: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static async Task<HashSet<string>> FetchExistingPropertyIDsAsync(IMongoCollection<BsonDocument> reservedHardwareCollection)
        {
            var existingPropertyIDs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var documents = await reservedHardwareCollection.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in documents)
            {
                if (doc.Contains("PropertyID"))
                {
                    existingPropertyIDs.Add(doc["PropertyID"].AsString.ToUpper());
                }
            }

            return existingPropertyIDs;
        }

        private static async Task<HashSet<string>> FetchExistingSINumbersAsync(IMongoCollection<BsonDocument> reservedHardwareCollection)
        {
            var existingSINumbers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var documents = await reservedHardwareCollection.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in documents)
            {
                if (doc.Contains("SINumber"))
                {
                    existingSINumbers.Add(doc["SINumber"].AsString);
                }
            }

            return existingSINumbers;
        }

        private static async Task<HashSet<string>> FetchExistingSerialNumbersAsync(IMongoCollection<BsonDocument> serialListCollection)
        {
            var existingSerialNumbers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var documents = await serialListCollection.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in documents)
            {
                if (doc.Contains("Serial"))
                {
                    existingSerialNumbers.Add(doc["Serial"].AsString.ToUpper());
                }
            }

            return existingSerialNumbers;
        }


        private static async Task<Dictionary<string, string>> FetchValidTypesAsync(IMongoCollection<BsonDocument> typeListCollection)
        {
            var validTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var documents = await typeListCollection.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in documents)
            {
                if (doc.Contains("List"))
                {
                    string type = doc["List"].AsString;
                    validTypes[type.ToUpper()] = type;
                }
            }

            return validTypes;
        }

        private static string CorrectWarrantyFormat(string warranty)
        {
            warranty = warranty.Trim().ToLower().Replace(",", "").Replace("and", "").Replace("only", "");

            var yearMatch = Regex.Match(warranty, @"(\d+)\s*(y|year|years|yr)");
            var monthMatch = Regex.Match(warranty, @"(\d+)\s*(m|month|months|mos)");
            var dayMatch = Regex.Match(warranty, @"(\d+)\s*(d|day|days|ds)");

            int years = yearMatch.Success ? int.Parse(yearMatch.Groups[1].Value) : 0;
            int months = monthMatch.Success ? int.Parse(monthMatch.Groups[1].Value) : 0;
            int days = dayMatch.Success ? int.Parse(dayMatch.Groups[1].Value) : 0;

            return $"years:{years} months:{months} days:{days}";
        }

        private static string CorrectType(string input, Dictionary<string, string> validTypes)
        {
            return validTypes.TryGetValue(input.ToUpper(), out string correctedType) ? correctedType : string.Empty;
        }

        private static string CorrectPurchaseDateFormat(string input)
        {
            if (DateTime.TryParse(input, out DateTime parsedDate))
            {
                // Format the date as "Friday, November 1, 2019"
                return parsedDate.ToString("dddd, MMMM dd, yyyy");
            }

            return string.Empty; // Return empty if the date cannot be parsed
        }

        public static async Task TransferSerialNoToLocation(string dbName, string targetLocation, string serialNoFrom, string notes)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var targetCollection = database.GetCollection<BsonDocument>(targetLocation);

            // Find the document for 'SerialNoFrom'
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };
            var documentFrom = await FindDocumentBySerialNo(database, serialNoFrom, excludeCollections);

            if (documentFrom == null)
            {
                MessageBox.Show($"SerialNo '{serialNoFrom}' not found in any collection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                documentFrom["OldLocation"] = targetLocation;
                documentFrom["Notes"] = notes;

                // Insert the document into the target collection
                await targetCollection.InsertOneAsync(documentFrom);

                // Delete the original document from its source collection
                var originalCollection = database.GetCollection<BsonDocument>(documentFrom["OldLocation"].AsString);
                var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNoFrom);
                await originalCollection.DeleteOneAsync(filter);

                //MessageBox.Show($"SerialNo '{serialNoFrom}' was successfully transferred to location '{targetLocation}'.", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error during transfer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task MoveToReplacement(string dbName, string serialNoTo, string notes)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var replacementCollection = database.GetCollection<BsonDocument>("Replacement");

            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };
            var documentTo = await FindDocumentBySerialNo(database, serialNoTo, excludeCollections);

            if (documentTo == null)
            {
                MessageBox.Show($"SerialNo '{serialNoTo}' not found in any collection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                documentTo["Notes"] = notes;

                // Insert into the "Replacement" collection
                await replacementCollection.InsertOneAsync(documentTo);

                // Delete from the original collection
                var originalCollection = database.GetCollection<BsonDocument>(documentTo["OldLocation"].AsString);
                var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNoTo);
                await originalCollection.DeleteOneAsync(filter);

                MessageBox.Show($"SerialNo '{serialNoTo}' was successfully moved to the 'Replacement' collection.", "Replacement Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving to Replacement: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<BsonDocument> FindDocumentBySerialNo(IMongoDatabase database, string serialNo, string[] excludeCollections)
        {
            // Iterate through all collection names in the database
            using (var cursor = await database.ListCollectionNamesAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var collectionName in cursor.Current)
                    {
                        // Skip excluded collections
                        if (!excludeCollections.Contains(collectionName))
                        {
                            var collection = database.GetCollection<BsonDocument>(collectionName);
                            var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNo);

                            // Search for the document by SerialNo
                            var document = await collection.Find(filter).FirstOrDefaultAsync();
                            if (document != null)
                            {
                                // Store the original collection name in the document
                                document["OldLocation"] = collectionName;
                                return document;
                            }
                        }
                    }
                }
            }

            // Return null if the document is not found
            return null;
        }

        public static async Task TransferAndDeleteOriginal(string dbName, string targetLocation, string serialNoFrom, string notes)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var targetCollection = database.GetCollection<BsonDocument>(targetLocation);

            // Find the document for 'serialNoFrom'
            var excludeCollections = new[] { "ExceptColl", "ExceptColl2", "ExceptColl3" };
            var documentFrom = await FindDocumentBySerialNo(database, serialNoFrom, excludeCollections);

            if (documentFrom == null)
            {
                MessageBox.Show($"SerialNo '{serialNoFrom}' not found in any collection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Update the document fields
                documentFrom["OldLocation"] = targetLocation;
                documentFrom["Notes"] = notes;

                // Insert the document into the target collection
                await targetCollection.InsertOneAsync(documentFrom);

                // Delete the original document from its source collection
                var originalCollection = database.GetCollection<BsonDocument>(documentFrom["OldLocation"].AsString);
                var filter = Builders<BsonDocument>.Filter.Eq("SerialNo", serialNoFrom);
                await originalCollection.DeleteOneAsync(filter);

                MessageBox.Show($"SerialNo '{serialNoFrom}' was successfully transferred to location '{targetLocation}' and deleted from its original collection.", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during transfer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void ChangePassword(string dbName, string collectionName, string username_Tb, string currentPassword_Tb, string newPassword_Tb, string repeatPassword_Tb)
        {
            // Input validation: Check if any TextBox is null or empty
            if (string.IsNullOrWhiteSpace(username_Tb) ||
                string.IsNullOrWhiteSpace(currentPassword_Tb) ||
                string.IsNullOrWhiteSpace(newPassword_Tb) ||
                string.IsNullOrWhiteSpace(repeatPassword_Tb))
            {
                MessageBox.Show("All fields are required. Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if new password matches repeat password
            if (newPassword_Tb != repeatPassword_Tb)
            {
                MessageBox.Show("New password and repeat password do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize MongoDB client and collection
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);
            var targetCollection = database.GetCollection<BsonDocument>(collectionName);

            // Find the user document by username
            var filter = Builders<BsonDocument>.Filter.Eq("username", username_Tb);
            var userDocument = targetCollection.Find(filter).FirstOrDefault();

            // Check if the user was found
            if (userDocument == null)
            {
                MessageBox.Show("User not found in the specified collection.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Decrypt the stored password
            string storedEncryptedPassword = userDocument["password"].AsString;
            string decryptedPassword;

            try
            {
                decryptedPassword = MyOtherMethods.DecryptPassword(storedEncryptedPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during password decryption: {ex.Message}", "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the current password matches
            if (currentPassword_Tb != decryptedPassword)
            {
                MessageBox.Show("Current password is incorrect.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Encrypt the new password
            string encryptedNewPassword;
            try
            {
                encryptedNewPassword = MyOtherMethods.EncryptPassword(newPassword_Tb);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during password encryption: {ex.Message}", "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the password in the collection
            var update = Builders<BsonDocument>.Update.Set("password", encryptedNewPassword);

            try
            {
                targetCollection.UpdateOne(filter, update);
                MessageBox.Show("Password successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating the password in the database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private static readonly HashSet<string> ExcludedCollections = new HashSet<string>
        {
            "Deployment_Unit_List",
            "Type_List",
            "Deployment_Location_List",
            "Serial_List",
            "Images",
            "Users",
            "CustomUsers_Permissions"
        };

        public static async Task<List<BsonDocument>> ReadAllDatabaseInBSON(string dbName)
        {
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbName);

            // Create a list to hold all documents from all collections
            var allDocuments = new List<BsonDocument>();

            // Get all collection names using IAsyncCursor and convert to a list
            var collectionNamesCursor = await database.ListCollectionNamesAsync();
            var collectionNames = await collectionNamesCursor.ToListAsync();

            // Iterate over all collections, except the excluded ones
            foreach (var collectionName in collectionNames)
            {
                if (ExcludedCollections.Contains(collectionName))
                    continue;

                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Retrieve all documents from the current collection asynchronously
                var documents = await collection.Find(new BsonDocument()).ToListAsync();

                // Add the collection name to each document and include required fields
                foreach (var doc in documents)
                {
                    var resultDoc = new BsonDocument
                    {
                        { "_id", doc.GetValue("_id", BsonNull.Value) },
                        { "Type", doc.GetValue("Type", BsonNull.Value) },
                        { "Brand", doc.GetValue("Brand", BsonNull.Value) },
                        { "Model", doc.GetValue("Model", BsonNull.Value) },
                        { "PropertyID", doc.GetValue("PropertyID", BsonNull.Value) },
                        { "SerialNo", doc.GetValue("SerialNo", BsonNull.Value) },
                        { "PONumber", doc.GetValue("PONumber", BsonNull.Value) },
                        { "SINumber", doc.GetValue("SINumber", BsonNull.Value) },
                        { "Cost", doc.GetValue("Cost", BsonNull.Value) },
                        { "Warranty", doc.GetValue("Warranty", BsonNull.Value) },
                        { "Supplier", doc.GetValue("Supplier", BsonNull.Value) },
                        { "PurchaseDate", doc.GetValue("PurchaseDate", BsonNull.Value) },
                        { "DateThisAdded", doc.GetValue("DateThisAdded", BsonNull.Value) },
                        { "CurrentLocation", collectionName }
                    };

                    allDocuments.Add(resultDoc);
                }
            }


            // Print all documents in JSON format
            /*
            foreach (var doc in allDocuments)
            {
                Console.WriteLine(doc.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));
            }
            */

            return allDocuments;

        }



        public static Dictionary<string, string> GetPermissions(string dbNameVal, string collNameVal, string userIDVal)
        {
            // Initialize MongoDB client and access database and collection
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbNameVal);
            var collection = database.GetCollection<BsonDocument>(collNameVal);

            // Filter to find the document with the specified userID
            var filter = Builders<BsonDocument>.Filter.Eq("userID", userIDVal);
            var document = collection.Find(filter).FirstOrDefault();

            if (document == null)
            {
                throw new Exception("User not found.");
            }

            // Create a dictionary to store the permissions
            var permissions = new Dictionary<string, string>();

            // Loop through the desired fields and add them to the dictionary
            foreach (var field in document)
            {
                if (field.Name == "Add" || field.Name == "Archive" || field.Name == "Archived" ||
                    field.Name == "ArtificialIntelligence" || field.Name == "AssetHistory" ||
                    field.Name == "Assets" || field.Name == "BackupAndRestoreData" ||
                    field.Name == "Borrow" || field.Name == "Borrowed" || field.Name == "Cleaning" ||
                    field.Name == "CreateReport" || field.Name == "Dashboard" ||
                    field.Name == "Disposed" || field.Name == "Edit" ||
                    field.Name == "Replace" || field.Name == "Replacement" ||
                    field.Name == "Reserved" || field.Name == "ShowImage" || field.Name == "Transfer")
                {
                    permissions[field.Name] = field.Value.ToString();
                }
            }

            return permissions;
        }













        public static void UpdateCheckBoxes(string dbNameVal, string collNameVal, string userIDVal, Form form)
        {
            // Initialize MongoDB client and access database and collection
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbNameVal);
            var collection = database.GetCollection<BsonDocument>(collNameVal);

            // Retrieve the document using userID
            var filter = Builders<BsonDocument>.Filter.Eq("userID", userIDVal);
            var document = collection.Find(filter).FirstOrDefault();

            if (document == null)
            {
                MessageBox.Show("No permissions found for the given userID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Iterate through each field in the document
            foreach (var field in document)
            {
                // Skip system fields (_id and userID)
                if (field.Name == "_id" || field.Name == "userID") continue;

                // Get the corresponding CheckBox by name
                var checkBoxName = $"{field.Name}_Cb";
                var checkBox = form.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;

                if (checkBox != null)
                {
                    // Update the CheckBox state based on the value
                    checkBox.Checked = field.Value.ToString() == "1";
                }
            }

            // Handle the visibility and state of assetEnabled_Panel
            var assetsCheckBox = form.Controls.Find("assets_Cb", true).FirstOrDefault() as CheckBox;
            var assetEnabledPanel = form.Controls.Find("assetEnabled_Panel", true).FirstOrDefault() as Panel;

            if (assetsCheckBox != null && assetEnabledPanel != null)
            {
                if (assetsCheckBox.Checked)
                {
                    assetEnabledPanel.Visible = true;
                }
                else
                {
                    // Disable all child CheckBoxes in assetEnabled_Panel
                    foreach (Control control in assetEnabledPanel.Controls)
                    {
                        if (control is CheckBox cb)
                        {
                            cb.Checked = false;
                        }
                    }

                    assetEnabledPanel.Visible = false;
                }
            }
        }


        public static async Task<bool> CheckDocumentExistsAsync_ForLocationList(string dbNameVal, string item)
        {
            // Initialize MongoDB client and access the database
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbNameVal);

            // Get all collection names in the database
            var collections = await database.ListCollectionNamesAsync();
            var collectionList = await collections.ToListAsync();

            foreach (var collectionName in collectionList)
            {
                // Check if the collection name matches exactly before '_'
                if (collectionName.Contains("_"))
                {
                    var prefix = collectionName.Split('_')[0]; // Get the part before '_'
                    if (prefix == item)
                    {
                        // Access the collection
                        var collection = database.GetCollection<BsonDocument>(collectionName);

                        // Check if the collection contains any documents
                        var count = await collection.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty);
                        if (count > 0)
                        {
                            return true; // Collection exists and contains documents
                        }
                    }
                }
            }

            return false; // No matching collection name found or no documents inside
        }


        public static async Task<bool> CheckDocumentExistsAsync_ForUnitList(string dbNameVal, string item)
        {
            // Initialize MongoDB client and access the database
            var client = new MongoClient(DefaultConnectionString);
            var database = client.GetDatabase(dbNameVal);

            // Get all collection names in the database
            var collections = await database.ListCollectionNamesAsync();
            var collectionList = await collections.ToListAsync();

            foreach (var collectionName in collectionList)
            {
                // Check if the collection name contains '_'
                if (collectionName.Contains("_"))
                {
                    var suffix = collectionName.Split('_').Last(); // Get the part after the last '_'
                    if (suffix == item) // Match the text after '_'
                    {
                        // Access the collection
                        var collection = database.GetCollection<BsonDocument>(collectionName);

                        // Check if the collection contains any documents
                        var count = await collection.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty);
                        if (count > 0)
                        {
                            return true; // Collection exists and contains documents
                        }
                    }
                }
            }

            return false; // No matching collection name found or no documents inside
        }











        public class ProgressDialog : Form
        {
            private Label progressLabel;

            public ProgressDialog()
            {
                this.Text = "Backup Progress";
                this.Size = new System.Drawing.Size(400, 150);
                this.StartPosition = FormStartPosition.CenterScreen;

                progressLabel = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Text = "Starting backup..."
                };

                this.Controls.Add(progressLabel);
            }

            public void UpdateProgress(string message)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<string>(UpdateProgress), message);
                }
                else
                {
                    progressLabel.Text = message;
                }
            }
        }



        public static async Task CreateBackup(string dbName, string path)
        {
            try
            {
                // Validate the user's password with retry mechanism
                bool isPasswordValid = await ValidatePasswordWithRetry(FrontPage_Final.StaticUserID.Text, "SmartAssetDb", "Users");
                if (!isPasswordValid)
                {
                    ShowCustomMessageBox("Password validation failed. Backup aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ShowCustomMessageBox("Password validated successfully. Proceeding with backup creation...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ensure the path ends with a directory separator
                if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    path += Path.DirectorySeparatorChar;
                }

                // Create a timestamp for the backup
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

                // Prompt the user to create a password for the backup file
                string backupPassword = PromptPassword("Set a Password for the Backup File");
                if (string.IsNullOrEmpty(backupPassword))
                {
                    ShowCustomMessageBox("Backup password creation canceled. Backup aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Specify the .rar file path with the specified name
                string rarFileName = $"Encrypted Asset ({timestamp}).rar";
                string rarFilePath = Path.Combine(path, rarFileName);

                // Ensure WinRAR is installed and accessible
                string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe"; // Adjust this path if necessary
                if (!File.Exists(winRarPath))
                {
                    throw new FileNotFoundException("WinRAR executable not found at the specified location.");
                }

                // Initialize MongoDB client
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);

                // Get all collection names
                var collectionNames = database.ListCollectionNames().ToList();

                // Create a temporary folder for the backup
                string tempBackupFolder = Path.Combine(Path.GetTempPath(), $"Backup_{timestamp}");
                Directory.CreateDirectory(tempBackupFolder);

                foreach (var collectionName in collectionNames)
                {
                    // Access each collection
                    var collection = database.GetCollection<BsonDocument>(collectionName);

                    // Get all documents from the collection
                    var documents = collection.Find(new BsonDocument()).ToList();

                    // Save documents to a BSON file in the temporary folder
                    string filePath = Path.Combine(tempBackupFolder, $"{collectionName}.bson");
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        using (var bsonWriter = new BsonBinaryWriter(fs))
                        {
                            var context = BsonSerializationContext.CreateRoot(bsonWriter);
                            var serializer = BsonSerializer.SerializerRegistry.GetSerializer<BsonDocument>();

                            foreach (var document in documents)
                            {
                                serializer.Serialize(context, document);
                            }
                        }
                    }

                    Console.WriteLine($"Backed up collection: {collectionName}");
                }

                // Compress and encrypt the files in the temporary folder directly into a .rar file
                string arguments = $"a -p{backupPassword} -ep1 \"{rarFilePath}\" \"{Path.Combine(tempBackupFolder, "*")}\"";

                // Run the WinRAR process
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = winRarPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception("Failed to create password-protected RAR file.");
                }

                Console.WriteLine("Encrypted RAR file created successfully.");

                // Clean up the temporary folder
                Directory.Delete(tempBackupFolder, true);

                // Inform the user
                ShowCustomMessageBox($"Backup completed successfully!\nEncrypted RAR file: {rarFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                ShowCustomMessageBox($"Directory not found: {dnfe.Message}", "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException fnfe)
            {
                ShowCustomMessageBox($"File not found: {fnfe.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uae)
            {
                ShowCustomMessageBox($"Access denied: {uae.Message}", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public static async Task<bool> ValidatePasswordWithRetry(string userId, string dbName, string collectionName)
        {
            // Attempt thresholds
            const int MAX_TRIES_1 = 3;
            const int MAX_TRIES_2 = 5;
            const int MAX_TRIES_3 = 10;
            const int MAX_TRIES_4 = 15;

            // Time penalties in milliseconds
            const int PENALTY_1 = 60_000;   // 1 minute
            const int PENALTY_2 = 3 * 60_000;   // 3 minutes
            const int PENALTY_3 = 8 * 60_000;   // 8 minutes
            const int PENALTY_4 = 60 * 60_000;  // 1 hour

            // Thresholds and penalties
            var thresholds = new[] { MAX_TRIES_1, MAX_TRIES_2, MAX_TRIES_3, MAX_TRIES_4 };
            var penalties = new[] { PENALTY_1, PENALTY_2, PENALTY_3, PENALTY_4 };

            int attempts = 0; // Counter for total attempts
            int currentPenaltyIndex = -1; // Tracks the current penalty level

            while (true)
            {
                // Prompt the user for their password
                string userPassword = PromptPassword("Enter Your Account Password");
                if (string.IsNullOrEmpty(userPassword))
                {
                    ShowCustomMessageBox("Password entry canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Encrypt and validate the user's password
                string encryptedPassword = MyOtherMethods.EncryptPassword(userPassword);
                bool isCorrectPass = await MyDbMethods.ValidateUserUsingUserID(dbName, collectionName, userId, encryptedPassword);

                if (isCorrectPass)
                {
                    ShowCustomMessageBox("Password validated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    attempts++;
                    int cumulativeAttempts = 0;

                    // Determine the current penalty level
                    for (int i = 0; i < thresholds.Length; i++)
                    {
                        cumulativeAttempts += thresholds[i];
                        if (attempts == cumulativeAttempts)
                        {
                            currentPenaltyIndex = i;

                            // Inform the user about the penalty
                            int waitTimeMinutes = penalties[i] / 60_000; // Convert milliseconds to minutes
                            ShowCustomMessageBox(
                                $"You have reached {attempts} failed attempts. Please wait {waitTimeMinutes} minutes before retrying.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            // Apply penalty delay
                            await Task.Delay(penalties[i]);
                            break;
                        }
                    }

                    // Handle exceeding maximum attempts
                    if (attempts > cumulativeAttempts)
                    {
                        // Store violation details dynamically
                        SaveViolationDetails(userId);

                        ShowCustomMessageBox(
                            $"You have exceeded the maximum number of {cumulativeAttempts} failed attempts. The application will now close.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        // Exit the application
                        Environment.Exit(0);
                        return false; // Unreachable, added for consistency
                    }
                }
            }
        }



        private static void SaveViolationDetails(string userId)
        {
            // Load the configuration file
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

            // Access or create the AppSettings section
            var settings = config.AppSettings.Settings;

            // Add or update "LastViolationUserId"
            if (settings["LastViolationUserId"] == null)
            {
                settings.Add("LastViolationUserId", userId);
            }
            else
            {
                settings["LastViolationUserId"].Value = userId;
            }

            // Add or update "ViolationTimestamp"
            if (settings["ViolationTimestamp"] == null)
            {
                settings.Add("ViolationTimestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                settings["ViolationTimestamp"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            // Save the updated configuration
            config.Save(ConfigurationSaveMode.Modified);
            System.Configuration.ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }


        public static DialogResult ShowCustomMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (Form messageBoxForm = new Form())
            {
                // Configure the form
                messageBoxForm.Text = title;
                messageBoxForm.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen
                messageBoxForm.AutoSize = true;
                messageBoxForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                messageBoxForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                messageBoxForm.MaximizeBox = false;
                messageBoxForm.MinimizeBox = false;
                messageBoxForm.ShowIcon = false;
                messageBoxForm.Padding = new Padding(10);

                // Create a table layout for icon and message
                TableLayoutPanel layoutPanel = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    AutoSize = true,
                    Dock = DockStyle.Fill
                };

                // Add the icon (if any)
                if (icon != MessageBoxIcon.None)
                {
                    PictureBox iconBox = new PictureBox
                    {
                        Width = 48,
                        Height = 48,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Dock = DockStyle.Left,
                        Margin = new Padding(10)
                    };

                    switch (icon)
                    {
                        case MessageBoxIcon.Error:
                            iconBox.Image = SystemIcons.Error.ToBitmap();
                            break;
                        case MessageBoxIcon.Warning:
                            iconBox.Image = SystemIcons.Warning.ToBitmap();
                            break;
                        case MessageBoxIcon.Information:
                            iconBox.Image = SystemIcons.Information.ToBitmap();
                            break;
                        case MessageBoxIcon.Question:
                            iconBox.Image = SystemIcons.Question.ToBitmap();
                            break;
                    }

                    layoutPanel.Controls.Add(iconBox, 0, 0);
                }

                // Add the message label
                Label messageLabel = new Label
                {
                    Text = message,
                    AutoSize = true,
                    MaximumSize = new Size(400, 0), // Limit the width for text wrapping
                    Dock = DockStyle.Fill,
                    Margin = new Padding(10)
                };
                layoutPanel.Controls.Add(messageLabel, 1, 0);

                // Add buttons
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    AutoSize = true,
                    Dock = DockStyle.Bottom
                };

                Button okButton = new Button { Text = "OK", DialogResult = DialogResult.OK, AutoSize = true };
                buttonPanel.Controls.Add(okButton);
                messageBoxForm.AcceptButton = okButton;

                if (buttons == MessageBoxButtons.OKCancel)
                {
                    Button cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true };
                    buttonPanel.Controls.Add(cancelButton);
                    messageBoxForm.CancelButton = cancelButton;
                }

                // Add the layout panel and button panel to the form
                messageBoxForm.Controls.Add(layoutPanel);
                messageBoxForm.Controls.Add(buttonPanel);

                // Show the custom message box
                return messageBoxForm.ShowDialog();
            }
        }



        private static void CreatePasswordProtectedRar(string folderPath, string outputRarFilePath, string password)
        {
            try
            {
                // Ensure WinRAR is installed and accessible
                string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe"; // Adjust the path if necessary
                if (!File.Exists(winRarPath))
                {
                    throw new FileNotFoundException("WinRAR executable not found at the specified location.");
                }

                // Construct the WinRAR command
                string arguments = $"a -p{password} -r \"{outputRarFilePath}\" \"{folderPath}\"";

                // Execute the command
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = winRarPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception("Failed to create password-protected RAR file.");
                }

                Console.WriteLine("Encrypted RAR file created successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during RAR encryption: {ex.Message}");
            }
        }







        public static async Task RestoreBackup(string dbName)
        {
            try
            {
                // Prompt the user to enter their password for validation
                string userPassword = PromptPassword("Enter Your Password for Validation");
                if (string.IsNullOrEmpty(userPassword))
                {
                    MessageBox.Show("Password entry canceled. Restoration aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Encrypt the entered password for validation
                string encryptedPassword = MyOtherMethods.EncryptPassword(userPassword);

                // Validate the user using the encrypted password
                bool isCorrectPass = await MyDbMethods.ValidateUserUsingUserID(
                    "SmartAssetDb",
                    "Users",
                    FrontPage_Final.StaticUserID.Text,
                    encryptedPassword
                );

                if (!isCorrectPass)
                {
                    MessageBox.Show("Invalid UserID or Password.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // User authenticated, proceed with backup restoration
                MessageBox.Show("Password validated successfully. Proceeding with restoration...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Prompt the user to select multiple JSON files
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    Title = "Select Backup JSON Files",
                    Multiselect = true // Enable multi-selection
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Restoration has been canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string[] jsonFilePaths = openFileDialog.FileNames;

                // Initialize MongoDB client
                var client = new MongoClient(DefaultConnectionString);
                var database = client.GetDatabase(dbName);

                // Process each selected JSON file
                foreach (string jsonFilePath in jsonFilePaths)
                {
                    try
                    {
                        // Determine the collection name from the file name
                        string collectionName = Path.GetFileNameWithoutExtension(jsonFilePath);
                        var collection = database.GetCollection<BsonDocument>(collectionName);

                        using (StreamReader reader = new StreamReader(jsonFilePath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                try
                                {
                                    var document = BsonDocument.Parse(line); // Parse JSON into BSON
                                    collection.InsertOne(document);
                                }
                                catch (Exception parseEx)
                                {
                                    Console.WriteLine($"Failed to parse or insert document in file {jsonFilePath}: {parseEx.Message}");
                                }
                            }
                        }

                        Console.WriteLine($"Restored collection: {collectionName}");
                    }
                    catch (Exception fileEx)
                    {
                        Console.WriteLine($"Failed to restore from file {jsonFilePath}: {fileEx.Message}");
                    }
                }

                // Inform the user
                MessageBox.Show("Database restoration completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during restoration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string PromptPassword(string prompt)
        {
            using (Form passwordForm = new Form())
            {
                // Configure the form
                passwordForm.Text = prompt;
                passwordForm.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen
                passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                passwordForm.MaximizeBox = false;
                passwordForm.MinimizeBox = false;
                passwordForm.Width = 340; // Default width of 240 + 100px
                passwordForm.AutoSize = true;
                passwordForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                passwordForm.Padding = new Padding(10);

                // Create a layout panel for better alignment
                TableLayoutPanel layoutPanel = new TableLayoutPanel
                {
                    ColumnCount = 1,
                    RowCount = 3,
                    Dock = DockStyle.Fill,
                    AutoSize = true
                };

                // Add the label
                Label label = new Label
                {
                    Text = "Enter Password:",
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                layoutPanel.Controls.Add(label, 0, 0);

                // Add the password box
                TextBox passwordBox = new TextBox
                {
                    PasswordChar = '*',
                    Width = 300, // Adjusted width for consistency with form
                    Anchor = AnchorStyles.None
                };
                layoutPanel.Controls.Add(passwordBox, 0, 1);

                // Add the confirm button
                Button confirmButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    AutoSize = true,
                    Anchor = AnchorStyles.None
                };
                layoutPanel.Controls.Add(confirmButton, 0, 2);

                // Set layout panel as the main control
                passwordForm.Controls.Add(layoutPanel);

                // Set confirm button as default
                passwordForm.AcceptButton = confirmButton;

                // Show the dialog and return the password
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    return passwordBox.Text;
                }
            }

            return null; // Return null if the user cancels
        }






        








    }
}