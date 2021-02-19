using System;

namespace Example.Core.Exceptions
{
    public class EntityBadRequestException : Exception
    {
        public EntityBadRequestException(string name)
            : base($"Invalid entity of type '{name}'.")
        {
        }
    }
}