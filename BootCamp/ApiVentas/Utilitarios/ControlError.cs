namespace ApiVentas.Utilitarios
{
    public class ControlError
    {
<<<<<<< HEAD
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
=======
        public void LogErrorMetodos(string clase, string metodo, string error)
        {
            var ruta = string.Empty;
            var archivo = string.Empty;
            DateTime fecha = DateTime.Now;

            try
            {
                ruta = "C:\\ApiVentas\\Logs";
                archivo = $"Log_{fecha.ToString("dd-MM-yyyy")}";
              if (!Directory.Exists(ruta))
>>>>>>> 51d753598d72b527e8641099d8c0352deff52358
                {
                    Directory.CreateDirectory(ruta);
                }

<<<<<<< HEAD
                var mensaje = $"\nSe presento una novedad en la clase: {clase}, en el metodo: {metodo}, con el siguiente error: {error}";
                File.AppendAllText(Path.Combine(ruta, archivo), mensaje);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error desde controlError: ", ex.Message);
            }
        }
=======
                StreamWriter write = new StreamWriter($"{ruta}\\{archivo}", true);
                write.WriteLine($"Se presentó una novedad en la clase: {clase}, en el método: {metodo}, con el siguiente error: {error}");
                write.Close();
            }
            catch (Exception ex)
            {
                StreamWriter writer=new StreamWriter($"{ruta}{archivo}", true);
                writer.WriteLine($"Se presento una novedad en la clase: '{clase}', en el metodo: '{metodo}', con el siguente error: '{message}'");
                writer.Close();
            }
>>>>>>> 51d753598d72b527e8641099d8c0352deff52358
    }
}
