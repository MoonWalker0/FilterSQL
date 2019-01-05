using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace FilterSQL
{
    class FileHandling
    {
        public bool MergeFiles (string pathFolder, string pathDB, bool newDatabase)
        {
            DirectoryInfo directory;   /*Folder operations*/
            SQLiteConnection database; /*DB instantion*/
            SQLiteCommand command;     /*SQL command to be sent*/
            string dataToBeEntered;    /*SQL command*/

            /*Create new database if there is required*/
            if (newDatabase)
            {
                if(!CreateDatabase(pathDB))
                {
                    return false;
                }
            }

            database = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;");
            database.Open();
             
            /*
             * Search whole folder (1 folder depth) for CVS files
             * 
             * Hardware implementation specific output is as follows:
             * 
             * Selected folder
             *              |-> Folder_1 
             *                      |-> CSV_File_1
             *              |-> Folder_2      
             *                      |-> CSV_File_2
             * ...
             */

            directory = new DirectoryInfo(pathFolder);

            /*All folders in selected folder*/
            foreach (var folder in directory.GetDirectories())
            {
                /*All files in each selected folder*/
                foreach (var file in folder.GetFiles())
                {
                    try
                    {
                        using (var currentFile = new StreamReader(file.FullName))
                        {
                            /*Skip first, header line of CVS file*/
                            currentFile.ReadLine();

                            /*All data in the given file*/
                            while (!currentFile.EndOfStream)
                            {
                                var line = currentFile.ReadLine();
                                var values = line.Split(';');

                                dataToBeEntered = "INSERT INTO CardInfo " +
                                                  "(ID, category, date, realMoney, payed, " +
                                                  "enteredMoney, cashlessMoney, autoReload) values " +
                                                  "(\"" + values[0] + "\"," +                            /* ID - column A */
                                                  values[1].ToString() + ", " +                          /* category - column B */
                                                  "\"" + Utilities.ToSQLDateFormat(values[2]) + "\", " + /* date - column C */
                                                  values[5].ToString() + ", " +                          /* realMoney - column F */
                                                  values[6].ToString() + ", " +                          /* payed - column G */
                                                  values[8].ToString() + ", " +                          /* enteredMoney - column H */
                                                  values[9].ToString() + ", " +                          /* cashlessMoney - column J */
                                                  values[22].ToString()                                  /* autoReload - column W */
                                                  + ")"; 

                                command = new SQLiteCommand(dataToBeEntered, database);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        database.Close();
                        return false;
                    }
                }
            }
            database.Close();

            return true;
        }

        bool CreateDatabase(string path)
        {
            try
            { 
                SQLiteConnection.CreateFile(path);
            }
            catch(System.IO.IOException)
            {
                return false;
            }

            SQLiteConnection database = new SQLiteConnection("Data Source=" + path + ";Version=3;");
            database.Open();

            string table = "CREATE TABLE CardInfo (ID VARCHAR(10), " +
                                                    "category INT, " +
                                                    "date TIMESTAMP, " +
                                                    "realMoney FLOAT, " +
                                                    "payed FLOAT, " +
                                                    "enteredMoney FLOAT, " +
                                                    "cashlessMoney FLOAT, " +
                                                    "autoReload FLOAT)";

            SQLiteCommand command = new SQLiteCommand(table, database);
            command.ExecuteNonQuery();  
            database.Close();

            return true;
        }
    }
}
