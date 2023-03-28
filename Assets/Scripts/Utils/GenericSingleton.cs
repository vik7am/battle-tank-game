namespace BattleTank
{
    public class GenericSingleton<T> where T : GenericSingleton<T>
    {
        private static T instance;

        public static T Instance(){
            if(instance == null)
                instance = (T)new GenericSingleton<T>();
            return instance;
        }
    }
}
