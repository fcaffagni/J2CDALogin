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
                //lblBoasVindas.Text = $"Usuário logado: {usuarioLogado}";
                
                if (string.IsNullOrEmpty(usuarioLogado))
                {
                    App.Current.MainPage = new Login();
                }
                else
                {
                    lblBoasVindas.Text = $"Usuário logado: {usuarioLogado}";
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
        bool confirma =  await DisplayAlert("Tem certeza?", "Sair do App?", "Sim", "Não");
        if (confirma)
        {
            SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new Login();
        }
    }
}