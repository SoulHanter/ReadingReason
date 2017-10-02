using Ascon.Pilot.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchRemarks.Utils.Loader
{
    public interface IObjectLoader : IObserver<IDataObject>
    {
        void Load(Action<IList<IDataObject>> onLoadedAction, Func<IType, bool> typesFilter, params Guid[] ids);
    }
}
