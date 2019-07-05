using System;
using System.Runtime.InteropServices;

using Windows.ApplicationModel.Resources;

namespace RMBCapConverter.Helpers
{
    internal static class ResourceExtensions
    {
        private static readonly ResourceLoader ResLoader = new ResourceLoader();

        public static string GetLocalized(this string resourceKey)
        {
            return ResLoader.GetString(resourceKey);
        }
    }
}
