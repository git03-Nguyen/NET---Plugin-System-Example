﻿namespace SharedContract
{
    public interface IPlugin
    {
        string Name { get; }
        void Run();
    }
}
