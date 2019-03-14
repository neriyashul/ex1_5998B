using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class SingleMission : IMission
    {
        private FuncIndexer myMission;
        string name;

        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated


        public SingleMission(FuncIndexer mission, string name)
        {
            this.name = name;
            this.myMission = mission;
        }

        event EventHandler<double> IMission.OnCalculate
        {
            add
            {
                OnCalculate += value;
            }

            remove
            {
                OnCalculate -= value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Type
        {
            get
            {
                return "Single";
            }
        }

        public double Calculate(double value)
        {
            OnCalculate(this, value);
            return this.myMission(value);
        }
    }
}
