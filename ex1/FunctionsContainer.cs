using System;
using System.Collections.Generic;

namespace Excercise_1 { 

    public delegate double FuncIndexer(double f);

    public class FunctionsContainer
    {

        Dictionary<string, FuncIndexer> funcDict = new Dictionary<string, FuncIndexer>();

        /******************
        * Indexer to the function.
        * input:    string.
        * output:   FuncIndexer.
        ******************/
        public FuncIndexer this[string name]
        {
            get
            {
                // if there is no such name -> create new function which do nothing.
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

        /******************
        * the function return list with all the missions.
        * input:    -
        * output:   List<string>.
        ******************/
        public List<string> getAllMissions()
        {
            return new List<string>(this.funcDict.Keys);
        }
    }
}
