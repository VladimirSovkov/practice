using Parse.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parse.Domain.Interface
{
    public interface IParseXML
    {
        IEnumerable<XMLModel> GetData(string url);
    }
}
