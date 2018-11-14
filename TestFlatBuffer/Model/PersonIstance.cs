using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestFlatBuffer.Model
{
  public class PersonInstance // : IPersonSerializable
  {
    public string name;
    public List<PersonInstance> parent;
    public Dictionary<string, int> Works { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, PersonInstance> NickNames { get; set; } = new Dictionary<string, PersonInstance>();

    public PersonInstance(string name, List<PersonInstance> parent)
    {
      this.name = name;
      this.parent = parent;
    }
 
    //public void Serialize()
    //{

    //}

    //public void Deserialize()
    //{

    //}

  }
}
