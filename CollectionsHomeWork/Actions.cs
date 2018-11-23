using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsHomeWork
{
    class Actions
    {
        public static List<Debtor> DebtbyEmail(List<Debtor> debtors,string email)
        {
            var tmp = debtors.Where(x => x.Email.Contains(email)).ToList();
            return tmp;
        }
        public static List<Debtor> DebtByAge(List<Debtor> debtors)
        {
            var tmp = debtors.Where(x => (DateTime.Now.Year - x.BirthDay.Year) > 26 && (DateTime.Now.Year - x.BirthDay.Year) < 36).ToList();
            return tmp;
        }
        public static List<Debtor> DebtMoreAmount(List<Debtor> debtors,int amount)
        {
            var tmp = debtors.Where(x => x.Debt > amount).ToList();
            return tmp;
        }
        public static List<Debtor> returnByNameCountansMobile(List<Debtor> debtors,int count,char num)
        {
            var tmp = debtors.Where(x => (x.FullName.Length > count) && x.Phone.IndexOf(num) != x.Phone.LastIndexOf(num)).ToList();
            return tmp;
        }
        public static List<Debtor> BornInWinter(List<Debtor> debtors)
        {
            var tmp = debtors.Where(x => x.BirthDay.Month > 11 || x.BirthDay.Month < 3).ToList();
            return tmp;
        }
        public static IEnumerable<IEnumerable<Debtor>> MoreDebtThanAverage(List<Debtor> debtors)
        {
            List <List<Debtor>> list = new List<List<Debtor>>();
            int average = 0;
            for(int a = 0;a < debtors.Count; a++)
            {
                average += debtors[a].Debt;
            }
            average /= debtors.Count;
            var tmp = debtors.Where(x => x.Debt > average).ToList();
            var rtrn = tmp.OrderByDescending(x => x.Debt).ToList();
            var rtrnnd = tmp.OrderBy(x => x.FullName = x.FullName.Substring(x.FullName.LastIndexOf(' '))).ToList();
            list.Add(rtrnnd);
            list.Add(rtrn);
            for(int a = 0;a < list.Count; a++)
            {
                yield return list[a];
            }
        }
        public static int YearMadeDebtors(List <Debtor> debtors)
        {
            var tmp = debtors.GroupBy(x => x.BirthDay.Year).OrderBy(x => x.Count());
            return tmp.Last().Key;
        }
        public static List<Debtor> ThreeSameLetter(List<Debtor> debtors)
        {
            var tmp = debtors.Where(x => (x.FullName.Length - x.FullName.Distinct().Count()) > 3).ToList();
            var rtrn = tmp.OrderBy(x => x.FullName).ToList();
            return rtrn;
        }
        public static List<Debtor> NotFindEight(List<Debtor> debtors,char num)
        {
            var tmp = debtors.Where(x => !x.Phone.Contains(num)).ToList();
            return tmp;
        }
        
        public static List<Debtor> MostDebt(List<Debtor> debtors,int count)
        {
            var tmp = debtors.OrderByDescending(x => x.Debt).ToList();
            List<Debtor> list = new List<Debtor>();
            for(int a = 0;a < count; a++)
            {
                list.Add(tmp[a]);
            }
            return list;
        }
        public static long CommobDebt(List<Debtor> debtors)
        {
            long num = 0;
            for(int a = 0;a < debtors.Count; a++)
            {
                num += debtors[a].Debt;
            }
            return num;
        }
        public static List<Debtor> uniquePhonNumber(List<Debtor> debtors)
        {
            var tmp = debtors.Where(x => x.Phone.Distinct().Count() == x.Phone.Count() - 1).ToList();
            return tmp;
        }
        public static List<Debtor> SecondWorldWar(List<Debtor> debtors)
        {
            //olenleride nezere aldim texmini
            var tmp = debtors.Where(x => x.BirthDay.Year < 1945 && x.BirthDay.Year > 1880).ToList();
            return tmp;
        }
        public static List<Debtor> DebtBack(List<Debtor> debtors)
        {
            var tmp = debtors.Where(x => (x.BirthDay.Month - DateTime.Now.Month) * 500 > x.Debt).ToList();
            return tmp;
        }
        public static List<Debtor> JoinLetters(List<Debtor> debtors, string word)
        {
            var tmp = debtors.Where(x => CheckerContain(x.FullName,word)).ToList();
            return tmp;
        }
        private static bool CheckerContain(string k,string b)
        {
            for(int a = 0;a < b.Length; a++)
            {
                if (!k.Contains(b[a]) && !k.Contains(char.ToUpper(b[a]))) return false;
            }
            return true;
        }
    }
}
