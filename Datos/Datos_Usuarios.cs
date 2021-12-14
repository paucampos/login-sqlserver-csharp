namespace Datos
{
    public class Datos_Usuarios
    {
        public Datos_Usuarios()
        {
            IntentosErroneos = 0;
        }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int IntentosErroneos  { get; set; }
    }
}
