using Prism.Regions;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Pokno.Infrastructure.Models
{
    public class Navigation
    {
        private static IRegion _contentRegion;
        private static UserControl _currentView;
        private static readonly Dispatcher _dispatcher = Application.Current.Dispatcher;

        public static void SwitchToReportView(UserControl view, IRegionManager regionManager, string regionName)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    bool exist = regionManager.Regions.ContainsRegionWithName(regionName);
                    if (exist)
                    {
                        _contentRegion = regionManager.Regions[regionName];
                    }
                    else
                    {
                        regionManager.Regions.Add(regionName, _contentRegion);
                    }

                    if (_currentView != null)
                    {
                        if (_currentView.ToString() == view.ToString())
                        {
                            _contentRegion.Add(view);
                            return;
                        }
                    }

                    _currentView = view;
                    _contentRegion.Add(view);
                    _contentRegion.Activate(view);

                    //Animation.SwitchToPage();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }




    }
}
