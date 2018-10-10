using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Pokno.Infrastructure.Animation
{
    public static class Animation
    {
        public static ResourceDictionary Resources { get; set; }

        public static void Init(ResourceDictionary resources)
        {
            Resources = resources;

            Storyboard stb1 = new Storyboard();
            stb1.Duration = new Duration(TimeSpan.FromSeconds(1));
            stb1.SpeedRatio = 3;

            DoubleAnimation daY1 = new DoubleAnimation { From = 0.00, To = 90.00 };
            Storyboard.SetTargetName(daY1, "Projections");
            Storyboard.SetTargetProperty(daY1, new PropertyPath("RotationX"));
            stb1.Children.Add(daY1);
            Resources.Add("EndOfPage", stb1);

            Storyboard stb = new Storyboard();
            stb.Duration = new Duration(TimeSpan.FromSeconds(1));
            stb.SpeedRatio = 3;

            DoubleAnimation daY = new DoubleAnimation { From = -90.00, To = 0.00 };
            Storyboard.SetTargetName(daY, "Projections");
            Storyboard.SetTargetProperty(daY, new PropertyPath("RotationX"));
            stb.Children.Add(daY);
            Resources.Add("StartOfPage", stb);
        }

        public static void SwitchToPage()
        {
            Storyboard currStb = Resources["EndOfPage"] as Storyboard;
            currStb.Completed += new EventHandler(currStb_Completed);
            currStb.Begin();
        }

        private static void currStb_Completed(object sender, EventArgs e)
        {
            Storyboard stb = Resources["StartOfPage"] as Storyboard;
            stb.Begin();
        }


    }


}
