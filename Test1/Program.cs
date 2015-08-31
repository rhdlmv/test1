using System;
              using System.Collections.Generic;
              using System.Linq;
              using StockTools.Utils; 
              using StockScript;
              using DataObject;


              namespace Test.Indicator
              {
                    public class paul_-testddd : IIndicator
                    {

                        public paul_-testddd()
                        {
                            
                        }   

                        private string _alias = "paul1";


                        public string Name { get { return "paul_-testddd";} }
public string Alias
{
    get { return _alias; }
    set { _alias = value;  }
}


                        public double ddd(CSTradeScriptContext context, HistoryPrices historyPrices)
{
	return double.NaN;
}

public int GetParameterCount() { return 0; }
public Type[] GetParameterTypes() { return null; }
public Dictionary<string, List<Data>> GetIndicatorDatas(CSTradeScriptContext context, object[] parameters)
{
Dictionary<string, List<Data>> results = new Dictionary<string, List<Data>>();
context.LogEntityType = LogEntityType.INDICATOR;
results.Add("ddd", new List<Data>());
context.CalculatingIndicatorName = this.Alias;
foreach(DateTime date in context.GetProcessDates())
{
context.CurrentDate = date;
double ddd = ddd(context, context.GetDataByDate<HistoryPrices>(date));
context.SetIndicatorData(this.Alias, "ddd", ddd);
results["ddd"].Add(new Data() { Date = date, Value = ddd });
}
return results;
}


                    }
              }
