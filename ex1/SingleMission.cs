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

        /**
         * constructor.
         */ 
        public SingleMission(FuncIndexer mission, string name)
        {
            this.name = name;
            this.myMission = mission;
        }

        /***************************
         * implement the EventHandler of IMission.
         ***************************/
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

        /******************
        * Calculate the function
        *    and do EventHandler. 
        * input:    double.
        * output:   double.
        ******************/
        public double Calculate(double value)
        {
            double outcome = this.myMission(value);
            // if OnCalculate != null -> invoke..
            OnCalculate?.Invoke(this, outcome);
            return outcome;
            
        }
    }
}
