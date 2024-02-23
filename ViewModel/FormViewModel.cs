using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace FormSubmitter.ViewModel
{
    public partial class FormViewModel : ObservableObject
    {

        private string _filePicker;
        public string filePicker
        {
            get => _filePicker;
            set
            {
                SetProperty(ref _filePicker, value);
            }
        }
        //We have a string called filePicker. We get our filePicker and set it to the SetProperty which indicates when a user has selected a new 
        //file from the Picker which is referenced to our _filePicker. 
        public RelayCommand<string> FilePickedCommand { get; set; }
        public FormViewModel()
        { 
            FilePickedCommand = new RelayCommand<string>(FilePicked);
        }

        private void FilePicked(string filePicker)
        {
            this.filePicker = filePicker;
        }

        [RelayCommand]
        static async Task RequestPermission()
        {
            var status = PermissionStatus.Unknown;

            status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if(status == PermissionStatus.Granted)
               return;
            
            if(Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                await Shell.Current.DisplayAlert("Request the damn permission", "Because needed", "OK");
                
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            if (status != PermissionStatus.Granted)
                await Shell.Current.DisplayAlert("Permission is a must", "Provide the permission", "OK");
        }
        [RelayCommand]
        private static async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }

                return result;
            }
            catch (Exception)
            {
                // The user canceled or something went wrong
            }

            return null;
        }
    }

}
