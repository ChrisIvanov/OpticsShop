namespace OpticsShop.Services.FileIO.Writer
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Global;
    using System.Text.Json;

    internal class Writer
    {


        // метод за записване на данни в JSON формат
        public void WriteToFile(Appointment appointment)
        {
            string filePath = GlobalVariables.APPOINTMENTS_FILE_PATH;
            string result = JsonSerializer.Serialize<Appointment>(appointment);

            File.WriteAllText(filePath, result);
        }
    }
}
