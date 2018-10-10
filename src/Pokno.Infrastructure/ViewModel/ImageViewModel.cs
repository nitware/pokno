using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

using Pokno.Infrastructure.Models;
using Pokno.Model.Model;

namespace Pokno.Infrastructure.ViewModel
{
    public class ImageViewModel : BaseViewModel
    {
        private BitmapImage _image1;
        private BitmapImage _image2;
        private BitmapImage _image3;
        private BitmapImage _image4;
        private BitmapImage _image5;
        private BitmapImage _image6;
        private BitmapImage _image7;
        private BitmapImage _image8;
        private BitmapImage _image9;
        private BitmapImage _image10;
        private BitmapImage _image11;
        private BitmapImage _image12;
        private BitmapImage _image13;
        private BitmapImage _image14;
        private BitmapImage _image15;
        private BitmapImage _image16;
        private BitmapImage _image17;
        private BitmapImage _image18;
        private BitmapImage _productLogo;

        public BitmapImage Image1
        {
            get { return _image1; }
            set
            {
                _image1 = value;
                base.OnPropertyChanged("Image1");
            }
        }
        public BitmapImage Image2
        {
            get { return _image2; }
            set
            {
                _image2 = value;
                base.OnPropertyChanged("Image2");
            }
        }
        public BitmapImage Image3
        {
            get { return _image3; }
            set
            {
                _image3 = value;
                base.OnPropertyChanged("Image3");
            }
        }
        public BitmapImage Image4
        {
            get { return _image4; }
            set
            {
                _image4 = value;
                base.OnPropertyChanged("Image4");
            }
        }
        public BitmapImage Image5
        {
            get { return _image5; }
            set
            {
                _image5 = value;
                base.OnPropertyChanged("Image5");
            }
        }
        public BitmapImage Image6
        {
            get { return _image6; }
            set
            {
                _image6 = value;
                base.OnPropertyChanged("Image6");
            }
        }
        public BitmapImage Image7
        {
            get { return _image7; }
            set
            {
                _image7 = value;
                base.OnPropertyChanged("Image7");
            }
        }
        public BitmapImage Image8
        {
            get { return _image8; }
            set
            {
                _image8 = value;
                base.OnPropertyChanged("Image8");
            }
        }
        public BitmapImage Image9
        {
            get { return _image9; }
            set
            {
                _image9 = value;
                base.OnPropertyChanged("Image9");
            }
        }
        public BitmapImage Image10
        {
            get { return _image10; }
            set
            {
                _image10 = value;
                base.OnPropertyChanged("Image10");
            }
        }
        public BitmapImage Image11
        {
            get { return _image11; }
            set
            {
                _image11 = value;
                base.OnPropertyChanged("Image11");
            }
        }
        public BitmapImage Image12
        {
            get { return _image12; }
            set
            {
                _image12 = value;
                base.OnPropertyChanged("Image12");
            }
        }
        public BitmapImage Image13
        {
            get { return _image13; }
            set
            {
                _image13 = value;
                base.OnPropertyChanged("Image13");
            }
        }
        public BitmapImage Image14
        {
            get { return _image14; }
            set
            {
                _image14 = value;
                base.OnPropertyChanged("Image14");
            }
        }

        public BitmapImage Image15
        {
            get { return _image15; }
            set
            {
                _image15 = value;
                base.OnPropertyChanged("Image15");
            }
        }
        public BitmapImage Image16
        {
            get { return _image16; }
            set
            {
                _image16 = value;
                base.OnPropertyChanged("Image16");
            }
        }
        public BitmapImage Image17
        {
            get { return _image17; }
            set
            {
                _image17 = value;
                base.OnPropertyChanged("Image17");
            }
        }
        public BitmapImage Image18
        {
            get { return _image18; }
            set
            {
                _image18 = value;
                base.OnPropertyChanged("Image18");
            }
        }
        public BitmapImage ProductLogo
        {
            get { return _productLogo; }
            set
            {
                _productLogo = value;
                base.OnPropertyChanged("ProductLogo");
            }
        }

        public void SetApplicationModeImages(ApplicationMode mode)
        {
            try
            {
                switch (mode.Id)
                {
                    case 1:
                        {
                            SetFarmImages();
                            break;
                        }
                    case 2:
                    case 4:
                        {
                            SetPosImages();
                            break;
                        }
                    case 3:
                        {
                            SetRetailImages();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void DisplayLogo()
        {
            ProductLogo = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\storepro_logo_white.jpg");
        }
       
        protected void SetPosImages()
        {
            Image1 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Pos\1.jpg");
            Image2 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\1.jpg");
            Image3 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\2.jpg");
            Image4 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\3.jpg");
            Image5 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\4.jpg");
            Image6 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Pos\2.jpg");
            Image7 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Pos\3.jpg");
            Image8 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\7.png");
            Image9 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\8.jpg");
        }

        protected void SetFarmImages()
        {
            Image1 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\1.jpg");
            Image2 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\2.jpg");
            Image3 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\3.jpg");
            Image4 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\4.jpg");
            Image5 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\5.jpg");
            Image6 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\7.jpg");
            Image7 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\8.jpg");
            Image8 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\9.jpg");
            Image9 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Farm\10.jpg");
            Image10 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\1.jpg");
            Image11 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\2.jpg");
            Image12 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\3.jpg");
            Image13 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\4.jpg");
            Image14 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\5.jpg");
            Image15 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\6.jpg");
            Image16 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\7.png");
            Image17 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\8.jpg");
        }

        protected void SetRetailImages()
        {
            Image1 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\1.jpg");
            Image2 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\2.jpg");
            Image3 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\3.jpg");
            Image4 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\4.jpg");
            Image5 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\5.jpg");
            Image6 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\6.jpg");
            Image7 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\7.png");
            Image8 = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Retail\8.jpg");
        }




       


    }
}
