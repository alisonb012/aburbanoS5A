using aburbanoS5A.Models;

namespace aburbanoS5A.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertarDatos_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtNombre.Text);

        statusMessage.Text = App.personRepo.statusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> lista = App.personRepo.GetAllPerson();
        ListPersonas.ItemsSource = lista;
    }
}