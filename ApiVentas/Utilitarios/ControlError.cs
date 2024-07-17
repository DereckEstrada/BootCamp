namespace ApiVentas.Utilitarios
{
    public class ControlError
    {
        public void LogErrorMetodos(string clase, string error, string metodo)
        {
            var ruta = string.Empty;
            var archivo = string.Empty;
            DateTime Fecha = DateTime.Now;

            try
            {
                ruta = "C:\\ProyectoIntegradorGrupal\\logs";
                archivo = $"Log_{Fecha.ToString("dd-MM-yyyy")}.txt";

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                var mensaje = $"\nSe presento una novedad en la clase: {clase}, en el metodo: {metodo}, con el siguiente error: {error}";
                File.AppendAllText(Path.Combine(ruta, archivo), mensaje);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error desde controlError: ", ex.Message);
            }
        }
    }
}
