using Whatsapp_Clone_UI.Views;

namespace Whatsapp_Clone_UI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new NewPage1());
	}
}
