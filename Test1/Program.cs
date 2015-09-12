//using System;
//using System.Collections.Generic;
//using System.Linq;
//using StockTools.Utils;
//using StockScript;
//using DataObject;


//namespace Test.Indicator
//{
//    public class paultest2 : IIndicator
//    {

//        public paultest2()
//        {

//        }

//        private string _alias = "paulTest2";


//        public string Name { get { return "paultest2"; } }
//        public string Alias
//        {
//            get { return _alias; }
//            set { _alias = value; }
//        }


//        public double dd(CSTradeScriptContext context, Application application, HistoryPrices historyPrices)
//        {
//            return double.NaN;
//        }

//        public int GetParameterCount() { return 1; }
//        public Type[] GetParameterTypes() { return new Type[] { typeof(Int32) }; }
//        public Dictionary<string, List<Data>> GetIndicatorDatas(CSTradeScriptContext context, object[] parameters)
//        {
//            Dictionary<string, List<Data>> results = new Dictionary<string, List<Data>>();
//            context.LogEntityType = LogEntityType.INDICATOR;
//            results.Add("dd", new List<Data>());
//            context.Arguments.gg = ConvertUtils.ToObject<int>(parameters[0]);
//            context.CalculatingIndicatorName = this.Alias;
//            foreach (DateTime date in context.GetProcessDates())
//            {
//                context.CurrentDate = date;
//                double dd = dd(context, context.GetDataByDate<Application>(date), context.GetDataByDate<HistoryPrices>(date));
//                context.SetIndicatorData(this.Alias, "dd", dd);
//                results["dd"].Add(new Data() { Date = date, Value = dd });
//            }
//            return results;
//        }


//    }
//}
