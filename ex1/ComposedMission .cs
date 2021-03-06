﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class ComposedMission : IMission
    {
        event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        List<FuncIndexer> missionList = new List<FuncIndexer>();

        private string name;

        /**
         * constructor.
         */
        public ComposedMission(string name)
        {
            this.name = name;
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
                return "Composed";
            }
        }

        /***************************
         * Add mission to mission list. 
         ***************************/
        public ComposedMission Add(FuncIndexer mission)
        {
            missionList.Add(mission);
            return this;
        }


        /***********************************
        * Calculate the functions,
        *           (calculate the first send the result
        *           to the second etc.)
        *    and do EventHandler. 
        * input:    double.
        * output:   double.
        ******************/
        double IMission.Calculate(double value)
        {
            double sum = value;
            foreach (FuncIndexer f in missionList)
            {
                sum = f(sum);
            }
            // if OnCalculate != null -> invoke..
            OnCalculate?.Invoke(this, sum);
            return sum;
        }
    }
}
