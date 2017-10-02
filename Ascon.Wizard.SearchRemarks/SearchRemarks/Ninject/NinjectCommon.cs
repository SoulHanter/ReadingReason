using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchRemarks.Ninject
{
    public class NinjectCommon
    {
        private static IKernel kernel;
        private static object syncRoot = new object();

        public static IKernel Kernel
        {
            get
            {
                if (kernel == null)
                {
                    lock (syncRoot)
                    {
                        if (kernel == null)
                        {
                            kernel = new StandardKernel();
                        }
                    }
                }
                return kernel;
            }
        }
    }
}
