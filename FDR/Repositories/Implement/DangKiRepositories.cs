using FDR.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDR.Repositories.Implement
{
    public class DangKiRepositories : BaseRepositories<DangKyLopHocPhan>, IDangKi
    {
        private readonly DbEntities db;

        public DangKiRepositories()
        {
            db = new DbEntities();
        }
        public IEnumerable<SinhVien> GetByIdClassSubject(string id)
        {
            var query = from s in db.SinhViens
                        join d in db.DangKyLopHocPhans on s.MaSinhVien equals d.MaSinhVien
                        where d.MaLopHocPhan.Equals(id)
                        select s;
            return query.ToList();
        }
    }
}
