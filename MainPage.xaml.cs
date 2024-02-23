using FormSubmitter.ViewModel;

namespace FormSubmitter
{
    public partial class MainPage : ContentPage
    {


        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }


        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync("///MainPage/FormPage");
        }
    }

}
