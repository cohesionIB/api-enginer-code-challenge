/*
 * Third Party Code that is not to be changed.
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lot.O.Invitation.Codes.Services
{
    public interface IRuntimeInfo
    {
        bool RunningOnNix { get; }
    }

    public class RuntimeInfo : IRuntimeInfo
    {
        public bool RunningOnNix => !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}
