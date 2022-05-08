using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HWS_LINQ
{
    internal class Agent
    {
        public string AgentName { get; set; }
        public int AgentId { get; set; }
        public List<Costumer> AgentCostumers { get; set; }

        public Agent(string name, int id)
        {
            AgentName = name;
            AgentId = id;
            AgentCostumers = new List<Costumer>();
        }

        public override string ToString()
        {
            return $"AgentName: {AgentName}, AgentId:{AgentId}";
        }
    }
}
