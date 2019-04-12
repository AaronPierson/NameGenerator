using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
//Programmer: Aaron Pierson
//Purpose: To Genrate Names for the user to help decide on A name
//Update Date: June 30 2018
namespace NameGenerator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        //Finding the folder the app is intalled to
        StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
        List<string> FF = new List<string>();
        List<string> FJ = new List<string>();
        List<string> FW = new List<string>();
        List<string> MF = new List<string>();
        List<string> MJ = new List<string>();
        List<string> MW = new List<string>();
        List<string> FP = new List<string>();
        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //loading the files
           
            //The location For each Name flile
            string FFfile = @"Assets\Names\Female\Human_Names_-_Fantasy_Female.csv";
            string FJfile = @"Assets\Names\Female\Human_Names_-_Japan_Female.csv";
            string FWfile = @"Assets\Names\Female\Human_Names_-_Western_Female.csv";
            string MFfile = @"Assets\Names\Male\Human_Names_-_Fantasy_Male.csv";
            string MJfile = @"Assets\Names\Male\Human_Names_-_Japan_Male.csv";
            string MWfile = @"Assets\Names\Male\Human_Names_-_Western_Male.csv";
            string PFfile = @"Assets\Names\Places\d100-list-fantasy-town-names.txt";
            //Reading each name file
            //Reading Female names
            //Reading Female Fantasy
            StorageFile FFF = await InstallationFolder.GetFileAsync(FFfile);
            var FFlines = await FileIO.ReadLinesAsync(FFF);
            FF = FFlines.ToList();
            //Reading Female Japenese
            StorageFile FJF = await InstallationFolder.GetFileAsync(FJfile);
            var FJlines = await FileIO.ReadLinesAsync(FJF);
             FJ = FJlines.ToList();
            //Reading Female west
            StorageFile FWF = await InstallationFolder.GetFileAsync(FWfile);
            var FWlines = await FileIO.ReadLinesAsync(FWF);
             FW = FWlines.ToList();

            //Reading Male names

            //Male Fantasy
            StorageFile MFF = await InstallationFolder.GetFileAsync(MFfile);
            var MFFlines = await FileIO.ReadLinesAsync(MFF);
            MF = MFFlines.ToList();

            //Male Japenese
            StorageFile MJF = await InstallationFolder.GetFileAsync(MJfile);
            var MJFlines = await FileIO.ReadLinesAsync(MJF);
             MJ = MJFlines.ToList();

            //Male Western
            StorageFile MWF = await InstallationFolder.GetFileAsync(MWfile);
            var MWFlines = await FileIO.ReadLinesAsync(MWF);
             MW = MWFlines.ToList();

            //Locations
            StorageFile PFF = await InstallationFolder.GetFileAsync(PFfile);
            var PFFlines = await FileIO.ReadLinesAsync(PFF);
            FP = PFFlines.ToList();
           
        }

        private void btnGen_Click(object sender, RoutedEventArgs e)
        {
           
            // List<String> FJ = File.ReadAllLines(@"Names\Female\Human_Names_-_Japan_Female.csv").ToList();
            List<string> NamesList = new List<string>();

            //which options are seleted
            switch (GenderBox.SelectedIndex)
            {
                case 0:
                    //If type and gender is set to all
                    if(typeBox.SelectedIndex == 0)
                    {
                        //Female
                        NamesList.AddRange(FF);
                        NamesList.AddRange(FJ);
                        NamesList.AddRange(FW);
                        //Male
                        NamesList.AddRange(MJ);
                        NamesList.AddRange(MF);
                        NamesList.AddRange(MW);
                    }
                    else if (typeBox.SelectedIndex == 1)
                    {
                        //Western
                        NamesList.AddRange(FW);
                        NamesList.AddRange(MW);
                    }
                    else if(typeBox.SelectedIndex == 2)
                    {
                        //Fantasy
                        NamesList.AddRange(FF);
                        NamesList.AddRange(MF);
                    }
                    else if(typeBox.SelectedIndex == 3)
                    {
                        //Japenese
                        NamesList.AddRange(FJ);
                        NamesList.AddRange(MJ);
                    }
                    else if (typeBox.SelectedIndex == 4)
                    {
                        //Places
                        NamesList.AddRange(FP);
                    }
                    break;

                case 1:
                    //If gender is set to male
                    if (typeBox.SelectedIndex == 0)
                    {
                        //Male
                        NamesList.AddRange(MJ);
                        NamesList.AddRange(MF);
                        NamesList.AddRange(MW);
                    }
                    else if (typeBox.SelectedIndex == 1)
                    {
                        //Western
                        
                        NamesList.AddRange(MW);
                    }
                    else if(typeBox.SelectedIndex == 2)
                    {
                        //Fantasy
                       
                        NamesList.AddRange(MF);
                    }
                    else if(typeBox.SelectedIndex ==3)
                    {
                        //Japenese
                        NamesList.AddRange(MJ);
                    }
                    else if (typeBox.SelectedIndex == 4)
                    {
                        //Places
                        NamesList.AddRange(FP);
                    }
                    break;

                case 2:
                    //If gender is set to female
                    if (typeBox.SelectedIndex == 0)
                    {
                        //Female
                        NamesList.AddRange(FF);
                        NamesList.AddRange(FJ);
                        NamesList.AddRange(FW);
                    }
                    else if (typeBox.SelectedIndex == 1)
                    {
                        //Western
                        NamesList.AddRange(FW);
                    
                    }
                    else if (typeBox.SelectedIndex == 2)
                    {
                        //Fantasy
                        NamesList.AddRange(FF);
                       
                    }
                    else if (typeBox.SelectedIndex == 3)
                    {
                        //Japenese
                        NamesList.AddRange(FJ);
                    }
                    else if (typeBox.SelectedIndex == 4)
                    {
                        //FPlaces
                        NamesList.AddRange(FP);
                    }
                    break;
            }//end of the whole switch

            //Filter first letter through the list
            //How many names does the user wants and give them that many names from the numberbox
            int numberofNames = 0;
            switch (NumberBox.SelectedIndex)
            {
                case 0:
                    numberofNames = 10;
                    break;

                case 1:
                    numberofNames = 25;
                    break;

                case 2:
                    numberofNames = 50;
                    break;
            }

            int i;
            //gen a random number
            Random rnd = new Random();
            //this is a arry of number that the user wants ints
               int[] Rnumber = new int[numberofNames];
            for ( i = 0; i < numberofNames;)
          {
               int ran = rnd.Next(1, NamesList.Count);
                Rnumber[i] = ran;
                i++;

           }//end of loop for random number

            //looping through a object
            int n = 1;
            //string p = ".";
            List<lstNames> items = new List<lstNames>();
            for (i = 0; i < numberofNames;)
            {
                
                items.Add(new lstNames() { Name = NamesList[Rnumber[i]], num = n});
                i++;
                n++;
            }
            lstOfNames.ItemsSource = items;

            #region
            
            //for (int i = 0; i < 5;)
            //{
            //   N1.Text = NamesList[Rnumber[i]];
            //  i++;
            //   N2.Text = NamesList[Rnumber[i]];
            //    i++;
            //   N3.Text = NamesList[Rnumber[i]];
            //    i++;
            //     N4.Text = NamesList[Rnumber[i]];
            //     i++;
            //     N5.Text = NamesList[Rnumber[i]];
            //    i++;
            // }// end of loop for assignine random names to textblocks
            #endregion


        } //End of class  

        private void lstOfNames_ItemClick(object sender, ItemClickEventArgs e)
        {
            //create data package to use clipboard 
            DataPackage dataPackage = new DataPackage();
            //tell that we want to copy
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            //get the item that the user selected and refer to our object that its in
            var name = (lstNames)e.ClickedItem;
            string click = name.Name.ToString();
            //put the name into the clip board
            dataPackage.SetText(click);
            Clipboard.SetContent(dataPackage);
            //notify the user what has happed
            //MessageDialog dialog = new MessageDialog("Copied to clipboard");
            //await dialog.ShowAsync();
            Flyout MyFlyout = Resources["MyFlyout"] as Flyout;
            MyFlyout.ShowAt(MyTextBox);


        }

        private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (typeBox.SelectedIndex == 1)
            {
                stkGender.Visibility = Visibility.Visible;

            }
            else if (typeBox.SelectedIndex == 2)
            {
                stkGender.Visibility = Visibility.Visible;
            }
            else if (typeBox.SelectedIndex == 3)
            {
                stkGender.Visibility = Visibility.Visible;
            }
            else if (typeBox.SelectedItem == "All")
            {
                stkGender.Visibility = Visibility.Visible;
            }
            else if (typeBox.SelectedIndex == 4)
            {
                stkGender.Visibility = Visibility.Collapsed;
            }

        }
    }
}
