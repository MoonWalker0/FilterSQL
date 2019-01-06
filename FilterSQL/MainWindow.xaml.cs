using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Controls;

namespace FilterSQL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } 

        private void ToDBButton(object sender, RoutedEventArgs e)
        {
            /*Select folder containing *.CVS files to be merged*/
            CommonOpenFileDialog dialogFolder = new CommonOpenFileDialog();
            dialogFolder.InitialDirectory = "C:\\Users\\jedrz\\Desktop\\VENDING\\Audyt kopia zapasowa\\1"; /*TEMP - REMOVE ME*/
            dialogFolder.IsFolderPicker = true;
            if (dialogFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                /*Select DB that will be updated or create a new one*/
                
                string databasePath;
                bool isDatabaseNew;
                MessageBoxResult newDatabaseRequired = MessageBox.Show("Create new database?",
                                                                       "Database", 
                                                                       MessageBoxButton.YesNoCancel);
                if(newDatabaseRequired == MessageBoxResult.Yes)
                {
                    CommonSaveFileDialog dialogDB = new CommonSaveFileDialog();
                    dialogDB.Filters.Add(new CommonFileDialogFilter("SQLite Files (*.sqlite)", ".sqlite"));
                    dialogDB.DefaultExtension = ".sqlite";
                    dialogDB.InitialDirectory = "C:\\Users\\jedrz\\Desktop\\VENDING\\Audyt kopia zapasowa\\1"; /*TEMP - REMOVE ME*/

                    if (dialogDB.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        databasePath = dialogDB.FileName;
                        isDatabaseNew = true;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (newDatabaseRequired == MessageBoxResult.No)
                {
                    CommonOpenFileDialog dialogDB = new CommonOpenFileDialog();
                    dialogDB.InitialDirectory = "C:\\Users\\jedrz\\Desktop\\VENDING\\Audyt kopia zapasowa\\1"; /*TEMP - REMOVE ME*/
                    dialogDB.Filters.Add(new CommonFileDialogFilter("SQLite Files (*.sqlite)", ".sqlite"));
                    if (dialogDB.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        databasePath = dialogDB.FileName;
                        isDatabaseNew = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                { 
                    return;
                }
                
                /*After selecting DB and folder with CVS files proceed to merging*/
                FileHandling fileHandling = new FileHandling();
                if (fileHandling.MergeFiles(dialogFolder.FileName, databasePath, isDatabaseNew))
                {
                    MessageBox.Show("Data added to the database.", "Success");
                }
                else
                {
                    MessageBox.Show("Failure - data was not added to the database.", "Failure");
                }
            }
        }

        private void LoadDBButton(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialogDB = new CommonOpenFileDialog();

            dialogDB.InitialDirectory = "C:\\Users\\jedrz\\Desktop\\VENDING\\Audyt kopia zapasowa\\1"; /*TEMP - REMOVE ME*/
            dialogDB.Filters.Add(new CommonFileDialogFilter("SQLite Files (*.sqlite)", ".sqlite"));

            if (dialogDB.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MainList.Items.Clear(); 
                MainList.ItemsSource = FileHandling.LoadAllByDate(dialogDB.FileName); 
            }
        }

        private void MainListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*Item selected on list*/
            textBoxSelectedID.Text = (MainList.SelectedItem as ListDisplay.ListItem?).Value.ItemID.ToString(); 
        }
    }
}
