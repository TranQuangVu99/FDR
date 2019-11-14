using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDR.Repositories.Interface
{
    public interface IDangKi:IBase<DangKyLopHocPhan> 
    {
        IEnumerable<SinhVien> GetByIdClassSubject(String id);
    }
}
