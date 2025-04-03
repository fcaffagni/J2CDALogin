namespace J2CDALogin;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<DadosUsuarios> listaUsuarios = new List<DadosUsuarios>()
            {
                new DadosUsuarios()
                {
                    Usuario = "joao",
                    Senha="1234"
                }
            };

            DadosUsuarios dadosDigitados = new DadosUsuarios()
            {
                Usuario = txbUser.Text,
                Senha = txbSenha.Text
            };

            if (listaUsuarios.Any
                (i => (dadosDigitados.Usuario == i.Usuario && dadosDigitados.Senha == i.Senha)))
            {
                await SecureStorage.SetAsync("usuario_logado", dadosDigitados.Usuario);

                App.Current.MainPage = new Protegida();
            }
            else
            {
                throw new Exception("Usuário ou Senha incorretos.");
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro: ", ex.Message, "Fechar");
        }
    }
}