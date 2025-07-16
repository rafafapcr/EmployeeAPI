﻿namespace Worker.Application.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException() : base("Resource was not found.")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}
