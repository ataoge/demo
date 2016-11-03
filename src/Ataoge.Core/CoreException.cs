namespace Ataoge
{
   
    public class CoreException : System.Exception
    {
        public CoreException() { }
        public CoreException( string message ) : base( message ) { }
        public CoreException( string message, System.Exception inner ) : base( message, inner ) { }
       
    }
}