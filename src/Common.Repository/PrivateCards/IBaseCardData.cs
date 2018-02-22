using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.PrivateCards
{
    public interface IBaseCardData
    {
        int ID { get; }
        string CardSecret { get; set; }
        string CategoryID { get; }
    }
}
