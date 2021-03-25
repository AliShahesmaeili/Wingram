using Instagram.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingram.Interfaces
{
    public interface IInstagramService
    {
        IInstaApi InstagramApi();
    }
}
