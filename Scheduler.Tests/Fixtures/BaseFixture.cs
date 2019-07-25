using System;
using Scheduler.Main.IoC;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Tests.Fixtures;

namespace Scheduler.Tests
{
    public class BaseFixture : IDisposable
    {
        public void Dispose() { }
    }
}