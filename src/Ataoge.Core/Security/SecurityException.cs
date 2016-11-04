using Ataoge;

namespace Ataog.Security
{
    public class SecurityException : CoreException
    {
        public SecurityException( string message ) : base( message ) { }
        public SecurityException( string message, System.Exception inner ) : base( message, inner ) { }
        
    }
}