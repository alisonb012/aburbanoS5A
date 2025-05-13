using aburbanoS5A.Models;

namespace aburbanoS5A.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
        InitializeComponent();
        CargarPersonasEnPicker();
	}
    private void CargarPersonasEnPicker()
    {
        var lista = App.personRepo.GetAllPerson();
        pickerPersonas.ItemsSource = lista;
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

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        var personaSeleccionada = pickerPersonas.SelectedItem as Persona;
        if (personaSeleccionada != null && !string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            App.personRepo.UpdatePerson(personaSeleccionada.Id, txtNombre.Text);
            DisplayAlert("Mensaje", App.personRepo.statusMessage, "OK");
            txtNombre.Text = "";
            pickerPersonas.SelectedItem = null;
            btnListar_Clicked(sender, e);
        }
        else
        {
            statusMessage.Text = "Seleccione una persona y escriba el nuevo nombre.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        var personaSeleccionada = pickerPersonas.SelectedItem as Persona;
        if (personaSeleccionada != null)
        {
            App.personRepo.DeletePerson(personaSeleccionada.Id);
            DisplayAlert("Mensaje", App.personRepo.statusMessage, "OK");
            pickerPersonas.SelectedItem = null;
            btnListar_Clicked(sender, e);
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para eliminar.";
        }
    }
    private void pickerPersonas_SelectedIndexChanged(object sender, EventArgs e)
    {
        var persona = pickerPersonas.SelectedItem as Persona;
        if (persona != null)
        {
            txtNombre.Text = persona.Name;
        }
    }
}