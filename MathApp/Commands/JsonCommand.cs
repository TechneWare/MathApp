using MathApp.Data;
using MathApp.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class JsonCommand : ICommand, ICommandFactory
    {
        private IDataContext dbContext;

        public string CommandName => "JsonDemo";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { "jd" };

        public string Description => "Performs serialization to Json and Back";

        public JsonCommand()
        { }
        public JsonCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Execute()
        {
            IEnumerable<IShape> deserializedShapes = SerializeDeserialize(dbContext.GetAllShapes(SortBy.None));
            Utils.DisplayShapes("=== Deserialized Shapes ===", deserializedShapes);
        }

        public ICommand MakeCommand(string[] args)
        {
            return new JsonCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return new JsonCommand(dbContext);
        }

        private IEnumerable<IShape> SerializeDeserialize(IEnumerable<IShape> shapes)
        {
            var serializerOpts = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            string json = JsonConvert.SerializeObject(shapes, serializerOpts);
            Console.WriteLine($"\n=== Json Serialized ===\n{json}");
            var deserializedShapes = JsonConvert.DeserializeObject<IEnumerable<IShape>>(json, serializerOpts);
            return deserializedShapes;
        }
    }
}
