using System;
using System.Linq;
using System.Collections.Generic;

namespace DumbChatbotLib
{
    public class Memory : IMemory
    {
        private readonly IDictionary<int, string> _heard;
        private readonly IDictionary<int, string> _said;

        public Memory()
        {
            _heard = new Dictionary<int, string>();
            _said = new Dictionary<int, string>();
        }

        public void Add(string heard, string said)
        {
            var heardKey = AddHeard(Prep(heard));
            AddSaid(heardKey, Prep(said));
        }

        public IList<string> SaidWhen(string heard)
        {
            var heardPairs = _heard.Where(p => p.Value == Prep(heard));
            IList<string> thingsSaid = new List<string>();
            foreach (var pair in heardPairs)
            {
                var said = _said
                    .Where(p => p.Key == pair.Key)
                    .FirstOrDefault();
                if (said.Key > 0)
                {
                    thingsSaid.Add(said.Value);
                }
            }
            return thingsSaid;
        }

        private int AddHeard(string heard)
        {
            if (string.IsNullOrWhiteSpace(heard))
            {
                return 0;
            }
            var heardKey = _heard.Count + 1;
            _heard.Add(heardKey, heard);
            return heardKey;
        }

        private void AddSaid(int heardKey, string said)
        {
            if (_said.ContainsKey(heardKey))
            {
                throw new InvalidOperationException(
                        $"{nameof(heardKey)} already added to said dictionary");
            }
            _said.Add(heardKey, said);
        }

        private string Prep(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "";
            }
            return s.Trim().ToLower();
        }

    }
}
