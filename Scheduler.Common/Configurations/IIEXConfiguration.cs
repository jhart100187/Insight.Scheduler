using System;

namespace Scheduler.Common.Configuration
{
    public interface IIEXConfiguration
    {
        string HOST { get; }

        string VERSION { get; }

        string TOKEN { get; }
    }
}