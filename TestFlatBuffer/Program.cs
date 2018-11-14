using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TestFlatBuffer.Model;
using FlatBuffers;
using SerializeClass;

namespace TestFlatBuffer
{
  class Program
  {
    static void Main(string[] args)
    {
     // var father = new PersonInstance("Father", null);
     // var child = new PersonInstance("child", new List<PersonInstance>(new PersonInstance[] { father }));
     // PersonInstance p = new PersonInstance(
     // "Figlio",
     // new List<PersonInstance> {
     //   father,
     //   new PersonInstance("Mother",null)
     // }
     //);

     // p.Works.Add("L1", 1);
     // p.NickNames.Add("F1", new PersonInstance("Friend", null));


     // var data = new PersonSerializer().Serialize(p).GetBytes();

     // var bufReaded = new ByteBuffer(data);
     // var dataReceived = Person.GetRootAsPerson(bufReaded);
     // var c = dataReceived.Name;
     // var f = dataReceived.Parent(0).Value.Name;
     // var record = dataReceived.WorksByKey("L1");
     // NickName record2 = dataReceived.NickNamesByKey("F1").Value;
     // Person a = record2.Value.Value;
    }
  }
}
