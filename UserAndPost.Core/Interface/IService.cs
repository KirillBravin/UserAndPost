using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPost.Core.Models;

namespace UserAndPost.Core.Interface
{
    public interface IService
    {
        IUserServices Services { get; }
        IPostServices PostServices { get; }
    }
}
