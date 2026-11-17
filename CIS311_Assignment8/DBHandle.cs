using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Author: Cody Syring
/// Filename: DBHandle.cs
/// Part of Project: CIS311_Assignment8.cs
///
/// File Purpose:
/// This class handles all the database work. Its goal is to get and return the
/// required information to the front end for display.
///  
/// It also handles what user we are currently looking at on the UI.
/// </summary>

namespace CIS311_Assignment8
{
    internal class DBHandle
    {
        // VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES
        // VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES
        // VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES -- VARIABLES

        //This variable will hold the connection string to our database.
        private const string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VetOffice;Integrated Security=True";
        //This variable holds what user we are currently looking at in our UI
        private int _currentUser;
        //This variable holds all users in our database.
        private DataTable _allUsers;

        private List<string> test;
        // METHODS/FUNCTIONS -- METHODS/FUNCTIONS -- METHODS/FUNCTIONS
        // METHODS/FUNCTIONS -- METHODS/FUNCTIONS -- METHODS/FUNCTIONS
        // METHODS/FUNCTIONS -- METHODS/FUNCTIONS -- METHODS/FUNCTIONS

        /// <summary>
        /// This constructor will set _currentUser to 0, being the first person in the db
        /// Will also get a DataTable of all users in the DB and store it.
        /// </summary>
        public DBHandle()
        {
            _currentUser = 0;
            _allUsers = dbRequestGetTable("Select * From Owner");
            test = new List<string>();
        }
        /// <summary>
        /// This method will send a quort to the database and returns the 
        /// table we get in responce. 
        /// </summary>
        /// <param name="strSQLCmd"></param>     the string we are storing the sql call in
        /// <returns>DataTable variable</returns>
        public DataTable dbRequestGetTable(String strSQLCmd)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Create a SqlCommand object with the SQL query and connection
                    SqlCommand cmd = new SqlCommand(strSQLCmd, conn);

                    // Create a SqlDataAdapter to execute the SQL command and fill the DataSet
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    // Create a new DataSet
                    DataSet dataSet = new DataSet();

                    // Fill the DataSet with data from the database
                    adapter.Fill(dataSet);

                    // Specify the DataTable name to bind to the DataGridView
                    // Change this based on your table name                         
                    return  dataSet.Tables[0];

                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// This method will get a query and send it to the database.
        /// </summary>
        /// <param name="query"></param>    This is the sql query we are sending.
        /// <returns>True if success, False if failed.</returns>
        private bool dbRequest(String query)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd  = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                    return false;
                }
                finally 
                { 
                    conn.Close(); 
                }
            }
        }
        /// <summary>
        /// This method will return the current row we are pointing at with _currentUser.
        /// </summary>
        /// <returns>The current row we are looking at.</returns>
        public DataRow GetRow()
        {
            return _allUsers.Rows[_currentUser];
        }
        /// <summary>
        /// This method will add one to the pointer _currentUser.
        /// It will than return the new row.
        /// </summary>
        /// <returns>Updated Row.</returns>
        public DataRow GoNextUser()
        {
            if ( _currentUser < _allUsers.Rows.Count-1) 
            {
                _currentUser++;          
            }
            return _allUsers.Rows[_currentUser];
        }
        /// <summary>
        /// This method will take one away from the pointer _currentUser.
        /// It will than return the new row.
        /// </summary>
        /// <returns>Updated Row.</returns>
        public DataRow GoBackUser()
        {
            if (_currentUser > 0)
            {
                _currentUser--;
            }
            return _allUsers.Rows[_currentUser];
        }
        /// <summary>
        /// This method will return the very first user every time.
        /// </summary>
        /// <returns>Updated Row.</returns>
        public DataRow GoFirst()
        {
            _currentUser = 0;
            return _allUsers.Rows[_currentUser];
        }
        /// <summary>
        /// This method will return the very last user every time.
        /// </summary>
        /// <returns><Updated Row./returns>
        public DataRow GoLast()
        {
            _currentUser = _allUsers.Rows.Count-1;
            return _allUsers.Rows[_currentUser];
        }
        /// <summary>
        /// This method will request all pets that are linked to the OwnerId 
        /// passed in. 
        /// </summary>
        /// <param name="OwnerId"></param>
        /// <returns>All Pets linked Owner Id passed in.</returns>
        public DataTable GetPetTable(string OwnerId) 
        {
            return dbRequestGetTable($"SELECT * FROM Pets WHERE OwnerId = {OwnerId}");
        }
        /// <summary>
        /// This method will request the database to update all fields in the data base that go with a given user id.
        /// It will update what ever Id thats passed in to the function.
        /// </summary>
        /// <param name="Id"></param>           Owners Id
        /// <param name="Name"></param>         Owners Name
        /// <param name="Address"></param>      Owners Address
        /// <param name="City"></param>         Owners City
        /// <param name="OwnerState"></param>   Owners State
        /// <param name="ZipCode"></param>      Owners Zip
        /// <param name="PhoneNumber"></param>  Owners Phone Number
        /// <returns>True if data base completed action.</returns>
        public bool updateUser(string Id, string Name, string Address, string City, string OwnerState, string ZipCode, string PhoneNumber)
        {
            string insertQuery = $"UPDATE Owner SET OwnerName = '{Name}', OwnerAddress = '{Address}', OwnerCity = '{City}', " +
                $"OwnerState = '{OwnerState}', OwnerZipCode = '{ZipCode}', OwnerPhoneNumber = '{PhoneNumber}' WHERE Id = {Id}";

            using (SqlConnection conn = new SqlConnection(connString))

                if (dbRequest(insertQuery))
            {
                _allUsers = dbRequestGetTable("Select * From Owner");
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This method will get a userId and request the database to remove 
        /// all pets that are linked to them.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>True if data base completed action.</returns>
        public bool removePets(string userID)
        {
            string insertQuery = $"DELETE FROM Pets WHERE OwnerId = '{userID}'";

            if (dbRequest(insertQuery))
            {
                _allUsers = dbRequestGetTable("Select * From Owner");
                _currentUser = 0;

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This data base will request that a user gets removed from the database.
        /// After it will call removePets to clean up all the pets linked. 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>True if data base completed action.</returns>
        public bool removeUser(String userID)
        {
            string insertQuery = $"DELETE FROM Owner WHERE Id = '{userID}'";         


            if (dbRequest(insertQuery))
            {
                removePets(userID);
                _allUsers = dbRequestGetTable("Select * From Owner");
                _currentUser = 0;

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This method will request the database to create a new user. 
        /// </summary>
        /// <param name="Name"></param>         Owners Name
        /// <param name="Address"></param>      Owners Address
        /// <param name="City"></param>         Owners City
        /// <param name="OwnerState"></param>   Owners State
        /// <param name="ZipCode"></param>      Owners Zip
        /// <param name="PhoneNumber"></param>  Owners Phone Number
        /// <returns>True if data base completed action.</returns>
        public bool insertUser(string Name,string Address, string City, string OwnerState, string ZipCode,string PhoneNumber)
        {
            string insertQuery = $"INSERT INTO Owner (OwnerName, OwnerAddress, OwnerCity, OwnerState, OwnerZipCode, OwnerPhoneNumber) " +
                $"VALUES ('{Name}', '{Address}', '{City}','{OwnerState}', '{ZipCode}', '{PhoneNumber}')";


            if (dbRequest(insertQuery))
            {
                _allUsers = dbRequestGetTable("Select * From Owner");
                return true;
            }
            else
            { 
                return false;
            }            
        }
        /// <summary>
        /// This method is a merg request. Its going to take a pets information and search the database
        /// for that id. If it exists it will update all pet data linking back. If not it will request
        /// to make a new row in the table.
        /// </summary>
        /// <param name="Id"></param>               pets id number
        /// <param name="PetName"></param>          pets name
        /// <param name="PetSpecies"></param>       pets species
        /// <param name="PetBirthday"></param>      pets birthday
        /// <param name="PetLastVisitDate"></param> pets Last Visit
        /// <param name="OwnerId"></param>          Pets Owners id
        /// <returns>True if data base completed action.</returns>
        public bool updateOrAddPet(string Id, string PetName, string PetSpecies, string PetBirthday,string PetLastVisitDate, string OwnerId)
        {
            string mergeQuery = @"MERGE INTO Pets AS target" + 
                        " USING (VALUES (@Id, @PetName, @PetSpecies, @PetBirthday, @PetLastVisitDate, @OwnerId))" +
                        " AS source (Id, PetName, PetSpecies, PetBirthday, PetLastVisitDate, OwnerId)" + 
                        " ON target.Id = source.Id" +
                        " WHEN MATCHED THEN" +
                        " UPDATE SET" +
                        " target.PetName = source.PetName," +
                        " target.PetSpecies = source.PetSpecies," +
                        " target.PetBirthday = source.PetBirthday," +
                        " target.PetLastVisitDate = source.PetLastVisitDate," +
                        "target.OwnerId = source.OwnerId" +
                        " WHEN NOT MATCHED THEN" +
                        " INSERT (PetName, PetSpecies, PetBirthday, PetLastVisitDate, OwnerId)" +
                        " VALUES (source.PetName, source.PetSpecies, source.PetBirthday, source.PetLastVisitDate, source.OwnerId);";

           if (Id =="")
            {
                test.Add(PetName);
            }
            // Assuming you have a database connection object named connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(mergeQuery, conn);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@PetName", PetName);
                    command.Parameters.AddWithValue("@PetSpecies", PetSpecies);
                    command.Parameters.AddWithValue("@PetBirthday", PetBirthday);
                    command.Parameters.AddWithValue("@PetLastVisitDate", PetLastVisitDate);
                    command.Parameters.AddWithValue("@OwnerId", OwnerId);

                    conn.Open();
                    var x = command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// This method will gather a list of id's from the UI and a list of id's
        /// from the database.
        /// It will than compare the two removing the extra id's stored in the
        /// database that are not in the UI for the given OwnerID.
        /// </summary>
        /// <param name="allResults"></param>   All the data gotton from the UI
        /// <param name="OwnerID"></param>      The current owner we are looking at
        /// <returns>True if data base completed action.</returns>
        public bool removePets(DataGridView allResults, string OwnerID)
        {
            List<string> petIdsUI = new List<string>();
            List<string> petIdsDB = new List<string>();
            List<string> petNames = new List<string>();
            DataGridViewRow targetRow = allResults.Rows[0];
            bool returnFlag = true;

            //This loop will build the list of id's that are in the UI
            if(!allResults.Rows[0].IsNewRow)
            {
                for (int i = 0; i < allResults.Rows.Count - 1; i++)
                {
                    targetRow = allResults.Rows[i];
                    petIdsUI.Add(targetRow.Cells[0].Value.ToString());

                    //If the pet has no Id its a new pet and now has one assigned
                    //We need to get the id assigend from the database and write
                    //it to the List.
                    if (petIdsUI[i] =="")
                    {
                        string petName = targetRow.Cells[1].Value.ToString();
                        var tempTable = dbRequestGetTable($"select Id from Pets where PetName = '{petName}'");

                        foreach(DataRow row in tempTable.Rows) 
                        {
                            petIdsUI[i] = row["Id"].ToString();
                        }
                    }
                }      
            }

            //This block will do the same as above, but get the table from the data base
            DataTable IdsInDataBase = dbRequestGetTable($"select Id,PetName from Pets where OwnerId = '{OwnerID}'");

            foreach (DataRow row in IdsInDataBase.Rows)
            {
                petIdsDB.Add(row["Id"].ToString());
                petNames.Add(row["PetName"].ToString());
            }

            //What ever is in the data base but not showing in the UI was removed by the user
            //and we need to remove from the database.
            List<string> petsToRemove = petIdsDB.Except(petIdsUI).ToList();

           
            //remove all id's in the remove list.
            foreach (string Id in petsToRemove)
            {
                if(returnFlag) 
                {
                    returnFlag = dbRequest($"delete from pets where id = '{Id}'");
                }
                    
            }                      
            return returnFlag;
        }
    }
}
