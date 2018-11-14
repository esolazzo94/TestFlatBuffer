using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFlatBuffer.Model
{
  public interface IPersonSerializable
  {
    void Serialize();
    void Deserialize();
  }
}
