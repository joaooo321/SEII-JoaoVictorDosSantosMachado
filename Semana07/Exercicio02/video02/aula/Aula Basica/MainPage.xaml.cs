namespace Aula_Basica
{
    public partial class MainPage : TabbedPage
    {
        string nome;

        public MainPage()
        {
            InitializeComponent();
            string endereco = @"<iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/uyzmSyvRWT8?si=EauzDSLzWt7iYavd"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"" referrerpolicy=""strict-origin-when-cross-origin"" allowfullscreen></iframe>";
            WVVideo.Source = new HtmlWebViewSource
            {
                Html = endereco
            };
        }

        private async void BTNOla_Clicked(object sender, EventArgs e)
        {
            nome = await DisplayPromptAsync("Nome", "Digite seu nome:", "OK");
            await DisplayAlert("Aviso", "Ola " + nome, "OK");
        }
    }

}
