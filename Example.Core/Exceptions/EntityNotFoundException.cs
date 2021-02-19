using System;

namespace Example.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, object key = null)
            : base($"Entity '{name}' ({ key ?? ""}) was not found.")
        {
        }
    }
}

