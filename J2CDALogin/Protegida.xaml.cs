namespace J2CDALogin;

public partial class Protegida : ContentPage
{
    public Protegida()
    {
        InitializeComponent();

        string? usuarioLogado = null;

        Task.Run(async () =>
        {
            try
            {
                usuarioLogado = await SecureStorage.Default.GetAsync("usuario_logado");
                //lblBoasVindas.Text = $"Usu�rio logado: {usuarioLogado}";
                
                if (string.IsNullOrEmpty(usuarioLogado))
                {
                    App.Current.MainPage = new Login();
                }
                else
                {
                    lblBoasVindas.Text = $"Usu�rio logado: {usuarioLogado}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Fechar");
            }
        });
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirma =  await DisplayAlert("Tem certeza?", "Sair do App?", "Sim", "N�o");
        if (confirma)
        {
            SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new Login();
        }
    }
}