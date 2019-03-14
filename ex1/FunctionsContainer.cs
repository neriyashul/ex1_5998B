using System;
using System.Collections.Generic;

namespace Excercise_1 { 

    public delegate double FuncIndexer(double f);

    public class FunctionsContainer
    {

        Dictionary<string, FuncIndexer> funcDict = new Dictionary<string, FuncIndexer>();
        

        public FuncIndexer this[string name]
        {
            get
            {
                if (!funcDict.ContainsKey(name))
                {
                    funcDict[name] = val => val;
                }
                return funcDict[name];
            }
            set
            {
                funcDict[name] = value;
            }
        }

        public List<string> getAllMissions()
        {
            return new List<string>(this.funcDict.Keys);
        }
    }
}
