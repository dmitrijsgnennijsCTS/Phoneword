using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        //creates a variable
        string translatedNumber;

        public MainPage()
        {
            
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            // Retrieves the translated number from the ToNumber function in PhonewordTranslator.cs
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            // If the entry label isn't empty then run the code below
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                //Enable the call button, so user can call
                callButton.IsEnabled = true;
                // The text inside the call button with the translated number
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                // If nothing in entry label then dont enable the call button
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        // Run the code bellow when call button is pressed/Enabled
        async void OnCall(object sender, EventArgs e)
        {
            // Display this alert to make sure that the user is sure to call
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                // Run the code bellow if Yes
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    //Add the called number to the history list/page
                    App.PhoneNumbers.Add(translatedNumber);
                    //Once the user called a single number the history page is enabled
                    callHistoryButton.IsEnabled = true;
                    //Dial the number that was translated 
                    dialer.Dial(translatedNumber);
                }
            }
        }
        //Run this code ehn the Call History button is Enabled
        async void OnCallHistory(object sender, EventArgs e)
            {
            //Create a page when the call history is pressed
                await Navigation.PushAsync(new CallHistoryPage());
            }
        }
    }
