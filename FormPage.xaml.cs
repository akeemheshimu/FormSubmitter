using CommunityToolkit.Mvvm.Input;
using FormSubmitter.ViewModel;


namespace FormSubmitter;



public partial class FormPage : ContentPage 
{
    public FormPage(FormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}