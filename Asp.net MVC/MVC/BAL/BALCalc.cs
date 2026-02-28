using DAL;

namespace BAL
{
    public class CalculatorBL
    {
        private CalculatorDAL _dal = new CalculatorDAL();

        public int BLAdd(int a, int b)
        {
            return _dal.Add(a, b);
        }
    }
}
