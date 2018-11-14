using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlatBuffers;
using SerializeClass;

namespace TestFlatBuffer.Model
{
  public class PersonSerializer
  {

    private FlatBufferBuilder _builder = new FlatBufferBuilder(1);

    public PersonSerializer()
    {
    }

    public PersonSerializer Serialize(PersonInstance value)
    {
      /*if (value is IPersonSerializable)
      {*/
        var person = WritePerson(value);
        _builder.Finish(person.Value);
     // }
      return this;
    }

    private StringOffset WriteString(string s)
    {
      return _builder.CreateString(s);
    }

    private Offset<Person> WritePerson(PersonInstance value)
    {
      VectorOffset parentVector = new VectorOffset();
      if (value.parent != null)
      {
        var persons = new Offset<Person>[value.parent.Count];
        int index = 0;
        foreach (var person in value.parent)
        {
          persons[index]= WritePerson(person);
          index++;
        }
        parentVector = Person.CreateParentVector(_builder,persons);   
      }

      VectorOffset worksVector = new VectorOffset();
      if (value.Works.Count > 0)
      {
        var works = new Offset<Work>[value.Works.Count];
        int index = 0;
        foreach (var work in value.Works)
        {
          works[index] = WriteWork(work);
          index++;
        }
        worksVector = Work.CreateSortedVectorOfWork(_builder, works);
      }

      VectorOffset nickNamesVector = new VectorOffset();
      if (value.NickNames.Count > 0)
      {
        var nickNames = new Offset<NickName>[value.NickNames.Count];
        int index = 0;
        foreach (var nickName in value.NickNames)
        {
          nickNames[index] = WriteNickName(nickName);
          index++;
        }
        nickNamesVector = NickName.CreateSortedVectorOfNickName(_builder, nickNames);
      }

      var name = WriteString(value.name);
      Person.StartPerson(_builder);
      Person.AddName(_builder, name);
      if (value.parent != null) Person.AddParent(_builder, parentVector);
      if (value.Works.Count > 0) Person.AddWorks(_builder, worksVector);
      if (value.NickNames.Count > 0) Person.AddNickNames(_builder, nickNamesVector);
      return Person.EndPerson(_builder);
    }

    private Offset<Work> WriteWork(KeyValuePair<string,int> value)
    {
      var stringID = WriteString(value.Key);
      return Work.CreateWork(_builder,stringID,value.Value);
    }

    private Offset<NickName> WriteNickName(KeyValuePair<string, PersonInstance> value)
    {
      var stringID = WriteString(value.Key);
      var person = WritePerson(value.Value);
      return NickName.CreateNickName(_builder, stringID, person);
    }

    public static PersonInstance Deserialize(byte[] data)
    {
      var bufReaded = new ByteBuffer(data);
      var dataReceived = Person.GetRootAsPerson(bufReaded);


      return null;
    }

    public Byte[] GetBytes()
    {
      return this._builder.SizedByteArray();
    }

  }
}
