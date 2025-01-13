namespace Gorusel_odevi2;

public partial class Giris : ContentPage
{
    private readonly FirebaseAuthService _authService;
    public Giris()
	{
        InitializeComponent();
        _authService = new FirebaseAuthService();

    }
    private async void OnLabelTapped(object sender, EventArgs e)
    {
        // Farklý bir sayfaya yönlendirme
        await Navigation.PushAsync(new MainPage());
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {

        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Hata", "E-posta ve ifre bo braklamaz.", "Tamam");
            return;
        }


        string result = await _authService.LoginUserAsync(email, password);
        await DisplayAlert("Sonuç", result, "Tamam");
    }
}