using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Localization
{
    public interface IResourceManagerProvider
    {
        ResourceManager ResourceManager { get; }
    }
}
