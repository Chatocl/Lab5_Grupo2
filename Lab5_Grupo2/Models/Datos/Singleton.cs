namespace Lab5_Grupo2.Models.Datos
{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }
        public Clases.Arbol_2_3<Vehiculos> ArbolVehiculos = new Clases.Arbol_2_3<Vehiculos>();
    }
}
