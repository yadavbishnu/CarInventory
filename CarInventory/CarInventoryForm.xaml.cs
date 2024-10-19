// Author:  Kyle Chapman
// Date:    October 9, 2024
// Description:UPDATED BY:
                //Name: Bishnu Yadav
                //Date: 17th Oct 2024
                //AppName: InClassExercise2
                //Description: This App will allow user to add the car information using Class.
// Functionality for the car inventory form.
// It's a bit incomplete since it's going to be used as a class exercise.
// It's meant for the user to enter car details that are added to a list,
// with some light validation using a static class. There should also be
// a class for car objects, but that part is left as an exercise.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CarInventoryForm : Window
    {
        // We MAY eventually want a class-level list of car objects.
        // Such a declaration would probably go here.

        /// <summary>
        /// Constructor for the Car Inventory form.
        /// </summary>
        public CarInventoryForm()
        {
            InitializeComponent();
            PopulateYears();
            ResetInputs();
        }

        /// <summary>
        /// Check if the entries are valid; if they are, add the car into the list.
        /// </summary>
        private void AddClick(object sender, RoutedEventArgs e)
        {
            // Is the model blank or whitespace?
            if (textModel.Text.Trim().Length > 0)
            {
                // Is the price a number?
                // If you want to add some challenge, validate this more thoroughly. e.g. should $1000.230202 be considered valid?
                if (Validation.IsDecimal(textPrice.Text))
                {
                    decimal price = decimal.Parse(textPrice.Text);
                    if (Validation.IsInRange(price, 0, decimal.MaxValue))
                    {
                        // All values are valid; create the Car object
                        string make = comboMake.Text;
                        string model = textModel.Text;
                        int year = int.Parse(comboYear.Text);
                        string color = textColor.Text;
                        bool isNew = checkIsNew.IsChecked == true;

                        // Create a new Car object
                        Car newCar = new Car(make, model, year, color, price, isNew);

                        // Add the car object to the ListView
                        listCars.Items.Add(newCar);

                        // Everything is valid! Ready for the next entry.
                        ResetInputs();
                        UpdateStatus("Car Added successfully!");
                    }
                    // The price was negative.
                    else
                    {
                        HighlightError(textPrice);
                        UpdateStatus("Error: Price must be entered as a positive number.");
                    }
                }
                // Price was non-numeric.
                else
                {
                    HighlightError(textPrice);
                    UpdateStatus("Error: Price must be numeric.");
                }
            }
            // The model was blank.
            else
            {
                HighlightError(textModel);
                UpdateStatus("Error: Model cannot be left blank.");
            }
        }

        /// <summary>
        /// Reset the form to its default state.
        /// </summary>
        private void ResetClick(object sender, RoutedEventArgs e)
        {
            ResetInputs();
            UpdateStatus("Ready for entries!");
        }

        /// <summary>
        /// Exit the application.
        /// </summary>
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Populate the combo box for the years.
        /// </summary>
        private void PopulateYears()
        {
            // Some declarations to know how many years we're including.
            const int YearsToInclude = 40;
            int currentYear = DateTime.Now.Year;
            
            // Count backwards some number of years, adding each prior year into the combo box.
            for (int year = currentYear; year >= currentYear - YearsToInclude; year--)
            {
                comboYear.Items.Add(year);
            }
        }

        /// <summary>
        /// Reset the form's input fields to a default state.
        /// </summary>
        private void ResetInputs()
        {
            comboMake.SelectedIndex = 0;
            textModel.Clear();
            RestoreControl(textModel);
            comboYear.SelectedIndex = 0;
            textPrice.Clear();
            RestoreControl(textPrice);
            checkIsNew.IsChecked = true;
            comboMake.Focus();
        }

        /// <summary>
        /// Update the status bar.
        /// </summary>
        /// <param name="message">the text to write to the status bar</param>
        private void UpdateStatus(string message)
        {
            statusMessage.Content = message;
        }

        /// <summary>
        /// Show a control in red when it's in an error state.
        /// </summary>
        /// <param name="errorControl">a control in error</param>
        private void HighlightError(Control errorControl)
        {
            errorControl.Background = Brushes.PaleVioletRed;
            errorControl.BorderBrush = Brushes.Red;
            errorControl.Focus();
        }

        /// <summary>
        /// Repaint a control in regular colours.
        /// </summary>
        /// <param name="controlToRestore">a control no longer in error</param>
        private void RestoreControl(Control controlToRestore)
        {
            controlToRestore.Background = Brushes.Gainsboro;
            controlToRestore.BorderBrush = Brushes.Black;
        }
    }
}