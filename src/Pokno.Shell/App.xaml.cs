
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.Threading;
using System.Windows.Markup;
using System.Globalization;
using Pokno.Infrastructure.Models;

namespace Pokno.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //SplashScreen splash = new SplashScreen();
            //splash.Show();
            
            //for (int i = 0; i < 1000; i++)
            //{
            //    int u = i;
            //} 
            
            //// Step 2 - Start a stop watch  
            //System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

            //timer.Start();
            //System.Threading.Thread.Sleep(2000);
            //timer.Stop();



            base.OnStartup(e);
            SetDateFormat();
            
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            //splash.Close();
        }

        private static void SetDateFormat()
        {
            try
            {
                // Creating a Global culture specific to our application.
                CultureInfo cultureInfo = new CultureInfo("en-GB");

                // Creating the DateTime Information specific to our application.
                DateTimeFormatInfo dateTimeInfo = new DateTimeFormatInfo();

                // Defining various date and time formats.
                dateTimeInfo.DateSeparator = "/";
                dateTimeInfo.LongDatePattern = "dd/MM/yyyy";
                dateTimeInfo.ShortDatePattern = "dd/MM/yyyy";
                dateTimeInfo.LongTimePattern = "HH:mm:ss";
                dateTimeInfo.ShortTimePattern = "HH:mm";

                //dateTimeInfo.LongTimePattern = "hh:mm:ss tt";
                //dateTimeInfo.ShortTimePattern = "hh:mm tt";

                // Setting application wide date time format.
                cultureInfo.DateTimeFormat = dateTimeInfo;

                // Assigning our custom Culture to the application.                        
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

       


        

    }


}
