namespace iForceCustomerVehicleDatabase.ViewModel
{

    /// Links models to colour as only some colours available for some models
    /// easy to find appropriate colour cobinations
    /// </summary>
    public class ModelColourVM
    {



        public ModelColourVM()
        {
        }

        public ModelVM Model;

        public ColourVM Colour;

        public long Id;

        public string Name;

    }
}