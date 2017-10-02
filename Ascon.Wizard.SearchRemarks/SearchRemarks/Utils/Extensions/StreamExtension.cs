using Ascon.Pilot.SDK;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static SearchRemarks.Ninject.NinjectCommon;

namespace SearchRemarks.Utils.Extensions
{
    public static class StreamExtension
    {
        private static IFileProvider _fileProvider => Kernel.Get<IFileProvider>();

        public static List<Stream> MapToStream(this IEnumerable<IFile> source)
        {
            var streams = new List<Stream>();

            if (source.Any())
            {
                foreach (var item in source)
                {
                    streams.Add(_fileProvider.OpenRead(item));
                }
            }

            return streams;
        }
    }
}
