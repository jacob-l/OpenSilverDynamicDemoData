﻿using OpenSilver.Simulator;
using System;

namespace OpenSilverDynamicDemoData.Simulator
{
    internal static class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            return SimulatorLauncher.Start(typeof(App));
        }
    }
}
