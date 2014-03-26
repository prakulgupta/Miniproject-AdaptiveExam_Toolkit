using System;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(OnlineExam.App_Start.MySuperPackage), "PreStart")]

namespace OnlineExam.App_Start {
    public static class MySuperPackage {
        public static void PreStart() {
            MVCControlsToolkit.Core.Extensions.Register();
        }
    }
}