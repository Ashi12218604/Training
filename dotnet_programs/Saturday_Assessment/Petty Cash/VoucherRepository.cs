using System.Collections.Generic;
namespace PettyCash
{
    public class VoucherRepository : IRepository<Voucher>
    {
        private readonly List<Voucher> _vs = new List<Voucher>();
        public void Add(Voucher v)
        {
            _vs.Add(v);
        }
        public List<Voucher> GetAll()
        {
            return _vs;
        }
    }
}
