using FlatBuffers;
using SerializeClass;
using System;
using System.Collections.Generic;
using TestFlatBuffer.Model;
using Xunit;

namespace TestTestFlatBuffer
{
  public class MyFlatBufferTests
  {
    [Fact(DisplayName = "when I serialize a recursive complex object then it will be serialized")]
    public void Test1()
    {
      var father = new PersonInstance("Father", null);
      var child = new PersonInstance("child", new List<PersonInstance>(new PersonInstance[] { father }));
      PersonInstance expected = new PersonInstance(
      "Figlio",
      new List<PersonInstance> {
        father,
        new PersonInstance("Mother",null)
      }
     );

      expected.Works.Add("L1", 1);
      expected.NickNames.Add("F1", new PersonInstance("Friend", null));


      var data = new PersonSerializer().Serialize(expected).GetBytes();

      var bufReaded = new ByteBuffer(data);
      var dataReceived = Person.GetRootAsPerson(bufReaded);
      var c = dataReceived.Name;
      var f = dataReceived.Parent(0).Value.Name;
      var record = dataReceived.WorksByKey("L1");
      NickName record2 = dataReceived.NickNamesByKey("F1").Value;
      Person a = record2.Value.Value;

      var actual = default(PersonInstance);
      actual = PersonSerializer.Deserialize(data);

      Assert.NotSame(expected, actual);
      Assert.Same(expected.name, actual.name);
    }
  }
}
