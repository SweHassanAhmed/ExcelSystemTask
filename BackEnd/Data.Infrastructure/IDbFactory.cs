using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public interface IDbFactory
    {
        BaseEntity Init();
    }
}
