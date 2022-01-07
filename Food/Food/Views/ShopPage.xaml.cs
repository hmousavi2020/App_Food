using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {
        public ShopPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private Timer timer;
        public List<Banner> Banners { get => GetBanners(); }
        public List<product> CollectionsList { get => GetProducts(); }
        public List<product> TrendsList { get => GetTrends(); }
        private List<Banner> GetBanners()
        {
            var bannerList = new List<Banner>();
            bannerList.Add(new Banner { Heading = "SUMMER COLLECTION", Message = "40% OFF", Caption = "این خیلی خوب هست", Image = "classic.png" });
            bannerList.Add(new Banner { Heading = "SUMMER COLLECTION", Message = "40% OFF", Caption = "این خیلی خوب هست", Image = "classic.png" });
            bannerList.Add(new Banner { Heading = "SUMMER COLLECTION", Message = "40% OFF", Caption = "این خیلی خوب هست", Image = "classic.png" });
            return bannerList;
        }

        private List<product> GetProducts()
        {
            var productList = new List<product>();
            productList.Add(new product { Image = "floral.png", Name = "یک چیزی هست دیگه", Price = "135000" });
            productList.Add(new product { Image = "floral.png", Name = "یک چیزی هست دیگه", Price = "135000" });
            productList.Add(new product { Image = "floral.png", Name = "یک چیزی هست دیگه", Price = "135000" });
            return productList;
        }

        private List<product> GetTrends()
        {
            var collectionsList = new List<product>();
            collectionsList.Add(new product { Image = "heeledshoe.png", Name = "دو چیزی هست دیگه", Price = "136000" });
            collectionsList.Add(new product { Image = "heeledshoe.png", Name = "دو چیزی هست دیگه", Price = "136000" });
            collectionsList.Add(new product { Image = "heeledshoe.png", Name = "دو چیزی هست دیگه", Price = "136000" });
            return collectionsList;
        }
        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = true, Enabled = true };
            timer.Elapsed += Timer_Elapsed;
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            timer.Dispose();
            base.OnDisappearing();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (cvBanners.Position == 2)
                {
                    cvBanners.Position = 0;
                    return;
                }
                cvBanners.Position += 1;
            });
        }
    }
    public class Banner
    {
        public string Heading { get; set; }
        public string Message { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }
    public class product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}