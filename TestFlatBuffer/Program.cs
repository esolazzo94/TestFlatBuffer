using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using TestFlatBuffer.Model;
using FlatBuffers;
using SerializeClass;

namespace TestFlatBuffer
{
  class Program
  {
    static void Main(string[] args)
    {
      var father = new PersonInstance("Father", null);
      var child = new PersonInstance("child", new List<PersonInstance>(new PersonInstance[] { father }));
      PersonInstance expected = new PersonInstance(
      "Figlio",
      new List<PersonInstance> {
        child,
        new PersonInstance("Mother",null)
      }
     );

      expected.Works.Add("L1", 1);
      expected.NickNames.Add("F1", new PersonInstance("Friend", null));


      var data = new PersonSerializer().Serialize(expected).GetBytes();

      using (BinaryWriter writer = new BinaryWriter(File.Open("file", FileMode.Create)))
      {
        writer.Write(data);
      }
      byte[] read;

      using (BinaryReader reader = new BinaryReader(File.Open("file",FileMode.Open)))
      {
        read = reader.ReadBytes((int)new FileInfo("file").Length);
      }

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
