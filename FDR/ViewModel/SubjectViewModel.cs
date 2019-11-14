using FDR.Repositories.Implement;
using FDR.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FDR.ViewModel
{
    public class SubjectViewModel:BaseViewModel
    {
        private ObservableCollection<MonHoc> _listSubject;
        private ObservableCollection<LopHocPhan> _listClassSub;
        public ObservableCollection<MonHoc> ListSubject
        {
            get => _listSubject;
            set
            {
                if(value!=null)
                {
                    _listSubject = value;
                    OnPropertyChanged("ListSubject");
                }
            }
        }
        public ObservableCollection<LopHocPhan> ListClassSub
        {
            get => _listClassSub;
            set
            {
                if (value != null)
                {
                    _listClassSub = value;
                    OnPropertyChanged("ListClassSub");
                }
            }
        }

        #region SelectedSub
        private MonHoc _selectedSub;
        private LopHocPhan _selectedClassSub;
        public MonHoc SelectedSub
        {
            get => _selectedSub;
            set
            {
                if (value != null)
                {
                    _selectedSub = value;
                    OnPropertyChanged("SelectedSub");

                    MaHocPhan = _selectedSub.MaHocPhan;
                    SoTinChi = _selectedSub.SoTinChi.ToString();
                    TenMonHoc = _selectedSub.TenMonHoc;
                    Khoa = _selectedSub.Khoa;
                    MaMonHoc = _selectedSub.MaMonHoc;
                    TenChuyenNganh = _selectedSub.TenChuyenNganh;
                }
            }
        }

        public LopHocPhan SelectedClassSub
        {
            get => _selectedClassSub;
            set
            {
                if (value != null)
                {
                    _selectedClassSub = value;
                    OnPropertyChanged("SelectedClassSub");

                    MaLopHocPhan = _selectedClassSub.MaLopHocPhan;
                    NgayHocTrongTuan = _selectedClassSub.GioHoc;
                    SiSoSinhVien = _selectedClassSub.SiSoSinhVien.ToString();
                    NgayBatDau = _selectedClassSub.NgayBatDau;
                    NgayKetThuc = _selectedClassSub.NgayKetThuc;
                    
                }
            }
        }
        #endregion

        public ObservableCollection<string> ListKey
        {
            get => _listKey;
            set
            {
                if(value!=null)
                {
                    _listKey = value;
                    OnPropertyChanged("ListKey");
                }
            }

        }

        private ObservableCollection<string> _listKey;
        public ObservableCollection<string> ListKeyClassSub
        {
            get => _listKeyClassSub;
            set
            {
                if (value != null)
                {
                    _listKeyClassSub = value;
                    OnPropertyChanged("ListKeyClassSub");
                }
            }

        }

        private ObservableCollection<string> _listKeyClassSub;

        #region SelectedKey
        private string _selectedKey;

        public string SelectedKey
        {
            get => _selectedKey;
            set
            {
                if(value!=null)
                {
                    _selectedKey = value;
                    OnPropertyChanged("SelectedKey");
                }
            }
        }

        private string _selectedKeyClassSub;

        public string SelectedKeyClassSub
        {
            get => _selectedKeyClassSub;
            set
            {
                if (value != null)
                {
                    _selectedKeyClassSub = value;
                    OnPropertyChanged("SelectedKeyClassSub");
                }
            }
        }
        #endregion
        //
        private IBase<MonHoc> _reposMH = null;
        private IBase<LopHocPhan> _reposLHP = null;

        //
        #region Key
        private string _keySub;

        public string KeySub
        {
            get => _keySub;
            set
            {
                if(value!=null)
                {
                    _keySub = value;
                    OnPropertyChanged("KeySub");

                    if(SelectedKey!=null)
                    {
                        if (SelectedKey.Equals("Mã Học Phần"))
                            ListSubject = new ObservableCollection<MonHoc>(_reposMH.GetMany(t => t.MaHocPhan.Contains(_keySub)));
                        else
                            ListSubject = new ObservableCollection<MonHoc>(_reposMH.GetMany(t => t.TenMonHoc.Contains(_keySub)));
                    }
                }
            }
        }

        private string _keyClassSub;

        public string KeyClassSub
        {
            get => _keyClassSub;
            set
            {
                if (value != null)
                {
                    _keyClassSub = value;
                    OnPropertyChanged("KeyClassSub");

                    if (SelectedKeyClassSub != null)
                    {
                        if (SelectedKeyClassSub.Equals("Mã Lớp Học Phần"))
                            ListClassSub = new ObservableCollection<LopHocPhan>(_reposLHP.GetMany(t => t.MaLopHocPhan.Contains(_keyClassSub)));
                       
                    }
                }
            }
        }
        #endregion
        #region Entities
        // Môn Học
        public string MaHocPhan
        {
            get => _maHocPhan;
            set
            {
                if(value!=null)
                {
                    _maHocPhan = value;
                    OnPropertyChanged("MaHocPhan");
                }
            }
        }

        public string SoTinChi
        {
            get => _soTinChi;
            set
            {
                if (value != null)
                {
                    _soTinChi = value;
                    OnPropertyChanged("SoTinChi");
                }
            }
        }

        public string TenMonHoc
        {
            get => _tenMonHoc;
            set
            {
               if(value!=null)
                {
                    _tenMonHoc = value;
                    OnPropertyChanged("TenMonHoc");
                }
            }
        }
        public string MaMonHoc
        {
            get => _maMonHoc;
            set
            {
                if (value != null)
                {
                    _maMonHoc = value;
                    OnPropertyChanged("MaMonHoc");
                }
            }
        }
        public string Khoa
        {
            get => _khoa;
            set
            {
                if (value != null)
                {
                    _khoa = value;
                    OnPropertyChanged("Khoa");
                }
            }
        }
        public string TenChuyenNganh
        {
            get => _tenChuyenNganh;
            set
            {
                if (value != null)
                {
                    _tenChuyenNganh = value;
                    OnPropertyChanged("TenChuyenNganh");
                }
            }
        }

        // Lop Hoc Phan
        public string MaLopHocPhan {
            get => _maLopHocPhan;
            set
            {
                if (value != null)
                {
                    _maLopHocPhan = value;
                    OnPropertyChanged("MaLopHocPhan");
                }
            }
        }
        public string NgayHocTrongTuan {
            get => _ngayHocTrongTuan;
            set
            {
                if (value != null)
                {
                    _ngayHocTrongTuan = value;
                    OnPropertyChanged("NgayHocTrongTuan");
                }
            }
        }
        public string SiSoSinhVien {
            get => _siSoSinhVien;
            set
            {
                if (value != null)
                {
                    _siSoSinhVien = value;
                    OnPropertyChanged("SiSoSinhVien");
                }
            }
        }
        public DateTime NgayBatDau
        {
            get => _ngayBatDau;
            set
            {
                if (value != null)
                {
                    _ngayBatDau = value;
                    OnPropertyChanged("NgayBatDau");
                }
            }
        }
        public DateTime NgayKetThuc {
            get => _ngayKetThuc;
            set
            {
                if (value != null)
                {
                    _ngayKetThuc = value;
                    OnPropertyChanged("NgayKetThuc");
                }
            }
        }

        // -------------------------------
        private string _maHocPhan, _soTinChi, _tenMonHoc, _khoa, _maMonHoc,_tenChuyenNganh;
        private string _maLopHocPhan, _ngayHocTrongTuan, _siSoSinhVien;
        private DateTime _ngayBatDau, _ngayKetThuc;
        #endregion
        #region Command
        public ICommand RefeshData1 { get; set; }
        public ICommand ThemMonHoc { get; set; }

        public ICommand SuaMonHoc { get; set; }

        public ICommand XoaMonHoc { get; set; }

        #endregion
        //----------------------------------------------------

        public SubjectViewModel()
        {
            _reposMH = new BaseRepositories<MonHoc>(); //??????
            _reposLHP = new BaseRepositories<LopHocPhan>(); //???????????


            CreateData();
        }

        private void CreateData()
        {
            ListSubject = new ObservableCollection<MonHoc>(_reposMH.GetAll());
            ListClassSub = new ObservableCollection<LopHocPhan>(_reposLHP.GetAll());
            ListKey = new ObservableCollection<string>() { "Mã Học Phần","Tên Môn Học"};
            ListKeyClassSub = new ObservableCollection<string>() { "Mã Lớp Học Phần" };
            RefeshData1 = new RelayCommand<object>
                (
                  (p) =>
                  {
                       return true;
                  },
                  (p)=>
                  {
                      MaHocPhan = TenMonHoc = SoTinChi = Khoa = MaMonHoc = TenChuyenNganh = null;
                  }
                );
            ThemMonHoc = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaHocPhan))
                          return false;
                      if (string.IsNullOrEmpty(SoTinChi))
                          return false;
                      if (string.IsNullOrEmpty(TenMonHoc))
                          return false;
                      if (string.IsNullOrEmpty(Khoa))
                          return false;
                      if (string.IsNullOrEmpty(MaMonHoc))
                          return false;
                      if (string.IsNullOrEmpty(TenChuyenNganh))
                          return false;
                      return true;
                  },
                  (p)=>
                  {
                      var data = new MonHoc() { MaHocPhan = MaHocPhan, SoTinChi = Convert.ToInt32(SoTinChi), TenMonHoc = TenMonHoc ,Khoa = Khoa, MaMonHoc = MaMonHoc, TenChuyenNganh = TenChuyenNganh};
                      var result = _reposMH.Insert(data);
                      if (result != null)
                      {
                          MessageBox.Show("OK");
                          ListSubject.Add(result);
                      }

                      else
                          MessageBox.Show("Fails");

                  }
                );
            SuaMonHoc = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaHocPhan))
                          return false;
                      if (string.IsNullOrEmpty(SoTinChi))
                          return false;
                      if (string.IsNullOrEmpty(TenMonHoc))
                          return false;
                      if (string.IsNullOrEmpty(Khoa))
                          return false;
                      if (string.IsNullOrEmpty(MaMonHoc))
                          return false;
                      if (string.IsNullOrEmpty(TenChuyenNganh))
                          return false;

                      return true;
                  },
                  (p) =>
                  {
                      var data = new MonHoc() { MaHocPhan = MaHocPhan, SoTinChi = Convert.ToInt32(SoTinChi), TenMonHoc = TenMonHoc,Khoa = Khoa, MaMonHoc = MaMonHoc, TenChuyenNganh = TenChuyenNganh };

                      if (_reposMH.Update(data))
                      {
                          MessageBox.Show("OK");
                          ListSubject.SingleOrDefault(t => t.MaHocPhan.Equals(SelectedSub.MaHocPhan)).TenMonHoc = TenMonHoc;
                          ListSubject.SingleOrDefault(t => t.MaHocPhan.Equals(SelectedSub.MaHocPhan)).SoTinChi = Convert.ToInt32(SoTinChi);
                          ListSubject.SingleOrDefault(t => t.MaHocPhan.Equals(SelectedSub.MaHocPhan)).Khoa = Khoa;
                          ListSubject.SingleOrDefault(t => t.MaHocPhan.Equals(SelectedSub.MaHocPhan)).TenChuyenNganh = TenChuyenNganh;


                      }
                      else
                          MessageBox.Show("Fails");

                  }
                );
            XoaMonHoc = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaMonHoc))
                          return false;
                      return true;
                  },
                  (p) =>
                  {
                      if (_reposMH.Delete(MaMonHoc))
                      {
                          MessageBox.Show("OK");
                          ListSubject.Remove(ListSubject.SingleOrDefault(t => t.MaMonHoc.Equals(SelectedSub.MaMonHoc)));
                      }
                      else
                          MessageBox.Show("Fails");

                  }
                );
        }
    }
}
