using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public interface ITagSeoProxy
    {
        object TagSeoCRUD(TagSeoItem tagSeoItem);
    }
}
