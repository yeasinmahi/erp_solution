namespace Utility
{
    public class Variables
    {
        private static Variables _instance;
        public char[] DelimiterChars { get; private set; }

        private Variables()
        {
            DelimiterChars =new[] { '[', ']' };
        }

        public static Variables GetInstance()
        {
            if (_instance == null)
            {
                return new Variables();
            }
            return _instance;
        }
    }
}
