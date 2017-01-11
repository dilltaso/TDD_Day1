using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Homework_TDD
{
    public class GroupSum
    {
        public static List<int> getSumByGroup(List<IProductInfo> allProduct, int groupNum, string field)
        {
            //當輸入負數groupNum, 跳出例外
            if (groupNum <= 0)            
                throw new ArgumentOutOfRangeException("Negative number of groupNum is illegal.");

            List<int> results = new List<int>();
            int decresedCount = allProduct.Count();
            int flag = 0;
            while(decresedCount > 0)//當decreadCount減至<=0, 跳出迴圈
            {
                int sum = 0;
                
                //法一: 舊做法
                //int i;
                //for(i = 0; i < groupNum; i++)
                //{
                //    if (flag + i >= allProduct.Count())
                //        break;
                //    IProductInfo productInfo = allProduct.ElementAt(flag + i);
                //    sum += productInfo.getValue(field);
                //}

                //法二: 嘗試使用Linq寫法處理
                sum = allProduct.Skip(flag).Take(groupNum).Sum(product => product.getValue(field));
                
                flag += groupNum;//0 -> 3,6,9                
                decresedCount -= groupNum;//11 -> 8,5,2

                results.Add(sum);
            }            

            return results;
        }
    }

    public interface IProductInfo
    {        
        int ID { get; set; }
        int Cost { get; set; }
        int Revenue { get; set; }
        int SellPrice { get; set; }
        int getValue(string fieldName);
    }
    
    public class ProductInfo: IProductInfo
    {
        public int ID { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }  
      
        public ProductInfo(int id, int cost, int revenue, int sellprice)
        {
            ID = id;
            Cost = cost;
            Revenue = revenue;
            SellPrice = sellprice;
        }

        public int getValue(string fieldName)
        {
            int output;
            switch(fieldName.ToUpper())
            {
                case "ID":
                    output = this.ID;
                    break;
                case "COST":
                    output = this.Cost;
                    break;
                case "REVENUE":
                    output = this.Revenue;
                    break;
                case "SELLPRICE":
                    output = this.SellPrice;
                    break;
                default:
                    output = 0;
                    break;
            }
            return output;
        }
    }
}
